CREATE TABLE [dbo].[Tickets]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PayPalReference] [nvarchar](max) NULL,
	[DonationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Tickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tickets] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [DonationDate]
GO

