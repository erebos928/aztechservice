CREATE TABLE [dbo].[Category] (
    [Id]     VARCHAR (16)  NOT NULL,
    [Title]  VARCHAR (250) NULL,
    [Parent] VARCHAR (16)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Category_Category] FOREIGN KEY ([Parent]) REFERENCES [dbo].[Category] ([Id])
);

