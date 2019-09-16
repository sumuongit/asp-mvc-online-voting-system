CREATE TABLE [dbo].[VoteCastingInformation] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [CandidateId] INT NULL,
    [VoterId]     INT NULL,
    [PositionId]  INT NULL,
    CONSTRAINT [PK_VoteCastingInformation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VoteCastingInformation_Candidate] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidate] ([CandidateId]),
    CONSTRAINT [FK_VoteCastingInformation_Position] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Position] ([PositionId]),
    CONSTRAINT [FK_VoteCastingInformation_Voter] FOREIGN KEY ([VoterId]) REFERENCES [dbo].[Voter] ([VoterId])
);

