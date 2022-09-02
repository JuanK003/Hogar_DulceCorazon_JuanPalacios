/*
Created: 31/08/2022
Modified: 01/09/2022
Model: Microsoft SQL Server 2019
Database: MS SQL Server 2019
*/


-- Create tables section -------------------------------------------------

-- Table Children

CREATE TABLE [Children]
(
 [ID_Children] Int IDENTITY(1,1) NOT NULL,
 [Name] Varchar(150) NOT NULL,
 [CUI] Varchar(100) NOT NULL,
 [Date_Birth] Datetime NOT NULL,
 [ID_Genre] Int NULL
)
go

-- Create indexes for table Children

CREATE INDEX [IX_Relationship1] ON [Children] ([ID_Genre])
go

-- Add keys for table Children

ALTER TABLE [Children] ADD CONSTRAINT [PK_Children] PRIMARY KEY ([ID_Children])
go

-- Table Genre

CREATE TABLE [Genre]
(
 [ID_Genre] Int IDENTITY(1,1) NOT NULL,
 [Genre_Type] Varchar(50) NOT NULL
)
go

-- Add keys for table Genre

ALTER TABLE [Genre] ADD CONSTRAINT [PK_Genre] PRIMARY KEY ([ID_Genre])
go

-- Table Adoptive_Parents

CREATE TABLE [Adoptive_Parents]
(
 [ID_AdoptiveParents] Int IDENTITY(1,1) NOT NULL,
 [Name] Varchar(150) NOT NULL,
 [Address] Varchar(150) NOT NULL,
 [Email] Varchar(150) NOT NULL,
 [Cellphone] Varchar(50) NOT NULL,
 [Work_Address] Varchar(150) NOT NULL,
 [ID_Genre] Int NULL,
 [ID_MedicalHistory] Int NULL,
 [ID_AdoptionDetail] Int NULL
)
go

-- Create indexes for table Adoptive_Parents

CREATE INDEX [IX_Relationship2] ON [Adoptive_Parents] ([ID_Genre])
go

CREATE INDEX [IX_Relationship6] ON [Adoptive_Parents] ([ID_MedicalHistory])
go

CREATE INDEX [IX_Relationship8] ON [Adoptive_Parents] ([ID_AdoptionDetail])
go

-- Add keys for table Adoptive_Parents

ALTER TABLE [Adoptive_Parents] ADD CONSTRAINT [PK_Adoptive_Parents] PRIMARY KEY ([ID_AdoptiveParents])
go

-- Table Medical_History

CREATE TABLE [Medical_History]
(
 [ID_MedicalHistory] Int IDENTITY(1,1) NOT NULL,
 [ID_Children] Int NULL,
 [Description] Text NOT NULL,
 [ID_Illeness] Int NULL,
 [Treatment] Varchar(500) NOT NULL,
 [Evaluation_Date] Datetime NOT NULL,
 [ID_BloodType] Int NULL
)
go

-- Create indexes for table Medical_History

CREATE INDEX [IX_Relationship3] ON [Medical_History] ([ID_Illeness])
go

CREATE INDEX [IX_Relationship5] ON [Medical_History] ([ID_Children])
go

CREATE INDEX [IX_Relationship11] ON [Medical_History] ([ID_BloodType])
go

-- Add keys for table Medical_History

ALTER TABLE [Medical_History] ADD CONSTRAINT [PK_Medical_History] PRIMARY KEY ([ID_MedicalHistory])
go

-- Table Illness

CREATE TABLE [Illness]
(
 [ID_Illeness] Int IDENTITY(1,1) NOT NULL,
 [Description] Varchar(150) NOT NULL
)
go

-- Add keys for table Illness

ALTER TABLE [Illness] ADD CONSTRAINT [PK_Illness] PRIMARY KEY ([ID_Illeness])
go

-- Table Adoption_Detail

CREATE TABLE [Adoption_Detail]
(
 [ID_AdoptionDetail] Int IDENTITY(1,1) NOT NULL,
 [Moving_Date] Date NOT NULL,
 [Adoption_Date] Date NOT NULL,
 [Return_Date] Date NOT NULL,
 [ID_Children] Int NULL
)
go

