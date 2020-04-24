DECLARE @xmlSchema nvarchar(max)  
Set @xmlSchema  = N' copy the schema collection here'  
CREATE XML SCHEMA COLLECTION MyCollection AS @xmlSchema   

Select * FROM Students FOR XML AUTO
Select * FROM Students FOR XML RAW
Select * FROM Students FOR XML PATH

SELECT 1 AS TAG,NULL AS PARENT,
	s.StudentId AS[Student!1!StudentId!ELEMENT],
	s.StudentName AS[Student!1!StudentName!ELEMENT], 
	s.Age AS[Student!1!Age!ELEMENT] 
	from Students s FOR XML EXPLICIT


Create PROC production.GetAvailableModelsAsXML
	AS BEGIN
	SELECT * FROM Production.Products ORDER BY SellStartDate,ProductName ASC FOR XML RAW,ROOT('AvaiableModels')
	END

alter PROC dbo.UpdateSalesTerritoriesByXML @SalesPersonMods as xml
AS BEGIN
	Declare @terrId int 
	set @terrId = ( SELECT Results.SalesPerson.value('SalesTerritoryId[1]','int') AS SalesTerritoryId
		FROM @SalesPersonMods.nodes('SalesPerson') Results(SalesPerson))
	update Sales.SalesPerson SET SalesTerritoryId = @terrId
END
