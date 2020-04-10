SELECT * FROM INFORMATION_SCHEMA.TABLES
SELECT * FROM INFORMATION_SCHEMA.PARAMETERS;
SELECT * FROM INFORMATION_SCHEMA.COLUMNS;
SELECT * FROM INFORMATION_SCHEMA.COLUMN_PRIVILEGES;
SELECT * FROM INFORMATION_SCHEMA.CHECK_CONSTRAINTS;
SElect * from sys.dm_exec_connections
SELECT * FROM  sys.views
SELECT * FROM  sys.tables
SELECT * FROM  sys.objects
SELECT * FROM sys.dm_exec_connections
SELECT * FROM sys.dm_exec_sessions
SELECT * FROm sys.dm_exec_requests
SELECT * FROM sys.dm_exec_query_stats

SELECT SCHEMA_NAME(schema_id) AS 'Schema', name AS 'Table'
	FROM sys.tables
	WHERE OBJECTPROPERTY(object_id,'TableHasIdentity') = 1
	ORDER BY 'Schema', 'Table';
	GO


CREATE VIEW vwVacationByJObTitile WITH ENCRYPTION AS 
	SELECT	JobTitle,Gender,VacationHours
	FROM	HumanResources.Employee	where CurrentFlag = 1
GO

DROP VIEW vwVacationByJObTitile		

CREATE VIEW vOnlineProducts as
	SELECT ProductId,Name,ProductNumber,Color,DaysToManufacture,Size,SizeUnitMeasureCode,ListPrice,Weight
		FROM Production.Product

SELECT * FROM vOnlineProducts