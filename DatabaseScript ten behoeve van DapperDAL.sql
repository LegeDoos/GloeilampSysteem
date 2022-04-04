USE [master]
GO
/****** Object:  Database [RobsHouseLightning]    Script Date: 25-3-2022 09:57:15 ******/
CREATE DATABASE [RobsHouseLightning]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RobsHouseLightning', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\RobsHouseLightning.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RobsHouseLightning_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\RobsHouseLightning_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RobsHouseLightning] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RobsHouseLightning].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RobsHouseLightning] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET ARITHABORT OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RobsHouseLightning] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RobsHouseLightning] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RobsHouseLightning] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RobsHouseLightning] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RobsHouseLightning] SET  MULTI_USER 
GO
ALTER DATABASE [RobsHouseLightning] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RobsHouseLightning] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RobsHouseLightning] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RobsHouseLightning] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RobsHouseLightning] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RobsHouseLightning] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RobsHouseLightning] SET QUERY_STORE = OFF
GO
USE [RobsHouseLightning]
GO
/****** Object:  User [Party]    Script Date: 25-3-2022 09:57:15 ******/
CREATE USER [Party] FOR LOGIN [Party] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Party]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Party]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Party]
GO
/****** Object:  Table [dbo].[LAMP]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LAMP](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[isOn] [bit] NULL,
	[state] [varchar](10) NULL,
	[frequency] [int] NULL,
	[lightswitchid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIGHTSWITCH]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIGHTSWITCH](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[isOn] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LAMP]  WITH CHECK ADD FOREIGN KEY([lightswitchid])
REFERENCES [dbo].[LIGHTSWITCH] ([id])
GO
/****** Object:  StoredProcedure [dbo].[DeleteLamp]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	Delete Lamp by ID
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLamp] 
	@LampId int
AS
BEGIN	
	
	DELETE FROM LAMP where id = @LampId
	    	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteLightSwitch]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	DELETE LightSwitch by ID
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLightSwitch]
	@Id int

AS
BEGIN	
	
	DELETE FROM LIGHTSWITCH 	
	WHERE id = @Id
	    	
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllLightSwitches]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	SELECT all LightSwitches
-- =============================================
CREATE PROCEDURE [dbo].[GetAllLightSwitches]	

AS
BEGIN	
	
	SELECT * FROM LIGHTSWITCH 		
	    	
END
GO
/****** Object:  StoredProcedure [dbo].[GetLampById]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	Get Lamp by ID
-- =============================================
CREATE PROCEDURE [dbo].[GetLampById] 
	@LampId int
AS
BEGIN	
	
	SELECT * FROM LAMP where id = @LampId
	    	
END
GO
/****** Object:  StoredProcedure [dbo].[GetLampsForLightSwitches]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	Get Lamps for LightSwitch
-- =============================================
CREATE PROCEDURE [dbo].[GetLampsForLightSwitches]
	@LSId int		
AS
BEGIN	
	
	SELECT * FROM LAMP WHERE lightswitchid = @LSId
	    	
END
GO
/****** Object:  StoredProcedure [dbo].[GetLightSwitchById]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	SELECT LightSwitch by ID
-- =============================================
CREATE PROCEDURE [dbo].[GetLightSwitchById]
	@LightSwitchId int

AS
BEGIN	
	
	SELECT * FROM LIGHTSWITCH WHERE id = @LightSwitchId
	    	
END
GO
/****** Object:  StoredProcedure [dbo].[InsertLightSwitch]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	INSERT NEW Lamp
-- =============================================
CREATE PROCEDURE [dbo].[InsertLightSwitch]
	@LampId int,
	@Name varchar(50),
	@IsOn bit
AS
BEGIN	
	
	INSERT INTO lightsWitch (id,[name],ison) VALUES(@LampId, @Name, @IsOn)
	    	
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLamp]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	Update Lamp by ID
-- =============================================
CREATE PROCEDURE [dbo].[UpdateLamp] 
	@LampId int,
	@IsOn bit,
	@State varchar(10)
AS
BEGIN	
	
	UPDATE LAMP 
	SET ison = @IsOn,
		[state] = @State
	where id = @LampId
	    	
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLightSwitch]    Script Date: 25-3-2022 09:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	UPDATE LightSwitch by ID
-- =============================================
CREATE PROCEDURE [dbo].[UpdateLightSwitch]
	@LightSwitchId int,
	@IsOn bit

AS
BEGIN	
	
	UPDATE LIGHTSWITCH 
	SET ison = @IsOn
	WHERE id = @LightSwitchId
	    	
END
GO
USE [master]
GO
ALTER DATABASE [RobsHouseLightning] SET  READ_WRITE 
GO
