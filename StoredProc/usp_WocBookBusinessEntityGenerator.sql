IF OBJECT_ID('dbo.usp_WocBookBusinessEntityGenerator') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookBusinessEntityGenerator
    IF OBJECT_ID('dbo.usp_WocBookBusinessEntityGenerator') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookBusinessEntityGenerator >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookBusinessEntityGenerator >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE

PROCEDURE [dbo].[usp_WocBookBusinessEntityGenerator]

@ObjectName

varchar(100)

AS

DECLARE

@name varchar(20),

@type

varchar(20)

DECLARE

objCursor CURSOR

FOR

SELECT

sc.name, st.name type FROM syscolumns sc

INNER

JOIN systypes st

ON

st.xusertype = sc.xusertype

WHERE

Id=OBJECT_ID(@ObjectName)

DECLARE

@declarationCodes varchar(8000),

@ctorCodes

varchar(8000),

@propertyCodes

varchar(8000)

SET

@declarationCodes = ''

SET

@ctorCodes = ''

SET

@propertyCodes = ''

OPEN

objCursor

FETCH

NEXT FROM objCursor

INTO

@name, @type

DECLARE

@cType varchar(20)-- C# type

DECLARE

@ctorParms varchar(4000)

SET

@ctorParms = ''

IF

@@FETCH_STATUS <> 0

BEGIN

CLOSE

objCursor

DEALLOCATE

objCursor

PRINT

'Error... Please check passed parameter'

RETURN

END

WHILE

@@FETCH_STATUS = 0

BEGIN

SET

@cType =

CASE

WHEN

@type LIKE '%char%' OR @type LIKE '%text%'

THEN

'string'

WHEN

@type IN ('decimal', 'numeric')

THEN

'double'

WHEN

@type = 'real'

THEN

'float'

WHEN

@type LIKE '%money%'

THEN

'decimal'

WHEN

@type = 'bit'

THEN

'bool'

WHEN

@type = 'bigint'

THEN

'long'

WHEN

@type LIKE '%int%'

THEN

'int'

WHEN

@type LIKE '%uniqueidentifier%'

THEN

'Guid'

WHEN

@type LIKE '%datetime%'

THEN

'DateTime'

WHEN

@type LIKE '%image%'

THEN

'byte[]'

ELSE

@type

END

--PRINT CHAR(9) + 'private ' + @ctype + ' ' + 'm_' + @name + ';'

SET

@declarationCodes = @declarationCodes + CHAR(9) + 'private ' + @ctype + ' ' + 'm_' + @name + ';' + CHAR(13)

SET

@ctorCodes = @ctorCodes + CHAR(9) + CHAR(9) + 'm_' + @name + ' = ' + LOWER(LEFT(@name, 1)) + SUBSTRING(@name, 2, LEN(@name)) + ';' + CHAR(13)

SET

@ctorParms = @ctorParms + @ctype + ' ' + LOWER(LEFT(@name, 1)) + SUBSTRING(@name, 2, LEN(@name)) + ', '

SET

@propertyCodes = @propertyCodes + CHAR(9) + 'public ' + @ctype + ' ' + @name + CHAR(13) +

CHAR

(9) + '{' + CHAR(13) +

CHAR

(9) + CHAR(9) + 'get { return m_' + @name + '; }' + CHAR(13) +

CHAR

(9) + CHAR(9) + 'set { m_' + @name + ' = value; }' + CHAR(13) +

CHAR

(9) + '}' + CHAR(13)

FETCH

NEXT FROM objCursor

INTO

@name, @type

END

PRINT

'[Serializable]'

PRINT

'public class ' + @ObjectName + 's'

PRINT

'{'

PRINT

@declarationCodes

PRINT

''

PRINT

CHAR(9) + 'public ' + @ObjectName + 's(' + LEFT(@ctorParms, LEN(@ctorParms) - 1) + ')'

PRINT

CHAR(9) + '{'

PRINT

@ctorCodes

PRINT

CHAR(9) + '}'

PRINT

''

PRINT

@propertyCodes

PRINT

'}'

CLOSE

objCursor

DEALLOCATE

objCursor

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookBusinessEntityGenerator') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookBusinessEntityGenerator >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookBusinessEntityGenerator >>>'
GO