CREATE TABLE [dbo].[Experience]
(
	[Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[Title] VARCHAR(200) NOT NULL,
	[Description] NVARCHAR(2000) NOT NULL,
	[Location] VARCHAR(200) NOT NULL,
	[Information] NVARCHAR(MAX) NULL,
	[PricePerPerson] DECIMAL(18, 2) NOT NULL,
	[MaxPartecipants] INT NOT NULL,
	[DurationInHours] INT NOT NULL,
	[ImageUrl] NVARCHAR(MAX	) NULL,
	[Rating] FLOAT NOT NULL DEFAULT 0,
	[TotalReviews] INT NOT NULL DEFAULT 0,
	[TotalBookings] INT NOT NULL DEFAULT 0,
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[HostProfileId] UNIQUEIDENTIFIER NOT NULL,
	[BookingId] UNIQUEIDENTIFIER NULL,

	CONSTRAINT [FK_Experience_HostProfile]
		FOREIGN KEY ([HostProfileId]) REFERENCES [dbo].[HostProfile]([Id]),

	

);