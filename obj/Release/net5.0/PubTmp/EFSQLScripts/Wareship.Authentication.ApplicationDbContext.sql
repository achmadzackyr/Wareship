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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE TABLE [UserStatus] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_UserStatus] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE TABLE [UserTier] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_UserTier] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Dob] datetime2 NOT NULL,
        [Street] nvarchar(max) NULL,
        [Subdistrict] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [Province] nvarchar(max) NULL,
        [Gender] nvarchar(max) NULL,
        [ProfilePictureUrl] nvarchar(max) NULL,
        [CreatedAt] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [UserTierId] int NOT NULL,
        [UserStatusId] int NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUsers_UserStatus_UserStatusId] FOREIGN KEY ([UserStatusId]) REFERENCES [UserStatus] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUsers_UserTier_UserTierId] FOREIGN KEY ([UserTierId]) REFERENCES [UserTier] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''fab4fac1-c546-41de-aebc-a14da6895711'', N''1'', N''Admin'', N''Admin''),
    (N''c7b013f0-5201-4317-abd8-c211f91b7330'', N''2'', N''Wareshouse'', N''Wareshouse''),
    (N''b7b013f0-5201-4317-abd8-c211f91b7660'', N''3'', N''Supplier'', N''Supplier''),
    (N''a7b013f0-5201-4317-abd8-c211f91b7990'', N''4'', N''Dropshipper'', N''Dropshipper'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[UserStatus]'))
        SET IDENTITY_INSERT [UserStatus] ON;
    EXEC(N'INSERT INTO [UserStatus] ([Id], [Name])
    VALUES (1, N''Active''),
    (2, N''Suspended''),
    (3, N''Banned'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[UserStatus]'))
        SET IDENTITY_INSERT [UserStatus] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[UserTier]'))
        SET IDENTITY_INSERT [UserTier] ON;
    EXEC(N'INSERT INTO [UserTier] ([Id], [Name])
    VALUES (1, N''Rookie''),
    (2, N''Champion''),
    (3, N''Ultimate''),
    (4, N''Mega'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[UserTier]'))
        SET IDENTITY_INSERT [UserTier] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'City', N'ConcurrencyStamp', N'CreatedAt', N'CreatedBy', N'Dob', N'Email', N'EmailConfirmed', N'Gender', N'LockoutEnabled', N'LockoutEnd', N'Name', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'ProfilePictureUrl', N'Province', N'SecurityStamp', N'Street', N'Subdistrict', N'TwoFactorEnabled', N'UserName', N'UserStatusId', N'UserTierId') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [City], [ConcurrencyStamp], [CreatedAt], [CreatedBy], [Dob], [Email], [EmailConfirmed], [Gender], [LockoutEnabled], [LockoutEnd], [Name], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [ProfilePictureUrl], [Province], [SecurityStamp], [Street], [Subdistrict], [TwoFactorEnabled], [UserName], [UserStatusId], [UserTierId])
    VALUES (N''b74ddd14-6340-4840-95c2-db12554843e5'', 0, N''Kabupaten Ciamis'', N''ec8f7902-cff4-4efe-8f1c-3524ac0fe9e8'', ''2021-09-08T20:14:36.7785891+07:00'', NULL, ''1989-12-07T00:00:00.0000000'', N''admin@example.com'', CAST(0 AS bit), N''Laki-Laki'', CAST(0 AS bit), NULL, N''Admin Suradmin'', NULL, N''ADMIN'', N''AQAAAAEAACcQAAAAEH0jDn03VbPBhaU2hmu7W7Gu14HLcbbMipm31aAnVpsFAbgUfq0zzd4NOTFgGgirzA=='', N''085223670378'', CAST(0 AS bit), N''https://images.pexels.com/photos/6652928/pexels-photo-6652928.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940'', N''Jawa Barat'', N''5ae82641-cd1e-4fb9-8647-120fc2a03dd3'', N''Dusun Desa, Desa Cijeungjing'', N''Cijeungjing'', CAST(0 AS bit), N''admin'', 1, 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'City', N'ConcurrencyStamp', N'CreatedAt', N'CreatedBy', N'Dob', N'Email', N'EmailConfirmed', N'Gender', N'LockoutEnabled', N'LockoutEnd', N'Name', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'ProfilePictureUrl', N'Province', N'SecurityStamp', N'Street', N'Subdistrict', N'TwoFactorEnabled', N'UserName', N'UserStatusId', N'UserTierId') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'City', N'ConcurrencyStamp', N'CreatedAt', N'CreatedBy', N'Dob', N'Email', N'EmailConfirmed', N'Gender', N'LockoutEnabled', N'LockoutEnd', N'Name', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'ProfilePictureUrl', N'Province', N'SecurityStamp', N'Street', N'Subdistrict', N'TwoFactorEnabled', N'UserName', N'UserStatusId', N'UserTierId') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [City], [ConcurrencyStamp], [CreatedAt], [CreatedBy], [Dob], [Email], [EmailConfirmed], [Gender], [LockoutEnabled], [LockoutEnd], [Name], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [ProfilePictureUrl], [Province], [SecurityStamp], [Street], [Subdistrict], [TwoFactorEnabled], [UserName], [UserStatusId], [UserTierId])
    VALUES (N''supplier-6340-4840-95c2-db12554843e5'', 0, N''Kabupaten Ciamis'', N''0e7d6c70-2ac2-4c31-aef6-cc5b925f80bd'', ''2021-09-08T20:14:36.8093084+07:00'', NULL, ''1989-12-07T00:00:00.0000000'', N''supplier@example.com'', CAST(0 AS bit), N''Laki-Laki'', CAST(0 AS bit), NULL, N''Susu Plier'', NULL, N''SUPPLIER'', N''AQAAAAEAACcQAAAAEBzhs+w+w5vpYueAX+hewJoqo+hT523uQhQSgXZ+jVETDZgiqOAMIdPsH8Ud8+0x+Q=='', N''085223670378'', CAST(0 AS bit), N''https://images.pexels.com/photos/6652928/pexels-photo-6652928.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940'', N''Jawa Barat'', N''2c06b3ca-f0fa-4f53-b249-89f54e1c881d'', N''Dusun Desa, Desa Cijeungjing'', N''Cijeungjing'', CAST(0 AS bit), N''supplier'', 1, 2)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'City', N'ConcurrencyStamp', N'CreatedAt', N'CreatedBy', N'Dob', N'Email', N'EmailConfirmed', N'Gender', N'LockoutEnabled', N'LockoutEnd', N'Name', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'ProfilePictureUrl', N'Province', N'SecurityStamp', N'Street', N'Subdistrict', N'TwoFactorEnabled', N'UserName', N'UserStatusId', N'UserTierId') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (N''fab4fac1-c546-41de-aebc-a14da6895711'', N''b74ddd14-6340-4840-95c2-db12554843e5'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (N''b7b013f0-5201-4317-abd8-c211f91b7660'', N''supplier-6340-4840-95c2-db12554843e5'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE INDEX [IX_AspNetUsers_UserStatusId] ON [AspNetUsers] ([UserStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    CREATE INDEX [IX_AspNetUsers_UserTierId] ON [AspNetUsers] ([UserTierId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210908131438_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210908131438_init', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Phone] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ZipCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Category] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [ThumbnailUrl] nvarchar(max) NULL,
        [IsTrash] int NOT NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Consignee] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Street] nvarchar(max) NULL,
        [Subdistrict] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [Province] nvarchar(max) NULL,
        [ZipCode] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [CreatedAt] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_Consignee] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Courier] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Courier] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Payment] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Payment] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [ProductStatus] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_ProductStatus] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Shipper] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Street] nvarchar(max) NULL,
        [Subdistrict] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [Province] nvarchar(max) NULL,
        [ZipCode] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [CreatedAt] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_Shipper] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [TransactionStatus] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_TransactionStatus] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Variation] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Variation] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Warehouse] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Jalan] nvarchar(max) NULL,
        [Kecamatan] nvarchar(max) NULL,
        [KabupatenKota] nvarchar(max) NULL,
        [Provinsi] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        CONSTRAINT [PK_Warehouse] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [SubCategory] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [ThumbnailUrl] nvarchar(max) NULL,
        [IsTrash] int NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_SubCategory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SubCategory_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [DeliveryService] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [CourierId] int NOT NULL,
        CONSTRAINT [PK_DeliveryService] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DeliveryService_Courier_CourierId] FOREIGN KEY ([CourierId]) REFERENCES [Courier] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Option] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [VariationId] int NOT NULL,
        CONSTRAINT [PK_Option] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Option_Variation_VariationId] FOREIGN KEY ([VariationId]) REFERENCES [Variation] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Product] (
        [Id] int NOT NULL IDENTITY,
        [Sku] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [Weight] float NOT NULL,
        [Volume] float NOT NULL,
        [UserId] int NOT NULL,
        [UserId1] nvarchar(450) NULL,
        [ProductStatusId] int NOT NULL,
        [SubCategoryId] int NOT NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Product_AspNetUsers_UserId1] FOREIGN KEY ([UserId1]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Product_ProductStatus_ProductStatusId] FOREIGN KEY ([ProductStatusId]) REFERENCES [ProductStatus] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Product_SubCategory_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [SubCategory] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Transaction] (
        [Id] int NOT NULL IDENTITY,
        [Airwaybill] nvarchar(max) NULL,
        [TotalPrice] float NOT NULL,
        [TotalShipping] float NOT NULL,
        [TotalDiscount] float NOT NULL,
        [TotalWeight] float NOT NULL,
        [TotalVolume] float NOT NULL,
        [TotalTax] float NOT NULL,
        [TotalFee] float NOT NULL,
        [TotalItem] int NOT NULL,
        [IsTrash] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdateAt] datetime2 NOT NULL,
        [UserId] int NOT NULL,
        [UserId1] nvarchar(450) NULL,
        [TransactionStatusId] int NOT NULL,
        [PaymentId] int NOT NULL,
        [DeliveryServiceId] int NOT NULL,
        [ShipperId] int NOT NULL,
        [ConsigneeId] int NOT NULL,
        CONSTRAINT [PK_Transaction] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Transaction_AspNetUsers_UserId1] FOREIGN KEY ([UserId1]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Transaction_Consignee_ConsigneeId] FOREIGN KEY ([ConsigneeId]) REFERENCES [Consignee] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Transaction_DeliveryService_DeliveryServiceId] FOREIGN KEY ([DeliveryServiceId]) REFERENCES [DeliveryService] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Transaction_Payment_PaymentId] FOREIGN KEY ([PaymentId]) REFERENCES [Payment] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Transaction_Shipper_ShipperId] FOREIGN KEY ([ShipperId]) REFERENCES [Shipper] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Transaction_TransactionStatus_TransactionStatusId] FOREIGN KEY ([TransactionStatusId]) REFERENCES [TransactionStatus] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [ProductImage] (
        [Id] int NOT NULL IDENTITY,
        [Url] nvarchar(max) NULL,
        [CreatedAt] datetime2 NOT NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_ProductImage] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductImage_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Stock] (
        [Id] int NOT NULL IDENTITY,
        [Sku] nvarchar(max) NULL,
        [Quantity] int NOT NULL,
        [IsTrash] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        [ProductId] int NOT NULL,
        [OptionId] int NOT NULL,
        [WarehouseId] int NOT NULL,
        CONSTRAINT [PK_Stock] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Stock_Option_OptionId] FOREIGN KEY ([OptionId]) REFERENCES [Option] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Stock_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Stock_Warehouse_WarehouseId] FOREIGN KEY ([WarehouseId]) REFERENCES [Warehouse] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE TABLE [Order] (
        [Id] int NOT NULL IDENTITY,
        [Quantity] int NOT NULL,
        [TransactionId] int NOT NULL,
        [StockId] int NOT NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Order_Stock_StockId] FOREIGN KEY ([StockId]) REFERENCES [Stock] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Order_Transaction_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [Transaction] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''f23afef9-6bfb-4cd8-a641-7e32de513c38'', [CreatedAt] = ''2021-09-12T17:48:41.3338161+07:00'', [NormalizedEmail] = N''ADMIN@EXAMPLE.COM'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDS0g0pwh0j32D4FC4exUPwdut7jdcUiV7wwGfwA/03ObokzEWRI2SsqXZuGqaZcwg=='', [SecurityStamp] = N''69cd6fa0-7614-4837-9ba2-552ee567d019''
    WHERE [Id] = N''b74ddd14-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''db1b54ce-6ce7-44fc-8135-c62bbdb16467'', [CreatedAt] = ''2021-09-12T17:48:41.3473139+07:00'', [NormalizedEmail] = N''SUPPLIER@EXAMPLE.COM'', [PasswordHash] = N''AQAAAAEAACcQAAAAEN+GLsO4fvzESyWk0PX7bb3OATeuUmnoOnqiDNdNic+5KyiuemRZ7cHnyZWnE1UxZQ=='', [SecurityStamp] = N''8094b38c-fa3b-4191-95d9-1a87abb40fbc''
    WHERE [Id] = N''supplier-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_DeliveryService_CourierId] ON [DeliveryService] ([CourierId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Option_VariationId] ON [Option] ([VariationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Order_StockId] ON [Order] ([StockId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Order_TransactionId] ON [Order] ([TransactionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Product_ProductStatusId] ON [Product] ([ProductStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Product_SubCategoryId] ON [Product] ([SubCategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Product_UserId1] ON [Product] ([UserId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_ProductImage_ProductId] ON [ProductImage] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Stock_OptionId] ON [Stock] ([OptionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Stock_ProductId] ON [Stock] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Stock_WarehouseId] ON [Stock] ([WarehouseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_SubCategory_CategoryId] ON [SubCategory] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Transaction_ConsigneeId] ON [Transaction] ([ConsigneeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Transaction_DeliveryServiceId] ON [Transaction] ([DeliveryServiceId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Transaction_PaymentId] ON [Transaction] ([PaymentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Transaction_ShipperId] ON [Transaction] ([ShipperId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Transaction_TransactionStatusId] ON [Transaction] ([TransactionStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    CREATE INDEX [IX_Transaction_UserId1] ON [Transaction] ([UserId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912104843_all-models')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210912104843_all-models', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105447_user-transaction')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ecfd7440-6d4a-4db0-bb1d-eed4dcbab1b8'', [CreatedAt] = ''2021-09-12T17:54:46.7777991+07:00'', [PasswordHash] = N''AQAAAAEAACcQAAAAEAj1PSJEQB54eAWH/u3sinECvzcXw/Xd20FLpXrTy/6Pc1S6XxNrkiGik71VKo3hiQ=='', [SecurityStamp] = N''5578cd5c-68b0-43ef-bb81-aea2b4501a5e''
    WHERE [Id] = N''b74ddd14-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105447_user-transaction')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''bc1c6155-7b10-4c85-9ab2-8529aaabedc1'', [CreatedAt] = ''2021-09-12T17:54:46.7913290+07:00'', [PasswordHash] = N''AQAAAAEAACcQAAAAEL9WfTlgjAxIAJiYUQP2tLfPTwOkT5EXgKncrRxipyL3474LNN3icurYoPo83tQB/g=='', [SecurityStamp] = N''554ec529-f862-4058-bd50-e5bcb823dfda''
    WHERE [Id] = N''supplier-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105447_user-transaction')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210912105447_user-transaction', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    ALTER TABLE [Product] DROP CONSTRAINT [FK_Product_AspNetUsers_UserId1];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    ALTER TABLE [Transaction] DROP CONSTRAINT [FK_Transaction_AspNetUsers_UserId1];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    DROP INDEX [IX_Transaction_UserId1] ON [Transaction];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    DROP INDEX [IX_Product_UserId1] ON [Product];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transaction]') AND [c].[name] = N'UserId1');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Transaction] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Transaction] DROP COLUMN [UserId1];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Product]') AND [c].[name] = N'UserId1');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Product] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Product] DROP COLUMN [UserId1];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transaction]') AND [c].[name] = N'UserId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Transaction] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Transaction] ALTER COLUMN [UserId] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Product]') AND [c].[name] = N'UserId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Product] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Product] ALTER COLUMN [UserId] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''5d7c9c24-2291-4855-aed0-9ad2b8129ea7'', [CreatedAt] = ''2021-09-12T17:59:18.0836688+07:00'', [PasswordHash] = N''AQAAAAEAACcQAAAAEP+NbK9rdwrM8a7oG1hKlUqso9gCEf7R+g+lrwVTxPTJAIb/PuhF3nwqySoY7XyVmg=='', [SecurityStamp] = N''bca923cb-bcc2-422b-a197-ba8db30aa006''
    WHERE [Id] = N''b74ddd14-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''362594e5-7ae2-43aa-9073-97517bd72879'', [CreatedAt] = ''2021-09-12T17:59:18.0970878+07:00'', [PasswordHash] = N''AQAAAAEAACcQAAAAEDq+Z1Hp+XXw2eYsey3Bc5Gjn3XIUqTNYnQ4PB5Zxyz1EdkuYgO7qnVUhWYCZtM7BQ=='', [SecurityStamp] = N''e8154c6c-b7c5-4235-a3c4-a16d876567cb''
    WHERE [Id] = N''supplier-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    CREATE INDEX [IX_Transaction_UserId] ON [Transaction] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    CREATE INDEX [IX_Product_UserId] ON [Product] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    ALTER TABLE [Product] ADD CONSTRAINT [FK_Product_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    ALTER TABLE [Transaction] ADD CONSTRAINT [FK_Transaction_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912105918_changetypeuserid')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210912105918_changetypeuserid', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    EXEC sp_rename N'[Warehouse].[Provinsi]', N'ZipCode', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    EXEC sp_rename N'[Warehouse].[Kecamatan]', N'Subdistrict', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    EXEC sp_rename N'[Warehouse].[KabupatenKota]', N'Street', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    EXEC sp_rename N'[Warehouse].[Jalan]', N'Province', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    ALTER TABLE [Warehouse] ADD [City] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    ALTER TABLE [Product] ADD [ChargeableWeight] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''1cb7ecdb-826b-4523-a30d-237d8aa93f5f'', [CreatedAt] = ''2021-09-14T21:31:00.9931823+07:00'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBPDYtnPrGDW7n6CgTTwKsWhjQ2Fyq6AGGFn4o0nBQjk4dwQAAdLsaV74hFhN1jBPg=='', [SecurityStamp] = N''c7cd069e-9e90-46f5-b324-81ab099ce9c7''
    WHERE [Id] = N''b74ddd14-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''41da727f-050c-4e3a-b499-456a8191b570'', [CreatedAt] = ''2021-09-14T21:31:01.0214818+07:00'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGJiq2W1E37gGMbJIHAXxhjRmRMJQLHs8M8X/YFhAbqK7rZUYDozHQUPYMxzypi3nA=='', [SecurityStamp] = N''1d5ae92e-ec53-49e3-bc98-78cf76611ac1''
    WHERE [Id] = N''supplier-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsTrash', N'Name', N'ThumbnailUrl') AND [object_id] = OBJECT_ID(N'[Category]'))
        SET IDENTITY_INSERT [Category] ON;
    EXEC(N'INSERT INTO [Category] ([Id], [IsTrash], [Name], [ThumbnailUrl])
    VALUES (10, 0, N''Handphone & Tablet'', NULL),
    (9, 0, N''Gaming'', NULL),
    (8, 0, N''Film & Musik'', NULL),
    (7, 0, N''Fashion Wanita'', NULL),
    (1, 0, N''Buku'', NULL),
    (5, 0, N''Fashion Muslim'', NULL),
    (4, 0, N''Fashion Anak & Bayi'', NULL),
    (3, 0, N''Elektronik'', NULL),
    (6, 0, N''Fashion Pria'', NULL),
    (2, 0, N''Dapur'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsTrash', N'Name', N'ThumbnailUrl') AND [object_id] = OBJECT_ID(N'[Category]'))
        SET IDENTITY_INSERT [Category] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Courier]'))
        SET IDENTITY_INSERT [Courier] ON;
    EXEC(N'INSERT INTO [Courier] ([Id], [Name])
    VALUES (1, N''JNE'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Courier]'))
        SET IDENTITY_INSERT [Courier] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Payment]'))
        SET IDENTITY_INSERT [Payment] ON;
    EXEC(N'INSERT INTO [Payment] ([Id], [Name])
    VALUES (1, N''Bank Transfer''),
    (2, N''Cash on Delivery''),
    (3, N''Paylater'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Payment]'))
        SET IDENTITY_INSERT [Payment] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[ProductStatus]'))
        SET IDENTITY_INSERT [ProductStatus] ON;
    EXEC(N'INSERT INTO [ProductStatus] ([Id], [Name])
    VALUES (2, N''Banned''),
    (1, N''Active''),
    (3, N''Deleted'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[ProductStatus]'))
        SET IDENTITY_INSERT [ProductStatus] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[TransactionStatus]'))
        SET IDENTITY_INSERT [TransactionStatus] ON;
    EXEC(N'INSERT INTO [TransactionStatus] ([Id], [Name])
    VALUES (1, N''Pending''),
    (2, N''Accepted''),
    (3, N''Processed''),
    (4, N''Delivered''),
    (5, N''Cancelled'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[TransactionStatus]'))
        SET IDENTITY_INSERT [TransactionStatus] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Variation]'))
        SET IDENTITY_INSERT [Variation] ON;
    EXEC(N'INSERT INTO [Variation] ([Id], [Name])
    VALUES (2, N''Warna''),
    (1, N''Ukuran'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Variation]'))
        SET IDENTITY_INSERT [Variation] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'Name', N'Phone', N'Province', N'Street', N'Subdistrict', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Warehouse]'))
        SET IDENTITY_INSERT [Warehouse] ON;
    EXEC(N'INSERT INTO [Warehouse] ([Id], [City], [Name], [Phone], [Province], [Street], [Subdistrict], [ZipCode])
    VALUES (1, N''Kota Tasikmalaya'', N''Warehouse JNE Tasikmalaya'', N'''', N''Jawa Barat'', N''Jl. Ir. H. Juanda No.21, RW.1, Cipedes'', N''Cipedes'', N''46151'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'Name', N'Phone', N'Province', N'Street', N'Subdistrict', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Warehouse]'))
        SET IDENTITY_INSERT [Warehouse] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CourierId', N'Name') AND [object_id] = OBJECT_ID(N'[DeliveryService]'))
        SET IDENTITY_INSERT [DeliveryService] ON;
    EXEC(N'INSERT INTO [DeliveryService] ([Id], [CourierId], [Name])
    VALUES (4, 1, N''JTR''),
    (1, 1, N''REG''),
    (3, 1, N''OKE''),
    (2, 1, N''YES'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CourierId', N'Name') AND [object_id] = OBJECT_ID(N'[DeliveryService]'))
        SET IDENTITY_INSERT [DeliveryService] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'VariationId') AND [object_id] = OBJECT_ID(N'[Option]'))
        SET IDENTITY_INSERT [Option] ON;
    EXEC(N'INSERT INTO [Option] ([Id], [Name], [VariationId])
    VALUES (12, N''Kuning'', 2),
    (11, N''Pink'', 2),
    (10, N''Biru'', 2),
    (9, N''Merah'', 2),
    (8, N''Putih'', 2),
    (6, N''43'', 1),
    (5, N''42'', 1),
    (4, N''41'', 1),
    (3, N''40'', 1),
    (2, N''39'', 1),
    (1, N''38'', 1),
    (7, N''Hitam'', 2)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'VariationId') AND [object_id] = OBJECT_ID(N'[Option]'))
        SET IDENTITY_INSERT [Option] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'IsTrash', N'Name', N'ThumbnailUrl') AND [object_id] = OBJECT_ID(N'[SubCategory]'))
        SET IDENTITY_INSERT [SubCategory] ON;
    EXEC(N'INSERT INTO [SubCategory] ([Id], [CategoryId], [IsTrash], [Name], [ThumbnailUrl])
    VALUES (19, 10, 0, N''Handphone'', NULL),
    (20, 10, 0, N''Tablet'', NULL),
    (18, 9, 0, N''Game Console'', NULL),
    (16, 8, 0, N''Gitar & Bass'', NULL),
    (2, 1, 0, N''Religi & Spiritual'', NULL),
    (3, 2, 0, N''Peralatan Makan & Minum'', NULL),
    (4, 2, 0, N''Peralatan Masak'', NULL),
    (5, 3, 0, N''Alat Pendingin Ruangan'', NULL),
    (6, 3, 0, N''TV & Aksesoris'', NULL),
    (7, 4, 0, N''Pakaian Anak Laki-Laki'', NULL),
    (17, 9, 0, N''CD Game'', NULL),
    (8, 4, 0, N''Pakaian Anak Perempuan'', NULL),
    (10, 5, 0, N''Perlengkapan Ibadah'', NULL),
    (11, 6, 0, N''Batik Pria'', NULL),
    (12, 6, 0, N''Celana Pria'', NULL),
    (13, 7, 0, N''Batik Wanita'', NULL),
    (14, 7, 0, N''Bawahan Wanita'', NULL),
    (15, 8, 0, N''Film & Serial'', NULL),
    (9, 5, 0, N''Jilbab'', NULL),
    (1, 1, 0, N''Kamus'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'IsTrash', N'Name', N'ThumbnailUrl') AND [object_id] = OBJECT_ID(N'[SubCategory]'))
        SET IDENTITY_INSERT [SubCategory] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ChargeableWeight', N'Description', N'Name', N'Price', N'ProductStatusId', N'Sku', N'SubCategoryId', N'UserId', N'Volume', N'Weight') AND [object_id] = OBJECT_ID(N'[Product]'))
        SET IDENTITY_INSERT [Product] ON;
    EXEC(N'INSERT INTO [Product] ([Id], [ChargeableWeight], [Description], [Name], [Price], [ProductStatusId], [Sku], [SubCategoryId], [UserId], [Volume], [Weight])
    VALUES (1, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A001'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0),
    (2, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A002'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0),
    (3, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A003'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0),
    (4, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A004'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0),
    (5, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A005'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0),
    (6, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A006'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0),
    (7, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A007'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0),
    (8, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A008'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0),
    (9, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A009'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0),
    (10, 1.0E0, N''Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya'', N''Kamus Bahasa Inggris 1 Juta Kata'', 100000.0E0, 1, N''A0010'', 1, N''supplier-6340-4840-95c2-db12554843e5'', 1.0E0, 1.0E0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ChargeableWeight', N'Description', N'Name', N'Price', N'ProductStatusId', N'Sku', N'SubCategoryId', N'UserId', N'Volume', N'Weight') AND [object_id] = OBJECT_ID(N'[Product]'))
        SET IDENTITY_INSERT [Product] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'ProductId', N'Url') AND [object_id] = OBJECT_ID(N'[ProductImage]'))
        SET IDENTITY_INSERT [ProductImage] ON;
    EXEC(N'INSERT INTO [ProductImage] ([Id], [CreatedAt], [ProductId], [Url])
    VALUES (1, ''2021-09-14T21:31:01.0406842+07:00'', 1, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940''),
    (2, ''2021-09-14T21:31:01.0409516+07:00'', 2, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940''),
    (3, ''2021-09-14T21:31:01.0409534+07:00'', 3, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940''),
    (4, ''2021-09-14T21:31:01.0409537+07:00'', 4, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940''),
    (5, ''2021-09-14T21:31:01.0409539+07:00'', 5, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940''),
    (6, ''2021-09-14T21:31:01.0409549+07:00'', 6, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940''),
    (7, ''2021-09-14T21:31:01.0409552+07:00'', 7, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940''),
    (8, ''2021-09-14T21:31:01.0409554+07:00'', 8, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940''),
    (9, ''2021-09-14T21:31:01.0409557+07:00'', 9, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940''),
    (10, ''2021-09-14T21:31:01.0409561+07:00'', 10, N''https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'ProductId', N'Url') AND [object_id] = OBJECT_ID(N'[ProductImage]'))
        SET IDENTITY_INSERT [ProductImage] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210914143103_seed-dan-ganti-bahasa-warehouse-prop', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC sp_rename N'[ProductImage].[Url]', N'Filename', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''84b3f356-5d46-461e-9fd9-633f1fbe3709'', [CreatedAt] = ''2021-09-22T20:50:53.2335547+07:00'', [PasswordHash] = N''AQAAAAEAACcQAAAAEESZcg8OlknXEKfZOoWX0xowJh2bCO8gYrxJvUq5dWYgn2GTWKub+kke+SZkCQ8coQ=='', [SecurityStamp] = N''fefed367-7a94-4475-a22e-847c3dcb7561''
    WHERE [Id] = N''b74ddd14-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''c093e816-a80f-49be-91ef-0929aff9d597'', [CreatedAt] = ''2021-09-22T20:50:53.2751521+07:00'', [PasswordHash] = N''AQAAAAEAACcQAAAAEMSowM6iZbmzPj5ioV6tkNfdVyDqeWFIJFMeNF69LqC6oJVLVwCRHwXRWHG07nygmQ=='', [SecurityStamp] = N''7359160e-aefc-4121-b6fa-c9736a42d6ec''
    WHERE [Id] = N''supplier-6340-4840-95c2-db12554843e5'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2846083+07:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2847285+07:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2847292+07:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2847294+07:00''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2847295+07:00''
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2847298+07:00''
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2847299+07:00''
    WHERE [Id] = 7;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2847301+07:00''
    WHERE [Id] = 8;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2847302+07:00''
    WHERE [Id] = 9;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    EXEC(N'UPDATE [ProductImage] SET [CreatedAt] = ''2021-09-22T20:50:53.2847303+07:00''
    WHERE [Id] = 10;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922135054_ubah-kolom-url-jadi-filename-product-images')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210922135054_ubah-kolom-url-jadi-filename-product-images', N'5.0.9');
END;
GO

COMMIT;
GO

