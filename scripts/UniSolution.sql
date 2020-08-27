USE [master]
GO
/****** Object:  Database [UniSolution]    Script Date: 27/08/2020 06:17:45 ******/
CREATE DATABASE [UniSolution]
GO
ALTER DATABASE [UniSolution] SET COMPATIBILITY_LEVEL = 150
GO
CREATE TABLE [dbo].[Tanque](
	[Deposito] [varchar](20) NOT NULL,
	[Capacidade] [varchar](20) NULL,
	[TipoProduto] [int] NULL,
 CONSTRAINT [PK_Tanque] PRIMARY KEY CLUSTERED 
(
	[Deposito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProduto]    Script Date: 27/08/2020 06:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProduto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](20) NULL,
 CONSTRAINT [PK_TipoDeProduto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tanque]  WITH CHECK ADD  CONSTRAINT [FK_Tanque_TipoDeProduto] FOREIGN KEY([TipoProduto])
REFERENCES [dbo].[TipoProduto] ([Id])
GO
ALTER TABLE [dbo].[Tanque] CHECK CONSTRAINT [FK_Tanque_TipoDeProduto]
GO
USE [master]
GO
ALTER DATABASE [UniSolution] SET  READ_WRITE 
GO
