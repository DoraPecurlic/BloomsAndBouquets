CREATE TABLE "User"(
    "Id" SERIAL PRIMARY KEY,
    "FirstName" VARCHAR(25),
    "LastName" VARCHAR(30),
	"Role" VARCHAR(20) 
);


CREATE TABLE "OrderType"(
    "Id" SERIAL PRIMARY KEY,
    "OrderType" VARCHAR(100) NOT NULL
	
);

CREATE TABLE "Order"(
    "Id" SERIAL PRIMARY KEY,
    "FlowerType" VARCHAR(25) NOT NULL,
    "Quantity" INT NOT NULL,
    "OrderTypeId" INT NOT NULL,
	"UserId" INT NOT NULL,
	
	
    FOREIGN KEY ("OrderTypeId") REFERENCES "OrderType"("Id"),
	FOREIGN KEY ("UserId") REFERENCES "User"("Id")

);