IF OBJECT_ID('dbo.Subcon') IS NOT NULL
BEGIN
    DROP TABLE dbo.Subcon
    IF OBJECT_ID('dbo.Subcon') IS NOT NULL
        PRINT '<<< FAILED DROPPING TABLE dbo.Subcon >>>'
    ELSE
        PRINT '<<< DROPPED TABLE dbo.Subcon >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subcon](
	[SubconID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[SubconCode] [nvarchar](50) NOT NULL,
	[Company] [nvarchar](100) NOT NULL,
	[Initial] [nvarchar](50) NOT NULL,
	[Person] [nvarchar](200) NOT NULL,
	[Telephone] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[Fax] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Remarks] [nvarchar](200) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
	[Passes1] [nvarchar](50) NULL,
	[Passes2] [nvarchar](50) NULL,
	[Expiry1] [datetime] NULL,
	[Expiry2] [datetime] NULL,
	[Delete] [nvarchar](1) NULL,
 CONSTRAINT [PK_Subcon] PRIMARY KEY CLUSTERED 
(
	[SubconID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Subcon] ADD  CONSTRAINT [DF_Subcon_Delete]  DEFAULT (N'N') FOR [Delete]
GO





SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.Subcon') IS NOT NULL
    PRINT '<<< CREATED TABLE dbo.Subcon >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE dbo.Subcon >>>'
GO