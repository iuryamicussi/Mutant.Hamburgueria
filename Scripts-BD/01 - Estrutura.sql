CREATE DATABASE Mutant_DesafioPratico
GO

USE [Mutant_DesafioPratico]
GO
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 28/07/2019 23:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredientes](
	[Codigo] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Preco] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lanches]    Script Date: 28/07/2019 23:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lanches](
	[Codigo] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Lanches] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lanches_Ingredientes]    Script Date: 28/07/2019 23:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lanches_Ingredientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoLanche] [int] NOT NULL,
	[CodigoIngrediente] [int] NOT NULL,
 CONSTRAINT [PK_Lanches_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendas]    Script Date: 28/07/2019 23:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeCliente] [varchar](100) NOT NULL,
	[CodigoLanche] [int] NOT NULL,
	[ValorCompraBruto] [decimal](10, 2) NOT NULL,
	[ValorCompraLiquido] [decimal](10, 2) NOT NULL,
	[DataCompra] [datetime] NOT NULL,
 CONSTRAINT [PK_Vendas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendas_Itens]    Script Date: 28/07/2019 23:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendas_Itens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdVenda] [int] NOT NULL,
	[CodigoIngrediente] [int] NOT NULL,
	[ValorIngrediente] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Vendas_Itens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ingredientes] ADD  CONSTRAINT [DF_Ingredientes_Preco]  DEFAULT ((0)) FOR [Preco]
GO
ALTER TABLE [dbo].[Vendas] ADD  CONSTRAINT [DF_Vendas_NomeCliente]  DEFAULT ('Consumidor') FOR [NomeCliente]
GO
ALTER TABLE [dbo].[Vendas] ADD  CONSTRAINT [DF_Vendas_ValorCompra]  DEFAULT ((0)) FOR [ValorCompraBruto]
GO
ALTER TABLE [dbo].[Vendas] ADD  CONSTRAINT [DF_Vendas_ValorCompraLiquido]  DEFAULT ((0)) FOR [ValorCompraLiquido]
GO
ALTER TABLE [dbo].[Vendas] ADD  CONSTRAINT [DF_Vendas_DataCompra]  DEFAULT (getdate()) FOR [DataCompra]
GO
ALTER TABLE [dbo].[Vendas_Itens] ADD  CONSTRAINT [DF_Vendas_Itens_ValorIngrediente]  DEFAULT ((0)) FOR [ValorIngrediente]
GO
ALTER TABLE [dbo].[Lanches_Ingredientes]  WITH CHECK ADD  CONSTRAINT [FK_Lanche_Receita_Ingredietes] FOREIGN KEY([CodigoIngrediente])
REFERENCES [dbo].[Ingredientes] ([Codigo])
GO
ALTER TABLE [dbo].[Lanches_Ingredientes] CHECK CONSTRAINT [FK_Lanche_Receita_Ingredietes]
GO
ALTER TABLE [dbo].[Lanches_Ingredientes]  WITH CHECK ADD  CONSTRAINT [FK_Lanche_Receita_Lanches] FOREIGN KEY([CodigoLanche])
REFERENCES [dbo].[Lanches] ([Codigo])
GO
ALTER TABLE [dbo].[Lanches_Ingredientes] CHECK CONSTRAINT [FK_Lanche_Receita_Lanches]
GO
ALTER TABLE [dbo].[Vendas]  WITH CHECK ADD  CONSTRAINT [FK_Vendas_Lanches] FOREIGN KEY([CodigoLanche])
REFERENCES [dbo].[Lanches] ([Codigo])
GO
ALTER TABLE [dbo].[Vendas] CHECK CONSTRAINT [FK_Vendas_Lanches]
GO
ALTER TABLE [dbo].[Vendas_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Vendas_Itens_Ingredientes] FOREIGN KEY([CodigoIngrediente])
REFERENCES [dbo].[Ingredientes] ([Codigo])
GO
ALTER TABLE [dbo].[Vendas_Itens] CHECK CONSTRAINT [FK_Vendas_Itens_Ingredientes]
GO
ALTER TABLE [dbo].[Vendas_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Vendas_Itens_Vendas] FOREIGN KEY([IdVenda])
REFERENCES [dbo].[Vendas] ([Id])
GO
ALTER TABLE [dbo].[Vendas_Itens] CHECK CONSTRAINT [FK_Vendas_Itens_Vendas]
GO
/****** Object:  StoredProcedure [dbo].[PRC_FinalizarVenda]    Script Date: 28/07/2019 23:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_FinalizarVenda]
	@CodigoLanche as int,
	@NomeCliente as varchar(100),
	@ValorCompraBruto as decimal(10,2),
	@ValorCompraLiquido as decimal(10,2),
	@Ingredientes as varchar(200)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @IdVenda as int

	INSERT INTO Vendas(NomeCliente,CodigoLanche,ValorCompraBruto,ValorCompraLiquido,DataCompra) Values
	(@NomeCliente, @CodigoLanche,@ValorCompraBruto,@ValorCompraLiquido,getdate()) 

	SET @IdVenda = SCOPE_IDENTITY();

	INSERT INTO Vendas_Itens(IdVenda,CodigoIngrediente,ValorIngrediente)
	SELECT	@IdVenda,value,I.Preco  
	FROM	STRING_SPLIT(@Ingredientes, ',') as ListaCodigoIngredientes
			Inner Join Ingredientes I On value = I.Codigo

END
GO
/****** Object:  StoredProcedure [dbo].[PRC_ListaDeLanches]    Script Date: 28/07/2019 23:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_ListaDeLanches]
AS
BEGIN
	SET NOCOUNT ON;

	Select		L.Codigo As CodigoLanche, L.Nome As NomeLanche,
				I.Codigo As CodigoIngrediente, I.Nome As NomeIngrediente, I.Preco As PrecoIngrediente
	From		Lanches L
				Left Join Lanches_Ingredientes LI on L.Codigo = LI.CodigoLanche
				Left Join Ingredientes I on LI.CodigoIngrediente = I.Codigo
END
GO
