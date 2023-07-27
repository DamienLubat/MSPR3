-- Ajouter 10 articles
INSERT INTO Medias (MediaPath) VALUES
    -- casque b
	('https://images.unsplash.com/photo-1545127398-14699f92334b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=870&q=80'),
    --jordan
	('https://images.unsplash.com/photo-1593081891731-fda0877988da?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=987&q=80'),
    --camera
	('https://images.unsplash.com/photo-1586253634026-8cb574908d1e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=870&q=80'),
    --ampoule
	('https://images.unsplash.com/photo-1619506147448-b56ba8ee11d7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=870&q=80'),
    --radio
	('https://images.unsplash.com/photo-1612869544295-eda1013274aa?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=870&q=80'),
    --glasses
	('https://images.unsplash.com/photo-1511499767150-a48a237f0083?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=880&q=80'),
    --chanel
	('https://images.unsplash.com/photo-1458538977777-0549b2370168?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=874&q=80'),
    --football
	('https://images.unsplash.com/photo-1614632537190-23e4146777db?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=870&q=80'),
    --car
	('https://images.unsplash.com/photo-1494905998402-395d579af36f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=870&q=80'),
    --cpu
	('https://images.unsplash.com/photo-1591799264318-7e6ef8ddb7ea?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=774&q=80');

INSERT INTO Languages (LanguageDescription) VALUES
    ('FR'),
    ('UK'),
    ('USA')

INSERT INTO Descriptives (IDLanguage, DescriptionShort, DescriptionLong) VALUES
    (1, 'Casque Beats', 'description_longue_Casque'),
	(1, 'Jordan', 'description_longue_Jordan'),
	(2, 'Camera', 'description_longue_Camera'),
	(3, 'Ampoule', 'description_longue_Ampoule'),
	(2, 'Radio', 'description_longue_Radio'),
	(3, 'Lunettes de Soleil', 'description_longue_Lunettes'),
	(1, 'Parfum', 'description_longue_Parfum'),
	(2, 'Balle de football', 'description_longue_Balle'),
	(3, 'Voiture', 'description_longue_Voiture'),
	(2, 'CPU', 'description_longue_CPU');

INSERT INTO Suppliers (Name, Adress, Phone) VALUES
    ('Petit', '1 Rue de la Liberté', '0123456789'),
    ('Moreau', '2 Boulevard Haussmann', '0987654321');

INSERT INTO Prices (Currency, PriceHT, QuantityMin) VALUES
    ('EUR', 10.5, 1),
    ('USD', 8.99, 3),
    ('GBP', 12.75, 2),
    ('EUR', 15.0, 1),
    ('USD', 9.99, 5);

INSERT INTO Taxs (Rate) VALUES
    (0.05),
    (0.1),
    (0.15),
    (0.2),
    (0.25);

INSERT INTO Volumes (VolumeDescription, VolumeWeight, Dimension) VALUES
    ('description_volume_1', 0.5, '10x10x10'),
    ('description_volume_2', 1.0, '15x15x15'),
    ('description_volume_3', 0.8, '12x12x12'),
    ('description_volume_4', 1.2, '18x18x18'),
    ('description_volume_5', 0.7, '11x11x11');

INSERT INTO Items (GTIN, ItemWeigth, SaleUnite, IDMedia, IDLanguage, IDDescriptive, IDSupplier, IDPrice, IDTax, IDVolume) VALUES
    ('gtin_1', 0.2, 5, 1, 1, 1, 1, 1, 1, 1),
    ('gtin_2', 0.4, 3, 2, 2, 2, 1, 2, 2, 2),
    ('gtin_3', 0.6, 2, 3, 3, 3, 2, 3, 3, 3),
    ('gtin_4', 0.8, 4, 4, 3, 4, 2, 4, 4, 4),
    ('gtin_5', 0.3, 6, 5, 2, 5, 1, 5, 5, 5),
    ('gtin_6', 0.5, 1, 6, 1, 1, 2, 1, 1, 1),
    ('gtin_7', 0.7, 3, 7, 2, 2, 2, 2, 2, 2),
    ('gtin_8', 0.9, 2, 8, 3, 3, 1, 3, 3, 3),
    ('gtin_9', 0.4, 4, 9, 2, 4, 1, 4, 4, 4),
    ('gtin_10', 0.6, 5, 10, 1, 5, 2, 5, 5, 5);

INSERT INTO Keywords (KeywordDescription, IDItem, IDMedia) VALUES
    ('mot_clé_1', 1, 1),
    ('mot_clé_2', 2, 2),
    ('mot_clé_3', 3, 3),
    ('mot_clé_4', 4, 4),
    ('mot_clé_5', 5, 5);

-- Ajouter 2 utilisateurs
INSERT INTO Users (Username, Password) VALUES
    ('user1', 'mdp1'),
    ('user2', 'mdp2');

-- Insérer des valeurs dans la table UsersItems
INSERT INTO UsersItems (IDItem, IDUser) VALUES
    (1, 1),
    (2, 1),
    (3, 2),
    (4, 2),
    (5, 2),
    (6, 1),
    (7, 1),
    (8, 2),
    (9, 2),
    (10, 1);
