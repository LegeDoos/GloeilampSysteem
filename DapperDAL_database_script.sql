USE [RobsHouseLightning]
GO
/****** Object:  Table [dbo].[LAMP]    Script Date: 8-4-2022 09:47:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LAMP](
	[id] [int] Identity(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[LIGHTSWITCH]    Script Date: 8-4-2022 09:47:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIGHTSWITCH](
	[id] [int]  Identity(1,1) NOT NULL,
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
/****** Object:  StoredProcedure [dbo].[DeleteLamp]    Script Date: 8-4-2022 09:47:13 ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteLightSwitch]    Script Date: 8-4-2022 09:47:13 ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllLightSwitches]    Script Date: 8-4-2022 09:47:13 ******/
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
/****** Object:  StoredProcedure [dbo].[GetLampById]    Script Date: 8-4-2022 09:47:13 ******/
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
/****** Object:  StoredProcedure [dbo].[GetLampsForLightSwitches]    Script Date: 8-4-2022 09:47:13 ******/
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
/****** Object:  StoredProcedure [dbo].[GetLightSwitchById]    Script Date: 8-4-2022 09:47:13 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertLampsOfLightSwitch]    Script Date: 8-4-2022 09:47:13 ******/
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
	/* without Identity
	Select @Lid = max(id)+1 from LAMP	
	INSERT INTO LAMP (id,[name],ison,lightswitchid, [state]) VALUES(@Lid, @Name, @IsOn, @LSId ,'uit')
	return @Lid  
	*/
	--whith identity
	INSERT INTO LAMP ([name],ison,lightswitchid, [state]) VALUES(@Name, @IsOn, @LSId ,'uit')
	select @Lid = SCOPE_IDENTITY()
	RETURN @Lid
	
END
GO
/****** Object:  StoredProcedure [dbo].[InsertLightSwitch]    Script Date: 8-4-2022 09:47:13 ******/
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
	/* without Identity
	Select @id = max(id)+1 from LIGHTSWITCH	
	INSERT INTO lightsWitch (id,[name],ison) VALUES(@id, @Name, @IsOn)
	Return @id
	*/
	--whith identity
	INSERT INTO lightsWitch ([name],ison) VALUES(@Name, @IsOn)
	select @id = SCOPE_IDENTITY()
	RETURN @id
	
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLamp]    Script Date: 8-4-2022 09:47:13 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateLightSwitch]    Script Date: 8-4-2022 09:47:13 ******/
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

-- =======================================================
-- Author:		Bob Tossaint
-- Create date: 20220414
-- Description:	INSERT NEW Lamp 
-- =======================================================
ALTER PROCEDURE [dbo].[InsertLamp]	
	@Name varchar(50),
	@IsOn bit,
	@LSid int,
	@Lid int OUTPUT
AS
BEGIN	

	INSERT INTO LAMP ([name],ison, lightswitchid, [state]) VALUES(@Name, @IsOn, @LSid, 'uit')
	select @Lid = SCOPE_IDENTITY()
	RETURN @Lid
	
END
