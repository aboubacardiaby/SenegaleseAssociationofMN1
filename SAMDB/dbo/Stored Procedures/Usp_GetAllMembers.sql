-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Usp_GetAllMembers
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT m.[MemberId]
      ,[FirstName]
      ,[LastName]
	  , a.[AddressLine1]
      ,a.[AddressLine2]
      ,a.[City]
      ,a.[State]
      ,a.[ZipCode]
	  ,p.PhoneNumber
	  ,e.EmailAddress 
  FROM [SAMDB].[dbo].[tblMember] m
  left JOIN [SAMDB].[dbo].tblAddress a ON m.MemberId =a.Memberid
  left JOIN [SAMDB].[dbo].EmailAddress e ON m.MemberId =e.Memberid
  left JOIN [SAMDB].[dbo].tblPhone P ON m.MemberId =p.Memberid
END
