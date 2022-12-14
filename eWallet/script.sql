USE [master]
GO
/****** Object:  Database [eWallet]    Script Date: 8/17/2022 5:10:22 PM ******/
CREATE DATABASE [eWallet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eWallet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eWallet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eWallet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eWallet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [eWallet] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eWallet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eWallet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eWallet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eWallet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eWallet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eWallet] SET ARITHABORT OFF 
GO
ALTER DATABASE [eWallet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eWallet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eWallet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eWallet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eWallet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eWallet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eWallet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eWallet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eWallet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eWallet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [eWallet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eWallet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eWallet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eWallet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eWallet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eWallet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eWallet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eWallet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eWallet] SET  MULTI_USER 
GO
ALTER DATABASE [eWallet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eWallet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eWallet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eWallet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eWallet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eWallet] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [eWallet] SET QUERY_STORE = OFF
GO
USE [eWallet]
GO
/****** Object:  Table [dbo].[States]    Script Date: 8/17/2022 5:10:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccounts]    Script Date: 8/17/2022 5:10:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NULL,
	[EmailConfirmed] [bit] NULL,
	[Password] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfiles]    Script Date: 8/17/2022 5:10:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Gender] [int] NULL,
	[Phone] [varchar](20) NULL,
	[Address] [varchar](200) NULL,
	[StateId] [int] NULL,
	[Balance] [decimal](18, 2) NULL,
	[UserId] [int] NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([Id], [Name]) VALUES (1, N'Lagos')
INSERT [dbo].[States] ([Id], [Name]) VALUES (2, N'Abia')
INSERT [dbo].[States] ([Id], [Name]) VALUES (3, N'Adamawa')
INSERT [dbo].[States] ([Id], [Name]) VALUES (4, N'Ogun')
INSERT [dbo].[States] ([Id], [Name]) VALUES (5, N'Osun')
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAccounts] ON 

INSERT [dbo].[UserAccounts] ([Id], [Email], [EmailConfirmed], [Password], [IsActive], [DateCreated]) VALUES (1, N'peterayebhere@gmail.com', 1, N'password', 1, CAST(N'2022-08-15T16:13:43.340' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserAccounts] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfiles] ON 

INSERT [dbo].[UserProfiles] ([Id], [FirstName], [LastName], [Gender], [Phone], [Address], [StateId], [Balance], [UserId], [DateCreated], [DateUpdated], [IsActive]) VALUES (1, N'peter', N'eikore', 1, N'07068352430', N'address.', 1, CAST(20000.00 AS Decimal(18, 2)), 1, CAST(N'2022-08-17T14:54:21.530' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[UserProfiles] OFF
GO
USE [master]
GO
ALTER DATABASE [eWallet] SET  READ_WRITE 
GO
