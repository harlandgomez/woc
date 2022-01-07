USE [ANS]
GO

/****** Object:  Table [dbo].[Contract]    Script Date: 08/07/2011 10:24:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Contract]

CREATE TABLE [dbo].[Contract](
	[ContractID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[BookingCode] [nvarchar](200) NOT NULL,
	[PONumber] [nvarchar](50) NOT NULL,
	[AgentID] [uniqueidentifier] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[StopDate] [datetime] NOT NULL,
	[TripType] [nvarchar](200) NULL,
	[TripFrom] [nvarchar](200) NULL,
	[TripTo] [nvarchar](200) NULL,
	[Seater] [int] NULL,
	[InvoiceText] [nvarchar](250) NULL,
	[PersonInCharge] [nvarchar](15) NULL,
	[Contact] [nvarchar](15) NULL,
	[RatesType] [nvarchar](5) NOT NULL,
	[Rates] [money] NULL,
	[Remarks1] [nvarchar](15) NULL,
	[Remarks2] [nvarchar](15) NULL,
	[DriverClaim] [nvarchar](15) NULL,
	[GST] [nvarchar](15) NULL,
	[Mon] [bit] NOT NULL,
	[Tue] [bit] NOT NULL,
	[Wed] [bit] NOT NULL,
	[Thu] [bit] NOT NULL,
	[Fri] [bit] NOT NULL,
	[Sat] [bit] NOT NULL,
	[Sun] [bit] NOT NULL,
	[StartMon] [nvarchar](10) NULL,
	[StartTue] [nvarchar](10) NULL,
	[StartWed] [nvarchar](10) NULL,
	[StartThu] [nvarchar](10) NULL,
	[StartFri] [nvarchar](10) NULL,
	[StartSat] [nvarchar](10) NULL,
	[StartSun] [nvarchar](10) NULL,
	[EndMon] [nvarchar](10) NULL,
	[EndTue] [nvarchar](10) NULL,
	[EndWed] [nvarchar](10) NULL,
	[EndThu] [nvarchar](10) NULL,
	[EndFri] [nvarchar](10) NULL,
	[EndSat] [nvarchar](10) NULL,
	[EndSun] [nvarchar](10) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
	[Delete] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Mon]  DEFAULT ((0)) FOR [Mon]
GO

ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Tue]  DEFAULT ((0)) FOR [Tue]
GO

ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Wed]  DEFAULT ((0)) FOR [Wed]
GO

ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Thu]  DEFAULT ((0)) FOR [Thu]
GO

ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Fri]  DEFAULT ((0)) FOR [Fri]
GO

ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Sat]  DEFAULT ((0)) FOR [Sat]
GO

ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Sun]  DEFAULT ((0)) FOR [Sun]
GO

ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Delete]  DEFAULT (N'N') FOR [Delete]
GO