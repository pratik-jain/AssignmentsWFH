--creating assembly 
create assembly [Database1]
AUTHORIZATION [dbo]
FROM 'C:\Users\Windows10\source\repos\Database1\bin\Debug\Database1.dll'
WITH PERMISSION_SET = SAFE
GO

--calling user defined scalar funaction written in c#
create function addition (@x int,@y int)
returns int
as
EXTERNAL NAME [Database1].UserDefinedFunctions.SqlFunction1

--executing function
select dbo.addition(1,10)

--calling a user definrd table value CLR funartuion c#
create function TestRegex (@str varchar(50))
returns varchar(50) AS 
EXTERNAL NAME [Database1].UserDefinedFunctions.ValidRegex

select dbo.TestRegex('abc')