CREATE TABLE [dbo].[Voter] (
    [VoterId]              INT              IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (50)    NULL,
    [ServiceId]            NVARCHAR (50)    NULL,
    [MobileNo]             NVARCHAR (50)    NULL,
    [Email]                NVARCHAR (50)    NULL,
    [BloodGroup]           NVARCHAR (25)    CONSTRAINT [DF__Voter__IsEligibl__4D94879B] DEFAULT ((0)) NULL,
    [IsSelected]           BIT              NULL,
    [IsCommittedVote]      BIT              CONSTRAINT [DF_Voter_IsCommittedVote] DEFAULT ((0)) NOT NULL,
    [UniqueIdentification] UNIQUEIDENTIFIER NULL,
    [IsMailSent]           BIT              NULL,
    CONSTRAINT [PK_Voter] PRIMARY KEY CLUSTERED ([VoterId] ASC)
);

