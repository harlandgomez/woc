USE [ANS]
GO

/****** Object:  Table [dbo].[Adhoc]    Script Date: 08/07/2011 21:56:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Adhoc](
	[AdhocID] [uniqueidentifier] NULL,
	[AgentID] [uniqueidentifier] NULL,
	[AdhocBookDate] [datetime] NULL,
	[TripType] [nvarchar](50) NULL,
	[TripFrom] [nvarchar](50) NULL,
	[TripTo] [nvarchar](50) NULL,
	[TimeDepart] [datetime] NULL,
	[TimeReturn] [datetime] NULL,
	[Seater] [bigint] NULL,
	[Purpose] [nvarchar](50) NULL,
	[PersonInCharge] [nvarchar](50) NULL,
	[DriverClaim] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]

GO


