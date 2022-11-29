CREATE TABLE [dbo].[UserProfile] (
    [UserId]    INT            IDENTITY (1, 1) NOT NULL,
    [UserName]  NVARCHAR (MAX) NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    [Address]   NVARCHAR (MAX) NULL,
    [City]      NVARCHAR (MAX) NULL,
    [State]     NCHAR (10)     NULL,
    [ZipCode]   NCHAR (10)     NULL,
    [Phone]     NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

