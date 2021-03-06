USE [TREKKINGDB]
GO
/****** Object:  StoredProcedure [dbo].[spAddOrder]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spAddOrder]
(
@UserID int,
@ProductID int,
@Quantity int,
@SubTotal decimal(18, 0),
@Country nvarchar(50),
@City nvarchar(50),
@PostCode nvarchar(50),
@FullAddress nvarchar(MAX),
@ContactName nvarchar(50),
@OrderDate datetime,
@OrderNumber nvarchar(10),
@OrderPrcSize nvarchar(10)
)
AS
BEGIN
INSERT INTO Orders
(
UserID,
ProductID,
Quantity,
SubTotal,
Country,
City,
PostCode,
FullAddress,
ContactName,
OrderDate,
OrderNumber,
OrderPrcSize
)
VALUES
(
@UserID,
@ProductID,
@Quantity,
@SubTotal,
@Country,
@City,
@PostCode,
@FullAddress,
@ContactName,
@OrderDate,
@OrderNumber,
@OrderPrcSize
)

END
GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spLogin]
(
@Email nvarchar(MAX),
@Password nvarchar(50)
)
AS
BEGIN

SELECT * FROM Users WHERE Email = @Email AND Password = @Password

END

GO
/****** Object:  StoredProcedure [dbo].[spRegister]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spRegister]
(
@Email nvarchar(MAX),
@Password nvarchar(50)
)
AS
BEGIN
INSERT INTO Users(Email,Password) VALUES (@Email,@Password)

END
GO
/****** Object:  StoredProcedure [dbo].[spRegisterDetail]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spRegisterDetail]
(
@Name_Surname nvarchar(50),
@UserID int
)
AS
BEGIN

INSERT INTO UserDetails(Name_Surname,UserID) VALUES (@Name_Surname,@UserID)
END

GO
/****** Object:  StoredProcedure [dbo].[spStokAzalt]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spStokAzalt]
(
@ProductID int,
@Quantity int
)
AS
BEGIN

declare @adet int, @yeniAdet int;
Select @adet = ProductQuantity from Products WHERE ProductID = @ProductID
SET @yeniAdet = @adet - @Quantity


UPDATE Products
SET
ProductQuantity = @yeniAdet
WHERE ProductID = @ProductID

END
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[SubTotal] [decimal](18, 0) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[PostCode] [nvarchar](50) NOT NULL,
	[FullAddress] [nvarchar](max) NOT NULL,
	[ContactName] [nvarchar](50) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderNumber] [nvarchar](10) NOT NULL,
	[OrderPrcSize] [nvarchar](10) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCateTwo]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCateTwo](
	[ProductCatTwoID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductCateTwo] PRIMARY KEY CLUSTERED 
(
	[ProductCatTwoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCatOne]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCatOne](
	[ProductCatOneID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductCatOne] PRIMARY KEY CLUSTERED 
(
	[ProductCatOneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[UnitPrice] [decimal](18, 0) NOT NULL,
	[ProductCatOneID] [int] NOT NULL,
	[ProductCatTwoID] [int] NOT NULL,
	[ProductQuantity] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurSize]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurSize](
	[PurSizeID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[SizeID] [int] NOT NULL,
 CONSTRAINT [PK_PurSize] PRIMARY KEY CLUSTERED 
(
	[PurSizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Size]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[SizeID] [int] IDENTITY(1,1) NOT NULL,
	[SizeName] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserDetailID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name_Surname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 16.7.2017 13:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCateTwo] FOREIGN KEY([ProductCatTwoID])
REFERENCES [dbo].[ProductCateTwo] ([ProductCatTwoID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCateTwo]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCatOne] FOREIGN KEY([ProductCatOneID])
REFERENCES [dbo].[ProductCatOne] ([ProductCatOneID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCatOne]
GO
ALTER TABLE [dbo].[PurSize]  WITH CHECK ADD  CONSTRAINT [FK_PurSize_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[PurSize] CHECK CONSTRAINT [FK_PurSize_Products]
GO
ALTER TABLE [dbo].[PurSize]  WITH CHECK ADD  CONSTRAINT [FK_PurSize_Size] FOREIGN KEY([SizeID])
REFERENCES [dbo].[Size] ([SizeID])
GO
ALTER TABLE [dbo].[PurSize] CHECK CONSTRAINT [FK_PurSize_Size]
GO
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_Users]
GO
