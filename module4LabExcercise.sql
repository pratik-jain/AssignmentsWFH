ALTER TABLE DirectMarketing.Opportunity
ALTER COLUMN OpportunityID int NOT NULL;
GO

ALTER TABLE DirectMarketing.Opportunity
ALTER COLUMN ProspectID int NOT NULL;
GO
ALTER TABLE DirectMarketing.Opportunity
ALTER COLUMN DateRaised datetime NOT NULL;
GO

ALTER TABLE DirectMarketing.Opportunity
ADD CONSTRAINT PK_Opportunity PRIMARY KEY CLUSTERED (OpportunityID, ProspectID);
GO

ALTER TABLE DirectMarketing.Opportunity
ADD CONSTRAINT dfDateRaised
DEFAULT (SYSDATETIME()) FOR DateRaised; 
GO

INSERT INTO [DirectMarketing].[Opportunity]
           ([OpportunityID]
           ,[ProspectID]
           ,[Likelihood]
           ,[Rating]
           ,[EstimatedClosingDate]
           ,[EstimatedRevenue])
     VALUES
           (1,1,8,'A','12/12/2013',123000.00)
GO


