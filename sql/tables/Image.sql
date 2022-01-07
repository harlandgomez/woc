USE [ANS]
GO

/****** Object:  Table [dbo].[Image]    Script Date: 10/23/2011 09:01:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Image](
	[ImageID] [uniqueidentifier] NOT NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[ImageFile] [image] NOT NULL,
	[ContentType] [nvarchar](200) NOT NULL,
	[Filesize] [int] NOT NULL,
	[CompanyID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


