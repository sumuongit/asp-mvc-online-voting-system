CREATE TABLE [dbo].[User] (
    [UserId]    INT           NOT NULL,
    [Name]      NVARCHAR (50) NULL,
    [ServiceId] NVARCHAR (50) NULL,
    [MobileNo]  NVARCHAR (50) NULL,
    [Email]     NVARCHAR (50) NULL,
    [Password]  NVARCHAR (50) NULL,
    [RoleId]    INT           NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
);

