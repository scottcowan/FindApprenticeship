﻿CREATE TABLE [Provider].[ProviderUser]
(
	[ProviderUserId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[ProviderUserGuid] UNIQUEIDENTIFIER NOT NULL , 
    [ProviderUserStatusId] INT NOT NULL,
    [ProviderId] INT NOT NULL, 
    [Username] NVARCHAR(100) NOT NULL, 
    [Fullname] NVARCHAR(MAX) NOT NULL, 
    [PreferredProviderSiteId] INT NULL, 
    [Email] NVARCHAR(MAX) NOT NULL, 
    [EmailVerificationCode] CHAR(6) NULL, 
    [EmailVerifiedDateTime] DATETIME2 NULL, 
    [PhoneNumber] NVARCHAR(MAX) NOT NULL, 
    [CreatedDateTime] DATETIME2 NOT NULL, 
    [UpdatedDateTime] DATETIME2 NULL, 
    [ReleaseNoteVersion] INT NULL DEFAULT 0, 
    CONSTRAINT [FK_ProviderUser_ProviderUserStatus] FOREIGN KEY ([ProviderUserStatusId]) REFERENCES [Provider].[ProviderUserStatus]([ProviderUserStatusId])
)
GO

CREATE UNIQUE INDEX [IX_ProviderUser_Username] ON [Provider].[ProviderUser] ([Username])
GO

CREATE INDEX [IX_ProviderUser_ProviderUserGuid] ON [Provider].[ProviderUser] ([ProviderUserGuid])
GO
