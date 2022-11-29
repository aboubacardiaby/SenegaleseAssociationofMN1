CREATE TABLE [dbo].[tblPhone] (
    [PhoneNumberID] INT          IDENTITY (1, 1) NOT NULL,
    [Memberid]      VARCHAR (50) NOT NULL,
    [PhoneNumber]   NCHAR (100)  NULL,
    [ModifiedDate]  DATETIME     NOT NULL,
    CONSTRAINT [PK_tblPhone] PRIMARY KEY CLUSTERED ([PhoneNumberID] ASC),
    CONSTRAINT [FK_tblPhone_tblMember] FOREIGN KEY ([Memberid]) REFERENCES [dbo].[tblMember] ([MemberId]) ON UPDATE CASCADE
);

