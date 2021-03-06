USE [Mutant_DesafioPratico]
GO
INSERT [dbo].[Lanches] ([Codigo], [Nome]) VALUES (1, N'X-Bacon')
INSERT [dbo].[Lanches] ([Codigo], [Nome]) VALUES (2, N'X-Burger')
INSERT [dbo].[Lanches] ([Codigo], [Nome]) VALUES (3, N'X-Egg')
INSERT [dbo].[Lanches] ([Codigo], [Nome]) VALUES (4, N'X-Egg Bacon')
INSERT [dbo].[Lanches] ([Codigo], [Nome]) VALUES (5, N'Personalizado')
INSERT [dbo].[Ingredientes] ([Codigo], [Nome], [Preco]) VALUES (1, N'Alface', CAST(0.40 AS Decimal(10, 2)))
INSERT [dbo].[Ingredientes] ([Codigo], [Nome], [Preco]) VALUES (2, N'Bacon', CAST(2.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredientes] ([Codigo], [Nome], [Preco]) VALUES (3, N'Hambúrguer de carne', CAST(3.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredientes] ([Codigo], [Nome], [Preco]) VALUES (4, N'Ovo', CAST(0.80 AS Decimal(10, 2)))
INSERT [dbo].[Ingredientes] ([Codigo], [Nome], [Preco]) VALUES (5, N'Queijo', CAST(1.50 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Lanches_Ingredientes] ON 

INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (1, 1, 2)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (2, 1, 3)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (3, 1, 5)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (4, 2, 3)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (5, 2, 5)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (6, 3, 4)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (7, 3, 3)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (8, 3, 5)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (9, 4, 2)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (10, 4, 3)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (11, 4, 4)
INSERT [dbo].[Lanches_Ingredientes] ([Id], [CodigoLanche], [CodigoIngrediente]) VALUES (12, 4, 5)
SET IDENTITY_INSERT [dbo].[Lanches_Ingredientes] OFF
