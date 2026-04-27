using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded { get; } = "Ürün başarıyla eklendi.";
        public static string ProductDeleted { get; } = "Ürün başarıyla silindi.";
        public static string ProductUpdated { get; } = "Ürün başarıyla güncellendi.";

        public static string UserNotFound { get; } = "Kullanıcı bulunamadı.";
        public static string UserCorrupted { get; } = "User credentials are corrupted.";
        public static string PasswordError { get; } = "Şifre hatalı.";
        public static string SuccessfulLogin { get; } = "Sisteme giriş başarılı.";

        public static string UserAlreadyExist { get; } = "Bu email ile kayıtlı bir kullanıcı zaten var.";
        public static string UserRegistered { get; } = "kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated { get; } = "Access Token başarıyla oluşturuldu.";

        public static string AuthorizationDenied { get; } = "Yetkiniz yok.";

    }
}
