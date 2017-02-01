CREATE TABLE [dbo].[Articles] (
    [Id]          VARCHAR (50)  NOT NULL,
    [price]       VARCHAR (50)  NOT NULL,
    [currency]    VARCHAR (10)  NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    [code]        VARCHAR (50)  NOT NULL,
    [title]       VARCHAR (MAX) NULL,
    [Voltage]     VARCHAR (10)  NULL,
    [Weight]      VARCHAR (50)  NULL,
    [Brand]       VARCHAR (50)  NULL,
    [Color]       VARCHAR (50)  NULL,
    [Size]        VARCHAR (50)  NULL,
    [image]       VARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

