CREATE TABLE [dbo].[Position] (
    [PositionId]   INT            IDENTITY (1, 1) NOT NULL,
    [PositionName] NVARCHAR (250) NULL,
    [NumberOfPost] INT            NULL,
    CONSTRAINT [PK_NominationPosition] PRIMARY KEY CLUSTERED ([PositionId] ASC)
);

