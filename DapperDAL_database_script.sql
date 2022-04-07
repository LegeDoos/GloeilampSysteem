USE [master]
GO
/****** Object:  Database [RobsHouseLightning]    Script Date: 7-4-2022 10:59:39 ******/
CREATE DATABASE [RobsHouseLightning]
 
USE [RobsHouseLightning]
GO
/****** Object:  User [Party]    Script Date: 7-4-2022 10:59:39 ******/
CREATE USER [Party] FOR LOGIN [Party] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Party]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Party]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Party]
GO
/****** Object:  Table [dbo].[LAMP]    Script Date: 7-4-2022 10:59:39 ******/
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
/****** Object:  Table [dbo].[LIGHTSWITCH]    Script Date: 7-4-2022 10:59:39 ******/
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

// insert data
insert into LIGHTSWITCH
values(1,'schakelaar woonkamer',0),
(2,'schakelaar keuken',0),
(3,'schakelaar gang',0),
(4,'schakelaar garage',0)

insert into LAMP
values (1,'philips',0,'uit',60,1),
(2,'philips',0,'uit',60,1),
(3,'philips',0,'uit',60,1),
(4,'philips',0,'uit',80,2),
(5,'philips',0,'uit',90,3),
(6,'osram',0,'uit',100,4)

/****** Object:  StoredProcedure [dbo].[DeleteLamp]    Script Date: 7-4-2022 10:59:39 ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteLightSwitch]    Script Date: 7-4-2022 10:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	DELETE LightSwitch by ID and Disconnect LAMPS
-- ==========================================================
CREATE PROCEDURE [dbo].[DeleteLightSwitch]
	@Id int

AS
BEGIN	
	-- lampen worden niet automatisch verwijderd als de schakelaar wordt verwijderd
	/*
	UPDATE LAMP
	set lightswitchid = null,
		isOn = 0,
		[state] = 'uit'
	where lightswitchid = @Id
	*/

	-- lampen worden ook automatisch verwijderd als de schakelaar wordt verwijderd	
	Delete from LAMP
	where lightswitchid = @Id

	DELETE FROM LIGHTSWITCH 	
	WHERE id = @Id
    	
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllLightSwitches]    Script Date: 7-4-2022 10:59:39 ******/
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
/****** Object:  StoredProcedure [dbo].[GetLampById]    Script Date: 7-4-2022 10:59:39 ******/
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
/****** Object:  StoredProcedure [dbo].[GetLampsForLightSwitches]    Script Date: 7-4-2022 10:59:39 ******/
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
/****** Object:  StoredProcedure [dbo].[GetLightSwitchById]    Script Date: 7-4-2022 10:59:39 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertLampsOfLightSwitch]    Script Date: 7-4-2022 10:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	INSERT NEW Lamp and connect to lightswitch
-- =======================================================
CREATE PROCEDURE [dbo].[InsertLampsOfLightSwitch]
	@LSId int,
	@Name varchar(50),
	@IsOn bit,
	@Lid int OUTPUT
AS
BEGIN	

	Select @Lid = max(id)+1 from LAMP	
	INSERT INTO LAMP (id,[name],ison,lightswitchid, [state]) VALUES(@Lid, @Name, @IsOn, @LSId ,'uit')
	
	return @Lid    	
END
GO
/****** Object:  StoredProcedure [dbo].[InsertLightSwitch]    Script Date: 7-4-2022 10:59:39 ******/
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
	@Name varchar(50),
	@IsOn bit,
	@id int OUTPUT
AS
BEGIN	

	Select @id = max(id)+1 from LIGHTSWITCH	
	INSERT INTO lightsWitch (id,[name],ison) VALUES(@id, @Name, @IsOn)
	Return @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLamp]    Script Date: 7-4-2022 10:59:39 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateLightSwitch]    Script Date: 7-4-2022 10:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ============================================================
-- Author:		Bob Tossaint
-- Create date: 20220325
-- Description:	UPDATE LightSwitch by ID And the Included Lamps
-- ============================================================
CREATE PROCEDURE [dbo].[UpdateLightSwitch]
	@LightSwitchId int,
	@IsOn bit

AS
BEGIN	
	declare @status varchar(3)
	select @status = 'uit'
	
	IF @IsOn = 1
    BEGIN
        select @status = 'aan'
    END

	
	UPDATE LIGHTSWITCH 
	SET ison = @IsOn		
	WHERE id = @LightSwitchId

	UPDATE LAMP
	SET isOn = @IsOn,
		[state] = @status
	WHERE lightswitchid = @LightSwitchId
	    	
END
GO
USE [master]
GO
ALTER DATABASE [RobsHouseLightning] SET  READ_WRITE 
GO
