USE [master]
GO
/****** Object:  Database [CMS]    Script Date: 28/03/2021 10:02:42 a. m. ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'CMS')
BEGIN
CREATE DATABASE [CMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [CMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CMS] SET  MULTI_USER 
GO
ALTER DATABASE [CMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [CMS]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 28/03/2021 10:02:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permiso]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Permiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Permiso] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PermisoXRol]    Script Date: 28/03/2021 10:02:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PermisoXRol]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PermisoXRol](
	[IdRol] [int] NOT NULL,
	[IdPermiso] [int] NOT NULL,
 CONSTRAINT [PK_PermisoXRol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC,
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 28/03/2021 10:02:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rol]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 28/03/2021 10:02:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[NombreCompleto] [varchar](200) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](100) NULL,
	[Email] [varchar](100) NOT NULL,
	[Edad] [int] NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 
GO
INSERT [dbo].[Permiso] ([Id], [Permiso]) VALUES (1, N'Noticias')
GO
INSERT [dbo].[Permiso] ([Id], [Permiso]) VALUES (2, N'Usuarios')
GO
INSERT [dbo].[Permiso] ([Id], [Permiso]) VALUES (3, N'Usuarios_Filtro_Nombre')
GO
INSERT [dbo].[Permiso] ([Id], [Permiso]) VALUES (4, N'Usuarios_Filtro_Rol')
GO
INSERT [dbo].[Permiso] ([Id], [Permiso]) VALUES (5, N'Usuarios_Editar')
GO
INSERT [dbo].[Permiso] ([Id], [Permiso]) VALUES (6, N'Usuarios_Crear')
GO
INSERT [dbo].[Permiso] ([Id], [Permiso]) VALUES (7, N'Usuarios_Eliminar')
GO
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (1, 1)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (1, 2)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (1, 3)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (1, 4)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (1, 5)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (1, 6)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (1, 7)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (2, 1)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (3, 2)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (3, 3)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (3, 4)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (4, 2)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (4, 3)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (4, 4)
GO
INSERT [dbo].[PermisoXRol] ([IdRol], [IdPermiso]) VALUES (4, 5)
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 
GO
INSERT [dbo].[Rol] ([Id], [Rol]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[Rol] ([Id], [Rol]) VALUES (2, N'Visitante')
GO
INSERT [dbo].[Rol] ([Id], [Rol]) VALUES (3, N'Asistente')
GO
INSERT [dbo].[Rol] ([Id], [Rol]) VALUES (4, N'Editor')
GO
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id], [Nombre], [Password], [NombreCompleto], [Direccion], [Telefono], [Email], [Edad], [IdRol]) VALUES (1, N'admon', N'123', N'Administrador del Sistema', N'Bogota', N'314567778', N'admon@cms.com', 35, 1)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PermisoXRol_Permiso]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermisoXRol]'))
ALTER TABLE [dbo].[PermisoXRol]  WITH CHECK ADD  CONSTRAINT [FK_PermisoXRol_Permiso] FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permiso] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PermisoXRol_Permiso]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermisoXRol]'))
ALTER TABLE [dbo].[PermisoXRol] CHECK CONSTRAINT [FK_PermisoXRol_Permiso]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PermisoXRol_Rol]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermisoXRol]'))
ALTER TABLE [dbo].[PermisoXRol]  WITH CHECK ADD  CONSTRAINT [FK_PermisoXRol_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PermisoXRol_Rol]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermisoXRol]'))
ALTER TABLE [dbo].[PermisoXRol] CHECK CONSTRAINT [FK_PermisoXRol_Rol]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuario_Rol]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuario_Rol]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
USE [master]
GO
ALTER DATABASE [CMS] SET  READ_WRITE 
GO
