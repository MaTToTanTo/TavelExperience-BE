CREATE TABLE [dbo].[SavedExperience]
(
  [Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
  [SavedAt] DATETIME DEFAULT GETDATE(),
  [TravelerProfileId] UNIQUEIDENTIFIER NOT NULL,
  [ExperienceId] UNIQUEIDENTIFIER NOT NULL,

  CONSTRAINT [FK_SavedExperience_TravelerProfile]
    FOREIGN KEY ([TravelerProfileId]) REFERENCES [dbo].[TravelerProfile]([Id]),

    CONSTRAINT [UQ_SavedExperience_TravelerProfile]
     UNIQUE ([TravelerProfileId]),

     CONSTRAINT [FK_SavedExperience_Experience]
     FOREIGN KEY ([ExperienceId]) REFERENCES [dbo].[Experience]([Id]),

     CONSTRAINT [UQ_SavedExperience_Experience]
      UNIQUE ([ExperienceId])


);