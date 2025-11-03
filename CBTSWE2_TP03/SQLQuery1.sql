CREATE DATABASE GerenciadorProdutosDB;
GO

USE GerenciadorProdutosDB;
GO

CREATE TABLE Produtos (
Id int identity(1,1) primary key,
Nome nvarchar(100) not null,
Descricao nvarchar(500) not null,
Preco decimaL(18,2) not null check (Preco > 0),
QuantidadeEstoque int not null check (QuantidadeEstoque >= 0)
);
