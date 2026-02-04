CREATE TABLE [dbo].[HostProfiles]
(
    [Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    [DisplayName] VARCHAR(200) NOT NULL,
    [BusinessName] VARCHAR(200) NULL,
    [Country] VARCHAR(100) NOT NULL,
    [City] VARCHAR(100) NOT NULL,    
    [AvatarUrl] VARCHAR(500) NULL,
    [WebsiteUrl] VARCHAR(500) NULL,
    [Bio] TEXT NULL,
    [IsVerified] BIT NOT NULL DEFAULT 0,
    [Rating] FLOAT NOT NULL DEFAULT 0,
    [TotalReviews] INT NOT NULL DEFAULT 0,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
    [UserId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [FK_HostProfiles_User]
        FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),

    CONSTRAINT [UQ_HostProfiles_User]
        UNIQUE ([UserId])
);