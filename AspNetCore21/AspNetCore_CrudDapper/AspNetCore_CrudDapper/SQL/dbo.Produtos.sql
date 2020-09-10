USE [CadastroTeste]
GO

CREATE TABLE [dbo].[Produtos]
(
	[ProdutoId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Nome] NCHAR(100) NOT NULL, 
    [Preco] DECIMAL(18, 2) NULL, 
    [Estoque] INT NULL
)

INSERT INTO Produtos(Nome, Estoque, Preco) 
VALUES('Caneta', 50, 2.50)

