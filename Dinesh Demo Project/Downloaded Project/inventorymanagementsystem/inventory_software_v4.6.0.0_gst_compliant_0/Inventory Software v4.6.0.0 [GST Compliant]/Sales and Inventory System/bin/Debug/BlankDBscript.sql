USE [master]
GO
USE [Inventory_DB]
GO
/****** Object:  Table [dbo].[Activation]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HardwareID] [nchar](100) NOT NULL,
	[ActivationID] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Activation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryName] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[State] [nchar](200) NULL,
	[ContactNo] [nchar](150) NULL,
	[EmailID] [nchar](150) NULL,
	[Logo] [image] NULL,
	[GSTIN] [nchar](30) NULL,
	[CIN] [nchar](30) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company_Contacts]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactPerson] [nchar](150) NOT NULL,
	[ContactNo] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Company_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[CustomerID] [nchar](30) NULL,
	[Name] [nchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nchar](200) NULL,
	[State] [nchar](150) NULL,
	[ZipCode] [nchar](15) NULL,
	[ContactNo] [nchar](150) NULL,
	[EmailID] [nchar](200) NULL,
	[Remarks] [nvarchar](max) NULL,
	[AccountNumber] [nchar](30) NULL,
	[AccountName] [nchar](200) NULL,
	[Bank] [nchar](200) NULL,
	[Branch] [nchar](200) NULL,
	[IFSCCode] [nchar](30) NULL,
	[GSTIN] [nchar](50) NULL,
	[PAN] [nchar](50) NULL,
	[CIN] [nchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailSetting]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServerName] [nchar](150) NOT NULL,
	[SMTPAddress] [nvarchar](250) NOT NULL,
	[Username] [nchar](200) NOT NULL,
	[Password] [nchar](100) NOT NULL,
	[Port] [int] NOT NULL,
	[TLS_SSL_Required] [nchar](10) NOT NULL,
	[IsDefault] [nchar](10) NOT NULL,
	[IsActive] [nchar](10) NOT NULL,
 CONSTRAINT [PK_EmailSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice_Payment]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Payment](
	[IP_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[PaymentMode] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Invoice_Payment] PRIMARY KEY CLUSTERED 
(
	[IP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice_Product]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Product](
	[IPo_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Barcode] [nchar](30) NULL,
	[SalesRate] [decimal](18, 2) NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[DiscountPer] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[CGSTPer] [decimal](18, 2) NOT NULL,
	[CGSTAmt] [decimal](18, 2) NOT NULL,
	[SGSTPer] [decimal](18, 2) NULL,
	[SGSTAmt] [decimal](18, 2) NULL,
	[IGSTPer] [decimal](18, 2) NULL,
	[IGSTAmt] [decimal](18, 2) NULL,
	[CESSPer] [decimal](18, 2) NULL,
	[CESSAmt] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[PurchaseRate] [decimal](18, 2) NOT NULL,
	[Margin] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Invoice_Product] PRIMARY KEY CLUSTERED 
(
	[IPo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceInfo]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceInfo](
	[Inv_ID] [int] NOT NULL,
	[InvoiceNo] [nchar](30) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[TaxType] [nchar](20) NULL,
	[Customer_ID] [int] NOT NULL,
	[SalesmanID] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[FreightCharges] [decimal](18, 2) NULL,
	[OtherCharges] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[RoundOff] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_InvoiceInfo] PRIMARY KEY CLUSTERED 
(
	[Inv_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceInfo1]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceInfo1](
	[Inv_ID] [int] NOT NULL,
	[InvoiceNo] [nchar](30) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[ServiceID] [int] NOT NULL,
	[RepairCharges] [decimal](18, 2) NOT NULL,
	[Upfront] [decimal](18, 2) NOT NULL,
	[ServiceTaxPer] [decimal](18, 2) NOT NULL,
	[ServiceTax] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_InvoiceInfo1] PRIMARY KEY CLUSTERED 
(
	[Inv_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LedgerBook]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Name] [nchar](200) NOT NULL,
	[LedgerNo] [nchar](50) NOT NULL,
	[Label] [nchar](200) NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[PartyID] [nchar](20) NULL,
 CONSTRAINT [PK_LedgerBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nchar](100) NOT NULL,
	[Operation] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[T_ID] [int] NOT NULL,
	[TransactionID] [nchar](20) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PaymentMode] [nchar](30) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](250) NULL,
	[PaymentModeDetails] [nvarchar](250) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[T_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[PID] [int] NOT NULL,
	[ProductCode] [nchar](30) NOT NULL,
	[ProductName] [nchar](200) NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[HSNCode] [nchar](30) NULL,
	[PartNo] [nchar](30) NULL,
	[Description] [nvarchar](max) NULL,
	[CostPrice] [decimal](18, 2) NOT NULL,
	[SellingPrice] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[Barcode] [nchar](30) NULL,
	[ReorderPoint] [int] NOT NULL,
	[OpeningStock] [decimal](18, 2) NOT NULL,
	[PurchaseUnit] [nchar](150) NULL,
	[SalesUnit] [nchar](150) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product_Join]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Join](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Photo] [image] NOT NULL,
 CONSTRAINT [PK_Product_Join] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[PO_ID] [int] NOT NULL,
	[PONo] [nchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[TaxType] [nchar](20) NULL,
	[SGST] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TermsAndConditions] [nvarchar](max) NOT NULL,
	[Terms] [nchar](30) NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[PO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrder_Join]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder_Join](
	[POJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CGSTPer] [decimal](18, 2) NULL,
	[CGSTAmt] [decimal](18, 2) NULL,
	[SGSTPer] [decimal](18, 2) NULL,
	[SGSTAmt] [decimal](18, 2) NULL,
	[IGSTPer] [decimal](18, 2) NULL,
	[IGSTAmt] [decimal](18, 2) NULL,
	[CESSPer] [decimal](18, 2) NULL,
	[CESSAmt] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 2) NULL,
	[DiscountAmt] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_PurchaseOrder_Join] PRIMARY KEY CLUSTERED 
(
	[POJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseReturn]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseReturn](
	[PR_ID] [int] NOT NULL,
	[PRNo] [nchar](30) NULL,
	[Date] [datetime] NULL,
	[PurchaseID] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[FreightCharges] [decimal](18, 2) NULL,
	[OtherCharges] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[RoundOff] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_PurchaseReturn] PRIMARY KEY CLUSTERED 
(
	[PR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseReturn_Join]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseReturn_Join](
	[PRJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseReturnID] [int] NOT NULL,
	[ProductID] [int] NULL,
	[Barcode] [nchar](50) NULL,
	[Qty] [decimal](18, 2) NULL,
	[MRP] [decimal](18, 2) NULL,
	[Price] [decimal](18, 2) NULL,
	[ReturnQty] [decimal](18, 2) NULL,
	[DiscPer] [decimal](18, 2) NULL,
	[DiscAmt] [decimal](18, 2) NULL,
	[CGSTPer] [decimal](18, 2) NULL,
	[CGSTAmt] [decimal](18, 2) NULL,
	[SGSTPer] [decimal](18, 2) NULL,
	[SGSTAmt] [decimal](18, 2) NULL,
	[IGSTPer] [decimal](18, 2) NULL,
	[IGSTAmt] [decimal](18, 2) NULL,
	[CESSPer] [decimal](18, 2) NULL,
	[CESSAmt] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_PurchaseReturn_Join] PRIMARY KEY CLUSTERED 
(
	[PRJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quotation]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation](
	[Q_ID] [int] NOT NULL,
	[QuotationNo] [nchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[TaxType] [nchar](20) NULL,
	[CustomerID] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[RoundOff] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_Quotation] PRIMARY KEY CLUSTERED 
(
	[Q_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quotation_Join]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation_Join](
	[QJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Barcode] [nchar](30) NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DiscountPer] [decimal](18, 2) NOT NULL,
	[DiscountAmt] [decimal](18, 2) NOT NULL,
	[CGSTPer] [decimal](18, 2) NOT NULL,
	[CGSTAmt] [decimal](18, 2) NOT NULL,
	[SGSTPer] [decimal](18, 2) NULL,
	[SGSTAmt] [decimal](18, 2) NULL,
	[IGSTPer] [decimal](18, 2) NULL,
	[IGSTAmt] [decimal](18, 2) NULL,
	[CESSPer] [decimal](18, 2) NULL,
	[CESSAmt] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Quotation_Join] PRIMARY KEY CLUSTERED 
(
	[QJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Registration]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[UserID] [nchar](100) NOT NULL,
	[UserType] [nchar](150) NOT NULL,
	[Password] [nchar](100) NOT NULL,
	[Name] [nchar](200) NOT NULL,
	[ContactNo] [nchar](150) NOT NULL,
	[EmailID] [nchar](200) NULL,
	[JoiningDate] [datetime] NULL,
	[Active] [nchar](10) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesMan]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesMan](
	[SM_ID] [int] NOT NULL,
	[SalesMan_ID] [nchar](30) NULL,
	[Name] [nchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nchar](200) NULL,
	[State] [nchar](150) NULL,
	[ZipCode] [nchar](15) NULL,
	[ContactNo] [nchar](150) NULL,
	[EmailID] [nchar](200) NULL,
	[Remarks] [nvarchar](max) NULL,
	[Photo] [image] NULL,
	[CommissionPer] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SalesMan] PRIMARY KEY CLUSTERED 
(
	[SM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Salesman_Commission]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salesman_Commission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[CommissionPer] [decimal](18, 2) NOT NULL,
	[Commission] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Salesman_Commission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesReturn]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesReturn](
	[SR_ID] [int] NOT NULL,
	[SRNo] [nchar](30) NULL,
	[Date] [datetime] NULL,
	[SalesID] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[FreightCharges] [decimal](18, 2) NULL,
	[OtherCharges] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[RoundOff] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SalesReturn] PRIMARY KEY CLUSTERED 
(
	[SR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesReturn_Join]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesReturn_Join](
	[SRJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[SalesReturnID] [int] NOT NULL,
	[ProductID] [int] NULL,
	[Barcode] [nchar](50) NULL,
	[Qty] [decimal](18, 2) NULL,
	[SalesRate] [decimal](18, 2) NULL,
	[DiscPer] [decimal](18, 2) NULL,
	[DiscAmt] [decimal](18, 2) NULL,
	[CGSTPer] [decimal](18, 2) NULL,
	[CGSTAmt] [decimal](18, 2) NULL,
	[SGSTPer] [decimal](18, 2) NULL,
	[SGSTAmt] [decimal](18, 2) NOT NULL,
	[IGSTPer] [decimal](18, 2) NULL,
	[IGSTAmt] [decimal](18, 2) NULL,
	[CESSPer] [decimal](18, 2) NULL,
	[CESSAmt] [decimal](18, 2) NULL,
	[ReturnQty] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[PurchaseRate] [decimal](18, 2) NULL,
	[Margin] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SalesReturn_Join] PRIMARY KEY CLUSTERED 
(
	[SRJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[S_ID] [int] NOT NULL,
	[ServiceCode] [nchar](30) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ServiceType] [nchar](150) NULL,
	[ServiceCreationDate] [datetime] NOT NULL,
	[ItemDescription] [nvarchar](max) NOT NULL,
	[ProblemDescription] [nvarchar](max) NULL,
	[ChargesQuote] [decimal](18, 2) NOT NULL,
	[AdvanceDeposit] [decimal](18, 2) NOT NULL,
	[EstimatedRepairDate] [datetime] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[Status] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[S_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Setting]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseTax] [nchar](20) NOT NULL,
	[SalesTax] [nchar](20) NOT NULL,
 CONSTRAINT [PK_PurchaseSetting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SMS]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_SMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SMSSetting]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMSSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[APIUrl] [nvarchar](max) NOT NULL,
	[IsDefault] [nchar](10) NOT NULL,
	[IsEnabled] [nchar](10) NOT NULL,
 CONSTRAINT [PK_SMSSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[ST_ID] [int] NOT NULL,
	[InvoiceNo] [nchar](30) NOT NULL,
	[PurchaseType] [nchar](20) NULL,
	[ReferenceNo1] [nchar](30) NULL,
	[ReferenceNo2] [nchar](30) NULL,
	[Date] [datetime] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[SupplierInvoiceNo] [nchar](30) NULL,
	[SupplierInvoiceDate] [datetime] NULL,
	[TaxType] [nchar](20) NULL,
	[SGST] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CESS] [decimal](18, 2) NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[PreviousDue] [decimal](18, 2) NULL,
	[FreightCharges] [decimal](18, 2) NULL,
	[OtherCharges] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[RoundOff] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TotalPayment] [decimal](18, 2) NOT NULL,
	[PaymentDue] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[ST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock_Product]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Product](
	[SP_ID] [int] IDENTITY(1,1) NOT NULL,
	[StockID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Barcode] [nvarchar](50) NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[MRP] [decimal](18, 2) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CGSTPer] [decimal](18, 2) NULL,
	[CGSTAmt] [decimal](18, 2) NULL,
	[SGSTPer] [decimal](18, 2) NULL,
	[SGSTAmt] [decimal](18, 2) NULL,
	[IGSTPer] [decimal](18, 2) NULL,
	[IGSTAmt] [decimal](18, 2) NULL,
	[CESSPer] [decimal](18, 2) NULL,
	[CESSAmt] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 2) NULL,
	[DiscountAmt] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Stock_Product] PRIMARY KEY CLUSTERED 
(
	[SP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockAdjustment]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockAdjustment](
	[SA_ID] [int] NOT NULL,
	[Date] [datetime] NULL,
	[ProductID] [int] NOT NULL,
	[Barcode] [nchar](50) NULL,
	[Qty] [decimal](18, 2) NULL,
	[Add_Subtract] [nchar](10) NULL,
	[ReasonForAdjustment] [nchar](150) NULL,
	[Remarks] [nvarchar](250) NULL,
 CONSTRAINT [PK_StockAdjustment] PRIMARY KEY CLUSTERED 
(
	[SA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[ID] [int] NOT NULL,
	[SubCategoryName] [nchar](150) NOT NULL,
	[Category] [nchar](150) NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] NOT NULL,
	[SupplierID] [nchar](30) NOT NULL,
	[Name] [nchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nchar](200) NULL,
	[State] [nchar](150) NULL,
	[ZipCode] [nchar](15) NULL,
	[ContactNo] [nchar](150) NULL,
	[EmailID] [nchar](200) NULL,
	[Remarks] [nvarchar](max) NULL,
	[AccountName] [nchar](150) NULL,
	[AccountNumber] [nchar](150) NULL,
	[Bank] [nchar](150) NULL,
	[Branch] [nchar](150) NULL,
	[IFSCCode] [nchar](50) NULL,
	[GSTIN] [nchar](100) NULL,
	[PAN] [nchar](100) NULL,
	[CIN] [nchar](30) NULL,
	[OpeningBalanceType] [nchar](20) NULL,
	[OpeningBalance] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupplierLedgerBook]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierLedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Name] [nchar](200) NOT NULL,
	[LedgerNo] [nchar](50) NOT NULL,
	[Label] [nchar](200) NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[PartyID] [nchar](20) NULL,
 CONSTRAINT [PK_SupplierLedgerBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Temp_Stock]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[Barcode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Temp_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnitMaster]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitMaster](
	[Unit] [nchar](150) NOT NULL,
 CONSTRAINT [PK_UnitMaster] PRIMARY KEY CLUSTERED 
(
	[Unit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[Id] [int] NOT NULL,
	[VoucherNo] [nchar](30) NOT NULL,
	[Name] [nchar](150) NULL,
	[Date] [datetime] NOT NULL,
	[Details] [nvarchar](250) NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Voucher_OtherDetails]    Script Date: 2017-08-18 6:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher_OtherDetails](
	[VD_ID] [int] IDENTITY(1,1) NOT NULL,
	[VoucherID] [int] NOT NULL,
	[Particulars] [nchar](200) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Voucher_OtherDetails] PRIMARY KEY CLUSTERED 
(
	[VD_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Registration] ([UserID], [UserType], [Password], [Name], [ContactNo], [EmailID], [JoiningDate], [Active]) VALUES (N'admin                                                                                               ', N'Admin                                                                                                                                                 ', N'MTIzNDU=                                                                                            ', N'Raj Sharma                                                                                                                                                                                              ', N'9827858191                                                                                                                                            ', N'raj20505@gmail.com                                                                                                                                                                                      ', CAST(N'2017-01-13 03:55:22.667' AS DateTime), N'Yes       ')
INSERT [dbo].[Registration] ([UserID], [UserType], [Password], [Name], [ContactNo], [EmailID], [JoiningDate], [Active]) VALUES (N'SP                                                                                                  ', N'Sales Person                                                                                                                                          ', N'MTIzNDU=                                                                                            ', N'Rahul                                                                                                                                                                                                   ', N'9876765654                                                                                                                                            ', N'rahul@gmail.com                                                                                                                                                                                         ', CAST(N'2017-01-13 22:32:12.413' AS DateTime), N'Yes       ')
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([ID], [PurchaseTax], [SalesTax]) VALUES (1, N'Exclusive           ', N'Exclusive           ')
SET IDENTITY_INSERT [dbo].[Setting] OFF
ALTER TABLE [dbo].[PurchaseReturn] ADD  CONSTRAINT [DF_PurchaseReturn_SubTotal]  DEFAULT ((0.00)) FOR [SubTotal]
GO
ALTER TABLE [dbo].[PurchaseReturn] ADD  CONSTRAINT [DF_PurchaseReturn_VATPer]  DEFAULT ((0.00)) FOR [CGST]
GO
ALTER TABLE [dbo].[PurchaseReturn] ADD  CONSTRAINT [DF_PurchaseReturn_VATAmt]  DEFAULT ((0.00)) FOR [SGST]
GO
ALTER TABLE [dbo].[PurchaseReturn] ADD  CONSTRAINT [DF_PurchaseReturn_GrandTotal]  DEFAULT ((0.00)) FOR [GrandTotal]
GO
ALTER TABLE [dbo].[SalesMan] ADD  CONSTRAINT [DF_SalesMan_Commission]  DEFAULT ((0.00)) FOR [CommissionPer]
GO
ALTER TABLE [dbo].[Salesman_Commission] ADD  CONSTRAINT [DF_Salesman_Commission_CommissionPer]  DEFAULT ((0.00)) FOR [CommissionPer]
GO
ALTER TABLE [dbo].[Salesman_Commission] ADD  CONSTRAINT [DF_Salesman_Commission_Commission]  DEFAULT ((0.00)) FOR [Commission]
GO
ALTER TABLE [dbo].[SalesReturn] ADD  CONSTRAINT [DF_SalesReturn_GrandTotal]  DEFAULT ((0.00)) FOR [GrandTotal]
GO
ALTER TABLE [dbo].[Invoice_Payment]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Payment_InvoiceInfo] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice_Payment] CHECK CONSTRAINT [FK_Invoice_Payment_InvoiceInfo]
GO
ALTER TABLE [dbo].[Invoice_Product]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Product_InvoiceInfo] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice_Product] CHECK CONSTRAINT [FK_Invoice_Product_InvoiceInfo]
GO
ALTER TABLE [dbo].[Invoice_Product]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Product_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Invoice_Product] CHECK CONSTRAINT [FK_Invoice_Product_Product]
GO
ALTER TABLE [dbo].[InvoiceInfo]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceInfo_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[InvoiceInfo] CHECK CONSTRAINT [FK_InvoiceInfo_Customer]
GO
ALTER TABLE [dbo].[InvoiceInfo1]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceInfo1_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([S_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[InvoiceInfo1] CHECK CONSTRAINT [FK_InvoiceInfo1_Service]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Registration] FOREIGN KEY([UserID])
REFERENCES [dbo].[Registration] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Registration]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Supplier]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[SubCategory] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SubCategory]
GO
ALTER TABLE [dbo].[Product_Join]  WITH CHECK ADD  CONSTRAINT [FK_Product_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Join] CHECK CONSTRAINT [FK_Product_Join_Product]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Supplier]
GO
ALTER TABLE [dbo].[PurchaseOrder_Join]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrder_Join] CHECK CONSTRAINT [FK_PurchaseOrder_Join_Product]
GO
ALTER TABLE [dbo].[PurchaseOrder_Join]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Join_PurchaseOrder] FOREIGN KEY([PurchaseOrderID])
REFERENCES [dbo].[PurchaseOrder] ([PO_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrder_Join] CHECK CONSTRAINT [FK_PurchaseOrder_Join_PurchaseOrder]
GO
ALTER TABLE [dbo].[PurchaseReturn]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturn_Stock] FOREIGN KEY([PurchaseID])
REFERENCES [dbo].[Stock] ([ST_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PurchaseReturn] CHECK CONSTRAINT [FK_PurchaseReturn_Stock]
GO
ALTER TABLE [dbo].[PurchaseReturn_Join]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturn_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseReturn_Join] CHECK CONSTRAINT [FK_PurchaseReturn_Join_Product]
GO
ALTER TABLE [dbo].[PurchaseReturn_Join]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturn_Join_PurchaseReturn] FOREIGN KEY([PurchaseReturnID])
REFERENCES [dbo].[PurchaseReturn] ([PR_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseReturn_Join] CHECK CONSTRAINT [FK_PurchaseReturn_Join_PurchaseReturn]
GO
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_Customer]
GO
ALTER TABLE [dbo].[Quotation_Join]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Quotation_Join] CHECK CONSTRAINT [FK_Quotation_Join_Product]
GO
ALTER TABLE [dbo].[Quotation_Join]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Join_Quotation] FOREIGN KEY([QuotationID])
REFERENCES [dbo].[Quotation] ([Q_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Quotation_Join] CHECK CONSTRAINT [FK_Quotation_Join_Quotation]
GO
ALTER TABLE [dbo].[Salesman_Commission]  WITH CHECK ADD  CONSTRAINT [FK_Salesman_Commission_InvoiceInfo] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Salesman_Commission] CHECK CONSTRAINT [FK_Salesman_Commission_InvoiceInfo]
GO
ALTER TABLE [dbo].[SalesReturn]  WITH CHECK ADD  CONSTRAINT [FK_SalesReturn_InvoiceInfo] FOREIGN KEY([SalesID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SalesReturn] CHECK CONSTRAINT [FK_SalesReturn_InvoiceInfo]
GO
ALTER TABLE [dbo].[SalesReturn_Join]  WITH CHECK ADD  CONSTRAINT [FK_SalesReturn_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesReturn_Join] CHECK CONSTRAINT [FK_SalesReturn_Join_Product]
GO
ALTER TABLE [dbo].[SalesReturn_Join]  WITH CHECK ADD  CONSTRAINT [FK_SalesReturn_Join_SalesReturn] FOREIGN KEY([SalesReturnID])
REFERENCES [dbo].[SalesReturn] ([SR_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesReturn_Join] CHECK CONSTRAINT [FK_SalesReturn_Join_SalesReturn]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Customer]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Supplier]
GO
ALTER TABLE [dbo].[Stock_Product]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Stock_Product] CHECK CONSTRAINT [FK_Stock_Product_Product]
GO
ALTER TABLE [dbo].[Stock_Product]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product_Stock] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([ST_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock_Product] CHECK CONSTRAINT [FK_Stock_Product_Stock]
GO
ALTER TABLE [dbo].[StockAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_StockAdjustment_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StockAdjustment] CHECK CONSTRAINT [FK_StockAdjustment_Product]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([CategoryName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category]
GO
ALTER TABLE [dbo].[Temp_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Temp_Stock_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Temp_Stock] CHECK CONSTRAINT [FK_Temp_Stock_Product]
GO
ALTER TABLE [dbo].[Voucher_OtherDetails]  WITH CHECK ADD  CONSTRAINT [FK_Voucher_OtherDetails_Voucher] FOREIGN KEY([VoucherID])
REFERENCES [dbo].[Voucher] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Voucher_OtherDetails] CHECK CONSTRAINT [FK_Voucher_OtherDetails_Voucher]
GO
USE [master]
GO
ALTER DATABASE [Inventory_DB] SET  READ_WRITE 
GO
