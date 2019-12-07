USE FightAndFeast

INSERT INTO [dbo].[Cart]
			([Total])
     VALUES
           (0),
		   (0)

INSERT INTO [dbo].[Customer]
           ([FirstName]
		   ,[LastName]
		   ,[DateCreated]
           ,[HasFought]
		   ,[Email]
		   ,[Phone]
		   ,[CartId])
     VALUES
           ('Bob', 'Baxter', '2019-11-18', 1, 'bob.e.baxter@gmail.com', '615-545-1543', 1),
           ('Josh', 'Jernigan', '2019-11-18', 1, 'josh.jernigan@gmail.com', '615-545-1544', 2)

INSERT INTO [dbo].[Seller]
           ([Name]
		   ,[DateCreated])
     VALUES
           ('Paper Street Soap Co.', '2019-11-1')

INSERT INTO [dbo].[InsuranceType]
           ([Name])
     VALUES
           ('Personal'),
		   ('Business')

INSERT INTO [dbo].[Insurance]
           ([Provider]
		   ,[TypeId])
     VALUES
           ('BlueCross BlueShield', 1),
		   ('Liberty Mutual', 2)

INSERT INTO [dbo].[EmergencyContact]
           ([FirstName]
		   ,[LastName]
		   ,[Relationship]
		   ,[Phone])
     VALUES
           ('Jazz', 'Godard', 'Spouse', '615-545-5555'),
		   ('Lakota', 'Jernigan', 'Spouse', '615-545-6666')

INSERT INTO [dbo].[Club]
           ([Name]
		   ,[Address]
		   ,[Phone]
		   ,[Capacity]
		   ,[Description])
     VALUES
           ('Fight Club Nashville', '100 Main St., Nashville, TN 37207', '615-827-9999', 50, 'Nashville''s Premier fight club')

INSERT INTO [dbo].[ProductType]
           ([Name])
     VALUES
           ('Ticket'),
		   ('Spectator Package'),
		   ('Fighter Package')

INSERT INTO [dbo].[Product]
           ([Name]
		   ,[TypeId]
		   ,[Price]
		   ,[Description]
		   ,[DateCreated]
		   ,[EventDate])
     VALUES
           ('General Admission Ticket', 1, 9.99, 'General Admission to a single fight night', '2019-11-18', '2019-12-18')

INSERT INTO [dbo].[PaymentType]
           ([Name])
     VALUES
           ('Credit Card'),
		   ('PayPal')

INSERT INTO [dbo].[CustomerPaymentType]
           ([CustomerId]
		   ,[PaymentTypeId]
		   ,[AccountNum])
     VALUES
           (1, 1, '5425-1235-7542-1234')

INSERT INTO [dbo].[Order]
           ([CustomerId]
		   ,[Total]
		   ,[CustomerPaymentTypeId])
     VALUES
           (1, 9.99, 1)

INSERT INTO [dbo].[CustomerInsurance]
           ([CustomerId]
		   ,[InsuranceId]
		   ,[PlanName]
		   ,[SubscriberNum]
		   ,[GroupNum])
     VALUES
           (1, 1, 'Essential Plan', '00', '12345')

INSERT INTO [dbo].[CustomerEmergencyContact]
           ([CustomerId]
		   ,[EmergencyContactId])
     VALUES
           (1, 1),
		   (2, 2)

INSERT INTO [dbo].[SellerClub]
           ([SellerId]
		   ,[ClubId])
     VALUES
           (1, 1)

INSERT INTO [dbo].[ClubProduct]
           ([ClubId]
		   ,[ProductId])
     VALUES
           (1, 1)

INSERT INTO [dbo].[CustomerOrder]
           ([CustomerId]
		   ,[OrderId])
     VALUES
           (1, 1)

INSERT INTO [dbo].[SellerInsurance]
           ([SellerId]
		   ,[InsuranceId])
     VALUES
           (1, 2)

INSERT INTO [dbo].[OrderLine]
           ([ProductId]
		   ,[OrderId]
		   ,[Quantity]
		   ,[UnitPrice])
     VALUES
           (1, 1, 1, 9.99)
