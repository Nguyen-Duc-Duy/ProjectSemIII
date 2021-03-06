USE [master]
GO
/****** Object:  Database [ManagerHotel_ProjectsXixao]    Script Date: 6/6/2020 9:52:08 AM ******/
CREATE DATABASE [ManagerHotel_ProjectsXixao]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ManagerHotel_ProjectsXixao', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ManagerHotel_ProjectsXixao.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ManagerHotel_ProjectsXixao_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ManagerHotel_ProjectsXixao_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ManagerHotel_ProjectsXixao].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET ARITHABORT OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET  MULTI_USER 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ManagerHotel_ProjectsXixao]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bills](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_em] [int] NOT NULL,
	[id_cus] [int] NOT NULL,
	[dateFrom] [varchar](50) NOT NULL,
	[decript] [nvarchar](256) NULL,
	[stt] [int] NOT NULL DEFAULT ((1)),
	[date_created] [datetime] NULL DEFAULT (getdate()),
	[date_update] [datetime] NULL DEFAULT (getdate()),
	[dateTo] [varchar](50) NOT NULL,
	[Prepay] [float] NULL,
	[InputMoney] [float] NOT NULL,
	[OutMoney] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] NOT NULL,
	[CountryCode] [nvarchar](100) NOT NULL,
	[CommonName] [nvarchar](100) NULL,
	[FormalName] [nvarchar](100) NULL,
	[CountryType] [nvarchar](100) NULL,
	[CountrySubType] [nvarchar](100) NULL,
	[Sovereignty] [nvarchar](100) NULL,
	[Capital] [nvarchar](100) NULL,
	[CurrencyCode] [nvarchar](100) NULL,
	[CurrencyName] [nvarchar](100) NULL,
	[TelephoneCode] [nvarchar](100) NULL,
	[CountryCode3] [nvarchar](100) NULL,
	[CountryNumber] [nvarchar](100) NULL,
	[InternetCountryCode] [nvarchar](100) NULL,
	[SortOrder] [int] NULL,
	[IsPublished] [bit] NULL,
	[Flags] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](32) NULL,
	[sex] [tinyint] NOT NULL,
	[car_personal] [varchar](15) NOT NULL,
	[adults] [int] NULL,
	[childrens] [int] NULL,
	[id_nation] [int] NOT NULL,
	[phone] [varchar](10) NULL,
	[stt] [int] NOT NULL DEFAULT ((1)),
	[decript] [nvarchar](256) NULL,
	[date_created] [datetime] NULL DEFAULT (getdate()),
	[date_update] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Details_Bill]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Details_Bill](
	[id_bill] [int] NOT NULL,
	[id_ser] [int] NOT NULL,
	[quantity] [tinyint] NOT NULL DEFAULT ((1)),
	[id_room] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_bill] ASC,
	[id_ser] ASC,
	[id_room] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](32) NULL,
	[email] [varchar](125) NULL,
	[phone] [varchar](10) NULL,
	[pass] [varchar](125) NULL,
	[avt] [varchar](256) NULL CONSTRAINT [DF_avt]  DEFAULT ('avt.png'),
	[stt] [int] NOT NULL DEFAULT ((1)),
	[decript] [nvarchar](256) NULL,
	[date_created] [datetime] NULL DEFAULT (getdate()),
	[date_update] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](125) NOT NULL,
	[id_type] [int] NOT NULL,
	[address_room] [nvarchar](125) NOT NULL,
	[descript] [nvarchar](256) NULL,
	[stt] [int] NOT NULL DEFAULT ((1)),
	[date_created] [datetime] NULL DEFAULT (getdate()),
	[date_update] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Servicers]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](125) NOT NULL,
	[price] [float] NOT NULL,
	[sale] [float] NULL,
	[stt] [int] NOT NULL DEFAULT ((1)),
	[descript] [nvarchar](256) NULL,
	[date_created] [datetime] NULL DEFAULT (getdate()),
	[date_update] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Types_Room]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types_Room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](125) NOT NULL,
	[stt] [int] NOT NULL DEFAULT ((1)),
	[moneys] [float] NOT NULL,
	[descript] [nvarchar](256) NULL,
	[date_created] [datetime] NULL DEFAULT (getdate()),
	[date_update] [datetime] NULL DEFAULT (getdate()),
	[AdultStandar] [int] NULL,
	[AdultMax] [int] NULL,
	[ChildrentStandar] [int] NULL,
	[ChildrentMax] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_BillCus] FOREIGN KEY([id_cus])
REFERENCES [dbo].[Customers] ([id])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_BillCus]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_BillEm] FOREIGN KEY([id_em])
REFERENCES [dbo].[Employees] ([id])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_BillEm]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_CusCountry] FOREIGN KEY([id_nation])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_CusCountry]
GO
ALTER TABLE [dbo].[Details_Bill]  WITH CHECK ADD  CONSTRAINT [FK_DetailsBill] FOREIGN KEY([id_bill])
REFERENCES [dbo].[Bills] ([id])
GO
ALTER TABLE [dbo].[Details_Bill] CHECK CONSTRAINT [FK_DetailsBill]
GO
ALTER TABLE [dbo].[Details_Bill]  WITH CHECK ADD  CONSTRAINT [FK_DetailsRoom] FOREIGN KEY([id_room])
REFERENCES [dbo].[Rooms] ([id])
GO
ALTER TABLE [dbo].[Details_Bill] CHECK CONSTRAINT [FK_DetailsRoom]
GO
ALTER TABLE [dbo].[Details_Bill]  WITH CHECK ADD  CONSTRAINT [FK_DetailsSer] FOREIGN KEY([id_ser])
REFERENCES [dbo].[Servicers] ([id])
GO
ALTER TABLE [dbo].[Details_Bill] CHECK CONSTRAINT [FK_DetailsSer]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_RoomsType] FOREIGN KEY([id_type])
REFERENCES [dbo].[Types_Room] ([id])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_RoomsType]
GO
/****** Object:  StoredProcedure [dbo].[billsOfMonth]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[billsOfMonth]
@dateStart varchar(50),@dateEnd varchar(50)
as
select b.dateFrom,COUNT(dateFrom) as 'num' from Bills b where dateFrom between '2020-06-01' and '2020-06-30' group by dateFrom

GO
/****** Object:  StoredProcedure [dbo].[billsOfMonthByDay]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[billsOfMonthByDay]
@date varchar(50)
as
select b.dateFrom ,COUNT(dateFrom) as 'num' from Bills b where dateFrom = @date group by dateFrom
GO
/****** Object:  StoredProcedure [dbo].[RoomsAble]    Script Date: 6/6/2020 9:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoomsAble]
@formDate varchar(12),@toDate varchar(12),@adults int, @childrents int
as 
select r.id, r.name,t.name as 'typeRoom',t.moneys as 'price',r.address_room as 'address_room',t.AdultMax,t.ChildrentMax,t.AdultStandar,t.ChildrentStandar from Rooms r
join Types_Room t
on t.id = r.id_type
 where r.id not in 
 (select db.id_room from Bills b
	join Details_Bill db
	on b.id = db.id_bill
	where dateFrom = @formDate or dateTo = @toDate
			
)and ((t.AdultMax >= @adults and t.ChildrentMax >= @childrents) or (t.AdultStandar >=@adults and t.ChildrentStandar >= @childrents))

GO
USE [master]
GO
ALTER DATABASE [ManagerHotel_ProjectsXixao] SET  READ_WRITE 
GO
