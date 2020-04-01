SELECT * FROM Production.Product ORDER BY ProductID;

create SCHEMA Directmarketing ;

create table Directmarketing.Competitor (CompetitorId int NOT NULL, Competitor varchar(30) NOT NULL, 
		CompetitorDomain varchar(20) NOT NULL,  CompetitorAddress varchar(max) NOT NULL,PRIMARY KEY (CompetitorId));

create table Directmarketing.TVAdvertisement  (TVAdvertisementId int NOT NULL, TVAdvertisementCompany varchar(20) NOT NULL,
	TVAdvertisementDuration time NOT NULL, TVAdvertisementCategory varchar(20) NOT NULL ,PRIMARY KEY(TVAdvertisementId) );

CREATE TABLE Directmarketing.CampaignResponse(CampId int NOT NULL, CampName varchar(20) NOT NULL, CampStartDate datetime NOT NULL,
	CampEndDate datetime NOT NULL, ResponseProfit int NOT NULL, CampLead varchar(50) NOT NULL, ResponseCount int NOT NULL,
		PRIMAry KEy (CampId));