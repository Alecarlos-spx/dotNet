USE CadastroTeste
CREATE TABLE [dbo].[Clientes] (
    [ClienteId]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (80) NOT NULL,
    [Endereco]    NVARCHAR (80) NOT NULL,
    [Numero]      NVARCHAR (10) NOT NULL,
    [Complemento] NVARCHAR (50) NOT NULL,
    [Cidade]      NVARCHAR (50) NOT NULL,
    [Estado]      NVARCHAR (50) NOT NULL,
    [Cep]         NVARCHAR (8)  NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([ClienteId] ASC)
);

