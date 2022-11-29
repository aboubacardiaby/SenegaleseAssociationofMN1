CREATE PROCEDURE [dbo].[ADD_NEWPHONE]
		@Memberid VARCHAR(50),
		@PhoneNumber NVARCHAR(100)
	
AS
BEGIN
INSERT INTO [dbo].[tblPhone]
           ([MEMBERID],
		   [PhoneNumber]
           ,[ModifiedDate])
     VALUES
           (@Memberid,
		   @PhoneNumber
           ,GETDATE())

END

