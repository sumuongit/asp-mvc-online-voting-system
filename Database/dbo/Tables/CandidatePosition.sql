CREATE TABLE [dbo].[CandidatePosition] (
    [CandidatePositionId] INT IDENTITY (1, 1) NOT NULL,
    [CandidateId]         INT NULL,
    [PositionId]          INT NULL,
    CONSTRAINT [PK_CandidateNomination_1] PRIMARY KEY CLUSTERED ([CandidatePositionId] ASC),
    CONSTRAINT [FK_CandidatePosition_Candidate] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidate] ([CandidateId]),
    CONSTRAINT [FK_CandidatePosition_Position] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Position] ([PositionId])
);

