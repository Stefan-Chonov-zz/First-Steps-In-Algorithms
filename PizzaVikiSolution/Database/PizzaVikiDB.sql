USE [master]
GO
/****** Object:  Database [PizzaVikiCategories]    Script Date: 09/09/2012 23:02:13 ******/
CREATE DATABASE [PizzaVikiCategories] ON  PRIMARY 
( NAME = N'PizzaVikiCategories', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\PizzaVikiCategories.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PizzaVikiCategories_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\PizzaVikiCategories_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PizzaVikiCategories] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PizzaVikiCategories].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PizzaVikiCategories] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET ANSI_NULLS OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET ANSI_PADDING OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET ARITHABORT OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [PizzaVikiCategories] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [PizzaVikiCategories] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [PizzaVikiCategories] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET  DISABLE_BROKER
GO
ALTER DATABASE [PizzaVikiCategories] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [PizzaVikiCategories] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [PizzaVikiCategories] SET  READ_WRITE
GO
ALTER DATABASE [PizzaVikiCategories] SET RECOVERY FULL
GO
ALTER DATABASE [PizzaVikiCategories] SET  MULTI_USER
GO
ALTER DATABASE [PizzaVikiCategories] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [PizzaVikiCategories] SET DB_CHAINING OFF
GO
USE [PizzaVikiCategories]
GO
/****** Object:  Table [dbo].[PhoneOrders]    Script Date: 09/09/2012 23:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhoneOrders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OperatorName] [nvarchar](20) NOT NULL,
	[LogoImage] [varchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_PhoneOrders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NavigationMenu]    Script Date: 09/09/2012 23:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NavigationMenu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[Link] [nvarchar](100) NOT NULL,
	[Text] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_NavigationMenu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 09/09/2012 23:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[BackgroundImagePath] [varchar](100) NOT NULL,
	[Link] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 09/09/2012 23:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BackgroundImagePath] [nvarchar](100) NOT NULL,
	[Ingredients] [nvarchar](100) NULL,
	[LowestPrice] [float] NULL,
	[AveragePrice] [float] NULL,
	[HighestPrice] [float] NULL,
	[Weight] [float] NULL,
	[CategoryID] [int] NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MainTable]    Script Date: 09/09/2012 23:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[NavigationMenu] [int] NOT NULL,
	[PhoneOrders] [int] NOT NULL,
 CONSTRAINT [PK_MainTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Product_Category1]    Script Date: 09/09/2012 23:02:14 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category1] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category1]
GO
/****** Object:  ForeignKey [FK_MainTable_Category]    Script Date: 09/09/2012 23:02:14 ******/
ALTER TABLE [dbo].[MainTable]  WITH CHECK ADD  CONSTRAINT [FK_MainTable_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[MainTable] CHECK CONSTRAINT [FK_MainTable_Category]
GO
/****** Object:  ForeignKey [FK_MainTable_NavigationMenu1]    Script Date: 09/09/2012 23:02:14 ******/
ALTER TABLE [dbo].[MainTable]  WITH CHECK ADD  CONSTRAINT [FK_MainTable_NavigationMenu1] FOREIGN KEY([NavigationMenu])
REFERENCES [dbo].[NavigationMenu] ([id])
GO
ALTER TABLE [dbo].[MainTable] CHECK CONSTRAINT [FK_MainTable_NavigationMenu1]
GO
/****** Object:  ForeignKey [FK_MainTable_PhoneOrders]    Script Date: 09/09/2012 23:02:14 ******/
ALTER TABLE [dbo].[MainTable]  WITH CHECK ADD  CONSTRAINT [FK_MainTable_PhoneOrders] FOREIGN KEY([PhoneOrders])
REFERENCES [dbo].[PhoneOrders] ([id])
GO
ALTER TABLE [dbo].[MainTable] CHECK CONSTRAINT [FK_MainTable_PhoneOrders]
GO
