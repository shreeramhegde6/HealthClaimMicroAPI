IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO



BEGIN TRANSACTION;
GO

CREATE TABLE [tblClaimType] (
    [ClaimTypeId] int NOT NULL IDENTITY,
    [ClaimTypeValue] nvarchar(50) NULL,
    CONSTRAINT [PK_tblClaimType] PRIMARY KEY ([ClaimTypeId])
);
GO

CREATE TABLE [tblLogin] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(50) NULL,
    [Password] nvarchar(50) NULL,
    [UserRole] nvarchar(50) NULL,
    [FirstName] nvarchar(30) NULL,
    [LastName] nvarchar(30) NULL,
    [Email] nvarchar(50) NULL,
    [DateOfBirth] date NULL,
    [State] nvarchar(50) NULL,
    [Address] nvarchar(50) NULL,
    [City] nvarchar(50) NULL,
    CONSTRAINT [PK_tblLogin] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [tblPhysician] (
    [PhysicianId] int NOT NULL IDENTITY,
    [PhysicianName] nvarchar(50) NULL,
    [PhysicianState] nvarchar(50) NULL,
    CONSTRAINT [PK_tblPhysician] PRIMARY KEY ([PhysicianId])
);
GO

CREATE TABLE [tblMember] (
    [MemberId] int NOT NULL IDENTITY,
    [PhysicianId] int NULL,
    [UserId] int NULL,
    [FirstName] nvarchar(30) NULL,
    [LastName] nvarchar(30) NULL,
    [Email] nvarchar(50) NULL,
    [DateOfBirth] date NULL,
    [City] nvarchar(50) NULL,
    [State] nvarchar(50) NULL,
    [Address] nvarchar(50) NULL,
    [CreatedBy] nvarchar(50) NULL,
    [CreatedDate] datetime NULL,
    [ModifiedBy] nvarchar(50) NULL,
    [ModifiedDate] datetime NULL,
    CONSTRAINT [PK_tblLogin] PRIMARY KEY ([MemberId]),
    CONSTRAINT [FK_tblMember_tblPhysician] FOREIGN KEY ([PhysicianId]) REFERENCES [tblPhysician] ([PhysicianId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [tblClaim] (
    [ClaimId] int NOT NULL IDENTITY,
    [MemberId] int NULL,
    [ClaimTypeId] int NULL,
    [ClaimAmount] decimal(18,0) NULL,
    [ClaimDate] datetime NULL,
    [ClaimRemark] nvarchar(100) NULL,
    [CreatedBy] nvarchar(50) NULL,
    [CreatedDate] datetime NULL,
    [ModifiedBy] nvarchar(50) NULL,
    [ModifiedDate] datetime NULL,
    CONSTRAINT [PK_tblClaim] PRIMARY KEY ([ClaimId]),
    CONSTRAINT [FK_tblClaim_tblClaimType] FOREIGN KEY ([ClaimTypeId]) REFERENCES [tblClaimType] ([ClaimTypeId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_tblClaim_tblMember1] FOREIGN KEY ([MemberId]) REFERENCES [tblMember] ([MemberId]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_tblClaim_ClaimTypeId] ON [tblClaim] ([ClaimTypeId]);
GO

CREATE INDEX [IX_tblClaim_MemberId] ON [tblClaim] ([MemberId]);
GO

CREATE INDEX [IX_tblMember_PhysicianId] ON [tblMember] ([PhysicianId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230228091511_InitialCreate', N'5.0.17');
GO

COMMIT;
GO


