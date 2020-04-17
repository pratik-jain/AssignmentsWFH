CREATE TRIGGER trProductionAudit
ON Production.Product
AFTER UPDATE AS
Declare @ProductID int,@PrevPrice money,@updatedPrice money

	SELECT @ProductID = ins.ProductID FROM inserted ins;
	SELECT @PrevPrice = del.ListPrice FROM deleted del;
	SELECT @updatedPrice = ins.ListPrice FROM inserted ins;

BEGIN

INSERT INTO Production.ProductAudit(ProductID,DateTime,PreviousPrice,UpdatedPrice) VALUES(@ProductID,GetDate(),@PrevPrice,@updatedPrice)	
	WHERE ins.ListPrice > 1000
END 
GO

