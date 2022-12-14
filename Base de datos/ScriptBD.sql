USE [master]
GO
/****** Object:  Database [taller_mecanico]    Script Date: 8/7/2022 18:13:57 ******/
CREATE DATABASE [taller_mecanico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'taller_mecanico', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\taller_mecanico.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'taller_mecanico_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\taller_mecanico_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [taller_mecanico] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [taller_mecanico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [taller_mecanico] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [taller_mecanico] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [taller_mecanico] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [taller_mecanico] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [taller_mecanico] SET ARITHABORT OFF 
GO
ALTER DATABASE [taller_mecanico] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [taller_mecanico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [taller_mecanico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [taller_mecanico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [taller_mecanico] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [taller_mecanico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [taller_mecanico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [taller_mecanico] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [taller_mecanico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [taller_mecanico] SET  ENABLE_BROKER 
GO
ALTER DATABASE [taller_mecanico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [taller_mecanico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [taller_mecanico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [taller_mecanico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [taller_mecanico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [taller_mecanico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [taller_mecanico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [taller_mecanico] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [taller_mecanico] SET  MULTI_USER 
GO
ALTER DATABASE [taller_mecanico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [taller_mecanico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [taller_mecanico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [taller_mecanico] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [taller_mecanico] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [taller_mecanico] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [taller_mecanico] SET QUERY_STORE = OFF
GO
USE [taller_mecanico]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 8/7/2022 18:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[CliCod] [int] IDENTITY(1,1) NOT NULL,
	[CliNom] [varchar](25) NOT NULL,
	[CliCi] [varchar](11) NOT NULL,
	[CliTel] [varchar](9) NOT NULL,
	[CliDir] [varchar](80) NOT NULL,
	[CliMail] [varchar](30) NULL,
	[FchRegistro] [date] NOT NULL,
	[CliContra] [varchar](12) NOT NULL,
	[Admin] [varchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[CliCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes_Vehiculos]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes_Vehiculos](
	[CliCod] [int] NOT NULL,
	[VehiculoCod] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CliCod] ASC,
	[VehiculoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historial_Clientes_Vehiculos]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial_Clientes_Vehiculos](
	[CliCod] [int] NOT NULL,
	[VehiculoCod] [int] NOT NULL,
	[FchCambio] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CliCod] ASC,
	[VehiculoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mecanicos]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mecanicos](
	[MecCod] [int] IDENTITY(1,1) NOT NULL,
	[MecNom] [varchar](25) NOT NULL,
	[MecCi] [varchar](11) NOT NULL,
	[MecTel] [varchar](9) NOT NULL,
	[MecFchIng] [date] NOT NULL,
	[MecValorHora] [int] NOT NULL,
	[MecActivo] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MecCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[ProveedorCod] [int] IDENTITY(1,1) NOT NULL,
	[ProveedrNom] [varchar](25) NOT NULL,
	[ProveedorRut] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProveedorCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reparacion]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reparacion](
	[RepCod] [int] IDENTITY(1,1) NOT NULL,
	[RepAnio] [int] NOT NULL,
	[VehiculoCod] [int] NULL,
	[FchEntrada] [date] NOT NULL,
	[FchSalida] [date] NULL,
	[MecCod] [int] NOT NULL,
	[RepDscEntrada] [varchar](80) NOT NULL,
	[ReoDscSalida] [varchar](80) NULL,
	[KmsEntrada] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RepCod] ASC,
	[RepAnio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reparacion_horas]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reparacion_horas](
	[RepCod] [int] NOT NULL,
	[RepAnio] [int] NOT NULL,
	[MecCod] [int] NOT NULL,
	[Horas] [int] NOT NULL,
	[CostoHora] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RepCod] ASC,
	[RepAnio] ASC,
	[MecCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reparacion_Repuestos]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reparacion_Repuestos](
	[RepCod] [int] NOT NULL,
	[RepAnio] [int] NOT NULL,
	[RepuestoCod] [varchar](9) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[CostoUnitario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RepCod] ASC,
	[RepAnio] ASC,
	[RepuestoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repuestos]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repuestos](
	[RepuestoCod] [varchar](9) NOT NULL,
	[RepuestoDsc] [varchar](80) NULL,
	[RepuestoCosto] [int] NOT NULL,
	[RepuestoTipo] [varchar](12) NULL,
	[ProveedorCod] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RepuestoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[ReservasCod] [int] IDENTITY(1,1) NOT NULL,
	[ReservaFch] [date] NOT NULL,
	[ReservaDsc] [varchar](80) NULL,
	[CliCod] [int] NULL,
	[VehiculoCod] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservasCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[VehiculoCod] [int] IDENTITY(1,1) NOT NULL,
	[Matricula] [varchar](7) NOT NULL,
	[Marca] [varchar](25) NOT NULL,
	[Modelo] [varchar](25) NOT NULL,
	[Anio] [numeric](4, 0) NOT NULL,
	[Color] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VehiculoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (1, N'Alberto', N'4.245.768-1', N'092569490', N'Avenida Palito 460', N'alberto6790@gmail.com', CAST(N'2022-05-15' AS Date), N'Albe092', N'No')
INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (2, N'Elian', N'5.256.898-2', N'99889078', N'Jose Salvo 500', N'Saborenpote@gmail.com', CAST(N'2022-07-08' AS Date), N'ManyaGordo', N'No')
INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (3, N'Juanpe', N'5.378.592-4', N'092446675', N'Don Bosco 352', N'RororoaJuanpe@gmail.com', CAST(N'2021-06-07' AS Date), N'Zoro4ever', N'No')
INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (4, N'Alen', N'1.744.123-8', N'098650137', N'Av.Italia 457', N'LopezAlen@gmail.com', CAST(N'2020-01-01' AS Date), N'Defensor2020', N'Si')
INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (5, N'Augusto', N'3.898.225-7', N'094447869', N'Av.Uganda 578', N'bettoprof@gmail.com', CAST(N'2022-02-25' AS Date), N'Pochiloco', N'No')
INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (6, N'Agustín', N'5.777.324-7', N'093447779', N'Av.Violeta 777', N'Abartt@gmail.com', CAST(N'2021-07-17' AS Date), N'Mojojo777', N'No')
INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (7, N'Jeremias', N'4.893.331-4', N'093443373', N'Av.Turkia 734', N'TurkoBidon@gmail.com', CAST(N'2022-01-14' AS Date), N'LaPlanta', N'No')
INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (8, N'Alex', N'5.796.324-6', N'094517875', N'Luis Menendez 140', N'AlonMisterio@gmail.com', CAST(N'2020-02-24' AS Date), N'Clancleta', N'No')
INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (9, N'Octavio', N'5.309.336-9', N'094582367', N'Los Horneros 164', N'TeamIchika@gmail.com', CAST(N'2020-01-03' AS Date), N'Knekro4444', N'No')
INSERT [dbo].[Clientes] ([CliCod], [CliNom], [CliCi], [CliTel], [CliDir], [CliMail], [FchRegistro], [CliContra], [Admin]) VALUES (10, N'Jorge', N'1.903.132-8', N'093675423', N'Av.Geo 990', N'geografo65@gmail.com', CAST(N'2021-08-13' AS Date), N'GeoGeo27', N'No')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (1, 4, CAST(N'2022-07-08' AS Date))
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (2, 5, CAST(N'2022-07-08' AS Date))
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (3, 6, CAST(N'2022-07-08' AS Date))
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (4, 7, CAST(N'2022-07-08' AS Date))
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (5, 9, CAST(N'2022-07-08' AS Date))
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (6, 3, CAST(N'2022-07-08' AS Date))
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (7, 8, CAST(N'2022-07-08' AS Date))
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (8, 10, CAST(N'2022-07-08' AS Date))
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (9, 2, CAST(N'2022-07-08' AS Date))
INSERT [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod], [Fecha]) VALUES (10, 1, CAST(N'2022-07-08' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Mecanicos] ON 

INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (1, N'Juanillo', N'5.526.788-2', N'099678543', CAST(N'2020-04-05' AS Date), 900, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (2, N'Sebastian', N'4.154.432-1', N'095234682', CAST(N'2021-12-07' AS Date), 570, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (3, N'Miguel', N'4.248.122-9', N'093274232', CAST(N'2020-11-10' AS Date), 720, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (4, N'Romina', N'4.556.721-7', N'094123331', CAST(N'2021-01-23' AS Date), 920, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (5, N'Elmo', N'3.757.452-8', N'093144234', CAST(N'2020-07-12' AS Date), 1000, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (6, N'Franco', N'1.856.132-4', N'092111839', CAST(N'2019-08-22' AS Date), 890, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (7, N'Daniel', N'3.252.567-9', N'094423779', CAST(N'2020-06-30' AS Date), 780, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (8, N'Bartolomeo', N'4.772.464-4', N'095453575', CAST(N'2022-08-04' AS Date), 590, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (9, N'Borsalino', N'4.679.964-9', N'096443777', CAST(N'2022-11-19' AS Date), 770, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (10, N'Mateo', N'2.878.554-5', N'094483465', CAST(N'2021-04-12' AS Date), 790, N'Si')
INSERT [dbo].[Mecanicos] ([MecCod], [MecNom], [MecCi], [MecTel], [MecFchIng], [MecValorHora], [MecActivo]) VALUES (11, N'Pepe', N'5.000.000-5', N'099999999', CAST(N'2022-07-09' AS Date), 550, N'Si')
SET IDENTITY_INSERT [dbo].[Mecanicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([ProveedorCod], [ProveedrNom], [ProveedorRut]) VALUES (1, N'Baratie', N'450303670014')
INSERT [dbo].[Proveedores] ([ProveedorCod], [ProveedrNom], [ProveedorRut]) VALUES (2, N'Pochita', N'654324783501')
INSERT [dbo].[Proveedores] ([ProveedorCod], [ProveedrNom], [ProveedorRut]) VALUES (3, N'Novachrono', N'338293679019')
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Reparacion] ON 

INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (1, 2020, 9, CAST(N'2020-07-24' AS Date), CAST(N'2020-07-28' AS Date), 10, N'Kit dañado', N'nuevo kit de distribución', 993000)
INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (1, 2021, 8, CAST(N'2021-08-12' AS Date), CAST(N'2021-08-15' AS Date), 9, N'Cambio de valvula', N'Nueva valvula', 723000)
INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (1, 2022, 2, CAST(N'2022-05-29' AS Date), CAST(N'1753-01-01' AS Date), 2, N'Faro roto', NULL, 565000)
INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (2, 2020, 10, CAST(N'2020-09-22' AS Date), CAST(N'2020-09-23' AS Date), 7, N'perdida de liquido', N'Cambio de bomba de agua', 775000)
INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (2, 2021, 7, CAST(N'2021-05-03' AS Date), CAST(N'2021-05-04' AS Date), 6, N'neumaticos gastados', N'cambio de neumaticos', 365000)
INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (2, 2022, 2, CAST(N'2022-05-29' AS Date), CAST(N'1753-01-01' AS Date), 1, N'Problema de motor', NULL, 238000)
INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (3, 2021, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-22' AS Date), 5, N'problemas de motor', N'Cambio de bobina', 876000)
INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (3, 2022, 4, CAST(N'2022-05-28' AS Date), CAST(N'1753-01-01' AS Date), 8, N'Embrague suelto', NULL, 567000)
INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (4, 2021, 1, CAST(N'2021-11-09' AS Date), CAST(N'2021-11-12' AS Date), 4, N'cambio de tornillos', N'se cambiaron tornillos', 235000)
INSERT [dbo].[Reparacion] ([RepCod], [RepAnio], [VehiculoCod], [FchEntrada], [FchSalida], [MecCod], [RepDscEntrada], [ReoDscSalida], [KmsEntrada]) VALUES (4, 2022, 3, CAST(N'2022-03-14' AS Date), CAST(N'2022-03-14' AS Date), 1, N'requiere cambio de aceite', N'se cambio el aceite', 150000)
SET IDENTITY_INSERT [dbo].[Reparacion] OFF
GO
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (1, 2020, 7, 12, 780)
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (1, 2021, 4, 8, 920)
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (1, 2022, 1, 2, 900)
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (2, 2020, 10, 20, 790)
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (2, 2021, 5, 3, 1000)
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (2, 2022, 8, 7, 590)
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (3, 2021, 6, 5, 890)
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (3, 2022, 1, 24, 900)
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (4, 2021, 9, 5, 770)
INSERT [dbo].[Reparacion_horas] ([RepCod], [RepAnio], [MecCod], [Horas], [CostoHora]) VALUES (4, 2022, 2, 2, 570)
GO
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (1, 2020, N'KKK321656', 1, 2800)
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (1, 2021, N'ABM545353', 1, 200)
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (1, 2022, N'MNA441554', 1, 1100)
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (2, 2020, N'DLL958205', 1, 5200)
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (2, 2021, N'THC954318', 1, 1900)
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (2, 2022, N'HDD451278', 1, 3700)
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (3, 2021, N'ZKM123456', 4, 6500)
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (3, 2022, N'MDL551235', 1, 12200)
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (4, 2021, N'ACD895003', 1, 5600)
INSERT [dbo].[Reparacion_Repuestos] ([RepCod], [RepAnio], [RepuestoCod], [Cantidad], [CostoUnitario]) VALUES (4, 2022, N'MGT589537', 1, 1700)
GO
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'ABM545353', N'Bolsa tornillos t4', 200, N'Varios', 3)
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'ACD895003', N'Válvula EGR', 5600, N'Motor', 2)
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'DLL958205', N'Kit de distribución', 5200, N'Motor', 2)
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'HDD451278', N'Embrague', 3700, N'Carrocería', 1)
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'KKK321656', N'Bomba de agua', 2800, N'Motor', 2)
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'MDL551235', N'Catalizador', 12200, N'Carrocería', 1)
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'MGT589537', N'Faro LED Stinger', 1700, N'Carrocería', 1)
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'MNA441554', N'Aceite 10w40', 1100, N'Lubricación', 3)
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'THC954318', N'Bobina de encendido', 1900, N'Motor', 2)
INSERT [dbo].[Repuestos] ([RepuestoCod], [RepuestoDsc], [RepuestoCosto], [RepuestoTipo], [ProveedorCod]) VALUES (N'ZKM123456', N'Cubierta Neumatico Radial Petlas', 6500, N'Carrocería', 1)
GO
SET IDENTITY_INSERT [dbo].[Reservas] ON 

INSERT [dbo].[Reservas] ([ReservasCod], [ReservaFch], [ReservaDsc], [CliCod], [VehiculoCod]) VALUES (1, CAST(N'2022-07-09' AS Date), N'gg', 4, 7)
SET IDENTITY_INSERT [dbo].[Reservas] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculos] ON 

INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (1, N'ACK8967', N'Citroen', N'Berlingo Van', CAST(1996 AS Numeric(4, 0)), N'Rojo')
INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (2, N'ACM1891', N'Subaru', N'Solterra', CAST(2021 AS Numeric(4, 0)), N'Rosado')
INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (3, N'AGU0503', N'Suzuki', N'Celerio', CAST(1999 AS Numeric(4, 0)), N'Amarillo')
INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (4, N'TOT2423', N'Audi', N'A8', CAST(2022 AS Numeric(4, 0)), N'Negro')
INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (5, N'OBB1930', N'Bugatti', N'Veyron', CAST(2020 AS Numeric(4, 0)), N'Dorado')
INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (6, N'LSD4420', N'Volkswagen', N'Fusca', CAST(1990 AS Numeric(4, 0)), N'Celeste')
INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (7, N'ALN1190', N'Fiat', N'Uno', CAST(1991 AS Numeric(4, 0)), N'Blanca')
INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (8, N'FAT6969', N'Fiat', N'Fiorino', CAST(1997 AS Numeric(4, 0)), N'Gris')
INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (9, N'ATR1415', N'Daihatsu', N'Delta', CAST(2010 AS Numeric(4, 0)), N'Rojo')
INSERT [dbo].[Vehiculos] ([VehiculoCod], [Matricula], [Marca], [Modelo], [Anio], [Color]) VALUES (10, N'LAW1903', N'Hyundai', N'HD78', CAST(2012 AS Numeric(4, 0)), N'Negro')
SET IDENTITY_INSERT [dbo].[Vehiculos] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Clientes__10ADB15C8E4EF86B]    Script Date: 8/7/2022 18:13:58 ******/
ALTER TABLE [dbo].[Clientes] ADD UNIQUE NONCLUSTERED 
(
	[CliMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Clientes__FA1DF9A9FB328D8C]    Script Date: 8/7/2022 18:13:58 ******/
ALTER TABLE [dbo].[Clientes] ADD UNIQUE NONCLUSTERED 
(
	[CliCi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [i_VehiculoCodCliVeh]    Script Date: 8/7/2022 18:13:58 ******/
CREATE NONCLUSTERED INDEX [i_VehiculoCodCliVeh] ON [dbo].[Clientes_Vehiculos]
(
	[VehiculoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [i_VehiculoCodHCV]    Script Date: 8/7/2022 18:13:58 ******/
CREATE NONCLUSTERED INDEX [i_VehiculoCodHCV] ON [dbo].[Historial_Clientes_Vehiculos]
(
	[VehiculoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Mecanico__E440BFF781BAF932]    Script Date: 8/7/2022 18:13:58 ******/
ALTER TABLE [dbo].[Mecanicos] ADD UNIQUE NONCLUSTERED 
(
	[MecCi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Proveedo__0BAFC9174E006148]    Script Date: 8/7/2022 18:13:58 ******/
ALTER TABLE [dbo].[Proveedores] ADD UNIQUE NONCLUSTERED 
(
	[ProveedorRut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [i_MecCodRep]    Script Date: 8/7/2022 18:13:58 ******/
CREATE NONCLUSTERED INDEX [i_MecCodRep] ON [dbo].[Reparacion]
(
	[MecCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [i_VehiculoCodRep]    Script Date: 8/7/2022 18:13:58 ******/
CREATE NONCLUSTERED INDEX [i_VehiculoCodRep] ON [dbo].[Reparacion]
(
	[VehiculoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [i_MecCodRepH]    Script Date: 8/7/2022 18:13:58 ******/
CREATE NONCLUSTERED INDEX [i_MecCodRepH] ON [dbo].[Reparacion_horas]
(
	[MecCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [i_RepuestoCodRepR]    Script Date: 8/7/2022 18:13:58 ******/
CREATE NONCLUSTERED INDEX [i_RepuestoCodRepR] ON [dbo].[Reparacion_Repuestos]
(
	[RepuestoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [i_ProveedorCodRepuestos]    Script Date: 8/7/2022 18:13:58 ******/
CREATE NONCLUSTERED INDEX [i_ProveedorCodRepuestos] ON [dbo].[Repuestos]
(
	[ProveedorCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [i_CliCodReservas]    Script Date: 8/7/2022 18:13:58 ******/
CREATE NONCLUSTERED INDEX [i_CliCodReservas] ON [dbo].[Reservas]
(
	[CliCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [i_VehiculoCodReservas]    Script Date: 8/7/2022 18:13:58 ******/
CREATE NONCLUSTERED INDEX [i_VehiculoCodReservas] ON [dbo].[Reservas]
(
	[VehiculoCod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Vehiculo__0FB9FB4F47098690]    Script Date: 8/7/2022 18:13:58 ******/
ALTER TABLE [dbo].[Vehiculos] ADD UNIQUE NONCLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (getdate()) FOR [FchRegistro]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT ('No') FOR [Admin]
GO
ALTER TABLE [dbo].[Clientes_Vehiculos] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Reparacion] ADD  DEFAULT (datepart(year,getdate())) FOR [RepAnio]
GO
ALTER TABLE [dbo].[Reparacion] ADD  DEFAULT (getdate()) FOR [FchEntrada]
GO
ALTER TABLE [dbo].[Clientes_Vehiculos]  WITH CHECK ADD FOREIGN KEY([CliCod])
REFERENCES [dbo].[Clientes] ([CliCod])
GO
ALTER TABLE [dbo].[Clientes_Vehiculos]  WITH CHECK ADD FOREIGN KEY([VehiculoCod])
REFERENCES [dbo].[Vehiculos] ([VehiculoCod])
GO
ALTER TABLE [dbo].[Historial_Clientes_Vehiculos]  WITH CHECK ADD FOREIGN KEY([CliCod])
REFERENCES [dbo].[Clientes] ([CliCod])
GO
ALTER TABLE [dbo].[Historial_Clientes_Vehiculos]  WITH CHECK ADD FOREIGN KEY([VehiculoCod])
REFERENCES [dbo].[Vehiculos] ([VehiculoCod])
GO
ALTER TABLE [dbo].[Reparacion]  WITH CHECK ADD FOREIGN KEY([MecCod])
REFERENCES [dbo].[Mecanicos] ([MecCod])
GO
ALTER TABLE [dbo].[Reparacion]  WITH CHECK ADD FOREIGN KEY([VehiculoCod])
REFERENCES [dbo].[Vehiculos] ([VehiculoCod])
GO
ALTER TABLE [dbo].[Reparacion_horas]  WITH CHECK ADD FOREIGN KEY([MecCod])
REFERENCES [dbo].[Mecanicos] ([MecCod])
GO
ALTER TABLE [dbo].[Reparacion_horas]  WITH CHECK ADD FOREIGN KEY([RepCod], [RepAnio])
REFERENCES [dbo].[Reparacion] ([RepCod], [RepAnio])
GO
ALTER TABLE [dbo].[Reparacion_Repuestos]  WITH CHECK ADD FOREIGN KEY([RepuestoCod])
REFERENCES [dbo].[Repuestos] ([RepuestoCod])
GO
ALTER TABLE [dbo].[Reparacion_Repuestos]  WITH CHECK ADD FOREIGN KEY([RepCod], [RepAnio])
REFERENCES [dbo].[Reparacion] ([RepCod], [RepAnio])
GO
ALTER TABLE [dbo].[Repuestos]  WITH CHECK ADD FOREIGN KEY([ProveedorCod])
REFERENCES [dbo].[Proveedores] ([ProveedorCod])
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD FOREIGN KEY([CliCod], [VehiculoCod])
REFERENCES [dbo].[Clientes_Vehiculos] ([CliCod], [VehiculoCod])
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD CHECK  (([Admin]='No' OR [Admin]='Si'))
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD CHECK  (([CliCi] like '[1-9][.][0-9][0-9][0-9][.][0-9][0-9][0-9][-][0-9]'))
GO
ALTER TABLE [dbo].[Mecanicos]  WITH CHECK ADD CHECK  (([MecActivo]='No' OR [MecActivo]='Si'))
GO
ALTER TABLE [dbo].[Mecanicos]  WITH CHECK ADD CHECK  (([MecCi] like '[1-9][.][0-9][0-9][0-9][.][0-9][0-9][0-9][-][0-9]'))
GO
ALTER TABLE [dbo].[Mecanicos]  WITH CHECK ADD CHECK  (([MecValorHora]>(0)))
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD CHECK  (([ProveedorRut] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Repuestos]  WITH CHECK ADD CHECK  (([RepuestoCod] like '[A-Z][A-Z][A-Z][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Repuestos]  WITH CHECK ADD CHECK  (([RepuestoTipo]='Varios' OR [RepuestoTipo]='Lubricación' OR [RepuestoTipo]='Carrocería' OR [RepuestoTipo]='Motor'))
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD CHECK  (([Anio]>=(1990)))
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD CHECK  (([Matricula] like '[A-Z][A-Z][A-Z][0-9][0-9][0-9][0-9]'))
GO
/****** Object:  StoredProcedure [dbo].[AdminListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[AdminListar]
As
Begin
	Select [CliCod],[CliNom],[CliCi],[CliTel],[CliDir],[CliMail],[FchRegistro],[CliContra],[Admin] from Clientes where Admin = 'Si';
End
GO
/****** Object:  StoredProcedure [dbo].[ClienteAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ClienteAlta]
	@CliNom varchar(25),
	@CliCi varchar(11),
	@CliTel varchar(9),
	@CliDir varchar(80),
	@CliMail varchar(30),
	@FchRegistro date,
	@CliContra varchar(12),
	@Admin varchar(2)
As
Begin
	Insert into Clientes (CliNom,CliCi,CliTel,CliDir,CliMail,FchRegistro,CliContra,Admin) 
	values(@CliNom,@CliCi,@CliTel,@CliDir,@CliMail,@FchRegistro,@CliContra,@Admin);
End
GO
/****** Object:  StoredProcedure [dbo].[ClienteBaja]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ClienteBaja]
	@CliCod int
As
Begin
	Delete from Clientes where CliCod = @CliCod;
End
GO
/****** Object:  StoredProcedure [dbo].[ClienteBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ClienteBuscar]
	@CliCod int
As
Begin
	Select * from Clientes where CliCod = @CliCod;
End
GO
/****** Object:  StoredProcedure [dbo].[ClienteModificar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ClienteModificar]
	@CliCod int,
	@CliNom varchar(25),
	@CliCi varchar(11),
	@CliTel varchar(9),
	@CliDir varchar(80),
	@CliMail varchar(30),
	@FchRegistro date,
	@CliContra varchar(12),
	@Admin varchar(2)
As
Begin
	Update Clientes set CliNom = @CliNom,
						CliCi = @CliCi, 
						CliTel = @CliTel, 
						CliDir = @CliDir, 
						CliMail = @CliMail, 
						FchRegistro = @FchRegistro,
						CliContra = @CliContra,
						Admin = @Admin
					where CliCod = @CliCod;
End
GO
/****** Object:  StoredProcedure [dbo].[ClientesListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ClientesListar]
As
Begin
	Select [CliCod],[CliNom],[CliCi],[CliTel],[CliDir],[CliMail],[FchRegistro],[CliContra],[Admin] from Clientes;
End
GO
/****** Object:  StoredProcedure [dbo].[ClientesVehiculosAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ClientesVehiculosAlta]
		@CliCod int,
		@VehiculoCod int
As
Begin
	Insert into Clientes_Vehiculos(CliCod, VehiculoCod)
	values(@CliCod, @VehiculoCod);
End
GO
/****** Object:  StoredProcedure [dbo].[ClientesVehiculosListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ClientesVehiculosListar]
As
Begin
	Select [CliCod],[VehiculoCod],[Fecha] from Clientes_Vehiculos; 
End
GO
/****** Object:  StoredProcedure [dbo].[ListadoReparacionesFinales]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ListadoReparacionesFinales]
@FchIn date,
@FchEnd date

as
Begin

Select C.[CliNom], V.[Matricula], R.[FchEntrada], Sum((RR.Cantidad * RR.CostoUnitario) + (RH.Horas * RH.CostoHora)) as [Costo]
from Reparacion R
inner join Clientes_Vehiculos CV on R.VehiculoCod = CV.VehiculoCod
inner Join Vehiculos V on R.VehiculoCod = V.VehiculoCod
inner join Clientes C on CV.CliCod = C.CliCod
inner join Reparacion_Repuestos RR on R.RepCod = RR.RepCod and R.RepAnio = RR.RepAnio
inner join Reparacion_horas RH on R.RepCod = RH.RepCod and R.RepAnio = RH.RepAnio
where R.FchEntrada >= @FchIn and R.FchEntrada <= @FchEnd and R.FchSalida <> '17530101'
Group By C.CliNom, V.Matricula, R.FchEntrada
Order by Costo desc
End
GO
/****** Object:  StoredProcedure [dbo].[ListadoReparacionesProceso]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ListadoReparacionesProceso]
@FchIn date
as
Begin

Select C.[CliNom], V.[Matricula], R.[FchEntrada]
from Reparacion R
inner join Clientes_Vehiculos CV on R.VehiculoCod = CV.VehiculoCod
inner Join Vehiculos V on R.VehiculoCod = V.VehiculoCod
inner join Clientes C on CV.CliCod = C.CliCod
where R.FchEntrada >= @FchIn and R.FchSalida = '17530101'
Group By C.CliNom, V.Matricula, R.FchEntrada
Order by R.FchEntrada desc
End
GO
/****** Object:  StoredProcedure [dbo].[ListadoRepuestoMasVendidos]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ListadoRepuestoMasVendidos]
as 
begin
Select R.[RepuestoCod], R.[RepuestoDsc], Sum(RR.Cantidad) as [CantidadTot]
from Repuestos R
inner join Reparacion_Repuestos RR on R.RepuestoCod = RR.RepuestoCod
Group by R.RepuestoCod, R.RepuestoDsc
Order by CantidadTot desc
end
GO
/****** Object:  StoredProcedure [dbo].[MecanicoAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MecanicoAlta]
		@MecNom varchar(25),
		@MecCi varchar(11),
		@MecTel varchar(9),
		@MecFchIng Date,
		@MecValorHora integer,
		@MecActivo varchar(2)
As
Begin
	Insert into Mecanicos (MecNom,MecCi,MecTel,MecFchIng,MecValorHora,MecActivo) 
	values (@MecNom,@MecCi,@MecTel,@MecFchIng,@MecValorHora,@MecActivo);
End
GO
/****** Object:  StoredProcedure [dbo].[MecanicoBaja]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MecanicoBaja]
	@MecCod integer
As
Begin
	Delete from Mecanicos where MecCod = @MecCod;
End
GO
/****** Object:  StoredProcedure [dbo].[MecanicoBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MecanicoBuscar]
	@MecCod integer
As
Begin
	Select * from Mecanicos where MecCod = @MecCod;
End
GO
/****** Object:  StoredProcedure [dbo].[MecanicoModificar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MecanicoModificar]
		@MecCod integer,
		@MecNom varchar(25),
		@MecCi varchar(11),
		@MecTel varchar(9),
		@MecFchIng Date,
		@MecValorHora integer,
		@MecActivo varchar(2)
As
Begin
	Update Mecanicos set  MecNom = @MecNom,
						  MecCi = @MecCi,
						  MecTel = @MecTel,
						  MecFchIng = @MecFchIng,
						  MecValorHora = @MecValorHora,
						  MecActivo = @MecActivo
					   where MecCod = @MecCod;
End
GO
/****** Object:  StoredProcedure [dbo].[MecanicosListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MecanicosListar]
As
Begin
	Select [MecCod],[MecNom],[MecCi],[MecTel],[MecFchIng],[MecValorHora],[MecActivo] from mecanicos;
End
GO
/****** Object:  StoredProcedure [dbo].[MecanicosListarActivos]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[MecanicosListarActivos]
As
Begin
	Select [MecCod],[MecNom],[MecCi],[MecTel],[MecFchIng],[MecValorHora],[MecActivo] from mecanicos where MecActivo = 'Si';
End
GO
/****** Object:  StoredProcedure [dbo].[NoAdminListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[NoAdminListar]
As
Begin
	Select [CliCod],[CliNom],[CliCi],[CliTel],[CliDir],[CliMail],[FchRegistro],[CliContra],[Admin] from Clientes where Admin = 'No';
End
GO
/****** Object:  StoredProcedure [dbo].[ProveedorAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ProveedorAlta]
		@ProveedorNom varchar(25),
		@ProveedorRut varchar(12)
As
Begin
	Insert into Proveedores(ProveedrNom,ProveedorRut) 
	values (@ProveedorNom,@ProveedorRut);
End
GO
/****** Object:  StoredProcedure [dbo].[ProveedorBaja]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ProveedorBaja]
	@ProveedorCod integer
As
Begin
	Delete from Proveedores where ProveedorCod = @ProveedorCod;
End
GO
/****** Object:  StoredProcedure [dbo].[ProveedorBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ProveedorBuscar]
	@ProveedorCod integer
As
Begin
	Select * from Proveedores where ProveedorCod = @ProveedorCod;
End
GO
/****** Object:  StoredProcedure [dbo].[ProveedoresListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ProveedoresListar]
As
Begin
	Select [ProveedorCod],[ProveedrNom],[ProveedorRut] from Proveedores;
End
GO
/****** Object:  StoredProcedure [dbo].[ProveedorModificar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ProveedorModificar]
		@ProveedorCod integer,
		@ProveedrNom varchar(25),
		@ProveedorRut varchar(12)
As
Begin
	Update Proveedores set ProveedrNom = @ProveedrNom,
						ProveedorRut = @ProveedorRut
					where ProveedorCod = @ProveedorCod;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionAlta]
		@RepAnio int,
		@VehiculoCod integer,
		@FchEntrada Date,
		@FchSalida Date,
		@MecCod integer,
		@RepDscEntrada varchar(80),
		@ReoDscSalida varchar(80),
		@KmsEntrada integer
As
Begin
	Insert into Reparacion (VehiculoCod,FchEntrada,FchSalida,MecCod,RepDscEntrada,ReoDscSalida,KmsEntrada) 
	values (@VehiculoCod,@FchEntrada,@FchSalida,@MecCod,@RepDscEntrada,@ReoDscSalida,@KmsEntrada);
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionBaja]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionBaja]
	@RepCod integer,
	@RepAnio int
As
Begin
	Delete from Reparacion where RepCod = @RepCod and RepAnio = @RepAnio;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionBuscar]
	@RepCod integer,
	@RepAnio int
As
Begin
	Select * from Reparacion where RepCod = @RepCod and RepAnio = @RepAnio;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionHorasAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionHorasAlta]
		@RepCod int,
		@RepAnio int,
		@MecCod int,
		@Horas int,
		@CostoHora int
As
Begin
	Insert into Reparacion_horas(RepCod,RepAnio,MecCod,Horas,CostoHora) 
	values (@RepCod,@RepAnio,@MecCod,@Horas,@CostoHora);
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionHorasBaja]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionHorasBaja]
	@RepCod integer,
	@RepAnio integer
As
Begin
	Delete from Reparacion_Repuestos where RepCod = @RepCod and RepAnio = @RepAnio;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionHorasBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionHorasBuscar]
	@RepCod integer,
	@RepAnio integer
As
Begin
	Select * from Reparacion_horas where RepCod = @RepCod and RepAnio = @RepAnio;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionHorasListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionHorasListar]
As
Begin
	Select [RepCod],[RepAnio],[MecCod],[Horas],[CostoHora] from Reparacion_horas;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionHorasModificar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionHorasModificar]
		@RepCod int,
		@RepAnio int,
		@MecCod int,
		@Horas int,
		@CostoHora int
As
Begin
	Update Reparacion_horas set MecCod = @MecCod, Horas = @Horas, CostoHora = @CostoHora
								where RepCod = @RepCod and RepAnio = @RepAnio;
						
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionListar]
As
Begin
	Select [RepCod],[RepAnio],[VehiculoCod],[FchEntrada],[FchSalida],[MecCod],[RepDscEntrada],[ReoDscSalida],[KmsEntrada] from Reparacion;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionListarCompleta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionListarCompleta]
As
Begin
	Select [RepCod],[RepAnio],[VehiculoCod],[FchEntrada],[FchSalida],[MecCod],[RepDscEntrada],[ReoDscSalida],[KmsEntrada] from Reparacion where FchSalida != '17530101' and ReoDscSalida != 'NULL';
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionListarPendiente]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionListarPendiente]
As
Begin
	Select [RepCod],[RepAnio],[VehiculoCod],[FchEntrada],[MecCod],[RepDscEntrada],[KmsEntrada] from Reparacion where FchSalida = '17530101';
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionModificar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionModificar]
		@RepCod integer,
		@RepAnio int,
		@VehiculoCod integer,
		@FchEntrada Date,
		@FchSalida Date,
		@MecCod integer,
		@RepDscEntrada varchar(80),
		@ReoDscSalida varchar(80),
		@KmsEntrada integer
As
Begin
	Update Reparacion set VehiculoCod = @VehiculoCod, 
						  FchEntrada = @FchEntrada,
						  FchSalida = @FchSalida,
						  MecCod = @MecCod,
						  RepDscEntrada = @RepDscEntrada,
						  ReoDscSalida = @ReoDscSalida,
						  KmsEntrada = @KmsEntrada
					   where RepCod = @RepCod and RepAnio = @RepAnio;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionRepuestosAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionRepuestosAlta]
		@RepCod int,
		@RepAnio int,
		@RepuestoCod varchar(9),
		@Cantidad int,
		@CostoUnitario int
As
Begin
	Insert into Reparacion_Repuestos(RepCod,RepAnio,RepuestoCod,Cantidad,CostoUnitario) 
	values (@RepCod,@RepAnio,@RepuestoCod,@Cantidad,@CostoUnitario);
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionRepuestosBaja]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionRepuestosBaja]
	@RepCod integer,
	@RepAnio integer
As
Begin
	Delete from Reparacion_Repuestos where RepCod = @RepCod and RepAnio = @RepAnio;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionRepuestosBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionRepuestosBuscar]
	@RepCod integer,
	@RepAnio integer
As
Begin
	Select * from Reparacion_Repuestos where RepCod = @RepCod and RepAnio = @RepAnio;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionRepuestosListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionRepuestosListar]
As
Begin
	Select [RepCod],[RepAnio],[RepuestoCod],[Cantidad],[CostoUnitario] from Reparacion_Repuestos;
End
GO
/****** Object:  StoredProcedure [dbo].[ReparacionRepuestosModificar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReparacionRepuestosModificar]
		@RepCod int,
		@RepAnio int,
		@RepustoCod varchar(9),
		@Cantidad int,
		@CostoUnitario int
As
Begin
	Update Reparacion_Repuestos set RepuestoCod = @RepustoCod, Cantidad = @Cantidad, CostoUnitario = @CostoUnitario
								where RepCod = @RepCod and RepAnio = @RepAnio;
						
End
GO
/****** Object:  StoredProcedure [dbo].[RepuestoAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[RepuestoAlta]
	@RepuestoCod varchar(9),
	@RepuestoDsc varchar(80),
	@RepuestoCosto int,
	@RepuestoTipo varchar(12),
	@ProveedorCod int
As
Begin
	Insert into Repuestos(RepuestoCod,RepuestoDsc,RepuestoCosto,RepuestoTipo,ProveedorCod)
	values(@RepuestoCod,@RepuestoDsc,@RepuestoCosto,@RepuestoTipo,@ProveedorCod);
End
GO
/****** Object:  StoredProcedure [dbo].[RepuestoBaja]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[RepuestoBaja]
	@RepuestoCod varchar(9)
As
Begin
	Delete from Repuestos where RepuestoCod = @RepuestoCod;
End
GO
/****** Object:  StoredProcedure [dbo].[RepuestoBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[RepuestoBuscar]
	@RepuestoCod varchar(9)
As
Begin
	Select * from Repuestos where RepuestoCod = @RepuestoCod;
End
GO
/****** Object:  StoredProcedure [dbo].[RepuestoModificar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[RepuestoModificar]
	@RepuestoCod varchar(9),
	@RepuestoDsc varchar(80),
	@RepuestoCosto int,
	@RepuestoTipo varchar(12),
	@ProveedoreCod int
As
Begin
	Update Repuestos set RepuestoDsc = @RepuestoDsc, 
						 RepuestoCosto = @RepuestoCosto, 
						 RepuestoTipo = @RepuestoTipo, 
						 ProveedorCod = @ProveedoreCod
					 where RepuestoCod = @RepuestoCod;
End
GO
/****** Object:  StoredProcedure [dbo].[RepuestosListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[RepuestosListar]
As
Begin
	Select [RepuestoCod],[RepuestoDsc],[RepuestoCosto],[RepuestoTipo],[ProveedorCod] from Repuestos;
End
GO
/****** Object:  StoredProcedure [dbo].[ReservaAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReservaAlta]
		@ReservaFch Date,
		@ReservaDsc varchar(80),
		@CliCod int,
		@VehiculoCod int
As
Begin
	Insert into Reservas (ReservaFch,ReservaDsc,CliCod,VehiculoCod) 
	values (@ReservaFch,@ReservaDsc,@CliCod,@VehiculoCod);
End
GO
/****** Object:  StoredProcedure [dbo].[ReservaBaja]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReservaBaja]
	@ReservasCod integer
As
Begin
	Delete from Reservas where ReservasCod = @ReservasCod;
End
GO
/****** Object:  StoredProcedure [dbo].[ReservaBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReservaBuscar]
	@ReservasCod integer
As
Begin
	Select * from Reservas where ReservasCod = @ReservasCod;
End
GO
/****** Object:  StoredProcedure [dbo].[ReservaModificar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReservaModificar]
		@ReservasCod integer,
		@ReservaFch Date,
		@ReservaDsc varchar(80),
		@CliCod int,
		@VehiculoCod int
As
Begin
	Update Reservas set ReservaFch = @ReservaFch,
						ReservaDsc = @ReservaDsc,
						CliCod = @CliCod,
						VehiculoCod = @VehiculoCod
					where ReservasCod = @ReservasCod;
End
GO
/****** Object:  StoredProcedure [dbo].[ReservasListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ReservasListar]
As
Begin
	Select [ReservasCod],[ReservaFch],[ReservaDsc],[CliCod],[VehiculoCod] from Reservas;
End
GO
/****** Object:  StoredProcedure [dbo].[UsuarioLoginBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[UsuarioLoginBuscar]
	@CliCi varchar(11),
	@CliContra varchar(12)
As
Begin
	Select [CliCod],[CliNom],[CliCi],[CliTel],[CliDir],[CliMail],[FchRegistro],[CliContra],[Admin] from Clientes where CliCi = @CliCi and CliContra = @CliContra;
End
GO
/****** Object:  StoredProcedure [dbo].[VehiculoAlta]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[VehiculoAlta]
		@Matricula varchar(7),
		@Marca varchar(25),
		@Modelo varchar(25),
		@Anio numeric(4),
		@Color varchar(25)
As
Begin
	Insert into Vehiculos (Matricula,Marca,Modelo,Anio,Color) 
	values (@Matricula,@Marca,@Modelo,@Anio,@Color);
End
GO
/****** Object:  StoredProcedure [dbo].[VehiculoBaja]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[VehiculoBaja]
	@VehiculoCod varchar(9)
As
Begin
	Delete from Vehiculos where VehiculoCod = @VehiculoCod;
End
GO
/****** Object:  StoredProcedure [dbo].[VehiculoBuscar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[VehiculoBuscar]
	@VehiculoCod integer
As
Begin
	Select * from Vehiculos where VehiculoCod = @VehiculoCod;
End
GO
/****** Object:  StoredProcedure [dbo].[VehiculoBuscarMatricula]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[VehiculoBuscarMatricula]
	@Matricula varchar(7)
As
Begin
	Select * from Vehiculos where Matricula = @Matricula;
End
GO
/****** Object:  StoredProcedure [dbo].[VehiculoModificar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[VehiculoModificar]
		@VehiculoCod integer,
		@Matricula varchar(7),
		@Marca varchar(25),
		@Modelo varchar(25),
		@Anio numeric(4),
		@Color varchar(25)
As
Begin
	Update Vehiculos set Matricula = @Matricula,
						 Marca = @Marca,
						 Modelo = @Modelo,
						 Anio = @Anio,
						 Color = @Color
					 where VehiculoCod = @VehiculoCod;
End
GO
/****** Object:  StoredProcedure [dbo].[VehiculosListar]    Script Date: 8/7/2022 18:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[VehiculosListar]
As
Begin
	Select [VehiculoCod],[Matricula],[Marca],[Modelo],[Anio],[Color] from Vehiculos;
End
GO
USE [master]
GO
ALTER DATABASE [taller_mecanico] SET  READ_WRITE 
GO
