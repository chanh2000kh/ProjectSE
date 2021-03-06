USE [QuanLyDinhDuong]
GO
/****** Object:  User [##MS_PolicyEventProcessingLogin##]    Script Date: 6/10/2021 11:25:34 AM ******/
CREATE USER [##MS_PolicyEventProcessingLogin##] FOR LOGIN [##MS_PolicyEventProcessingLogin##] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [##MS_PolicyTsqlExecutionLogin##]    Script Date: 6/10/2021 11:25:34 AM ******/
CREATE USER [##MS_PolicyTsqlExecutionLogin##] FOR LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [DESKTOP-DIQ358F\ACER]    Script Date: 6/10/2021 11:25:34 AM ******/
CREATE USER [DESKTOP-DIQ358F\ACER] FOR LOGIN [DESKTOP-DIQ358F\ACER] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [DESKTOP-DIQ358F\ACER]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IdLogin] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buoi]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buoi](
	[Id] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGiaNhanXet]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGiaNhanXet](
	[Id] [nvarchar](100) NOT NULL,
	[IdUser] [nvarchar](100) NULL,
	[DanhGia] [int] NULL,
	[NhanXet] [ntext] NULL,
	[Ngay] [date] NULL,
 CONSTRAINT [PK_DanhGiaNhanXet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeHoach]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeHoach](
	[Id] [nvarchar](100) NOT NULL,
	[IdMonAn] [nvarchar](100) NULL,
	[SoLuong] [int] NULL,
	[IdNguoiDung] [nvarchar](100) NULL,
	[IdBuoi] [nvarchar](100) NULL,
	[IdThu] [nvarchar](100) NULL,
	[NgayLapKeHoach] [date] NULL,
	[GhiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_KeHoach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[Id] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Calo] [float] NULL,
	[Carb] [float] NULL,
	[Fat] [float] NULL,
	[Protein] [float] NULL,
	[ThongTin] [ntext] NULL,
	[HinhAnh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[Id] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[ChieuCao] [int] NULL,
	[CanNang] [int] NULL,
	[TanSuatHoatDong] [nvarchar](100) NOT NULL,
	[MucTieu] [nvarchar](100) NULL,
	[CanNangMongMuon] [int] NULL,
	[Thang] [int] NULL,
	[GioiTinh] [nvarchar](100) NULL,
	[IdLogin] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinDinhDuong]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinDinhDuong](
	[Id] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[ThongTin] [ntext] NULL,
	[HinhAnh] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thu]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thu](
	[Id] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThucDon]    Script Date: 6/10/2021 11:25:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThucDon](
	[Id] [nvarchar](100) NOT NULL,
	[IdMonAn] [nvarchar](100) NULL,
	[SoLuong] [int] NULL,
	[Ngay] [date] NULL,
	[IdNguoiDung] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](100) NULL,
	[Calo] [float] NULL,
	[Carb] [float] NULL,
	[Protein] [float] NULL,
	[Fat] [float] NULL,
	[Name] [nvarchar](100) NULL,
	[HinhAnh] [nvarchar](max) NULL,
 CONSTRAINT [PK_ThucDon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admin]  WITH CHECK ADD  CONSTRAINT [FK_Admin_Login] FOREIGN KEY([IdLogin])
REFERENCES [dbo].[Login] ([Id])
GO
ALTER TABLE [dbo].[Admin] CHECK CONSTRAINT [FK_Admin_Login]
GO
ALTER TABLE [dbo].[DanhGiaNhanXet]  WITH CHECK ADD  CONSTRAINT [FK_DanhGiaNhanXet_NguoiDung1] FOREIGN KEY([IdUser])
REFERENCES [dbo].[NguoiDung] ([Id])
GO
ALTER TABLE [dbo].[DanhGiaNhanXet] CHECK CONSTRAINT [FK_DanhGiaNhanXet_NguoiDung1]
GO
ALTER TABLE [dbo].[KeHoach]  WITH CHECK ADD  CONSTRAINT [FK_KeHoach_Buoi] FOREIGN KEY([IdBuoi])
REFERENCES [dbo].[Buoi] ([Id])
GO
ALTER TABLE [dbo].[KeHoach] CHECK CONSTRAINT [FK_KeHoach_Buoi]
GO
ALTER TABLE [dbo].[KeHoach]  WITH CHECK ADD  CONSTRAINT [FK_KeHoach_MonAn] FOREIGN KEY([IdMonAn])
REFERENCES [dbo].[MonAn] ([Id])
GO
ALTER TABLE [dbo].[KeHoach] CHECK CONSTRAINT [FK_KeHoach_MonAn]
GO
ALTER TABLE [dbo].[KeHoach]  WITH CHECK ADD  CONSTRAINT [FK_KeHoach_NguoiDung] FOREIGN KEY([IdNguoiDung])
REFERENCES [dbo].[NguoiDung] ([Id])
GO
ALTER TABLE [dbo].[KeHoach] CHECK CONSTRAINT [FK_KeHoach_NguoiDung]
GO
ALTER TABLE [dbo].[KeHoach]  WITH CHECK ADD  CONSTRAINT [FK_KeHoach_Thu] FOREIGN KEY([IdThu])
REFERENCES [dbo].[Thu] ([Id])
GO
ALTER TABLE [dbo].[KeHoach] CHECK CONSTRAINT [FK_KeHoach_Thu]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_Login] FOREIGN KEY([IdLogin])
REFERENCES [dbo].[Login] ([Id])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_Login]
GO
ALTER TABLE [dbo].[ThucDon]  WITH CHECK ADD  CONSTRAINT [FK_ThucDon_MonAn] FOREIGN KEY([IdMonAn])
REFERENCES [dbo].[MonAn] ([Id])
GO
ALTER TABLE [dbo].[ThucDon] CHECK CONSTRAINT [FK_ThucDon_MonAn]
GO
ALTER TABLE [dbo].[ThucDon]  WITH CHECK ADD  CONSTRAINT [FK_ThucDon_NguoiDung] FOREIGN KEY([IdNguoiDung])
REFERENCES [dbo].[NguoiDung] ([Id])
GO
ALTER TABLE [dbo].[ThucDon] CHECK CONSTRAINT [FK_ThucDon_NguoiDung]
GO
