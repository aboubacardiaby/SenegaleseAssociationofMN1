
CREATE PROCEDURE [dbo].[ADD_NEWEMAILADDRESS]
		@Memberid VARCHAR(100),		
		@EmailAddress NVARCHAR(100)
		

AS
BEGIN
INSERT INTO [dbo].[EmailAddress]
           ([Memberid]
           ,[EmailAddress]
           ,[ModifiedDate])
     VALUES
           (@Memberid
           ,@EmailAddress
           ,GETDATE())
END


