USE [master]
GO
/****** Object:  Database [military_district]    Script Date: 10.05.2024 0:26:54 ******/
CREATE DATABASE [military_district]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'military_district', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\military_district.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'military_district_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\military_district_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [military_district] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [military_district].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [military_district] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [military_district] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [military_district] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [military_district] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [military_district] SET ARITHABORT OFF 
GO
ALTER DATABASE [military_district] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [military_district] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [military_district] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [military_district] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [military_district] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [military_district] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [military_district] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [military_district] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [military_district] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [military_district] SET  DISABLE_BROKER 
GO
ALTER DATABASE [military_district] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [military_district] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [military_district] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [military_district] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [military_district] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [military_district] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [military_district] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [military_district] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [military_district] SET  MULTI_USER 
GO
ALTER DATABASE [military_district] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [military_district] SET DB_CHAINING OFF 
GO
ALTER DATABASE [military_district] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [military_district] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [military_district] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [military_district] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [military_district] SET QUERY_STORE = OFF
GO
USE [military_district]
GO
/****** Object:  Table [dbo].[companies]    Script Date: 10.05.2024 0:26:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companies](
	[Id_companies] [int] NOT NULL,
	[Name_companies] [varchar](max) NULL,
	[Commander] [varchar](max) NULL,
	[Type_of_troops] [int] NULL,
	[Date_foundation] [datetime] NULL,
	[Date_update_information] [datetime] NULL,
 CONSTRAINT [PK_companies] PRIMARY KEY CLUSTERED 
(
	[Id_companies] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[country]    Script Date: 10.05.2024 0:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 10.05.2024 0:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[locations](
	[Id_locations] [int] NOT NULL,
	[Country] [int] NULL,
	[City] [varchar](max) NULL,
	[Address] [varchar](max) NULL,
	[Square] [int] NULL,
	[Count_structures] [int] NULL,
 CONSTRAINT [PK_locations] PRIMARY KEY CLUSTERED 
(
	[Id_locations] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parts]    Script Date: 10.05.2024 0:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parts](
	[Id_part] [int] NOT NULL,
	[Locations] [int] NULL,
	[Companies] [int] NULL,
	[Date_of_foundation] [datetime] NULL,
 CONSTRAINT [PK_Parts] PRIMARY KEY CLUSTERED 
(
	[Id_part] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[technique]    Script Date: 10.05.2024 0:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[technique](
	[Id_technique] [int] NOT NULL,
	[Name_technique] [varchar](max) NULL,
	[Companies] [int] NULL,
	[Characteristics] [varchar](max) NULL,
 CONSTRAINT [PK_Technique] PRIMARY KEY CLUSTERED 
(
	[Id_technique] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type_of_troops]    Script Date: 10.05.2024 0:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type_of_troops](
	[Id_type_of_troops] [int] NOT NULL,
	[Name_type_of_troops] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[Count_serviceman] [int] NULL,
	[Date_foundation] [datetime] NULL,
 CONSTRAINT [PK_type_of_troops_1] PRIMARY KEY CLUSTERED 
(
	[Id_type_of_troops] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 10.05.2024 0:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[Id] [int] NULL,
	[Login] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Role] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[weapons]    Script Date: 10.05.2024 0:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[weapons](
	[Id_weapons] [int] NOT NULL,
	[Name_weapons] [varchar](max) NULL,
	[Companies] [int] NULL,
	[Description] [varchar](max) NULL,
	[Date_update_information] [datetime] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id_weapons] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[companies]  WITH CHECK ADD  CONSTRAINT [FK_companies_type_of_troops] FOREIGN KEY([Type_of_troops])
REFERENCES [dbo].[type_of_troops] ([Id_type_of_troops])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[companies] CHECK CONSTRAINT [FK_companies_type_of_troops]
GO
ALTER TABLE [dbo].[locations]  WITH CHECK ADD  CONSTRAINT [FK_locations_locations] FOREIGN KEY([Country])
REFERENCES [dbo].[country] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[locations] CHECK CONSTRAINT [FK_locations_locations]
GO
ALTER TABLE [dbo].[parts]  WITH CHECK ADD  CONSTRAINT [FK_parts_companies] FOREIGN KEY([Companies])
REFERENCES [dbo].[companies] ([Id_companies])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[parts] CHECK CONSTRAINT [FK_parts_companies]
GO
ALTER TABLE [dbo].[parts]  WITH CHECK ADD  CONSTRAINT [FK_parts_locations] FOREIGN KEY([Locations])
REFERENCES [dbo].[locations] ([Id_locations])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[parts] CHECK CONSTRAINT [FK_parts_locations]
GO
ALTER TABLE [dbo].[technique]  WITH CHECK ADD  CONSTRAINT [FK_technique_companies] FOREIGN KEY([Companies])
REFERENCES [dbo].[companies] ([Id_companies])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[technique] CHECK CONSTRAINT [FK_technique_companies]
GO
ALTER TABLE [dbo].[weapons]  WITH CHECK ADD  CONSTRAINT [FK_weapons_companies] FOREIGN KEY([Companies])
REFERENCES [dbo].[companies] ([Id_companies])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[weapons] CHECK CONSTRAINT [FK_weapons_companies]
GO
USE [master]
GO
ALTER DATABASE [military_district] SET  READ_WRITE 
GO
