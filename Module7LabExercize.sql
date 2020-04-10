SELECT * FROM sys.query_store_query_text
SELECT * FROM sys.query_context_settings
SELECT * FROM sys.query_store_query
SELECT * FROM sys.query_store_plan
SELECT * FROM sys.query_store_runtime_stats_interval
SELECT * FROM sys.database_query_store_options

SELECT * FROM sys.dm_exec_query_optimizer_info

use Master
Go
ALTER DATABASE AdventureWorks2017
SET QUERY_STORE = ON SET STATISTICS XML ON;
GO


