IF OBJECT_ID('dbo.Sequence') IS NOT NULL
BEGIN
    DROP TABLE dbo.Sequence
    IF OBJECT_ID('dbo.Sequence') IS NOT NULL
        PRINT '<<< FAILED DROPPING TABLE dbo.Sequence >>>'
    ELSE
        PRINT '<<< DROPPED TABLE dbo.Sequence >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE TABLE [dbo].[Sequence](
	[SequenceID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[SequenceCount] [nvarchar](50) NOT NULL,
	[ColumnCode] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](50) NULL,
	[Postfix] [nvarchar](50) NULL,
 CONSTRAINT [PK_MaxCode_1] PRIMARY KEY CLUSTERED 
(
	[SequenceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Sequence] ADD  CONSTRAINT [DF_MaxCode_SequenceID]  DEFAULT (newid()) FOR [SequenceID]
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.Sequence') IS NOT NULL
    PRINT '<<< CREATED TABLE dbo.Sequence >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE dbo.Sequence >>>'
GO