/*
Script de déploiement pour ProducteurDB

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ProducteurDB"
:setvar DefaultFilePrefix "ProducteurDB"
:setvar DefaultDataPath "C:\Users\dewal\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\dewal\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de la base de données $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de Table [dbo].[Address]...';


GO
CREATE TABLE [dbo].[Address] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Rue]        NVARCHAR (50) NOT NULL,
    [Numero]     NVARCHAR (7)  NOT NULL,
    [Ville]      NVARCHAR (50) NOT NULL,
    [Codepostal] NVARCHAR (10) NOT NULL,
    [Pays]       NVARCHAR (50) NOT NULL,
    [Lat]        FLOAT (53)    NOT NULL,
    [Lon]        FLOAT (53)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Customer]...';


GO
CREATE TABLE [dbo].[Customer] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [Lastname]  VARCHAR (50)     NOT NULL,
    [Firstname] VARCHAR (50)     NOT NULL,
    [AddressId] INT              NOT NULL,
    [Email]     VARCHAR (384)    NOT NULL,
    [Password]  BINARY (64)      NOT NULL,
    [Presalt]   UNIQUEIDENTIFIER NOT NULL,
    [Postsalt]  UNIQUEIDENTIFIER NOT NULL,
    [isAdmin]   BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Producer]...';


GO
CREATE TABLE [dbo].[Producer] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Lastname]  VARCHAR (50)  NOT NULL,
    [Firstname] VARCHAR (30)  NULL,
    [AddressId] INT           NOT NULL,
    [Email]     VARCHAR (384) NOT NULL,
    [Password]  BINARY (64)   NOT NULL,
    [Presalt]   BINARY (64)   NOT NULL,
    [Postsalt]  BINARY (64)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Product]...';


GO
CREATE TABLE [dbo].[Product] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Quantite]     FLOAT (53)     NOT NULL,
    [ProducteurID] INT            NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [Price]        FLOAT (53)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Purchase]...';


GO
CREATE TABLE [dbo].[Purchase] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Date]       DATETIME2 (7) NOT NULL,
    [ProductID]  INT           NOT NULL,
    [CustomerID] INT           NOT NULL,
    [Quantity]   FLOAT (53)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Customer_Address]...';


GO
ALTER TABLE [dbo].[Customer]
    ADD CONSTRAINT [FK_Customer_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Producer_Address]...';


GO
ALTER TABLE [dbo].[Producer]
    ADD CONSTRAINT [FK_Producer_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Produit_Producteur]...';


GO
ALTER TABLE [dbo].[Product]
    ADD CONSTRAINT [FK_Produit_Producteur] FOREIGN KEY ([ProducteurID]) REFERENCES [dbo].[Producer] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Purchase_ToCustomer]...';


GO
ALTER TABLE [dbo].[Purchase]
    ADD CONSTRAINT [FK_Purchase_ToCustomer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Purchase_ToProduct]...';


GO
ALTER TABLE [dbo].[Purchase]
    ADD CONSTRAINT [FK_Purchase_ToProduct] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'Création de Fonction [dbo].[Hash]...';


GO
CREATE FUNCTION [dbo].[Hash]
(
	@saltedPwd NVARCHAR(max)
)
RETURNS BINARY(64)
AS
BEGIN
	RETURN  HASHBYTES('SHA2_512',@saltedPwd)
END
GO
PRINT N'Création de Fonction [dbo].[Salt]...';


GO
CREATE FUNCTION [dbo].[Salt]
(
	@presalt UNIQUEIDENTIFIER,
	@password NVARCHAR(200),
	@postSalt UNIQUEIDENTIFIER
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @SaltedPwd as NVARCHAR(max)
	RETURN CONCAT(@presalt, @password, @postSalt)
END
GO
PRINT N'Création de Procédure [dbo].[checkCustomer]...';


GO
CREATE PROCEDURE [dbo].[checkCustomer]
	@email NVARCHAR(384),
	@password NVARCHAR(32)
AS	
	SELECT	[Id],
			[lastName],
			[firstName],
			[Email],
			'********' AS [Password],
			[AddressId],
			[isAdmin]
	FROM [Customer]
	WHERE [Email] LIKE @email
		AND [Password] = [dbo].[Hash]([dbo].[Salt]([Presalt],@password,[Postsalt]))
GO
PRINT N'Création de Procédure [dbo].[checkProducer]...';


GO
CREATE PROCEDURE [dbo].[checkProducer]
	@email NVARCHAR(384),
	@password NVARCHAR(32)
AS	
	SELECT	[Id],
			[lastname],
			[firstname],
			[Email],
			'********' AS [Password],
			[AddressId]
	FROM [Producer]
	WHERE [Email] LIKE @email
		AND [Password] = [dbo].[Hash]([dbo].[Salt]([Presalt],@password,[Postsalt]))
GO
PRINT N'Création de Procédure [dbo].[CreateAdress]...';


GO
CREATE PROCEDURE [dbo].[CreateAdress]
	@Rue NVARCHAR(50),
	@Numero NVARCHAR(7),
	@Ville NVARCHAR(50),
	@Codepostal NVARCHAR(10),
	@Pays NVARCHAR(50),
	@Long float,
	@Lat float
AS
	INSERT INTO[Address]([Rue],[Numero],[Codepostal],[Ville],[Pays],[Lon],[Lat])
	OUTPUT [inserted].Id
	Values (@Rue, @Numero, @Codepostal, @Ville,  @Pays, @Long, @Lat)
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[CreateCustomer]...';


GO
CREATE PROCEDURE [dbo].[CreateCustomer]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384),
	@Password NVARCHAR(50),
	@isAdmin BIT,
	@AddressId INT

AS	
	DECLARE @Presalt UNIQUEIDENTIFIER = NEWID()
	DECLARE @Postsalt UNIQUEIDENTIFIER = NEWID()
	DECLARE @PwdHased as BINARY(64)
	SET @PwdHased=[dbo].[Hash]([dbo].[Salt](@Presalt,@Password,@Postsalt))
	
	

	INSERT INTO [Customer]([Lastname], [Firstname], [Email], [Password], [Presalt], [Postsalt], [AddressId],[isAdmin])
	OUTPUT [Inserted].[Id]
	VALUES (@LastName,@FirstName,@Email,@PwdHased,@Presalt, @Postsalt, @AddressId, @isAdmin)
GO
PRINT N'Création de Procédure [dbo].[CreateProducer]...';


GO
CREATE PROCEDURE [dbo].[CreateProducer]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384),
	@Password NVARCHAR(50),
	@AddressId INT
AS	
	
	DECLARE @Presalt UNIQUEIDENTIFIER = NEWID()
	DECLARE @Postsalt UNIQUEIDENTIFIER = NEWID()
	DECLARE @PwdHased as BINARY(64)
	SET @PwdHased=[dbo].[Hash]([dbo].[Salt](@Presalt,@Password,@Postsalt))
	
	INSERT INTO [Producer]([Lastname], [Firstname], [Email], [Password], [Presalt], [Postsalt], [AddressId])
	OUTPUT [Inserted].[Id]
	VALUES (@LastName,@FirstName,@Email,@PwdHased,@Presalt, @Postsalt, @AddressId)
GO
PRINT N'Création de Procédure [dbo].[CreateProduct]...';


GO
CREATE PROCEDURE [dbo].[CreateProduct]
	@nom nvarchar(100),
	@quantite float,
	@ProducteurId int,
	@Description nvarchar(max),
	@Price float
AS
	BEGIN
		INSERT INTO [Product]([Name],[Quantite],[ProducteurID],[Description],[Price])
		OUTPUT [Inserted].[Id]
		Values (@nom, @quantite, @ProducteurId, @Description,@Price)
		RETURN 0
	END
GO
PRINT N'Création de Procédure [dbo].[CreatePurchase]...';


GO
CREATE PROCEDURE [dbo].[CreatePurchase]
	@Date datetime2,
	@ProductId int,
	@CustomerId int,
	@Quantite float
As
	BEGIN
		INSERT INTO [Purchase]([Date],[CustomerID],[ProductID], [Quantity])
		OUTPUT [inserted].[Id]
		VALUES (@Date,@CustomerId,@ProductId,@Quantite)
		RETURN 0
	END
GO
PRINT N'Création de Procédure [dbo].[DeleteProduct]...';


GO
CREATE PROCEDURE [dbo].[DeleteProduct]
	@id int
AS	
	BEGIN
		DELETE FROM [Product] where [Id]=@id
		RETURN 0
	END
GO
PRINT N'Création de Procédure [dbo].[GetAddressByCustomer]...';


GO
CREATE PROCEDURE [dbo].[GetAddressByCustomer]
	@id int
AS
	SELECT * from [Address]
	WHERE [Id]=(SELECT AddressId FROM [Customer] where Id=@id)
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetAddressByProducer]...';


GO
CREATE PROCEDURE [dbo].[GetAddressByProducer]
	@id int
AS
	SELECT * from [Address]
	WHERE [Id]=(SELECT AddressId FROM [Producer] where Id=@id)
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetAdressById]...';


GO
CREATE PROCEDURE [dbo].[GetAdressById]
	@id int
AS
	SELECT * FROM [Address] WHERE [Id]=@id
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetCustomerById]...';


GO
CREATE PROCEDURE [dbo].[GetCustomerById]
	@id int
AS
	BEGIN
		SELECT [Id],[Lastname],[Firstname],[AddressId],[Email],'******' as [Password], [isAdmin] FROM [Customer]
		WHERE [Id]=@id
		RETURN 0
	END
GO
PRINT N'Création de Procédure [dbo].[GetCustomerByPurchase]...';


GO
CREATE PROCEDURE [dbo].[GetCustomerByPurchase]
	@id int
AS
	SELECT [Id],[Lastname],[Firstname],[AddressId],[Email],'******' as [Password], [isAdmin] FROM [Customer] 
	WHERE [Id]=(SELECT [CustomerID] FROM [Purchase] where [Id]=@id)
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetProducerById]...';


GO
CREATE PROCEDURE [dbo].[GetProducerById]
	@id int
AS
	BEGIN
		SELECT [Id],[Lastname],[Firstname],[AddressId],[Email],'******' as [Password] FROM [Producer]
		WHERE [Id]=@id
		RETURN 0
	END
GO
PRINT N'Création de Procédure [dbo].[GetProducerByProduct]...';


GO
CREATE PROCEDURE [dbo].[GetProducerByProduct]
	@id int
AS
	SELECT [Id],[Lastname],[Firstname],[AddressId],[Email],'******' as [Password] FROM [Producer] 
	WHERE [Id]=(SELECT [ProducteurID] FROM [Product] where [Id]=@id)
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetProductById]...';


GO
CREATE PROCEDURE [dbo].[GetProductById]
	@id int
AS
	BEGIN
		SELECT * FROM [Product]
		WHERE [Id]=@id
		RETURN 0
	END
GO
PRINT N'Création de Procédure [dbo].[GetProductByPurchase]...';


GO
CREATE PROCEDURE [dbo].[GetProductByPurchase]
	@id int
AS
	SELECT * FROM [Product] 
	WHERE [Id]=(SELECT [ProductID] FROM [Purchase] where [Id]=@id)
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetProducters]...';


GO
CREATE PROCEDURE [dbo].[GetProducters]
AS
	SELECT [Id],[LastName],[FirstName],[Email],'********' AS [Password],[AddressId]
	FROM [Producer]
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetProducts]...';


GO
CREATE PROCEDURE [dbo].[GetProducts]
AS
	SELECT * from [Product]
RETURN 0
GO
PRINT N'Création de Procédure [dbo].[GetPurchaseById]...';


GO
CREATE PROCEDURE [dbo].[GetPurchaseById]
	@id int
AS
	BEGIN
		SELECT * FROM [Purchase]
		WHERE [Id]=@id
		RETURN 0
	END
GO
PRINT N'Création de Procédure [dbo].[UpdateProduct]...';


GO
CREATE PROCEDURE [dbo].[UpdateProduct]
	@id int,
	@nom nvarchar(100),
	@quantite decimal,
	@description nvarchar(max),
	@Price decimal
AS
	BEGIN
		UPDATE [Product]
		SET [Name]=@nom,
			[Quantite]=@quantite,
			[Description]=@description,
			[Price]=@Price
		WHERE [Id]=@id
		RETURN 0
	END
GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '02872d87-1ffc-40f1-9da8-34597919ad9f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('02872d87-1ffc-40f1-9da8-34597919ad9f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e2c52087-a150-4978-ae8d-538b1c7c0b37')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e2c52087-a150-4978-ae8d-538b1c7c0b37')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'eeac34f8-05da-4dce-aaad-dae7cfa553bf')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('eeac34f8-05da-4dce-aaad-dae7cfa553bf')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6757f651-a976-403b-8152-b3eb82aa06e2')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6757f651-a976-403b-8152-b3eb82aa06e2')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '96cd5643-3a4a-45fc-adfa-8c45f3b0b72c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('96cd5643-3a4a-45fc-adfa-8c45f3b0b72c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3f19d422-2655-41db-a8c0-859cb6ca623c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3f19d422-2655-41db-a8c0-859cb6ca623c')

GO

GO

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
