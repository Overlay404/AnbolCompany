USE [Anbol]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameCountry] [nvarchar](50) NULL,
	[color] [nvarchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NULL,
	[CustomerId] [int] NULL,
	[ExecutorId] [int] NULL,
	[StageId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[OrderId] [int] NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameProduct] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[date] [datetime] NULL,
	[count] [int] NULL,
	[photoPath] [varbinary](max) NULL,
	[UnitId] [int] NOT NULL,
	[CountryId] [int] NULL,
	[cost] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCountry]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCountry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_ProductCountry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSupply]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSupply](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[SupplyId] [int] NULL,
	[cost] [int] NULL,
	[count] [int] NULL,
 CONSTRAINT [PK_ProductSupply] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleId]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleId](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_RoleId] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stage]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameStage] [nvarchar](50) NULL,
 CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supply]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductCountryId] [int] NULL,
	[date] [datetime] NULL,
	[ProviderId] [int] NULL,
 CONSTRAINT [PK_Supply] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[meaning] [nvarchar](50) NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01.12.2022 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[RoleId] [int] NULL,
	[password] [nvarchar](50) NULL,
	[login] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[firstname] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[GenderId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([id], [name]) VALUES (1, N'Мужской')
INSERT [dbo].[Gender] ([id], [name]) VALUES (2, N'Женский')
INSERT [dbo].[Gender] ([id], [name]) VALUES (3, N'Не двоичный')
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleId] ON 

INSERT [dbo].[RoleId] ([id], [name]) VALUES (1, N'Покупатель')
INSERT [dbo].[RoleId] ([id], [name]) VALUES (2, N'Администратор')
INSERT [dbo].[RoleId] ([id], [name]) VALUES (3, N'Менеджер')
INSERT [dbo].[RoleId] ([id], [name]) VALUES (4, N'Кладовщик')
SET IDENTITY_INSERT [dbo].[RoleId] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [name], [RoleId], [password], [login], [lastname], [firstname], [email], [phone], [GenderId]) VALUES (2, N'Абдул', 1, N'123', N'232', N' Логорифм', N'Жопкович', N'уьвдыдвла', N'192031238', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_RoleId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[RoleId] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_RoleId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_RoleId1] FOREIGN KEY([ExecutorId])
REFERENCES [dbo].[RoleId] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_RoleId1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Stage] FOREIGN KEY([StageId])
REFERENCES [dbo].[Stage] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Stage]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Order]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Unit] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Unit]
GO
ALTER TABLE [dbo].[ProductCountry]  WITH CHECK ADD  CONSTRAINT [FK_ProductCountry_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[ProductCountry] CHECK CONSTRAINT [FK_ProductCountry_Country]
GO
ALTER TABLE [dbo].[ProductCountry]  WITH CHECK ADD  CONSTRAINT [FK_ProductCountry_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[ProductCountry] CHECK CONSTRAINT [FK_ProductCountry_Product]
GO
ALTER TABLE [dbo].[ProductSupply]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupply_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[ProductSupply] CHECK CONSTRAINT [FK_ProductSupply_Product]
GO
ALTER TABLE [dbo].[ProductSupply]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupply_Supply] FOREIGN KEY([SupplyId])
REFERENCES [dbo].[Supply] ([id])
GO
ALTER TABLE [dbo].[ProductSupply] CHECK CONSTRAINT [FK_ProductSupply_Supply]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_ProductCountry] FOREIGN KEY([ProductCountryId])
REFERENCES [dbo].[ProductCountry] ([id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_ProductCountry]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Provider] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Provider] ([id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Provider]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Gender]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleId] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_RoleId]
GO
