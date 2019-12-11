CREATE DATABASE FightAndFeast
GO

USE FightAndFeast
CREATE TABLE [Customer] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [FirstName] NVARCHAR(50),
  [LastName] NVARCHAR(50),
  [DateCreated] DATETIME,
  [HasFought] BIT,
  [Email] NVARCHAR(50),
  [Phone] NVARCHAR(50),
  [CartId] INT
)
GO

CREATE TABLE [Seller] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(50),
  [DateCreated] DATETIME
)
GO

CREATE TABLE [Insurance] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Provider] NVARCHAR(50),
  [TypeId] INT
)
GO

CREATE TABLE [InsuranceType] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(50)
)
GO

CREATE TABLE [EmergencyContact] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [FirstName] NVARCHAR(50),
  [LastName] NVARCHAR(50),
  [Relationship] NVARCHAR(50),
  [Phone] NVARCHAR(50)
)
GO

CREATE TABLE [Club] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(50),
  [Address] NVARCHAR(50),
  [Phone] NVARCHAR(50),
  [Capacity] INT,
  [Description] NVARCHAR(500)
)
GO

CREATE TABLE [Product] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(50),
  [TypeId] INT,
  [Price] MONEY,
  [Description] NVARCHAR(500),
  [DateCreated] DATETIME,
  [EventDate] DATETIME
)
GO

CREATE TABLE [ProductType] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(50)
)
GO

CREATE TABLE [Order] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [CustomerId] INT,
  [Total] MONEY,
  [CustomerPaymentTypeId] INT
)
GO

CREATE TABLE [Cart] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Total] MONEY
)
GO

CREATE TABLE [PaymentType] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(50),
)
GO

CREATE TABLE [CustomerPaymentType] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [CustomerId] INT,
  [PaymentTypeId] INT,
  [AccountNum] NVARCHAR(50)
)
GO

CREATE TABLE [CustomerInsurance] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [CustomerId] INT,
  [InsuranceId] INT,
  [PlanName] NVARCHAR(50),
  [SubscriberNum] NVARCHAR(50),
  [GroupNum] NVARCHAR(50)
)
GO

CREATE TABLE [CustomerEmergencyContact] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [CustomerId] INT,
  [EmergencyContactId] INT
)
GO

CREATE TABLE [SellerClub] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [SellerId] INT,
  [ClubId] INT
)
GO

CREATE TABLE [ClubProduct] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [ClubId] INT,
  [ProductId] INT,
)
GO

CREATE TABLE [CustomerOrder] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [CustomerId] INT,
  [OrderId] INT
)
GO

CREATE TABLE [SellerInsurance] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [SellerId] INT,
  [InsuranceId] INT
)
GO

CREATE TABLE [OrderLine] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [ProductId] INT,
  [OrderId] INT,
  [Quantity] INT,
  [UnitPrice] MONEY
)
GO

CREATE TABLE [CartLine] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [ProductId] INT,
  [CartId] INT,
  [Quantity] INT,
  [UnitPrice] MONEY
)
GO

ALTER TABLE [Customer] ADD FOREIGN KEY ([CartId]) REFERENCES [Cart] ([Id])
GO

ALTER TABLE [Insurance] ADD FOREIGN KEY ([TypeId]) REFERENCES [InsuranceType] ([Id])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([TypeId]) REFERENCES [ProductType] ([Id])
GO

ALTER TABLE [Order] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id])
GO

ALTER TABLE [CustomerPaymentType] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id])
GO

ALTER TABLE [CustomerPaymentType] ADD FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentType] ([Id])
GO

ALTER TABLE [CustomerInsurance] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id])
GO

ALTER TABLE [CustomerInsurance] ADD FOREIGN KEY ([InsuranceId]) REFERENCES [Insurance] ([Id])
GO

ALTER TABLE [CustomerEmergencyContact] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id])
GO

ALTER TABLE [CustomerEmergencyContact] ADD FOREIGN KEY ([EmergencyContactId]) REFERENCES [EmergencyContact] ([Id])
GO

ALTER TABLE [SellerClub] ADD FOREIGN KEY ([SellerId]) REFERENCES [Seller] ([Id])
GO

ALTER TABLE [SellerClub] ADD FOREIGN KEY ([ClubId]) REFERENCES [Club] ([Id])
GO

ALTER TABLE [ClubProduct] ADD FOREIGN KEY ([ClubId]) REFERENCES [Club] ([Id])
GO

ALTER TABLE [ClubProduct] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
GO

ALTER TABLE [CustomerOrder] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id])
GO

ALTER TABLE [CustomerOrder] ADD FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id])
GO

ALTER TABLE [SellerInsurance] ADD FOREIGN KEY ([SellerId]) REFERENCES [Seller] ([Id])
GO

ALTER TABLE [SellerInsurance] ADD FOREIGN KEY ([InsuranceId]) REFERENCES [Insurance] ([Id])
GO

ALTER TABLE [OrderLine] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
GO

ALTER TABLE [OrderLine] ADD FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id])
GO

ALTER TABLE [CartLine] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
GO

ALTER TABLE [CartLine] ADD FOREIGN KEY ([CartId]) REFERENCES [Cart] ([Id])
GO
