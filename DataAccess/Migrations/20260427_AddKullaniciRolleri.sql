-- Faz 1: KullaniciRolleri tablosu ve indeksler
IF NOT EXISTS (
    SELECT 1
    FROM sys.tables
    WHERE name = 'KullaniciRolleri'
)
BEGIN
    CREATE TABLE [dbo].[KullaniciRolleri]
    (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [KullaniciID] INT NOT NULL,
        [RolTanimID] INT NOT NULL,
        CONSTRAINT [FK_KullaniciRolleri_Kullanicilar] FOREIGN KEY ([KullaniciID]) REFERENCES [dbo].[Kullanicilar]([KullaniciID]) ON DELETE CASCADE,
        CONSTRAINT [FK_KullaniciRolleri_RolTanimlari] FOREIGN KEY ([RolTanimID]) REFERENCES [dbo].[RolTanimlari]([RolTanimID]) ON DELETE CASCADE
    );

    CREATE UNIQUE INDEX [IX_KullaniciRolleri_KullaniciID_RolTanimID]
        ON [dbo].[KullaniciRolleri] ([KullaniciID], [RolTanimID]);
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_RolYetkileri_RolTanimID_OperationClaimID'
)
BEGIN
    CREATE UNIQUE INDEX [IX_RolYetkileri_RolTanimID_OperationClaimID]
        ON [dbo].[RolYetkileri] ([RolTanimID], [OperationClaimID]);
END
GO
