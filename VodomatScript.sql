USE [master]
GO
/****** Object:  Database [Vodomet]    Script Date: 06.05.2022 20:20:43 ******/
CREATE DATABASE [Vodomet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vodomet', FILENAME = N'D:\Program Files\MSSQL15.SQLEXPRESS\MSSQL\DATA\Vodomet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Vodomet_log', FILENAME = N'D:\Program Files\MSSQL15.SQLEXPRESS\MSSQL\DATA\Vodomet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Vodomet] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vodomet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vodomet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vodomet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vodomet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vodomet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vodomet] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vodomet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Vodomet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vodomet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vodomet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vodomet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vodomet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vodomet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vodomet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vodomet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vodomet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Vodomet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vodomet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vodomet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vodomet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vodomet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vodomet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Vodomet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vodomet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Vodomet] SET  MULTI_USER 
GO
ALTER DATABASE [Vodomet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vodomet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Vodomet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Vodomet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Vodomet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Vodomet] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Vodomet] SET QUERY_STORE = OFF
GO
USE [Vodomet]
GO
/****** Object:  Table [dbo].[AquaAccount]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AquaAccount](
	[Id] [int] NOT NULL,
	[Password] [int] NULL,
	[Price] [decimal](7, 2) NULL,
	[Balance] [decimal](7, 2) NULL,
	[Bonus] [decimal](7, 2) NULL,
	[AddedBonus] [decimal](7, 2) NULL,
	[Groupp] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](11) NULL,
 CONSTRAINT [PK_AquaAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AquaAccountHistory]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AquaAccountHistory](
	[IdAquaAccount] [int] NOT NULL,
	[IdVodomat] [int] NOT NULL,
	[Date] [date] NULL,
	[AddCash] [decimal](7, 2) NULL,
	[AddBankCard] [decimal](7, 2) NULL,
	[WriteDowns] [decimal](7, 2) NULL,
	[Litres] [int] NULL,
 CONSTRAINT [PK_AquaAccountHistory] PRIMARY KEY CLUSTERED 
(
	[IdAquaAccount] ASC,
	[IdVodomat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auth]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auth](
	[IdRole] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Auth_1] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BonusHistory]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BonusHistory](
	[IdAquaAccount] [int] NOT NULL,
	[Date] [date] NULL,
	[AddBonus] [decimal](7, 2) NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_BonusHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CollectionHistory]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollectionHistory](
	[IdCollector] [nvarchar](50) NOT NULL,
	[IdVodomat] [int] NOT NULL,
	[CollectionSum] [decimal](7, 2) NULL,
	[WriteDown] [decimal](7, 2) NULL,
	[AmountSum] [decimal](7, 2) NULL,
 CONSTRAINT [PK_CollectionHistory] PRIMARY KEY CLUSTERED 
(
	[IdCollector] ASC,
	[IdVodomat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Collector]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collector](
	[Id] [nvarchar](50) NOT NULL,
	[Date] [date] NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Comment] [nvarchar](max) NULL,
	[Permission] [bit] NULL,
 CONSTRAINT [PK_Collector] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drebezg]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drebezg](
	[Id] [int] NOT NULL,
	[HitTime] [int] NULL,
	[LowWater] [int] NULL,
	[NoWater] [int] NULL,
	[FullTank] [int] NULL,
	[No220B] [int] NULL,
	[MovementTime] [int] NULL,
	[TempTime] [int] NULL,
 CONSTRAINT [PK_Drebezg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marketing]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marketing](
	[Id] [int] NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Price] [decimal](7, 2) NULL,
 CONSTRAINT [PK_Marketing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [int] NOT NULL,
	[TempTime] [bit] NULL,
	[HitTime] [bit] NULL,
	[LowWater] [bit] NULL,
	[NoWater] [bit] NULL,
	[FullTank] [bit] NULL,
	[No220B] [bit] NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recovery]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recovery](
	[TempTime] [int] NULL,
	[HitTime] [int] NULL,
	[LowWater] [int] NULL,
	[NoWater] [int] NULL,
	[FullTank] [int] NULL,
	[No220B] [int] NULL,
	[MovementTime] [int] NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Recovery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[Id] [int] NOT NULL,
	[IdDrebezg] [int] NOT NULL,
	[IdRecovery] [int] NOT NULL,
	[IdTrigerring] [int] NOT NULL,
	[IdNotifications] [int] NOT NULL,
	[PulsePerLitre] [int] NULL,
	[MaxLitres] [int] NULL,
	[CoinRatio] [int] NULL,
	[BanknoteRatio] [int] NULL,
	[APN] [nvarchar](50) NULL,
	[SIMNumber] [nvarchar](50) NULL,
	[TimeOfShowKeysBalance] [int] NULL,
	[FreeWaterDeliveryMode] [bit] NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Triggering]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Triggering](
	[Id] [int] NOT NULL,
	[Temp] [nvarchar](50) NULL,
	[HitTime] [bit] NULL,
	[LowWater] [bit] NULL,
	[NoWater] [bit] NULL,
	[FullTank] [bit] NULL,
	[MovementTime] [bit] NULL,
 CONSTRAINT [PK_Triggering] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vodomat]    Script Date: 06.05.2022 20:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vodomat](
	[Id] [int] NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Kopilka] [decimal](7, 2) NULL,
	[AmountLitres] [decimal](7, 2) NULL,
	[PO] [int] NULL,
	[Hit] [date] NULL,
	[LowWater] [date] NULL,
	[NoWater] [date] NULL,
	[FullTank] [date] NULL,
	[Clog] [date] NOT NULL,
	[Temp] [date] NULL,
	[No220V] [date] NULL,
	[MDB] [date] NULL,
	[PC] [date] NULL,
	[IdSetting] [int] NOT NULL,
	[FirmwareVersion] [nvarchar](50) NULL,
	[IdMarketing] [int] NOT NULL,
 CONSTRAINT [PK_Vodomat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AquaAccountHistory]  WITH CHECK ADD  CONSTRAINT [FK_AquaAccountHistory_AquaAccount] FOREIGN KEY([IdAquaAccount])
REFERENCES [dbo].[AquaAccount] ([Id])
GO
ALTER TABLE [dbo].[AquaAccountHistory] CHECK CONSTRAINT [FK_AquaAccountHistory_AquaAccount]
GO
ALTER TABLE [dbo].[AquaAccountHistory]  WITH CHECK ADD  CONSTRAINT [FK_AquaAccountHistory_Vodomat] FOREIGN KEY([IdVodomat])
REFERENCES [dbo].[Vodomat] ([Id])
GO
ALTER TABLE [dbo].[AquaAccountHistory] CHECK CONSTRAINT [FK_AquaAccountHistory_Vodomat]
GO
ALTER TABLE [dbo].[Auth]  WITH CHECK ADD  CONSTRAINT [FK_Auth_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Auth] CHECK CONSTRAINT [FK_Auth_Role]
GO
ALTER TABLE [dbo].[Auth]  WITH CHECK ADD  CONSTRAINT [FK_Auth_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Auth] CHECK CONSTRAINT [FK_Auth_User]
GO
ALTER TABLE [dbo].[BonusHistory]  WITH CHECK ADD  CONSTRAINT [FK_BonusHistory_AquaAccount1] FOREIGN KEY([IdAquaAccount])
REFERENCES [dbo].[AquaAccount] ([Id])
GO
ALTER TABLE [dbo].[BonusHistory] CHECK CONSTRAINT [FK_BonusHistory_AquaAccount1]
GO
ALTER TABLE [dbo].[CollectionHistory]  WITH CHECK ADD  CONSTRAINT [FK_CollectionHistory_Collector] FOREIGN KEY([IdCollector])
REFERENCES [dbo].[Collector] ([Id])
GO
ALTER TABLE [dbo].[CollectionHistory] CHECK CONSTRAINT [FK_CollectionHistory_Collector]
GO
ALTER TABLE [dbo].[CollectionHistory]  WITH CHECK ADD  CONSTRAINT [FK_CollectionHistory_Vodomat] FOREIGN KEY([IdVodomat])
REFERENCES [dbo].[Vodomat] ([Id])
GO
ALTER TABLE [dbo].[CollectionHistory] CHECK CONSTRAINT [FK_CollectionHistory_Vodomat]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD  CONSTRAINT [FK_Setting_Drebezg] FOREIGN KEY([IdDrebezg])
REFERENCES [dbo].[Drebezg] ([Id])
GO
ALTER TABLE [dbo].[Setting] CHECK CONSTRAINT [FK_Setting_Drebezg]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD  CONSTRAINT [FK_Setting_Notifications] FOREIGN KEY([IdNotifications])
REFERENCES [dbo].[Notifications] ([Id])
GO
ALTER TABLE [dbo].[Setting] CHECK CONSTRAINT [FK_Setting_Notifications]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD  CONSTRAINT [FK_Setting_Recovery] FOREIGN KEY([IdRecovery])
REFERENCES [dbo].[Recovery] ([Id])
GO
ALTER TABLE [dbo].[Setting] CHECK CONSTRAINT [FK_Setting_Recovery]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD  CONSTRAINT [FK_Setting_Triggering] FOREIGN KEY([IdTrigerring])
REFERENCES [dbo].[Triggering] ([Id])
GO
ALTER TABLE [dbo].[Setting] CHECK CONSTRAINT [FK_Setting_Triggering]
GO
ALTER TABLE [dbo].[Vodomat]  WITH CHECK ADD  CONSTRAINT [FK_Vodomat_Marketing] FOREIGN KEY([IdMarketing])
REFERENCES [dbo].[Marketing] ([Id])
GO
ALTER TABLE [dbo].[Vodomat] CHECK CONSTRAINT [FK_Vodomat_Marketing]
GO
ALTER TABLE [dbo].[Vodomat]  WITH CHECK ADD  CONSTRAINT [FK_Vodomat_Setting] FOREIGN KEY([IdSetting])
REFERENCES [dbo].[Setting] ([Id])
GO
ALTER TABLE [dbo].[Vodomat] CHECK CONSTRAINT [FK_Vodomat_Setting]
GO
USE [master]
GO
ALTER DATABASE [Vodomet] SET  READ_WRITE 
GO
