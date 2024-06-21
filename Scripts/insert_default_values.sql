-- Insert za tablicu OrderType
INSERT INTO "OrderType" ("OrderType")
VALUES 
('Bouquet'),
('Flower Box'),
('Flower Basket');

-- Insert za tablicu User
INSERT INTO "User" ("FirstName", "LastName", "Role")
VALUES 
('Dino', 'Rozing', 'Buyer'),
('Sara', 'Begic', 'Buyer'),
('Kan', 'Kan', 'Admin');

-- Insert za tablicu Order
INSERT INTO "Order" ("FlowerType", "Quantity", "OrderTypeId", "UserId")
VALUES 
('Roses', 10, 1, 1),  -- Dino Rozing, Bouquet
('Tulips', 5, 2, 2),  -- Sara Begic, Flower Box
('Lilies', 3, 3, 3);  -- Kan Kan, Flower Basket
