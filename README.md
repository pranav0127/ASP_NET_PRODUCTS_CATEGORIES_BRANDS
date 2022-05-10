# ASP_NET_PRODUCTS_CATEGORIES_BRANDS

# ASP.NET-BRAND_CATEGORY_PRODUCT

***Change the Connection String in the database folder***

## First Create a Local Database in your system : 
### Now Create a Three tables named : 
 1. **products**
 2. **brands**
 3. **categories**

## using script given below:

1. 
CREATE TABLE [dbo].[brands](<br>
	[brand_id] [int] IDENTITY(1,1) NOT NULL,<br>
	[brand_name] [varchar](255) NOT NULL,<br>
PRIMARY KEY CLUSTERED <br>
(<br>
	[brand_id] ASC<br>
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]<br>
) ON [PRIMARY]<br>



2.
CREATE TABLE [dbo].[categories](<br>
	[category_id] [int] IDENTITY(1,1) NOT NULL,<br>
	[category_name] [varchar](255) NOT NULL,<br>
PRIMARY KEY CLUSTERED <br>
(<br>
	[category_id] ASC<br>
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]<br>
) ON [PRIMARY]<br>



3.
CREATE TABLE [dbo].[products](<br>
	[product_id] [int] IDENTITY(1,1) NOT NULL,<br>
	[product_name] [varchar](255) NOT NULL,<br>
	[brand_id] [int] NOT NULL,<br>
	[category_id] [int] NOT NULL,<br>
	[model_year] [smallint] NOT NULL,<br>
	[list_price] [decimal](10, 2) NOT NULL,<br>
PRIMARY KEY CLUSTERED <br>
(<br>
	[product_id] ASC<br>
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]<br>
) ON [PRIMARY]<br>
GO<br>




ALTER TABLE [dbo].[products]  WITH CHECK ADD FOREIGN KEY([brand_id])<br>
REFERENCES [dbo].[brands] ([brand_id])<br>
ON UPDATE CASCADE<br>
ON DELETE CASCADE<br>
GO<br>

ALTER TABLE [dbo].[products]  WITH CHECK ADD FOREIGN KEY([category_id])<br>
REFERENCES [dbo].[categories] ([category_id])<br>
ON UPDATE CASCADE<br>
ON DELETE CASCADE<br>
GO<br>
