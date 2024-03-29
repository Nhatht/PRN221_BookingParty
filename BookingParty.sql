USE [master]
GO
/****** Object:  Database [BookingParty]    Script Date: 26/03/2024 2:00:39 SA ******/
CREATE DATABASE [BookingParty]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookingParty', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BookingParty.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookingParty_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BookingParty_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookingParty] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookingParty].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookingParty] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookingParty] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookingParty] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookingParty] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookingParty] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookingParty] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BookingParty] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookingParty] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookingParty] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookingParty] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookingParty] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookingParty] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookingParty] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookingParty] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookingParty] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookingParty] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookingParty] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookingParty] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookingParty] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookingParty] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookingParty] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookingParty] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookingParty] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookingParty] SET  MULTI_USER 
GO
ALTER DATABASE [BookingParty] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookingParty] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookingParty] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookingParty] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookingParty] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookingParty] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BookingParty] SET QUERY_STORE = OFF
GO
USE [BookingParty]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 26/03/2024 2:00:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](255) NULL,
	[Gender] [nvarchar](255) NULL,
	[Role] [nvarchar](255) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [accounts_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogPost]    Script Date: 26/03/2024 2:00:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account_Id] [int] NOT NULL,
	[Heading] [nvarchar](255) NOT NULL,
	[PageTitle] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](255) NOT NULL,
	[Short_Description] [nvarchar](255) NOT NULL,
	[ImageUrl] [nvarchar](255) NOT NULL,
	[PublishedDate] [datetime] NOT NULL,
	[Visible] [bit] NOT NULL,
 CONSTRAINT [blogpost_id_primary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 26/03/2024 2:00:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuestId] [int] NOT NULL,
	[PartyId] [int] NOT NULL,
	[TotalPrice] [decimal](8, 2) NOT NULL,
	[NumberOfPeople] [int] NOT NULL,
	[Inquiry] [nvarchar](255) NULL,
	[StartDate] [datetime] NOT NULL,
	[Status] [nvarchar](200) NOT NULL,
 CONSTRAINT [booking_id_primary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedBack]    Script Date: 26/03/2024 2:00:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBack](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuestId] [int] NOT NULL,
	[PartyId] [int] NOT NULL,
	[Comment] [nvarchar](255) NOT NULL,
	[ReviewDate] [datetime] NOT NULL,
 CONSTRAINT [feedback_id_primary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Party]    Script Date: 26/03/2024 2:00:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Party](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HostId] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NOT NULL,
	[City] [nvarchar](255) NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
	[Theme] [nvarchar](255) NULL,
	[Package] [nvarchar](255) NULL,
	[Max_People] [int] NOT NULL,
	[Image_Url] [varchar](255) NOT NULL,
	[Request] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [party_id_primary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (1, N'nhatht.02@gmail.com', N'123', N'Nhật ', N'098765432', N'Male', N'Admin', 1)
INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (2, N'user@gmail.com', N'123', N'Hiệp Nguyên', N'098765432', N'Female', N'User', 1)
INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (3, N'host@gmail.com', N'123', N'John', N'012345678', N'Male', N'Host', 1)
INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (4, N'user2@gmail.com', N'123', N'Hoàng Anh', N'098765432', N'Male', N'User', 1)
INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (5, N'Host2@gmail.com', N'123', N'Imeida', N'098765432', N'Female', N'Host', 1)
INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (6, N'guest@gmail.com', N'1234567', N'Anh Duy', N'0976464259', N'Male', N'Guest', 1)
INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (8, N'nhat2002@gmail.com', N'2002', N'Trịnh Nhật', N'0123456789', N'Male', N'User', 1)
INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (10, N'hoanganh002@gmail.com', N'002', N'Hào', N'0234567899', N'Male', N'User', 1)
INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (11, N'mitokulam@gmail.com', N'123', N'Thầy Lâm', N'0913277862', N'Male', N'Host', 1)
INSERT [dbo].[Accounts] ([id], [Email], [Password], [UserName], [Phone], [Gender], [Role], [Status]) VALUES (12, N'mitolamit@gmail.com', N'123', N'Thầy Lâm', N'012345678', N'Male', N'User', 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogPost] ON 

INSERT [dbo].[BlogPost] ([Id], [Account_Id], [Heading], [PageTitle], [Content], [Short_Description], [ImageUrl], [PublishedDate], [Visible]) VALUES (5, 3, N'10 Best Venues for Corporate Events  ', N'Top Corporate Event Venues ', N'Planning a corporate event? Check out...', N'Discover top venues...   ', N'https://factoriacp.com/wp-content/uploads/2019/05/0362-1.jpg', CAST(N'2023-05-10T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BlogPost] ([Id], [Account_Id], [Heading], [PageTitle], [Content], [Short_Description], [ImageUrl], [PublishedDate], [Visible]) VALUES (6, 5, N'How to Plan the Perfect Wedding', N'Ultimate Wedding Planning Guide ', N'Planning your dream wedding?', N'Step-by-step guide', N'https://i.pinimg.com/originals/f0/7d/d8/f07dd8645a96b777575af3837d26eb4a.jpg', CAST(N'2023-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BlogPost] ([Id], [Account_Id], [Heading], [PageTitle], [Content], [Short_Description], [ImageUrl], [PublishedDate], [Visible]) VALUES (7, 8, N'Hosting Memorable Birthday Parties  ', N'Birthday Party Ideas', N'Make your next birthday party unforgettable', N'Fun themes and activities', N'https://lucha-libre.co.uk/wp-content/uploads/2023/11/lidya-nada-MD_ha01Bk7c-unsplash-1024x683.jpg', CAST(N'2023-07-20T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[BlogPost] ([Id], [Account_Id], [Heading], [PageTitle], [Content], [Short_Description], [ImageUrl], [PublishedDate], [Visible]) VALUES (8, 10, N'Choosing the Right Caterer for Your Event', N'Catering Services Guide   ', N'Catering can make or break your event', N'Tips for selecting the best caterer', N'https://www.noshcatering.com.au/wp-content/uploads/2018/07/chuttersnap-464815-unsplash.jpg', CAST(N'2023-08-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BlogPost] OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (7, 1, 15, CAST(100000.00 AS Decimal(8, 2)), 40, N'asasa', CAST(N'2024-02-10T00:00:00.000' AS DateTime), N'Not Approved')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (8, 2, 15, CAST(10000.00 AS Decimal(8, 2)), 30, N'xss', CAST(N'2024-03-30T00:00:00.000' AS DateTime), N'Approved')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (9, 2, 15, CAST(10000.00 AS Decimal(8, 2)), 38, N'12asdfasd', CAST(N'2024-03-29T00:00:00.000' AS DateTime), N'Deny')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (10, 2, 15, CAST(100.00 AS Decimal(8, 2)), 39, NULL, CAST(N'2024-03-30T00:00:00.000' AS DateTime), N'Paid')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (37, 3, 17, CAST(500.00 AS Decimal(8, 2)), 400, N'We are interested in hosting', CAST(N'2024-02-10T00:00:00.000' AS DateTime), N'Finish')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (39, 3, 18, CAST(400.00 AS Decimal(8, 2)), 300, N'Planning a birthday party', CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'Paid')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (40, 3, 23, CAST(700.00 AS Decimal(8, 2)), 450, N'Family gathering celebration', CAST(N'2024-01-01T00:00:00.000' AS DateTime), N'Paid')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (41, 5, 25, CAST(700.00 AS Decimal(8, 2)), 450, N'Looking for a venue for', CAST(N'2023-09-05T00:00:00.000' AS DateTime), N'Deni')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (42, 5, 24, CAST(600.00 AS Decimal(8, 2)), 350, N'Planning a small business', CAST(N'2024-01-15T00:00:00.000' AS DateTime), N'Paid')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (43, 3, 26, CAST(200.00 AS Decimal(8, 2)), 150, N'School reunion gathering', CAST(N'2024-01-25T00:00:00.000' AS DateTime), N'Approved')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (44, 5, 16, CAST(400.00 AS Decimal(8, 2)), 100, N'Require AV equipment for presentations', CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'Finish')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (45, 5, 10, CAST(300.00 AS Decimal(8, 2)), 150, N'Require vegetarian menu options', CAST(N'2023-11-05T00:00:00.000' AS DateTime), N'Finish')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (49, 3, 15, CAST(600.00 AS Decimal(8, 2)), 300, N'Interested in floral arrangements for the event', CAST(N'2023-12-30T00:00:00.000' AS DateTime), N'Finish')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (50, 5, 23, CAST(400.00 AS Decimal(8, 2)), 200, N'Require additional parking arrangements', CAST(N'2024-02-14T00:00:00.000' AS DateTime), N'Not Approved')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (51, 3, 25, CAST(400.00 AS Decimal(8, 2)), 200, N'Interested in wine tasting options', CAST(N'2023-08-07T00:00:00.000' AS DateTime), N'Finish')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (52, 5, 23, CAST(500.00 AS Decimal(8, 2)), 300, N'Interested in photography services', CAST(N'2023-09-09T00:00:00.000' AS DateTime), N'Finish')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (53, 5, 23, CAST(400.00 AS Decimal(8, 2)), 250, N'Interested in customized cocktail menu', CAST(N'2023-10-10T00:00:00.000' AS DateTime), N'Finish')
INSERT [dbo].[Booking] ([Id], [GuestId], [PartyId], [TotalPrice], [NumberOfPeople], [Inquiry], [StartDate], [Status]) VALUES (54, 2, 28, CAST(1000.00 AS Decimal(8, 2)), 250, NULL, CAST(N'2024-03-24T00:00:00.000' AS DateTime), N'Finish')
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedBack] ON 

INSERT [dbo].[FeedBack] ([Id], [GuestId], [PartyId], [Comment], [ReviewDate]) VALUES (6, 2, 28, N'Good ', CAST(N'2024-03-25T13:40:58.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[FeedBack] OFF
GO
SET IDENTITY_INSERT [dbo].[Party] ON 

INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (3, 5, N'Bien Xanh Restaurant is located on the blue beach of Nha Trang city, with beautiful and breathtaking scenery. This is the ideal destination for weddings, parties or important events', N'Blue Sea Restaurant', N'Nha Trang', CAST(1800.00 AS Decimal(8, 2)), N'Wedding', N'Diamond Package', 400, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711341402/hsnob1i0y5wzzqfpowqr.jpg', 1, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (5, 3, N'Royal Convention Center is a large and comfortable conference room, located in the heart of Ho Chi Minh City. With luxurious space and modern equipment', N'Royal Convention Center', N'Ho Chi Minh', CAST(1500.00 AS Decimal(8, 2)), N'Gala', N'Gold Package', 300, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711340928/zdhtygbqnwyggdlcphyg.jpg', 1, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (7, 5, N'Hoa Lai Reception Hall is a luxurious and cozy reception space located in the center of Da Nang city. With unique design and beautiful interior.', N'Restaurant on the High Floor', N'Ha Noi', CAST(3000.00 AS Decimal(8, 2)), N'Upstairs Party', N'Diamond Package', 500, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711341422/gj4aawpazxjxeqqn7bvu.webp', 1, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (8, 5, N'The High Floor Restaurant is a modern culinary space with beautiful views of the city scene in the center of Hanoi capital. With luxurious space and modern equipment, this restaurant is very suitable for high-end parties such as upstairs parties.', N'Highlands Conference Center', N'Da Lat', CAST(1800.00 AS Decimal(8, 2)), N'Industrial Party', N'Diamond Package', 400, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711341467/m1c8jnmqwlosq9xtak3g.jpg', 1, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (10, 3, N'Country Farm Area is an ideal resort space in Da Lat city, with green nature and large space. This farm is an ideal place for weddings, outdoor parties or other outdoor entertainment events.', N'Wine Farm', N'Da Lat', CAST(2200.00 AS Decimal(8, 2)), N'Party in the Field', N'Gold Package', 200, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711340757/gjde0igferhbxdbhftgn.jpg', 1, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (15, 3, N'Tiệc cưới ', N'Mary room', N'Q9', CAST(1000.00 AS Decimal(8, 2)), N'Mary room', N'Vip', 500, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711340186/ghnt7inhjbn2vcgythbg.jpg', 3, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (16, 3, N'Nhà Hàng Đồ Ăn', N'Nhà Hàng', N'Q3', CAST(122.00 AS Decimal(8, 2)), N'Nhà Hàng', N'VIP', 70, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711340258/d1nubiznnd3m9apq6hhc.jpg', 0, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (17, 3, N'Nhà thổ ', N'Mary room Duy', N'Nhà Duy', CAST(2000.00 AS Decimal(8, 2)), N'Tân Hôn', N'VIP', 50, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711340405/j3ie8v4ji9we2xnfmvhy.jpg', 0, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (18, 5, N'Asdas', N'12', N'Nhà Duy', CAST(12200.00 AS Decimal(8, 2)), N'Tân Hôn', N'VIP', 60000000, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711309666/awn5ubvuye26aqoac1l2.png', 0, 0)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (23, 3, N'The Sky Lounge offers stunning views of the city skyline and is perfect for cocktail parties or evening receptions. With its chic atmosphere and premium amenities', N'The Sky Lounge', N'Cần Thơ', CAST(250.00 AS Decimal(8, 2)), N'Cocktail Party', N'Diamond Package', 150, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711340993/uopyprm7fnxksjazr3ry.jpg', 1, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (24, 5, N'The Grand Ballroom at Riverside Hotel is a majestic venue suitable for grand receptions and gala dinners.', N'The Grand Ballroom', N'Vinh', CAST(3000.00 AS Decimal(8, 2)), N'Gala Dinner', N'Platinum Package', 300, N'https://th.bing.com/th/id/R.85b07f8ddac2576478ff935ba019f3c9?rik=CzQTKgKUpRxEww&pid=ImgRaw&r=0', 1, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (25, 5, N'The Rooftop Terrace boasts panoramic views of the cityscape and is an ideal venue for rooftop parties or sunset cocktails.', N'The Rooftop Terrace', N'Cà Mau', CAST(200.00 AS Decimal(8, 2)), N'Rooftop Party', N'Diamond Package', 120, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711342293/gnyw70npc4jobiqvhbii.webp', 1, 1)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (26, 3, N'Quyên Góp Từ Thiện', N'Từ Thiện', N'Hồ Chí Minh', CAST(100.00 AS Decimal(8, 2)), N'Quyên Góp Cho Em', N'Normal', 1000, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711339344/rlanuuchfiosmtr3ckto.png', 0, 0)
INSERT [dbo].[Party] ([Id], [HostId], [Description], [Name], [City], [Price], [Theme], [Package], [Max_People], [Image_Url], [Request], [Status]) VALUES (28, 11, N'FPT ', N'FPT TP Q9', N'HCM', CAST(1000.00 AS Decimal(8, 2)), N'FPT', N'VIP', 300, N'http://res.cloudinary.com/dkmytrmhe/image/upload/v1711348441/ql43fpq0kyxorafm19bl.jpg', 0, 1)
SET IDENTITY_INSERT [dbo].[Party] OFF
GO
ALTER TABLE [dbo].[Booking] ADD  CONSTRAINT [df_Status]  DEFAULT ('Not Approved') FOR [Status]
GO
ALTER TABLE [dbo].[Party] ADD  DEFAULT ('0') FOR [Request]
GO
ALTER TABLE [dbo].[BlogPost]  WITH CHECK ADD  CONSTRAINT [blogpost_account_id_foreign] FOREIGN KEY([Account_Id])
REFERENCES [dbo].[Accounts] ([id])
GO
ALTER TABLE [dbo].[BlogPost] CHECK CONSTRAINT [blogpost_account_id_foreign]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [booking_gusetid_foreign] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Accounts] ([id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [booking_gusetid_foreign]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [booking_partyid_foreign] FOREIGN KEY([PartyId])
REFERENCES [dbo].[Party] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [booking_partyid_foreign]
GO
ALTER TABLE [dbo].[FeedBack]  WITH CHECK ADD  CONSTRAINT [feedback_guestid_foreign] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Accounts] ([id])
GO
ALTER TABLE [dbo].[FeedBack] CHECK CONSTRAINT [feedback_guestid_foreign]
GO
ALTER TABLE [dbo].[FeedBack]  WITH CHECK ADD  CONSTRAINT [feedback_partyid_foreign] FOREIGN KEY([PartyId])
REFERENCES [dbo].[Party] ([Id])
GO
ALTER TABLE [dbo].[FeedBack] CHECK CONSTRAINT [feedback_partyid_foreign]
GO
ALTER TABLE [dbo].[Party]  WITH CHECK ADD  CONSTRAINT [party_hostid_foreign] FOREIGN KEY([HostId])
REFERENCES [dbo].[Accounts] ([id])
GO
ALTER TABLE [dbo].[Party] CHECK CONSTRAINT [party_hostid_foreign]
GO
USE [master]
GO
ALTER DATABASE [BookingParty] SET  READ_WRITE 
GO
