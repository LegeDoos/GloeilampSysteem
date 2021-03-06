USE [master]
GO
/****** Object:  Database [GloeilampSysteem]    Script Date: 6-4-2022 08:48:20 ******/
CREATE DATABASE [GloeilampSysteem]
GO
USE [GloeilampSysteem]
GO
/****** Object:  Table [dbo].[Lamp]    Script Date: 6-4-2022 08:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lamp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[IsOn] [int] NOT NULL,
	[State] [varchar](50) NULL,
	[LightSwitchId] [int] NULL,
 CONSTRAINT [PK_Lamp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LightSwitch]    Script Date: 6-4-2022 08:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LightSwitch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[IsOn] [int] NULL,
 CONSTRAINT [PK_LightSwitch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Lamp]  WITH CHECK ADD  CONSTRAINT [FK_Lamp_LightSwitch] FOREIGN KEY([LightSwitchId])
REFERENCES [dbo].[LightSwitch] ([Id])
GO
ALTER TABLE [dbo].[Lamp] CHECK CONSTRAINT [FK_Lamp_LightSwitch]
GO
USE [master]
GO
ALTER DATABASE [GloeilampSysteem] SET  READ_WRITE 
GO
