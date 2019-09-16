CREATE TABLE [dbo].[Candidate] (
    [CandidateId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [ServiceId]   NVARCHAR (50)  NULL,
    [Designation] NVARCHAR (100) NULL,
    [WorkPlace]   NVARCHAR (250) NULL,
    [MobileNo]    NVARCHAR (50)  NULL,
    [Email]       NVARCHAR (50)  NULL,
    [PhotoPath]   NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED ([CandidateId] ASC)
);

