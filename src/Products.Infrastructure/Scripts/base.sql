CREATE TABLE Product (
    ProductId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10,2) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);


CREATE TABLE Item (
    ItemId INT PRIMARY KEY IDENTITY,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    BatchNumber NVARCHAR(50),
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
);