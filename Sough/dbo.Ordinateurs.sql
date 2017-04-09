CREATE TABLE [dbo].[Ordinateurs] (
    [IdOrdinateur] BIGINT          IDENTITY (1, 1) NOT NULL,
    [marque]       NVARCHAR (MAX)  NOT NULL,
    [DisqueDur]    INT             NOT NULL,
    [ram]          INT             NOT NULL,
    [processeur]   NVARCHAR (MAX)  NULL,
    [EstNeuf]      NVARCHAR(MAX)             NOT NULL,
    [prix]         BIGINT          NOT NULL,
    [ville]        NVARCHAR (50)   NOT NULL,
    [AderName]     NVARCHAR (50)   NULL,
    [Email]        NVARCHAR (MAX)  NULL,
    [phone]        NVARCHAR (13)   NOT NULL,
    [image1]       VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.Ordinateurs] PRIMARY KEY CLUSTERED ([IdOrdinateur] ASC)
);

