CREATE PROCEDURE [dbo].[ADD_NEWMEMBER]	 
	  @FirstName NVARCHAR(100),
	  @LastName NVARCHAR(100),	  
	  @AddressLine1 VARCHAR(100),	
	  @AddressLine2 VARCHAR(100),
	  @City VARCHAR(100),	
	  @State VARCHAR(100),
	  @Zipcode VARCHAR(100),
	  @PhoneNumber NVARCHAR(100),
	  @EmailAddress NVARCHAR(100),
	  @CreatedBy NVARCHAR(100)
AS
BEGIN
	BEGIN TRANSACTION;
		DECLARE @PhoneNumberID INT,
			  @EmailAddressID INT,
			@MemberId NVARCHAR(100),
			  @AddressID INT
		SET @Memberid =CONCAT(SUBSTRING(@FirstName, 0,3) ,SUBSTRING(@LastName, 0,2),(CAST(RAND(CHECKSUM(NEWID())) * 100 as INT) + 1))  

		INSERT INTO [dbo].[tblMember]
				   ([MemberId]
				   ,[FirstName]
				   ,[LastName]				  
				   ,[CreatedBy]
				   ,[createdDate])
			 VALUES
				   (@MemberId
				   ,@FirstName
				   ,@LastName				   
				   ,@CreatedBy
				   ,GETDATE())
		-- INSERT ADDRESS AND GET ADDRESSID
		 EXEC [dbo].[ADD_NEWADDRESS]@Memberid, @AddressLine1,@AddressLine2,@City,@State,@Zipcode
 
		-- INSERT PHONE NUMBER
		EXEC [DBO].[ADD_NEWPHONE] @Memberid,@PhoneNumber
		-- INSERT NEW E-MAIL ADDRESS
		EXEC [dbo].[ADD_NEWEMAILADDRESS]@Memberid, @EmailAddress
		
	COMMIT TRANSACTION;
END

