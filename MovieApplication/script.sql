USE [master]
GO
/****** Object:  Database [Problem6Db]    Script Date: 25-03-2020 11:04:03 ******/
CREATE DATABASE [Problem6Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Problem6Db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Problem6Db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Problem6Db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Problem6Db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Problem6Db] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Problem6Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Problem6Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Problem6Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Problem6Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Problem6Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Problem6Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Problem6Db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Problem6Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Problem6Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Problem6Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Problem6Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Problem6Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Problem6Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Problem6Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Problem6Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Problem6Db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Problem6Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Problem6Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Problem6Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Problem6Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Problem6Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Problem6Db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Problem6Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Problem6Db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Problem6Db] SET  MULTI_USER 
GO
ALTER DATABASE [Problem6Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Problem6Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Problem6Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Problem6Db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Problem6Db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Problem6Db] SET QUERY_STORE = OFF
GO
USE [Problem6Db]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 25-03-2020 11:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[ActorId] [int] IDENTITY(1,1) NOT NULL,
	[ActorName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 25-03-2020 11:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[MovieName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vMovieDetails]    Script Date: 25-03-2020 11:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vMovieDetails]
AS
SELECT        dbo.Movies.MovieId, dbo.Movies.MovieName, dbo.Actors.ActorName, dbo.Actors.ActorId
FROM            dbo.Movies INNER JOIN
                         dbo.Actors ON dbo.Movies.ActorId = dbo.Actors.ActorId
GO
/****** Object:  Table [dbo].[MovieActors]    Script Date: 25-03-2020 11:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieActors](
	[MovieActorId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[ActorId] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MovieActors]  WITH CHECK ADD  CONSTRAINT [FK_MovieActors_Actors] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([ActorId])
GO
ALTER TABLE [dbo].[MovieActors] CHECK CONSTRAINT [FK_MovieActors_Actors]
GO
ALTER TABLE [dbo].[MovieActors]  WITH CHECK ADD  CONSTRAINT [FK_MovieActors_Movies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
GO
ALTER TABLE [dbo].[MovieActors] CHECK CONSTRAINT [FK_MovieActors_Movies]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Movies"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Actors"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vMovieDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vMovieDetails'
GO
USE [master]
GO
ALTER DATABASE [Problem6Db] SET  READ_WRITE 
GO
