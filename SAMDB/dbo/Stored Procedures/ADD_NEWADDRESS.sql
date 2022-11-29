
CREATE PROCEDURE [dbo].[ADD_NEWADDRESS]
		@Memberid VARCHAR(50),
		@AddressLine1 VARCHAR(100),	
		@AddressLine2 VARCHAR(100),
		@City VARCHAR(100),	
		@State VARCHAR(100),
		@Zipcode VARCHAR(100)
		
AS
BEGIN
INSERT INTO [dbo].[tblAddress]
           ([MEMBERID],
		   [AddressLine1]
           ,[AddressLine2]
           ,[City]
           ,[State]
           ,[ZipCode]
			,[ModifiedDate])
     VALUES
           (@Memberid,
           @AddressLine1
           ,@AddressLine2
           ,@City
           ,@State
           ,@Zipcode
           ,GETDATE())

END

