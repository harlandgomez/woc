IF OBJECT_ID('dbo.sp_WocBookGSTType') IS NOT NULLഀ
BEGINഀ
    DROP PROCEDURE dbo.sp_WocBookGSTTypeഀ
    IF OBJECT_ID('dbo.sp_WocBookGSTType') IS NOT NULLഀ
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_WocBookGSTType >>>'ഀ
    ELSEഀ
        PRINT '<<< DROPPED PROCEDURE dbo.sp_WocBookGSTType >>>'ഀ
ENDഀ
GOഀ
SET ANSI_NULLS ONഀ
GOഀ
SET QUOTED_IDENTIFIER OFFഀ
GOഀ
ഀ
CREATE PROCEDURE [dbo].[sp_WocBookGSTType]ഀ
/* WITH ENCRYPTION */ഀ
ASഀ
BEGINഀ
ഀ
		ഀ
		SELECT GstTypeCode, ഀ
			[Description]ഀ
		FROM GSTTYPEഀ
		ORDER By SortOrderഀ
		ഀ
ENDഀ
ഀ
GOഀ
SET ANSI_NULLS OFFഀ
GOഀ
SET QUOTED_IDENTIFIER OFFഀ
GOഀ
IF OBJECT_ID('dbo.sp_WocBookGSTType') IS NOT NULLഀ
    PRINT '<<< CREATED PROCEDURE dbo.sp_WocBookGSTType >>>'ഀ
ELSEഀ
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_WocBookGSTType >>>'ഀ
GO