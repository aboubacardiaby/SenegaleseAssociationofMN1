CREATE TABLE [dbo].[EmailAddress] (
    [EmailAddressID] INT          IDENTITY (1, 1) NOT NULL,
    [Memberid]       VARCHAR (50) NOT NULL,
    [EmailAddress]   NCHAR (100)  NULL,
    [ModifiedDate]   DATETIME     NULL,
    CONSTRAINT [PK_EmailAddress] PRIMARY KEY CLUSTERED ([EmailAddressID] ASC),
    CONSTRAINT [FK_EmailAddress_tblMember] FOREIGN KEY ([Memberid]) REFERENCES [dbo].[tblMember] ([MemberId]) ON UPDATE CASCADE
);

