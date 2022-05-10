////////////////////////////////////////////////////////////////Products---1/////////////////////////////////////////////
Create Proc Product_Upsert
@Product_Name varchar(50),
@Brand_Id int,
@Category_Id int,
@List_Price decimal(10, 2),
@Model_Year int,
@Id int=0

As
Begin
if @Id = 0
Begin
	Insert into products(product_name, category_id, brand_id, model_year, list_price)
	values(@Product_Name, @Category_Id, @Brand_Id, @Model_Year, @List_Price);

END
Else
BEGIN
	Update products set product_name=@Product_Name, category_id=@Category_Id, brand_id=@Brand_Id, model_year=@Model_Year, list_price=@List_Price
	Where product_id=@Id;
END

END

////////////////////////////////////////////////////////////////////////Products----2/////////////////////////////////////////////////////

Create Proc Load_Products
@Product_Id Int=Null
AS
Begin

Select p.product_id, p.product_name, b.brand_name, c.category_name, p.model_year, p.list_price, p.brand_id, p.category_id from products p
Inner join brands as b on b.brand_id = p.brand_id
Inner join categories as c on c.category_id = p.category_id 
Where (@Product_Id Is Null Or product_id = @Product_Id);

END

/////////////////////////////////////////////////////////////Brands----1/////////////////////////////////////////////////////////////////////////

Create Proc Load_Brands
@BRAND_ID INT=NULL
AS
BEGIN

SELECT * FROM brands
where (@BRAND_ID IS NULL OR brand_id=@BRAND_ID);

END

/////////////////////////////////////////////////////////////Category----1//////////////////////////////////////////////////////////////////////

Create Proc Load_Categories
@CATEGORY_ID INT=NULL
AS
BEGIN

SELECT * FROM category
where (@CATEGORY_ID IS NULL OR category_id=@CATEGORY_ID);

END

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


