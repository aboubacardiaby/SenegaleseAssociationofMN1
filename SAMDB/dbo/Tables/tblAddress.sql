CREATE TABLE [dbo].[tblAddress] (
    [AddressID]    INT          IDENTITY (1, 1) NOT NULL,
    [Memberid]     VARCHAR (50) NOT NULL,
    [AddressLine1] NCHAR (100)  NULL,
    [AddressLine2] NCHAR (100)  NULL,
    [City]         NCHAR (100)  NULL,
    [State]        NCHAR (50)   NULL,
    [ZipCode]      NCHAR (100)  NULL,
    [ModifiedDate] DATETIME     NOT NULL,
    CONSTRAINT [PK_tblAddress] PRIMARY KEY CLUSTERED ([AddressID] ASC),
    CONSTRAINT [FK_tblAddress_tblAddress] FOREIGN KEY ([Memberid]) REFERENCES [dbo].[tblMember] ([MemberId]) ON UPDATE CASCADE
);

