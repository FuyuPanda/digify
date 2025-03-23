USE [master]
GO
/****** Object:  Database [digify]    Script Date: 23/03/2025 13:08:23 ******/
CREATE DATABASE [digify]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'digify', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\digify.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'digify_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\digify_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [digify] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [digify].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [digify] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [digify] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [digify] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [digify] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [digify] SET ARITHABORT OFF 
GO
ALTER DATABASE [digify] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [digify] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [digify] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [digify] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [digify] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [digify] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [digify] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [digify] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [digify] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [digify] SET  DISABLE_BROKER 
GO
ALTER DATABASE [digify] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [digify] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [digify] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [digify] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [digify] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [digify] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [digify] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [digify] SET RECOVERY FULL 
GO
ALTER DATABASE [digify] SET  MULTI_USER 
GO
ALTER DATABASE [digify] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [digify] SET DB_CHAINING OFF 
GO
ALTER DATABASE [digify] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [digify] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [digify] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [digify] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'digify', N'ON'
GO
ALTER DATABASE [digify] SET QUERY_STORE = OFF
GO
USE [digify]
GO
/****** Object:  User [digify]    Script Date: 23/03/2025 13:08:24 ******/
CREATE USER [digify] FOR LOGIN [digify] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [digify]
GO
/****** Object:  Table [dbo].[user]    Script Date: 23/03/2025 13:08:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[companyName] [varchar](255) NOT NULL,
	[npwp] [varchar](40) NOT NULL,
	[directorName] [varchar](255) NOT NULL,
	[picName] [varchar](255) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[phoneNumber] [varchar](40) NOT NULL,
	[npwpPath] [varchar](255) NOT NULL,
	[poaPath] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [digify] SET  READ_WRITE 
GO
