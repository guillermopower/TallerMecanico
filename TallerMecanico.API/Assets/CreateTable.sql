USE [master]
GO
/****** Object:  Database [TallerMecanico]    Script Date: 2/7/2024 12:27:43 PM ******/
CREATE DATABASE [TallerMecanico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TallerMecanico', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TallerMecanico.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TallerMecanico_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TallerMecanico.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TallerMecanico] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TallerMecanico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TallerMecanico] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TallerMecanico] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TallerMecanico] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TallerMecanico] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TallerMecanico] SET ARITHABORT OFF 
GO
ALTER DATABASE [TallerMecanico] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TallerMecanico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TallerMecanico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TallerMecanico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TallerMecanico] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TallerMecanico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TallerMecanico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TallerMecanico] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TallerMecanico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TallerMecanico] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TallerMecanico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TallerMecanico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TallerMecanico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TallerMecanico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TallerMecanico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TallerMecanico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TallerMecanico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TallerMecanico] SET RECOVERY FULL 
GO
ALTER DATABASE [TallerMecanico] SET  MULTI_USER 
GO
ALTER DATABASE [TallerMecanico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TallerMecanico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TallerMecanico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TallerMecanico] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TallerMecanico] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TallerMecanico] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TallerMecanico', N'ON'
GO
ALTER DATABASE [TallerMecanico] SET QUERY_STORE = OFF
GO
USE [TallerMecanico]
GO
/****** Object:  Table [dbo].[Automoviles]    Script Date: 2/7/2024 12:27:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Automoviles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdVehiculo] [bigint] NOT NULL,
	[Tipo] [smallint] NULL,
	[CantidadPuertas] [smalldatetime] NULL,
 CONSTRAINT [PK_Automoviles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DescuentosRecargos]    Script Date: 2/7/2024 12:27:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescuentosRecargos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[ValorAbsoluto] [decimal](16, 2) NULL,
	[ValorPorcentual] [decimal](16, 2) NULL,
	[EsValorAbsoluto] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
 CONSTRAINT [PK_DescuentosRecargos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Desperfectos]    Script Date: 2/7/2024 12:27:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desperfectos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPresupuesto] [bigint] NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[ManoDeObra] [decimal](16, 2) NULL,
	[Tiempo] [int] NULL,
 CONSTRAINT [PK_Desperfectos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DesperfectosRepuestos]    Script Date: 2/7/2024 12:27:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesperfectosRepuestos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdDesperfecto] [bigint] NOT NULL,
	[IdRepuesto] [bigint] NOT NULL,
 CONSTRAINT [PK_DesperfectosRepuestos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motos]    Script Date: 2/7/2024 12:27:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdVehiculo] [bigint] NOT NULL,
	[Cilindrada] [varchar](50) NULL,
 CONSTRAINT [PK_Motos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presupuestos]    Script Date: 2/7/2024 12:27:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presupuestos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Total] [decimal](16, 2) NOT NULL,
	[IdVehiculo] [bigint] NOT NULL,
 CONSTRAINT [PK_Presupuestos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repuestos]    Script Date: 2/7/2024 12:27:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repuestos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Precio] [decimal](16, 2) NULL,
 CONSTRAINT [PK_Repuestos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 2/7/2024 12:27:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](100) NOT NULL,
	[Modelo] [varchar](100) NOT NULL,
	[Patente] [varchar](50) NOT NULL,
	[FechaIngreso] [datetime] NULL,
 CONSTRAINT [PK_Vehiculos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DescuentosRecargos] ADD  CONSTRAINT [DF_DescuentosRecargos_ValorAbsoluto]  DEFAULT ((0)) FOR [ValorAbsoluto]
GO
ALTER TABLE [dbo].[DescuentosRecargos] ADD  CONSTRAINT [DF_DescuentosRecargos_ValorPorcentual]  DEFAULT ((0)) FOR [ValorPorcentual]
GO
ALTER TABLE [dbo].[DescuentosRecargos] ADD  CONSTRAINT [DF_DescuentosRecargos_EsValorAbsoluto]  DEFAULT ((0)) FOR [EsValorAbsoluto]
GO
ALTER TABLE [dbo].[DescuentosRecargos] ADD  CONSTRAINT [DF_DescuentosRecargos_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Automoviles]  WITH CHECK ADD  CONSTRAINT [FK_Automoviles_Vehiculos] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculos] ([Id])
GO
ALTER TABLE [dbo].[Automoviles] CHECK CONSTRAINT [FK_Automoviles_Vehiculos]
GO
ALTER TABLE [dbo].[Desperfectos]  WITH CHECK ADD  CONSTRAINT [FK_Desperfectos_Presupuestos] FOREIGN KEY([IdPresupuesto])
REFERENCES [dbo].[Presupuestos] ([Id])
GO
ALTER TABLE [dbo].[Desperfectos] CHECK CONSTRAINT [FK_Desperfectos_Presupuestos]
GO
ALTER TABLE [dbo].[DesperfectosRepuestos]  WITH CHECK ADD  CONSTRAINT [FK_DesperfectosRepuestos_Desperfectos] FOREIGN KEY([IdDesperfecto])
REFERENCES [dbo].[Desperfectos] ([Id])
GO
ALTER TABLE [dbo].[DesperfectosRepuestos] CHECK CONSTRAINT [FK_DesperfectosRepuestos_Desperfectos]
GO
ALTER TABLE [dbo].[DesperfectosRepuestos]  WITH CHECK ADD  CONSTRAINT [FK_DesperfectosRepuestos_Repuestos] FOREIGN KEY([IdRepuesto])
REFERENCES [dbo].[Repuestos] ([Id])
GO
ALTER TABLE [dbo].[DesperfectosRepuestos] CHECK CONSTRAINT [FK_DesperfectosRepuestos_Repuestos]
GO
ALTER TABLE [dbo].[Motos]  WITH CHECK ADD  CONSTRAINT [FK_Motos_Vehiculos] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculos] ([Id])
GO
ALTER TABLE [dbo].[Motos] CHECK CONSTRAINT [FK_Motos_Vehiculos]
GO
ALTER TABLE [dbo].[Presupuestos]  WITH CHECK ADD  CONSTRAINT [FK_Presupuestos_Vehiculos] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculos] ([Id])
GO
ALTER TABLE [dbo].[Presupuestos] CHECK CONSTRAINT [FK_Presupuestos_Vehiculos]
GO
USE [master]
GO
ALTER DATABASE [TallerMecanico] SET  READ_WRITE 
GO
