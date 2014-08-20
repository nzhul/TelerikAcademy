USE [master]
GO
/****** Object:  Database [MultilingualDictionaryDB]    Script Date: 14.7.2013 г. 13:03:32 ч. ******/
CREATE DATABASE [MultilingualDictionaryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MultilingualDictionaryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultilingualDictionaryDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MultilingualDictionaryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultilingualDictionaryDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MultilingualDictionaryDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MultilingualDictionaryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MultilingualDictionaryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET  MULTI_USER 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MultilingualDictionaryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MultilingualDictionaryDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MultilingualDictionaryDB', N'ON'
GO
USE [MultilingualDictionaryDB]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 14.7.2013 г. 13:03:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[WordId] [int] NOT NULL,
	[Explanation] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 14.7.2013 г. 13:03:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartsOfSpeach]    Script Date: 14.7.2013 г. 13:03:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartsOfSpeach](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PartsOfSpeach] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 14.7.2013 г. 13:03:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[WordId] [int] NOT NULL,
	[TranslationId] [int] NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC,
	[TranslationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 14.7.2013 г. 13:03:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[PartOfSpeechID] [int] NOT NULL,
	[AntonymId] [int] NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsToHypernyms]    Script Date: 14.7.2013 г. 13:03:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsToHypernyms](
	[WordId] [int] NOT NULL,
	[HypernymId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsToSynonyms]    Script Date: 14.7.2013 г. 13:03:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsToSynonyms](
	[WordId] [int] NOT NULL,
	[SynonymId] [int] NOT NULL,
 CONSTRAINT [PK_WordsToSynonyms] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC,
	[SynonymId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([id])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Languages]
GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Words]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([TranslationId])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words1] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words1]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartsOfSpeach] FOREIGN KEY([PartOfSpeechID])
REFERENCES [dbo].[PartsOfSpeach] ([id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartsOfSpeach]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Words] FOREIGN KEY([AntonymId])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Words]
GO
ALTER TABLE [dbo].[WordsToHypernyms]  WITH CHECK ADD  CONSTRAINT [FK_WordsToHypernyms_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[WordsToHypernyms] CHECK CONSTRAINT [FK_WordsToHypernyms_Words]
GO
ALTER TABLE [dbo].[WordsToHypernyms]  WITH CHECK ADD  CONSTRAINT [FK_WordsToHypernyms_Words1] FOREIGN KEY([HypernymId])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[WordsToHypernyms] CHECK CONSTRAINT [FK_WordsToHypernyms_Words1]
GO
ALTER TABLE [dbo].[WordsToSynonyms]  WITH CHECK ADD  CONSTRAINT [FK_WordsToSynonyms_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[WordsToSynonyms] CHECK CONSTRAINT [FK_WordsToSynonyms_Words]
GO
ALTER TABLE [dbo].[WordsToSynonyms]  WITH CHECK ADD  CONSTRAINT [FK_WordsToSynonyms_Words1] FOREIGN KEY([SynonymId])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[WordsToSynonyms] CHECK CONSTRAINT [FK_WordsToSynonyms_Words1]
GO
USE [master]
GO
ALTER DATABASE [MultilingualDictionaryDB] SET  READ_WRITE 
GO