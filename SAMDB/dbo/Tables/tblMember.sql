CREATE TABLE [dbo].[tblMember] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [MemberId]    VARCHAR (50) NOT NULL,
    [FirstName]   NCHAR (100)  NOT NULL,
    [LastName]    NCHAR (100)  NOT NULL,
    [CreatedBy]   NCHAR (70)   NULL,
    [createdDate] DATETIME     NOT NULL,
    CONSTRAINT [PK_tblMember] PRIMARY KEY CLUSTERED ([MemberId] ASC)
);

