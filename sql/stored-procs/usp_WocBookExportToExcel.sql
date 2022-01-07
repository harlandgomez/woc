IF OBJECT_ID('dbo.usp_WocBookExportToExcel') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookExportToExcel
    IF OBJECT_ID('dbo.usp_WocBookExportToExcel') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookExportToExcel >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookExportToExcel >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[usp_WocBookExportToExcel](
@QueryTypeID INT = 1
/* WITH ENCRYPTION */
)
AS
BEGIN
	/*****************************************************************
		Export to Excel QueryTypeID:
		1 - Driver
		2 - Bus
		3 - Agent
		4 - SubCon
		5 - Staff
		6 - Company
		7 - Contract
	******************************************************************/
	
		IF @QueryTypeID = 1 
	BEGIN
		SELECT DriverName As Name
			, FIN AS IC
			, Address1 + ' ' + Address2 + ' ' + Address3 AS [Address]
			, Contact 
			, BusNo AS [Bus No]
			, Passes1 AS [Pass 1]
			, Expiry1 AS [Expiry]
			, Passes2 AS [Pass 2]
			, Expiry2 AS [Expiry]
			, Passes3 AS [Pass 3]
			, Expiry3 AS [Expiry]						
			, Resigned	
			, [Delete]
		FROM Driver
	END
	ELSE IF @QueryTypeID = 2
	BEGIN
		SELECT BusNo AS [Bus No]
			, Seater AS [Seater]
			, Company
			, Brand
			, [Year]  
			, Parking
			, Passes1 AS [Pass 1]
			, Expiry1 AS [Expiry]
			, Passes2 AS [Pass 2]
			, Expiry2 AS [Expiry]
			, Passes3 AS [Pass 3]
			, Expiry3 AS [Expiry]		
			, ScrappedDate [Scrap]
			, [Delete]			
		FROM Bus
	END
	ELSE IF @QueryTypeID = 3
	BEGIN
		SELECT AgentCode AS 'S/N'
			, Agent
			, Prefix
			, [Address]
			, ContactPerson1 AS [Contact1]
			, ContactTelephone1 AS Tel
			, HP1 AS [HP]
			, ContactPerson2 AS [Contact2]
			, ContactTelephone2 AS Tel
			, HP2 AS [HP]
			, StopDate AS [Stop]
			, [Delete]  
		FROM Agent
	END
	ELSE IF @QueryTypeID = 4
	BEGIN
		SELECT
		 Company
		, Person
		, Mobile AS [HP]
		, Telephone AS [Tel]
		, Fax
		, [Address]
		, Remarks 
		, [Delete]		
		 FROM SubCon
	END
	ELSE IF @QueryTypeID = 5
	BEGIN
		SELECT 
			LoginID,
			FirstName as Name,
			NRIC,
			(Address1 + ' ' + Address2  + ' ' + Address3) as [Address],
			Contact,
			DOB,
			[Delete]			
		 FROM Users
	END
	ELSE IF @QueryTypeID = 6
	BEGIN
		SELECT 
			Company,
			[Address],
			Telephone,
			Email,
			Website,
			Prefix,
			GST,
			[Delete]
		 FROM Company
	END
	ELSE IF @QueryTypeID = 7
	BEGIN
		 SELECT A.Prefix AS Pfx
			,	A.Agent 
			,	C.BookingCode AS Ref
			,	CASE C.TripType WHEN '2' THEN C.TripFrom + ' <> ' + C.TripTo ELSE C.TripFrom + ' > ' + C.TripTo END AS [Route] 
			,	C.Seater 
			,	C.StartDate AS [Start Date]
			,	C.StopDate AS [Stop Date]
			,	C.Rates AS [Amount]
			,	CASE C.Mon WHEN 1 THEN 'YES' ELSE 'NO' END AS [Monday]
			,	CASE C.Tue WHEN 1 THEN 'YES' ELSE 'NO' END AS [Tuesday]
			,	CASE C.Wed WHEN 1 THEN 'YES' ELSE 'NO' END AS [Wednesday]
			,	CASE C.Thu WHEN 1 THEN 'YES' ELSE 'NO' END AS [Thursday]
			,	CASE C.Fri WHEN 1 THEN 'YES' ELSE 'NO' END AS [Friday]
			,	CASE C.Sat WHEN 1 THEN 'YES' ELSE 'NO' END AS [Saturday]
			,	CASE C.Sun WHEN 1 THEN 'YES' ELSE 'NO' END AS [Sunday]
			,	C.PoNumber AS [PO No]
		 FROM [Contract] AS C
		 INNER JOIN Agent AS A ON A.AgentID = C.AgentID
	END
	ELSE IF @QueryTypeID = 8
	BEGIN
		SELECT A.AdhocCode AS [Ref No.]
			,	B.Agent
			,	A.AdhocBookDate AS [Depart Date]
			,	A.TimeDepart AS [Start Time]
			,	A.TimeReturn AS [End Time]
			,	CASE A.TripType WHEN 'One Way' THEN A.TripFrom + ' > ' + A.TripTo ELSE A.TripFrom + ' <> ' + A.TripTo END AS Destination 
			,	A.Purpose
			,	A.PersonInCharge AS [Person In Charge]
			,	A.Contact
		FROM Adhoc AS A
		INNER JOIN Agent AS B ON A.AgentID = B.AgentID
	END	
END

GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookExportToExcel') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookExportToExcel >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookExportToExcel >>>'
GO