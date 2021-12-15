
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Apartamento](
	[ApartamentoId] [int] IDENTITY(1,1) NOT NULL,
	[BlocoId] [int] NOT NULL,
	[Numero] [varchar](10) NOT NULL,
	[Andar] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Apartamento] PRIMARY KEY CLUSTERED 
(
	[ApartamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Morador](
	[MoradorId] [int] IDENTITY(1,1) NOT NULL,
	[ApartamentoId] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[Telefone] [varchar](30) NOT NULL,
	[Cpf] [varchar](11) NOT NULL,
	[Email] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Morador] PRIMARY KEY CLUSTERED 
(
	[MoradorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Condominio](
	[CondominioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Telefone] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Condominio] PRIMARY KEY CLUSTERED 
(
	[CondominioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Bloco](
	[BlocoId] [int] IDENTITY(1,1) NOT NULL,
	[CondominioId] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Bloco] PRIMARY KEY CLUSTERED 
(
	[BlocoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


