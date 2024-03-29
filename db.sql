USE [DBTuyenSinh]
GO
/****** Object:  Table [dbo].[DonVi]    Script Date: 11/06/2023 10:42:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonVi](
	[DonVi_ID] [int] IDENTITY(1,1) NOT NULL,
	[DonVi_Ma] [nchar](20) NOT NULL,
	[DonVi_Ten] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DonVi] PRIMARY KEY CLUSTERED 
(
	[DonVi_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocBa]    Script Date: 11/06/2023 10:42:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocBa](
	[HocBa_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[HocBa_HocKi] [int] NOT NULL,
	[HocBa_Lop] [int] NOT NULL,
	[HocBa_DiemToan] [float] NULL,
	[HocBa_DiemLi] [float] NULL,
	[HocBa_DiemHoa] [float] NULL,
	[HocBa_DiemVan] [float] NULL,
	[HocBa_DiemAnh] [float] NULL,
	[HocBa_DiemGDCD] [float] NULL,
	[HocBa_DiemSinh] [float] NULL,
	[HocBa_DiemSu] [float] NULL,
	[HocBa_DiemDia] [float] NULL,
	[HocBa_HocLuc] [int] NULL,
	[ThiSinh_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_HocBa] PRIMARY KEY CLUSTERED 
(
	[HocBa_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQua]    Script Date: 11/06/2023 10:42:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQua](
	[KetQua_ID] [int] IDENTITY(1,1) NOT NULL,
	[KetQua_DiemTH1] [float] NULL,
	[KetQua_DiemTH2] [float] NULL,
	[KetQua_DiemTH3] [float] NULL,
	[KetQua_DiemTH4] [float] NULL,
	[TrangThai] [bit] NULL,
	[HocBa_ID] [bigint] NULL,
 CONSTRAINT [PK_KetQua] PRIMARY KEY CLUSTERED 
(
	[KetQua_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 11/06/2023 10:42:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[Nganh_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nganh_Ma] [nchar](20) NOT NULL,
	[Nganh_Ten] [nvarchar](250) NOT NULL,
	[Nganh_ToHopXT] [text] NULL,
	[Nganh_SP] [bit] NOT NULL,
	[DonVi_ID] [int] NOT NULL,
	[Nganh_Ma_Ten] [nvarchar](500) NULL,
 CONSTRAINT [PK_Nganh] PRIMARY KEY CLUSTERED 
(
	[Nganh_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 11/06/2023 10:42:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[NguoiDung_ID] [int] IDENTITY(1,1) NOT NULL,
	[NguoiDung_UserName] [nvarchar](250) NULL,
	[NguoiDung_Pass] [nvarchar](250) NULL,
	[NguoiDung_HoTen] [nvarchar](250) NULL,
	[NguoiDung_DienThoai] [nvarchar](250) NULL,
	[NguoiDung_Email] [nvarchar](250) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[NguoiDung_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThiSinh]    Script Date: 11/06/2023 10:42:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThiSinh](
	[ThiSinh_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ThiSinh_HoTen] [nvarchar](100) NOT NULL,
	[ThiSinh_DienThoai] [nchar](20) NOT NULL,
	[ThiSinh_HoSoDinhKem] [nvarchar](3000) NOT NULL,
	[ThiSinh_BangTN] [nvarchar](500) NULL,
	[ThiSinh_CCCD] [nvarchar](500) NULL,
	[ThiSinh_NgayNop] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[Nganh_ID] [int] NULL,
	[ID_Nganh1] [int] NULL,
	[ID_Nganh2] [int] NULL,
	[ID_Nganh3] [int] NULL,
 CONSTRAINT [PK_ThiSinh] PRIMARY KEY CLUSTERED 
(
	[ThiSinh_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DonVi] ON 

INSERT [dbo].[DonVi] ([DonVi_ID], [DonVi_Ma], [DonVi_Ten]) VALUES (1, N'cntt                ', N'Khoa Công nghệ thông tin và truyền thông')
SET IDENTITY_INSERT [dbo].[DonVi] OFF
GO
SET IDENTITY_INSERT [dbo].[Nganh] ON 

INSERT [dbo].[Nganh] ([Nganh_ID], [Nganh_Ma], [Nganh_Ten], [Nganh_ToHopXT], [Nganh_SP], [DonVi_ID], [Nganh_Ma_Ten]) VALUES (1, N'7480201             ', N'Công nghệ thông tin ', N'A,B,C,D', 1, 1, N'7480201-Công nghệ thông tin ')
INSERT [dbo].[Nganh] ([Nganh_ID], [Nganh_Ma], [Nganh_Ten], [Nganh_ToHopXT], [Nganh_SP], [DonVi_ID], [Nganh_Ma_Ten]) VALUES (2, N'7140210             ', N'Sư phạm Tin', N'A,B,C,D', 0, 1, N'7140210-Sư phạm Tin')
INSERT [dbo].[Nganh] ([Nganh_ID], [Nganh_Ma], [Nganh_Ten], [Nganh_ToHopXT], [Nganh_SP], [DonVi_ID], [Nganh_Ma_Ten]) VALUES (3, N'7320104             ', N'Truyền thông đa phương tiện', N'A,B,C,D', 0, 1, N'7320104-Truyền thông đa phương tiện')
SET IDENTITY_INSERT [dbo].[Nganh] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([NguoiDung_ID], [NguoiDung_UserName], [NguoiDung_Pass], [NguoiDung_HoTen], [NguoiDung_DienThoai], [NguoiDung_Email]) VALUES (1, N'adminfict', N'2FDA08E054C2A4B7132B602B6698C802', N'Admin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[ThiSinh] ON 

INSERT [dbo].[ThiSinh] ([ThiSinh_ID], [ThiSinh_HoTen], [ThiSinh_DienThoai], [ThiSinh_HoSoDinhKem], [ThiSinh_BangTN], [ThiSinh_CCCD], [ThiSinh_NgayNop], [DiaChi], [Nganh_ID], [ID_Nganh1], [ID_Nganh2], [ID_Nganh3]) VALUES (2, N'Vũ Hương Giang', N'0941537993          ', N'UploadedFiles/0941537993_133308675908659223_inbound7866099615972904433.pdf#', NULL, N'UploadedCCCD/0941537993_133308675908629302_inbound2887480946346507462.jpg', N'2023/06/10 17:46:26', NULL, 3, 0, 0, 0)
INSERT [dbo].[ThiSinh] ([ThiSinh_ID], [ThiSinh_HoTen], [ThiSinh_DienThoai], [ThiSinh_HoSoDinhKem], [ThiSinh_BangTN], [ThiSinh_CCCD], [ThiSinh_NgayNop], [DiaChi], [Nganh_ID], [ID_Nganh1], [ID_Nganh2], [ID_Nganh3]) VALUES (3, N'Hoàng Văn Bính', N'0989194765          ', N'UploadedFiles/0989194765_133308685703499594_image.jpg#', NULL, N'UploadedCCCD/0989194765_133308685703479644_image.jpg', N'2023/06/10 18:15:26', NULL, 3, 0, 0, 0)
INSERT [dbo].[ThiSinh] ([ThiSinh_ID], [ThiSinh_HoTen], [ThiSinh_DienThoai], [ThiSinh_HoSoDinhKem], [ThiSinh_BangTN], [ThiSinh_CCCD], [ThiSinh_NgayNop], [DiaChi], [Nganh_ID], [ID_Nganh1], [ID_Nganh2], [ID_Nganh3]) VALUES (4, N'Trương Thị Trang Linh ', N'0349328035          ', N'UploadedFiles/0349328035_133308774199046782_inbound192162967872290271.pdf#', NULL, N'UploadedCCCD/0349328035_133308774198867261_inbound8358264141838529771.pdf', N'2023/06/10 20:30:19', NULL, 1, 0, 0, 0)
INSERT [dbo].[ThiSinh] ([ThiSinh_ID], [ThiSinh_HoTen], [ThiSinh_DienThoai], [ThiSinh_HoSoDinhKem], [ThiSinh_BangTN], [ThiSinh_CCCD], [ThiSinh_NgayNop], [DiaChi], [Nganh_ID], [ID_Nganh1], [ID_Nganh2], [ID_Nganh3]) VALUES (5, N'Dương Thị Ngọc Ánh', N'0966768317          ', N'UploadedFiles/0966768317_133308774482898739_Học bạ.pptx#', NULL, N'UploadedCCCD/0966768317_133308774482898739_căn cuo.jpg', N'2023/06/10 20:30:48', NULL, 1, 0, 0, 0)
INSERT [dbo].[ThiSinh] ([ThiSinh_ID], [ThiSinh_HoTen], [ThiSinh_DienThoai], [ThiSinh_HoSoDinhKem], [ThiSinh_BangTN], [ThiSinh_CCCD], [ThiSinh_NgayNop], [DiaChi], [Nganh_ID], [ID_Nganh1], [ID_Nganh2], [ID_Nganh3]) VALUES (6, N'Phạm Thị Hằng', N'0392840284          ', N'UploadedFiles/0392840284_133308796738961114_IMG_0395-hình ảnh.zip#UploadedFiles/0392840284_133308796738961114_IMG_0395-hình ảnh.zip#', NULL, N'UploadedCCCD/0392840284_133308796738951137_IMG_0343-hình ảnh.zip', N'2023/06/10 21:07:53', NULL, 1, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[ThiSinh] OFF
GO
ALTER TABLE [dbo].[Nganh] ADD  CONSTRAINT [DF_Nganh_NganhSP]  DEFAULT ((0)) FOR [Nganh_SP]
GO
ALTER TABLE [dbo].[HocBa]  WITH CHECK ADD  CONSTRAINT [FK_HocBa_ThiSinh] FOREIGN KEY([ThiSinh_ID])
REFERENCES [dbo].[ThiSinh] ([ThiSinh_ID])
GO
ALTER TABLE [dbo].[HocBa] CHECK CONSTRAINT [FK_HocBa_ThiSinh]
GO
ALTER TABLE [dbo].[KetQua]  WITH CHECK ADD  CONSTRAINT [FK_KetQua_HocBa] FOREIGN KEY([HocBa_ID])
REFERENCES [dbo].[HocBa] ([HocBa_ID])
GO
ALTER TABLE [dbo].[KetQua] CHECK CONSTRAINT [FK_KetQua_HocBa]
GO
ALTER TABLE [dbo].[Nganh]  WITH CHECK ADD  CONSTRAINT [FK_Nganh_DonVi] FOREIGN KEY([DonVi_ID])
REFERENCES [dbo].[DonVi] ([DonVi_ID])
GO
ALTER TABLE [dbo].[Nganh] CHECK CONSTRAINT [FK_Nganh_DonVi]
GO
ALTER TABLE [dbo].[ThiSinh]  WITH CHECK ADD  CONSTRAINT [FK_ThiSinh_Nganh] FOREIGN KEY([Nganh_ID])
REFERENCES [dbo].[Nganh] ([Nganh_ID])
GO
ALTER TABLE [dbo].[ThiSinh] CHECK CONSTRAINT [FK_ThiSinh_Nganh]
GO
