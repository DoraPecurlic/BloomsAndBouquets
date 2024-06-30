INSERT INTO "OrderType" ("OrderType")
VALUES 
('Bouquet'),
('Flower Box'),
('Flower Basket');

INSERT INTO "User" ("FirstName", "LastName", "Role")
VALUES 
('Dino', 'Rozing', 'Buyer'),
('Sara', 'Begic', 'Buyer'),
('Kan', 'Kan', 'Admin');

INSERT INTO "Order" ("FlowerType", "Quantity", "OrderTypeId", "UserId")
VALUES 
('Roses', 10, 1, 1),  -- Dino Rozing, Bouquet
('Tulips', 5, 2, 2),  -- Sara Begic, Flower Box
('Lilies', 3, 3, 3);  -- Kan Kan, Flower Basket

DELETE FROM "Order";

INSERT INTO "Order" ("FlowerType", "Quantity", "OrderTypeId", "UserId", "Price")
VALUES 
('Roses', 10, 1, 1, 19.50),  
('Tulips', 5, 2, 2, 25.00),  
('Lilies', 3, 3, 3, 30.00);  