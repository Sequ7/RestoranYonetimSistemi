using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IKullaniciService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IKullaniciService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici)
        {
            // 1. GetClaims metoduna gönderirken de dikkat etmeliyiz
            var claims = _userService.GetClaims(kullanici);

            // 2. TERCÜME BURADA: Senin verilerini, TokenHelper'ın anladığı 'User' nesnesine paketliyoruz.
            var userForToken = new Core.Entities.Concrete.User
            {
                Id = kullanici.KullaniciID,
                Email = kullanici.EPosta,
                FirstName = kullanici.Ad,
                LastName = kullanici.Soyad,
                Status = kullanici.Aktif
            };

            // 3. Artık TokenHelper mutlu, çünkü ona kendi istediği 'User' tipini verdik.
            var accessToken = _tokenHelper.CreateToken(userForToken, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Erişim jetonu oluşturuldu");
        }

        public IDataResult<Kullanici> Login(UserForLoginDto userForLoginDto)
        {
            // Senin EPosta sütununa göre sorguluyoruz
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null) return new ErrorDataResult<Kullanici>("Kullanıcı bulunamadı");

            // Hash doğrulaması
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Kullanici>("Parola hatası");
            }

            // Aktiflik kontrolü (SQL'deki 'Aktif' sütunu)
            if (!userToCheck.Aktif)
            {
                return new ErrorDataResult<Kullanici>("Hesabınız aktif değil.");
            }

            return new SuccessDataResult<Kullanici>(userToCheck, "Başarılı giriş");
        }

        public IDataResult<Kullanici> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new Kullanici
            {
                EPosta = userForRegisterDto.Email,
                Ad = userForRegisterDto.FirstName,
                Soyad = userForRegisterDto.LastName,
                KullaniciAdi = userForRegisterDto.KullaniciAdi,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Aktif = true
            };

            _userService.Add(user);
            return new SuccessDataResult<Kullanici>(user, "Kayıt başarıyla tamamlandı");
        }

        public IResult UserExists(string email)
        {
            var userExists = _userService.GetByMail(email);

            if (userExists != null)
            {
                // Eğer kullanıcı varsa, hata döndür ki aynı maille tekrar kayıt olmasın
                return new ErrorResult("Bu kullanıcı zaten mevcut");
            }

            // Kullanıcı yoksa, yolun açık olduğunu (başarılı) söyle
            return new SuccessResult();
        }
    }
}
