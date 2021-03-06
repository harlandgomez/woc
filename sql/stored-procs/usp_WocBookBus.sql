USE [ANS]
GO
/****** Object:  StoredProcedure [dbo].[usp_WocBookBus]    Script Date: 07/21/2011 15:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

ALTER

PROCEDURE [dbo].[usp_WocBookBus]
(
@BusCode NVARCHAR(50),
@Brand NVARCHAR(50),
@Parking NVARCHAR(50),
@BusNo NVARCHAR(50),
@Year NVARCHAR(50),
@BusNo1 NVARCHAR(200),
@BusNo2 NVARCHAR(200),
@BusNo3 NVARCHAR(200),
@Company NVARCHAR(200),
@Seater int,
@Type NVARCHAR(50),
@CreatedBy uniqueidentifier,	
@CreatedDate DATETIME,
@UpdatedBy	uniqueidentifier,
@UpdatedDate DATETIME,
@Passes1 NVARCHAR(50),
@Passes2 NVARCHAR(50),
@Passes3 NVARCHAR(50),
@Expiry1 DATETIME,
@Expiry2 DATETIME,
@Expiry3 DATETIME,
@Delete NVARCHAR(50),
@Scrapped bit,
@ScrappedDate DATETIME = '1/1/1753 12:00:00 AM',
@SubconInitial NVARCHAR(50) = NULL,
@QueryTypeID INT
)
AS

BEGIN

IF @QueryTypeID = 1
BEGIN 

	INSERT INTO Bus
       (	BusID,
			BusNo1,
			BusNo2,
			BusNo3,
			Seater,
			[Year],
			Company,
			Brand,
			[Type],
			BusNo,
			CreatedBy,
			CreatedDate,
			UpdatedBy,
			UpdatedDate,
			BusCode,
			Parking,
			Passes1,
			Passes2,
			Passes3,
			Expiry1,
			Expiry2,
			Expiry3,
			Scrapped,
			SubconInitial
		)
     VALUES
		(	newid(),
			@BusNo1,
			@BusNo2,
			@BusNo3,
			@Seater,
			@Year,
			@Company,
			@Brand,
			@Type,
			@BusNo,
			@CreatedBy,
			@CreatedDate,
			@UpdatedBy,
			@UpdatedDate,
			@BusCode,
			@Parking,
			@Passes1,
			@Passes2,
			@Passes3,
			@Expiry1,
			@Expiry2,
			@Expiry3,
			@Scrapped,
			@SubconInitial
		)
	
END 

IF @QueryTypeID = 2
BEGIN
	UPDATE Bus
		SET 
		
	    BusNo1 = @BusNo1,
		BusNo2 = @BusNo2, 
		BusNo3  = @BusNo3,
		Seater = @Seater,
		Company = @Company,
		Brand = @Brand,
		Parking = @Parking,
		[Type] =  @Type,
		BusNo = @BusNo,
	    UpdatedBy = @UpdatedBy,
		UpdatedDate = @UpdatedDate,
	    Passes1 = @Passes1,
		Passes2 = @Passes2,
		Passes3 = @Passes3,
		Expiry1 = @Expiry1,
		Expiry2 = @Expiry2,
		Expiry3 = @Expiry3,
		Scrapped = @Scrapped,
		ScrappedDate = @ScrappedDate,
		SubconInitial = @SubconInitial,
		[Year] = @Year		
		
	WHERE BusCode = @BusCode
END

IF @QueryTypeID = 3
BEGIN 
	UPDATE Bus
	SET [Delete] = 'Y',
	UpdatedBy =@UpdatedBy,
	CreatedDate = getdate(),
	UpdatedDate = getDate()
	WHERE BusCode=@BusCode;
END

END


