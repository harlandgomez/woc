IF OBJECT_ID('dbo.Company') IS NOT NULL
BEGIN
    DROP TABLE dbo.Company
    IF OBJECT_ID('dbo.Company') IS NOT NULL
        PRINT '<<< FAILED DROPPING TABLE dbo.Company >>>'
    ELSE
        PRINT '<<< DROPPED TABLE dbo.Company >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Company] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Telephone] [nvarchar](15) NULL,
	[Fax] [nvarchar](200) NULL,
	[Email] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[ROC] [nvarchar](50) NULL,
	[Prefix] [nvarchar](50) NULL,
	[GST] [nvarchar](50) NULL,
	[ReflectToOperation] [nvarchar](1) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
	[Delete] [nvarchar](1) NULL,
	[CompanyCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF_Company_Delete]  DEFAULT (N'N') FOR [Delete]
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.Company') IS NOT NULL
    PRINT '<<< CREATED TABLE dbo.Company >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE dbo.Company >>>'
GO