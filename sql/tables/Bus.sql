IF OBJECT_ID('dbo.Bus') IS NOT NULL
BEGIN
    DROP TABLE dbo.Bus
    IF OBJECT_ID('dbo.Bus') IS NOT NULL
        PRINT '<<< FAILED DROPPING TABLE dbo.Bus >>>'
    ELSE
        PRINT '<<< DROPPED TABLE dbo.Bus >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE TABLE [dbo].[Bus](
	[BusID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[BusNo1] [nvarchar](200) NOT NULL,
	[BusNo2] [nvarchar](200) NOT NULL,
	[BusNo3] [nvarchar](200) NOT NULL,
	[Seater] [int] NULL,
	[Company] [nvarchar](200) NULL,
	[Brand] [nvarchar](50) NULL,
	[Parking] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[BusNo] [nvarchar](50) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[BusCode] [nvarchar](50) NULL,
	[Passes1] [nvarchar](50) NULL,
	[Passes2] [nvarchar](50) NULL,
	[Passes3] [nvarchar](50) NULL,
	[Expiry1] [datetime] NULL,
	[Expiry2] [datetime] NULL,
	[Expiry3] [datetime] NULL,
	[Delete] [nvarchar](50) NULL,
	[Scrapped] [bit] NULL,
	[ScrappedDate] [datetime] NULL,
	[Year] [nvarchar](50) NULL,
	[PlateNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bus] PRIMARY KEY CLUSTERED 
(
	[BusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Bus] ADD  CONSTRAINT [DF_Bus_Scrapped]  DEFAULT ((0)) FOR [Scrapped]
GO



SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.Bus') IS NOT NULL
    PRINT '<<< CREATED TABLE dbo.Bus >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE dbo.Bus >>>'
GO