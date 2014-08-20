USE [master]
GO
/****** Object:  Database [Towns]    Script Date: 8/20/2014 7:02:36 PM ******/
CREATE DATABASE [Towns]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Towns', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Towns.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Towns_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Towns_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Towns] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Towns].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Towns] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Towns] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Towns] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Towns] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Towns] SET ARITHABORT OFF 
GO
ALTER DATABASE [Towns] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Towns] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Towns] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Towns] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Towns] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Towns] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Towns] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Towns] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Towns] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Towns] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Towns] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Towns] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Towns] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Towns] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Towns] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Towns] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Towns] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Towns] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Towns] SET  MULTI_USER 
GO
ALTER DATABASE [Towns] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Towns] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Towns] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Towns] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Towns] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Towns]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 8/20/2014 7:02:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[address_id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [text] NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 8/20/2014 7:02:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Continent](
	[continent_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[continent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 8/20/2014 7:02:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[country_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[country_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 8/20/2014 7:02:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[person_id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Town]    Script Date: 8/20/2014 7:02:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[town_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[town_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

GO
INSERT [dbo].[Address] ([address_id], [address_text], [town_id]) VALUES (1, N'bul. Dragan Tzankov 66', 1)
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Continent] ON 

GO
INSERT [dbo].[Continent] ([continent_id], [name]) VALUES (1, N'Europe')
GO
INSERT [dbo].[Continent] ([continent_id], [name]) VALUES (2, N'North America')
GO
INSERT [dbo].[Continent] ([continent_id], [name]) VALUES (3, N'Asia')
GO
INSERT [dbo].[Continent] ([continent_id], [name]) VALUES (4, N'Australia')
GO
INSERT [dbo].[Continent] ([continent_id], [name]) VALUES (5, N'Africa')
GO
INSERT [dbo].[Continent] ([continent_id], [name]) VALUES (6, N'South America')
GO
INSERT [dbo].[Continent] ([continent_id], [name]) VALUES (7, N'Antarctica')
GO
SET IDENTITY_INSERT [dbo].[Continent] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

GO
INSERT [dbo].[Country] ([country_id], [name], [continent_id]) VALUES (1, N'Bulgaria', 1)
GO
INSERT [dbo].[Country] ([country_id], [name], [continent_id]) VALUES (2, N'Germany', 1)
GO
INSERT [dbo].[Country] ([country_id], [name], [continent_id]) VALUES (3, N'USA', 2)
GO
INSERT [dbo].[Country] ([country_id], [name], [continent_id]) VALUES (4, N'Canada', 2)
GO
INSERT [dbo].[Country] ([country_id], [name], [continent_id]) VALUES (5, N'Katar', 5)
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

GO
INSERT [dbo].[Person] ([person_id], [firstname], [lastname], [address_id]) VALUES (2, N'Pesho', N'Petrov', 1)
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[Town] ON 

GO
INSERT [dbo].[Town] ([town_id], [name], [country_id]) VALUES (1, N'Sofia     ', 1)
GO
INSERT [dbo].[Town] ([town_id], [name], [country_id]) VALUES (2, N'Berlin    ', 2)
GO
SET IDENTITY_INSERT [dbo].[Town] OFF
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Adress_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([town_id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Adress_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([continent_id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([address_id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([country_id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [Towns] SET  READ_WRITE 
GO