-- Create indexes for table Adoption_Detail

CREATE INDEX [IX_Relationship7] ON [Adoption_Detail] ([ID_Children])
go

-- Add keys for table Adoption_Detail

ALTER TABLE [Adoption_Detail] ADD CONSTRAINT [PK_Adoption_Detail] PRIMARY KEY ([ID_AdoptionDetail])
go

-- Table Temporal_Place

CREATE TABLE [Temporal_Place]
(
 [ID_TemporalPlace] Int IDENTITY(1,1) NOT NULL,
 [Address] Varchar(100) NOT NULL,
 [Cellphone] Varchar(75) NOT NULL,
 [ID_Children] Int NULL,
 [ID_TemporaryCaregiver] Int NULL
)
go

-- Create indexes for table Temporal_Place

CREATE INDEX [IX_Relationship9] ON [Temporal_Place] ([ID_Children])
go

CREATE INDEX [IX_Relationship10] ON [Temporal_Place] ([ID_TemporaryCaregiver])
go

-- Add keys for table Temporal_Place

ALTER TABLE [Temporal_Place] ADD CONSTRAINT [PK_Temporal_Place] PRIMARY KEY ([ID_TemporalPlace])
go

-- Table Temporary_Caregiver

CREATE TABLE [Temporary_Caregiver]
(
 [ID_TemporaryCaregiver] Int IDENTITY(1,1) NOT NULL,
 [Name] Varchar(150) NOT NULL,
 [Address] Varchar(150) NOT NULL,
 [Cellphone] Varchar(50) NOT NULL,
 [Email] Varchar(100) NOT NULL
)
go

-- Add keys for table Temporary_Caregiver

ALTER TABLE [Temporary_Caregiver] ADD CONSTRAINT [PK_Temporary_Caregiver] PRIMARY KEY ([ID_TemporaryCaregiver])
go

-- Table Blood_Type

CREATE TABLE [Blood_Type]
(
 [ID_BloodType] Int IDENTITY(1,1) NOT NULL,
 [Name_Blood] Varchar(100) NOT NULL
)
go

-- Add keys for table Blood_Type

ALTER TABLE [Blood_Type] ADD CONSTRAINT [PK_Blood_Type] PRIMARY KEY ([ID_BloodType])
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [Children] ADD CONSTRAINT [Relationship1] FOREIGN KEY ([ID_Genre]) REFERENCES [Genre] ([ID_Genre]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Adoptive_Parents] ADD CONSTRAINT [Relationship2] FOREIGN KEY ([ID_Genre]) REFERENCES [Genre] ([ID_Genre]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Medical_History] ADD CONSTRAINT [Relationship3] FOREIGN KEY ([ID_Illeness]) REFERENCES [Illness] ([ID_Illeness]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Medical_History] ADD CONSTRAINT [Relationship5] FOREIGN KEY ([ID_Children]) REFERENCES [Children] ([ID_Children]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Adoptive_Parents] ADD CONSTRAINT [Relationship6] FOREIGN KEY ([ID_MedicalHistory]) REFERENCES [Medical_History] ([ID_MedicalHistory]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Adoption_Detail] ADD CONSTRAINT [Relationship7] FOREIGN KEY ([ID_Children]) REFERENCES [Children] ([ID_Children]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Adoptive_Parents] ADD CONSTRAINT [Relationship8] FOREIGN KEY ([ID_AdoptionDetail]) REFERENCES [Adoption_Detail] ([ID_AdoptionDetail]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Temporal_Place] ADD CONSTRAINT [Relationship9] FOREIGN KEY ([ID_Children]) REFERENCES [Children] ([ID_Children]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Temporal_Place] ADD CONSTRAINT [Relationship10] FOREIGN KEY ([ID_TemporaryCaregiver]) REFERENCES [Temporary_Caregiver] ([ID_TemporaryCaregiver]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Medical_History] ADD CONSTRAINT [Relationship11] FOREIGN KEY ([ID_BloodType]) REFERENCES [Blood_Type] ([ID_BloodType]) ON UPDATE NO ACTION ON DELETE NO ACTION
go




