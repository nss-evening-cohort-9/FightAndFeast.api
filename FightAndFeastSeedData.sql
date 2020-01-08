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
           ('Paper Street Soap Co.', '2000-11-1'),
		   ('Flizzard', '2001-01-2'),
		   ('Conqo', '2002-10-3'),
		   ('Mash City', '2003-02-4'),
		   ('Scrawk', '2004-09-5'),
		   ('Dynamyth', '2005-03-6'),
		   ('Tournament Resident', '2006-08-7'),
		   ('FightRight', '2007-04-8'),
		   ('Reinvestigate Participate', '2008-07-9'),
		   ('FearInterfere', '2009-05-10'),
		   ('Bleedmede', '2010-06-11'),
		   ('Pushout Scout', '2011-06-12'),
		   ('Club Pub', '2012-05-13'),
		   ('Bloodshed Broadhead', '2013-07-14'),
		   ('Flightnight', '2014-04-15'),
		   ('Sportfish Skirmish', '2015-08-16'),
		   ('Pipero', '2016-03-17'),
		   ('Knostic', '2017-09-18'),
		   ('Chixat', '2018-02-19'),
		   ('Sanitext', '2019-10-20')

INSERT INTO [dbo].[InsuranceType]
           ([Name])
     VALUES
           ('Personal'),
		   ('Business')

