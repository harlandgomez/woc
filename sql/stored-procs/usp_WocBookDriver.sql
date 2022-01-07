USE [ANS]
GO

/****** Object:  StoredProcedure [dbo].[sp_WocBookDriver]    Script Date: 07/23/2011 09:42:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE

PROCEDURE [dbo].[sp_WocBookDriver](
@DriverCode NVARCHAR(50),
@DriverName NVARCHAR(50),
@Address1 NVARCHAR(50),
@Address2 NVARCHAR(50),
@Address3 NVARCHAR(50),
@Contact NVARCHAR(50),
@DateJoin DateTime,
@CountryID UNIQUEIDENTIFIER,
@BusNo NVARCHAR(50),
@CreatedBy UNIQUEIDENTIFIER,
@CreatedDate DateTime,
@UpdatedBy UNIQUEIDENTIFIER,
@UpdatedDate DateTime,
@FIN NVARCHAR(50),
@DOB NVARCHAR(50),
@Delete  NVARCHAR(50),
@Passes1 NVARCHAR(50),
@Passes2 NVARCHAR(50),
@Passes3 NVARCHAR(50),
@Expiry1 DateTime,
@Expiry2 DateTime,
@Expiry3 DateTime,
@Resigned bit,
@ResignedDate DateTime,
@QueryTypeID INT
)
AS

BEGIN

IF @QueryTypeID = 1
BEGIN 

	INSERT INTO Driver
       (	DriverID,
			DriverName,
			Address1,
			Address2,
			Address3,
			Contact,
			DateJoin,
			CountryID,
			BusNo,
			CreatedBy,
			CreatedDate,
			FIN,
			DOB,
			DriverCode,
			[Delete],
			Passes1,
			Passes2,
			Passes3,
			Expiry1,
			Expiry2,
			Expiry3
		)
     VALUES
		(	newid(),
			@DriverName,
			@Address1,
			@Address2,
			@Address3,
			@Contact,
			@DateJoin,
			@CountryID,
			@BusNo,
			@CreatedBy,
			@CreatedDate,
		    @FIN,
			@DOB,
			@DriverCode,
			@Delete,
			@Passes1,
			@Passes2,
			@Passes3,
			@Expiry1,
			@Expiry2,
			@Expiry3
			
		)
	
END 

IF @QueryTypeID = 2
BEGIN
	UPDATE Driver
		SET 
			DriverName = @DriverName,
			Address1 = @Address1,
			Address2 = @Address2,
			Address3 = @Address3,
			Contact = @Contact,
			DateJoin = @DateJoin,
			CountryID = @CountryID,
			BusNo = @BusNo,
			FIN = @FIN,
			DOB =@DOB,
			DriverCode =@DriverCode,
			Passes1 = @Passes1,
			Passes2 = @Passes2,
			Passes3 = @Passes3,
			Expiry1 = @Expiry1,
			Expiry2 = @Expiry2,
			Expiry3 = @Expiry3,
			UpdatedBy = @UpdatedBy,
			UpdatedDate = getDate(),
			Resigned  =  @Resigned,
			ResignedDate = @ResignedDate
			
			
	WHERE DriverCode=@DriverCode
END

IF @QueryTypeID = 3
BEGIN 
	UPDATE Driver
	SET [Delete] = 'Y',
	CreatedBy = @CreatedBy,
	UpdatedBy =@UpdatedBy,
	CreatedDate = getdate(),
	UpdatedDate = getDate()
	WHERE DriverCode=@DriverCode;
END

END



GO


