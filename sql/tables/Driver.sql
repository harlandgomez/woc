IF OBJECT_ID('dbo.Driver') IS NOT NULL
BEGIN
    DROP TABLE dbo.Driver
    IF OBJECT_ID('dbo.Driver') IS NOT NULL
        PRINT '<<< FAILED DROPPING TABLE dbo.Driver >>>'
    ELSE
        PRINT '<<< DROPPED TABLE dbo.Driver >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE TABLE [dbo].[Driver](
	[DriverID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DriverName] [nvarchar](50) NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[Address3] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NULL,
	[DateJoin] [datetime] NULL,
	[CountryID] [uniqueidentifier] NOT NULL,
	[BusNo] [nvarchar](50) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[FIN] [nvarchar](50) NULL,
	[DOB] [nvarchar](50) NULL,
	[DriverCode] [nvarchar](50) NULL,
	[Delete] [nvarchar](50) NULL,
	[Passes1] [nvarchar](50) NULL,
	[Passes2] [nvarchar](50) NULL,
	[Passes3] [nvarchar](50) NULL,
	[Expiry1] [datetime] NULL,
	[Expiry2] [datetime] NULL,
	[Expiry3] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[Resigned] [bit] NULL,
	[ResignedDate] [datetime] NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[DriverID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Driver] ADD  CONSTRAINT [DF_Driver_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.Driver') IS NOT NULL
    PRINT '<<< CREATED TABLE dbo.Driver >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE dbo.Driver >>>'
GO