USE [ANS]
GO

/****** Object:  Table [dbo].[ContractSchedule]    Script Date: 08/07/2011 09:21:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
DROP TABLE [dbo].[ContractSchedule]
CREATE TABLE [dbo].[ContractSchedule](
	[ContractScheduleID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ContractID] [uniqueidentifier] NOT NULL,
	[ScheduleDate] [datetime] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL
 CONSTRAINT [PK_ContractSchedule] PRIMARY KEY CLUSTERED 
(
	[ContractScheduleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



