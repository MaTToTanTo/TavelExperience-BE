CREATE TABLE [dbo].[Booking]
(
	[Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[TravelerProfileId] UNIQUEIDENTIFIER NOT NULL,
	[ExperienceId] UNIQUEIDENTIFIER NOT NULL,
	[BookingDate] DATETIME NOT NULL,
	[NumberOfGuests] INT NOT NULL,
	[TotalPrice] DECIMAL(18, 2) NOT NULL,
	[Status] VARCHAR(50) NOT NULL DEFAULT 'Pending',
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[ConfirmedAt] DATETIME NULL,
	[CancelledAt] DATETIME NULL,

	CONSTRAINT [FK_Booking_TravelerProfile]
		FOREIGN KEY ([TravelerProfileId]) REFERENCES [dbo].[TravelerProfile]([Id]),

        
	
	CONSTRAINT [FK_Booking_Experience]
		FOREIGN KEY ([ExperienceId]) REFERENCES [dbo].[Experience]([Id]),

		
	
	
);