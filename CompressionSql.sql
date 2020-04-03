USE AdventureWorks2017;
GO
EXEC sp_estimate_data_compression_savings 'Sales', 'SalesOrderDetail', NULL, NULL, 'ROW'
GO