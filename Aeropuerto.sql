USE [master]
GO
/****** Object:  Database [Aeropuerto]    Script Date: 13/8/2021 21:46:45 ******/
CREATE DATABASE [Aeropuerto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Aeropuerto', FILENAME = N'J:\Program\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Aeropuerto.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Aeropuerto_log', FILENAME = N'J:\Program\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Aeropuerto_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Aeropuerto] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Aeropuerto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Aeropuerto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Aeropuerto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Aeropuerto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Aeropuerto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Aeropuerto] SET ARITHABORT OFF 
GO
ALTER DATABASE [Aeropuerto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Aeropuerto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Aeropuerto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Aeropuerto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Aeropuerto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Aeropuerto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Aeropuerto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Aeropuerto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Aeropuerto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Aeropuerto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Aeropuerto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Aeropuerto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Aeropuerto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Aeropuerto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Aeropuerto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Aeropuerto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Aeropuerto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Aeropuerto] SET RECOVERY FULL 
GO
ALTER DATABASE [Aeropuerto] SET  MULTI_USER 
GO
ALTER DATABASE [Aeropuerto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Aeropuerto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Aeropuerto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Aeropuerto] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Aeropuerto] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Aeropuerto] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Aeropuerto', N'ON'
GO
ALTER DATABASE [Aeropuerto] SET QUERY_STORE = OFF
GO
USE [Aeropuerto]
GO
/****** Object:  Table [dbo].[Acceso]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acceso](
	[Usuario] [nvarchar](50) NOT NULL,
	[Contrasena] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aerolinea]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aerolinea](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Aerolinea] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Departamentoid] [int] NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CiudadOrigenId] [int] NOT NULL,
	[CiudadDestinoId] [int] NOT NULL,
	[FechaSalida] [datetime] NOT NULL,
	[FechaLlegada] [datetime] NOT NULL,
	[NumeroVuelo] [nvarchar](20) NOT NULL,
	[AerolineaId] [int] NOT NULL,
	[EstadoVuelo] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Vuelos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_VuelosArolineaNumeroVuelo]    Script Date: 13/8/2021 21:46:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_VuelosArolineaNumeroVuelo] ON [dbo].[Vuelo]
(
	[AerolineaId] ASC,
	[NumeroVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelos_CiudadDestinoId] FOREIGN KEY([CiudadDestinoId])
REFERENCES [dbo].[Ciudad] ([Id])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelos_CiudadDestinoId]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelos_CiudadOrigenId] FOREIGN KEY([CiudadOrigenId])
REFERENCES [dbo].[Ciudad] ([Id])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelos_CiudadOrigenId]
GO
/****** Object:  StoredProcedure [dbo].[Sp_AccesoBuscar]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jesus Albeiro Gaviria
-- Create date: 2021/08/12
-- Description: Buscar Acceso por usuario y contraseña
-- =============================================
CREATE PROCEDURE [dbo].[Sp_AccesoBuscar]
	@Usuario nvarchar(50),
	@Contrasena nvarchar(max)

AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		Usuario,
		Contrasena
	FROM
		Acceso
	WHERE
		Usuario = Usuario AND
		Contrasena = @Contrasena

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_AerolineaBuscar]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--==========================================
-- Author:		Jesus Albeiro Gaviria
-- Create date: 2021/08/13
-- Description: Buscar Aerolinea
-- =============================================
CREATE PROCEDURE [dbo].[Sp_AerolineaBuscar]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		Id,
		Nombre
	FROM
		Aerolinea

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_CiudadBuscar]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--==========================================
-- Author:		Jesus Albeiro Gaviria
-- Create date: 2021/08/13
-- Description: Buscar ciudades
-- =============================================
CREATE PROCEDURE [dbo].[Sp_CiudadBuscar]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		Id,
		Nombre
	FROM
		Ciudad

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_VueloActualizar]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jesus Albeiro Gaviria
-- Create date: 2021/08/12
-- Description:	Actualizar vuelo
-- =============================================
CREATE PROCEDURE [dbo].[Sp_VueloActualizar]
	@Id int,
	@CiudadOrigenId int,
	@CiudadDestinoId int,
	@FechaSalida datetime,
	@FechaLlegada datetime,
	@NumeroVuelo nvarchar(20),
	@AerolineaId int,
	@EstadoVuelo nvarchar(10)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE 
		Vuelo 
	SET
		CiudadOrigenId = @CiudadOrigenId,
		CiudadDestinoId = @CiudadDestinoId,
		FechaSalida = @FechaSalida,
		FechaLlegada = @FechaLlegada,
		NumeroVuelo = @NumeroVuelo,
		AerolineaId = @AerolineaId,
		EstadoVuelo = @EstadoVuelo
	WHERE
		Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_VueloBuscar]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jesus Albeiro Gaviria
-- Create date: 2021/08/12
-- Description: Buscar vuelos
-- =============================================
CREATE PROCEDURE [dbo].[Sp_VueloBuscar]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		vuelo.Id,
		ciudadOrigen.Nombre CiudadOrigen,
		ciudadDestino.Nombre CiudadDestino,
		vuelo.FechaSalida,
		vuelo.FechaLlegada,
		vuelo.NumeroVuelo,
		aerolinea.Nombre Aerolinea,
		vuelo.EstadoVuelo
	FROM
		Vuelo vuelo
	INNER JOIN Ciudad ciudadOrigen on vuelo.CiudadOrigenId = ciudadOrigen.Id
	INNER JOIN Ciudad ciudadDestino on vuelo.CiudadDestinoId = ciudadDestino.Id
	INNER JOIN Aerolinea aerolinea on vuelo.AerolineaId = aerolinea.Id

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_VueloBuscarPorId]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jesus Albeiro Gaviria
-- Create date: 2021/08/12
-- Description: Buscar vuelo por id 
-- =============================================
CREATE PROCEDURE [dbo].[Sp_VueloBuscarPorId]
	@Id  int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		Id,
		CiudadOrigenId,
		CiudadDestinoId,
		FechaSalida,
		FechaLlegada,
		NumeroVuelo,
		AerolineaId,
		EstadoVuelo
	FROM
		Vuelo
	WHERE
		Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_VueloCrear]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jesus Albeiro Gaviria
-- Create date: 2021/08/12
-- Description:	Crear nuevo vuelo
-- =============================================
CREATE PROCEDURE [dbo].[Sp_VueloCrear]
	@CiudadOrigenId int,
	@CiudadDestinoId int,
	@FechaSalida datetime,
	@FechaLlegada datetime,
	@NumeroVuelo nvarchar(20),
	@AerolineaId int,
	@EstadoVuelo nvarchar(10)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Vuelo(
		CiudadOrigenId, 
		CiudadDestinoId, 
		FechaSalida, 
		FechaLlegada, 
		NumeroVuelo, 
		AerolineaId, 
		EstadoVuelo)
	VALUES(
		@CiudadOrigenId,
		@CiudadDestinoId,
		@FechaSalida,
		@FechaLlegada,
		@NumeroVuelo,
		@AerolineaId,
		@EstadoVuelo)
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_VueloEliminar]    Script Date: 13/8/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jesus Albeiro Gaviria
-- Create date: 2021/08/12
-- Description:	Eliminar vuelo
-- =============================================
CREATE PROCEDURE [dbo].[Sp_VueloEliminar]
	@Id  int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE
		Vuelo 
	WHERE
		Id = @Id
END
GO
USE [master]
GO
ALTER DATABASE [Aeropuerto] SET  READ_WRITE 
GO

INSERT INTO Acceso (Usuario,Contrasena) values('jgaviria', '123456')