INSERT INTO [dbo].[Insurance]
           ([Provider]
		   ,[TypeId])
     VALUES
	 	   ('Hospitalization Authorization', 1),
		   ('Deductibility Annuity', 1),
		   ('Availiability Commodity', 1),
		   ('Rusticity Annuity', 1),
		   ('Ecoviti', 1),
		   ('Gaslean', 1),
		   ('Emergency Solvency', 1),
		   ('Preventive Incentive', 1),
		   ('Ethoid', 1),
		   ('Estate Freight', 1),
           ('BlueCross BlueShield', 2),
		   ('Liberty Mutual', 2),
		   ('Billocity', 2),
		   ('Paternis', 2),
		   ('Security Quality', 2),
		   ('Claritol', 2),
		   ('Datazo', 2),
		   ('Medicaid Prepaid', 2),
		   ('Onomic', 2),
		   ('Seroxil', 2)

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
           ('Fight Club Nashville', '100 Main St., Nashville, TN 37207', '615-827-9999', 50, 'Nashville''s Premier fight club'),
		   ('The Alabaster Sword', '8701 Rose Drive, Grand Haven, MI 49417', '555-555-5555', 50, 'Clubmitta'),
		   ('The Bloody Club', '98 Peg Shop Drive, Clifton Park, NY 12065', '555-555-5555', 50, 'Clubmitta'),
		   ('The Craftman''s Saloon', '41 Philmont Street, Lanham, MD 20706', '555-555-5555', 50, 'Clubmitta'),
		   ('Tavery', '9001 Green Hill Rd., East Stroudsburg, PA 18301', '555-555-5555', 50, 'Clubmitta'),
		   ('The Dog''s Tavern', '35 S. Cedar Street, Moorhead, MN 56560', '555-555-5555', 50, 'Clubmitta'),
		   ('The Duplicate Bottle', '93 West Henry Smith Dr., Braintree, MA 02184', '555-555-5555', 50, 'Clubmitta'),
		   ('Flagon and Scripture', '52 Big Rock Cove Dr., Wethersfield, CT 06109', '555-555-5555', 50, 'Clubmitta'),
		   ('The Inn of Hobgoblins', '713 Brickyard Street, Bakersfield, CA 93306', '555-555-5555', 50, 'Clubmitta'),
		   ('The Inn of Trolls', '8366 Piper Drive, Brentwood, NY 11717', '555-555-5555', 50, 'Clubmitta'),
		   ('The Inn of the Devils', '881 Honey Creek Ave., Grand Haven, MI 49417', '555-555-5555', 50, 'Clubmitta'),
		   ('Phoenix Bar', '46 Wilson Drive, Buford, GA 30518', '555-555-5555', 50, 'Clubmitta'),
		   ('Stone Crown Inn', '758 Fremont Court, Mcallen, TX 78501', '555-555-5555', 50, 'Clubmitta'),
		   ('The Pick Tavern', '2 Southampton St., Westlake, OH 44145', '555-555-5555', 50, 'Clubmitta'),
		   ('Ranger Arms', '619 Vine Road, Charlotte, NC 28205', '555-555-5555', 50, 'Clubmitta'),
		   ('The Mason Pub', '402 San Juan Dr., Newtown, PA 18940', '555-555-5555', 50, 'Clubmitta'),
		   ('Chatelaine Inn', '982 W. Wellington Court, Garden City, NY 11530', '555-555-5555', 50, 'Clubmitta'),
		   ('Wild Chapel Inn', '8001 Peg Shop St., Summerville, SC 29483', '555-555-5555', 50, 'Clubmitta'),
		   ('The Windmill', '73 Green Dr., Chapel Hill, NC 27516', '555-555-5555', 50, 'Clubmitta'),
		   ('The Axe Tavern', '37 Bridgeton Ave., Elizabeth, NJ 07202', '555-555-5555', 50, 'Clubmitta')

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
           ('General Admission Ticket', 1, 9.99, 'General Admission to a single fight night.', '2019-11-18', '2019-12-18'),
		   ('Front Row Ticket', 1, 49.99, 'A front row ticket to the fight.', '2019-11-18', '2019-12-18'),
		   ('Ticket', 1, 8.49, 'General Admission to a single fight night.', '2019-11-18', '2019-12-18'),
		   ('VIP Ticket', 1, 69.90, 'Ticket for special VIP seating and service.', '2019-11-18', '2019-12-18'),
		   ('Reserved Seating', 1, 49.99, 'Ticket for special reserved seating and service.', '2019-11-18', '2019-12-18'),
		   ('Multi-day Pass', 1, 259.99, 'Pass to attend 2 full days of fights - your choice of the dates!', '2019-11-18', '2019-12-18'),
		   ('One-day Pass', 1, 60.00, 'Pass to attend one full day of fights - your choice of the date!', '2019-11-18', '2019-12-18'),
		   ('Early Bird Ticket', 1, 14.99, 'Special pricing for early purchasing of a General Admission Ticket to a single fight night.', '2019-11-18', '2019-12-18'),
		   ('Two-day Pass', 1, 80.00, 'Pass to attend 2 full days of fights - your choice of the dates!', '2019-11-18', '2019-12-18'),
		   ('Fight Night Ticket', 1, 7.99, 'General Admission to a single fight night.', '2019-11-18', '2019-12-18'),
		   ('Late Night Fight Ticket', 1, 11.99, 'General Admission to a single fight night.', '2019-11-18', '2019-12-18'),
		   ('VIP Late Night Ticket', 1, 74.99, 'Ticket for special VIP seating and service.', '2019-11-18', '2019-12-18'),
		   ('Reserved Seating Ticket', 1, 59.99, 'Ticket for special reserved seating and service.', '2019-11-18', '2019-12-18'),
		   ('Multi-fight Ticket', 1, 225.00, 'Pass to attend 2 full days of fights - your choice of the dates!', '2019-11-18', '2019-12-18'),
		   ('General Fight Admission', 1, 12.00, 'General Admission to a single fight night.', '2019-11-18', '2019-12-18'),
		   ('Two-fight Pass', 1, 14.99, 'Pass to attend 2 fights - your choice of the fights!', '2019-11-18', '2019-12-18'),
		   ('Backstage Pass', 1, 299.99, 'Special pass to meet the fighters backstage!', '2019-11-18', '2019-12-18'),
		   ('Early Bird Ticket', 1, 5.99, 'Special pricing for early purchasing of a General Admission Ticket to a single fight night.', '2019-11-18', '2019-12-18'),
		   ('Late Night Fight Pass', 1, 9.99, 'General Admission to a single fight night', '2019-11-18', '2019-12-18'),
		   ('Ticket', 1, 10.00, 'General Admission to a single fight night', '2019-11-18', '2019-12-18'),
		   ('All Day Pass', 1, 59.99, 'Pass to attend one full days of fights - your choice of the date!', '2019-11-18', '2019-12-18'),
		   ('Two-day Ticket', 1, 79.99, 'Pass to attend 2 full days of fights - your choice of the dates!', '2019-11-18', '2019-12-18'),
		   ('General Admission Ticket, One Night Stay, and Breakfast', 2, 69.99, 'General Admission to a single fight night, one night stay, and breakfast in the morning.', '2019-11-18', '2019-12-18'),
		   ('Front Row Ticket, One Night Stay and Breakfast', 2, 109.99, 'A front row ticket to the fight, a one night stay, and breakfast in the morning.', '2019-11-18', '2019-12-18'),
		   ('Ticket, One Night Stay, and Brunch', 2, 68.49, 'General Admission to a single fight night, a one night stay, and brunch the next day.', '2019-11-18', '2019-12-18'),
		   ('VIP Ticket, One Night Stay, and Brunch', 2, 129.90, 'Ticket for special VIP seating and service, a one night stay, and brunch the next day.', '2019-11-18', '2019-12-18'),
		   ('Multi-day Pass with Stays with Meals', 2, 429.99, 'Pass to attend 2 full days of fights, 2 nights of stays, and 3 meals per day - your choice of the dates!', '2019-11-18', '2019-12-18'),
		   ('One-day Pass with Stay with Meals', 2, 120.00, 'Pass to attend one full day of fights, a one night stay, 3 meals for the day, and brunch the next day - your choice of the date!', '2019-11-18', '2019-12-18'),
		   ('Two-day Pass with Stays with Meals', 2, 190.00, 'Pass to attend 2 full days of fights, two nights stay, 3 meals per day, and breakfast the next day - your choice of the dates!', '2019-11-18', '2019-12-18'),
		   ('Fight Night Ticket, One Night Stay, and Breakfast', 2, 67.99, 'General Admission to a single fight night, one night stay, and breakfast in the morning.', '2019-11-18', '2019-12-18'),
		   ('Late Night Fight Ticket, One Night Stay, with Brunch', 2, 71.99, 'General Admission to a single fight night, one night stay, and brunch in the morning.', '2019-11-18', '2019-12-18'),
		   ('VIP Late Night Ticket, One Night Stay, and Brunch', 2, 134.99, 'Ticket for special VIP seating and service, a one night stay, and brunch the next day.', '2019-11-18', '2019-12-18'),
		   ('Reserved Seating Ticket, One Night Stay, and Breakfast', 2, 119.99, 'Ticket for special reserved seating and service, a one night stay, and breakfast in the morning.', '2019-11-18', '2019-12-18'),
		   ('Legal Services', 3, 49.99, 'Legal services for a fighter on fight night.', '2019-11-18', '2019-12-18'),
		   ('Medical Services', 3, 49.99, 'Full medical services for a fighter on fight night.', '2019-11-18', '2019-12-18'),
		   ('Psychological Services', 3, 49.99, 'Psychological service for a fighter post-fight.', '2019-11-18', '2019-12-18'),
		   ('Fighter Stay and Meal Package', 3, 39.99, 'Fight night dinner, One Night Stay, and breakfast in the morning.', '2019-11-18', '2019-12-18'),
		   ('Fighter One Night Stay with Breakfast', 3, 40.00, 'One night stay on fight night and breakfast in the morning.', '2019-11-18', '2019-12-18'),
		   ('Fighter Full Service - Legal, Medical, Psychological', 3, 99.99, 'Full legal, medical, and psychological services for fight night.', '2019-11-18', '2019-12-18'),
		   ('Wellness Package', 3, 49.99, 'Massage and sauna the day after the fight.', '2019-11-18', '2019-12-18')

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
           (1, 1),
		   (2, 2),
		   (3, 3),
		   (4, 4),
		   (5, 5),
		   (6, 6),
		   (7, 7),
		   (8, 8),
		   (19, 9),
		   (10, 10),
		   (11, 11),
		   (12, 12),
		   (13, 13),
		   (14, 14),
		   (15, 15),
		   (16, 16),
		   (17, 17),
		   (18, 18),
		   (19, 19),
		   (20, 20),
		   (1, 21),
		   (3, 22),
		   (5, 23),
		   (7, 24),
		   (9, 25),
		   (10, 26),
		   (11, 27),
		   (12, 28),
		   (13, 29),
		   (15, 30),
		   (17, 31),
		   (19, 32),
		   (20, 33),
		   (1, 34),
		   (4, 35),
		   (7, 36),
		   (10, 37),
		   (13, 38),
		   (16, 39),
		   (19, 40)

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
