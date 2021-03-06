USE [master]
GO
/****** Object:  Database [AirportManagement]    Script Date: 11/5/2018 11:22:28 AM ******/
CREATE DATABASE [AirportManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Airport', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Airport.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Airport_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Airport_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AirportManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AirportManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AirportManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AirportManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AirportManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AirportManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AirportManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [AirportManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AirportManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AirportManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AirportManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AirportManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AirportManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AirportManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AirportManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AirportManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AirportManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AirportManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AirportManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AirportManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AirportManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AirportManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AirportManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AirportManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AirportManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AirportManagement] SET  MULTI_USER 
GO
ALTER DATABASE [AirportManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AirportManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AirportManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AirportManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AirportManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AirportManagement]
GO
/****** Object:  Table [dbo].[Airport]    Script Date: 11/5/2018 11:22:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airport](
	[Airport_ID] [nvarchar](7) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[MaxFWParkingPlace] [int] NULL,
	[MaxHelicopterParkingPlace] [int] NULL,
	[RunawaySize] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Airport] PRIMARY KEY CLUSTERED 
(
	[Airport_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FixedWings]    Script Date: 11/5/2018 11:22:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixedWings](
	[FW_ID] [nvarchar](7) NOT NULL,
	[Model] [nvarchar](40) NULL,
	[PlanType] [nchar](3) NULL,
	[CruiseSpeed] [decimal](18, 0) NULL,
	[EmptyWeight] [decimal](18, 0) NULL,
	[MaxTakeOffWeight] [decimal](18, 0) NULL,
	[MinRunAwaySize] [decimal](18, 0) NULL,
	[FlyMethod] [nvarchar](50) NULL,
	[Airport_ID] [nvarchar](7) NOT NULL,
 CONSTRAINT [PK_FixedWings] PRIMARY KEY CLUSTERED 
(
	[FW_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Helicopter]    Script Date: 11/5/2018 11:22:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Helicopter](
	[Helicopter_ID] [nvarchar](7) NOT NULL,
	[Model] [nvarchar](40) NULL,
	[CruiseSpeed] [decimal](18, 0) NULL,
	[EmtyWeight] [decimal](18, 0) NULL,
	[MaxTakeOffWeight] [decimal](18, 0) NULL,
	[Range] [decimal](18, 0) NULL,
	[FlyMethod] [nvarchar](50) NULL,
	[Airport_ID] [nvarchar](7) NOT NULL,
 CONSTRAINT [PK_Helicopter] PRIMARY KEY CLUSTERED 
(
	[Helicopter_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FixedWings]  WITH CHECK ADD  CONSTRAINT [FK_FixedWings_Airport] FOREIGN KEY([Airport_ID])
REFERENCES [dbo].[Airport] ([Airport_ID])
GO
ALTER TABLE [dbo].[FixedWings] CHECK CONSTRAINT [FK_FixedWings_Airport]
GO
ALTER TABLE [dbo].[Helicopter]  WITH CHECK ADD  CONSTRAINT [FK_Helicopter_Airport] FOREIGN KEY([Airport_ID])
REFERENCES [dbo].[Airport] ([Airport_ID])
GO
ALTER TABLE [dbo].[Helicopter] CHECK CONSTRAINT [FK_Helicopter_Airport]
GO
USE [master]
GO
ALTER DATABASE [AirportManagement] SET  READ_WRITE 
GO
