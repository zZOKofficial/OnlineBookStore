----------------------

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'OnlineBookStoreDB')
BEGIN
    CREATE DATABASE OnlineBookStoreDB;
END
GO

USE OnlineBookStoreDB;
GO


------------------------------------------------------------
-- 2. USERS TABLE
------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Users' AND xtype = 'U')
BEGIN
    CREATE TABLE Users
    (
        UserID INT IDENTITY(1,1) PRIMARY KEY,

        FullName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100) NOT NULL UNIQUE,
        Password NVARCHAR(100) NOT NULL,

        Phone NVARCHAR(20) NULL,
        Address NVARCHAR(250) NULL,

        Role NVARCHAR(20) NOT NULL,
        Status NVARCHAR(20) NOT NULL,

        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME NULL,

        CONSTRAINT CK_Users_Role
        CHECK (Role IN ('Admin', 'Manager', 'Customer')),

        CONSTRAINT CK_Users_Status
        CHECK (Status IN ('Pending', 'Active', 'Inactive', 'Rejected'))
    );
END
GO



-- 3. BOOKS TABLE


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Books' AND xtype = 'U')
BEGIN
    CREATE TABLE Books
    (
        BookID INT IDENTITY(1,1) PRIMARY KEY,

        Title NVARCHAR(150) NOT NULL,
        Author NVARCHAR(100) NOT NULL,
        Category NVARCHAR(100) NOT NULL,

        Price DECIMAL(10,2) NOT NULL,
        Stock INT NOT NULL,

        Status NVARCHAR(20) NOT NULL DEFAULT 'Available',

        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME NULL,

        CONSTRAINT CK_Books_Price
        CHECK (Price >= 0),

        CONSTRAINT CK_Books_Stock
        CHECK (Stock >= 0),

        CONSTRAINT CK_Books_Status
        CHECK (Status IN ('Available', 'Unavailable'))
    );
END
GO

-- 4. CARTS TABLE

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Carts' AND xtype = 'U')
BEGIN
    CREATE TABLE Carts
    (
        CartID INT IDENTITY(1,1) PRIMARY KEY,

        UserID INT NOT NULL,
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

        Status NVARCHAR(20) NOT NULL DEFAULT 'Active',

        CONSTRAINT FK_Carts_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID),

        CONSTRAINT CK_Carts_Status
        CHECK (Status IN ('Active', 'Ordered'))
    );
END
GO

-- 5. CART ITEMS TABLE


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'CartItems' AND xtype = 'U')
BEGIN
    CREATE TABLE CartItems
    (
        CartItemID INT IDENTITY(1,1) PRIMARY KEY,

        CartID INT NOT NULL,
        BookID INT NOT NULL,

        Quantity INT NOT NULL,
        Price DECIMAL(10,2) NOT NULL,

        CONSTRAINT FK_CartItems_Carts
        FOREIGN KEY (CartID) REFERENCES Carts(CartID),

        CONSTRAINT FK_CartItems_Books
        FOREIGN KEY (BookID) REFERENCES Books(BookID),

        CONSTRAINT CK_CartItems_Quantity
        CHECK (Quantity > 0),

        CONSTRAINT CK_CartItems_Price
        CHECK (Price >= 0)
    );
END
GO



-- 6. ORDERS TABLE

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Orders' AND xtype = 'U')
BEGIN
    CREATE TABLE Orders
    (
        OrderID INT IDENTITY(1,1) PRIMARY KEY,

        UserID INT NOT NULL,
        OrderDate DATETIME NOT NULL DEFAULT GETDATE(),

        TotalAmount DECIMAL(10,2) NOT NULL,
        Status NVARCHAR(20) NOT NULL DEFAULT 'Pending',

        CONSTRAINT FK_Orders_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID),

        CONSTRAINT CK_Orders_TotalAmount
        CHECK (TotalAmount >= 0),

        CONSTRAINT CK_Orders_Status
        CHECK (Status IN ('Pending', 'Confirmed', 'Delivered', 'Cancelled'))
    );
END
GO



-- 7. ORDER DETAILS TABLE


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'OrderDetails' AND xtype = 'U')
BEGIN
    CREATE TABLE OrderDetails
    (
        OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,

        OrderID INT NOT NULL,
        BookID INT NOT NULL,

        Quantity INT NOT NULL,
        Price DECIMAL(10,2) NOT NULL,

        CONSTRAINT FK_OrderDetails_Orders
        FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),

        CONSTRAINT FK_OrderDetails_Books
        FOREIGN KEY (BookID) REFERENCES Books(BookID),

        CONSTRAINT CK_OrderDetails_Quantity
        CHECK (Quantity > 0),

        CONSTRAINT CK_OrderDetails_Price
        CHECK (Price >= 0)
    );
END
GO


------------------------------------------------------------
-- 8. PAYMENTS TABLE
-- Needed for PaymentForm
------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Payments' AND xtype = 'U')
BEGIN
    CREATE TABLE Payments
    (
        PaymentID INT IDENTITY(1,1) PRIMARY KEY,

        OrderID INT NOT NULL,

        PaymentMethod NVARCHAR(50) NOT NULL,
        TransactionID NVARCHAR(100) NULL,

        Amount DECIMAL(10,2) NOT NULL,
        PaymentStatus NVARCHAR(20) NOT NULL DEFAULT 'Pending',

        PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),

        CONSTRAINT FK_Payments_Orders
        FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),

        CONSTRAINT CK_Payments_Amount
        CHECK (Amount >= 0),

        CONSTRAINT CK_Payments_Method
        CHECK (PaymentMethod IN ('Cash on Delivery', 'bKash', 'Nagad', 'Card')),

        CONSTRAINT CK_Payments_Status
        CHECK (PaymentStatus IN ('Pending', 'Paid', 'Failed', 'Refunded'))
    );
END
GO



-- 9. CHANGE LOGS TABLE


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'ChangeLogs' AND xtype = 'U')
BEGIN
    CREATE TABLE ChangeLogs
    (
        LogID INT IDENTITY(1,1) PRIMARY KEY,

        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        CreatedBy INT NULL,

        ActionType NVARCHAR(50) NOT NULL,
        Description NVARCHAR(500) NOT NULL,

        CONSTRAINT FK_ChangeLogs_Users
        FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
    );
END
GO



-- 10. INSERTING DEFAULT TEST ACCOUNTS


IF NOT EXISTS (SELECT * FROM Users WHERE Email = 'admin@gmail.com')
BEGIN
    INSERT INTO Users
    (
        FullName,
        Email,
        Password,
        Phone,
        Address,
        Role,
        Status
    )
    VALUES
    (
        'System Admin',
        'admin@gmail.com',
        'admin123',
        '01700000001',
        'Dhaka',
        'Admin',
        'Active'
    );
END
GO

IF NOT EXISTS (SELECT * FROM Users WHERE Email = 'manager@gmail.com')
BEGIN
    INSERT INTO Users
    (
        FullName,
        Email,
        Password,
        Phone,
        Address,
        Role,
        Status
    )
    VALUES
    (
        'Book Store Manager',
        'manager@gmail.com',
        'manager123',
        '01700000002',
        'Dhaka',
        'Manager',
        'Active'
    );
END
GO

IF NOT EXISTS (SELECT * FROM Users WHERE Email = 'customer@gmail.com')
BEGIN
    INSERT INTO Users
    (
        FullName,
        Email,
        Password,
        Phone,
        Address,
        Role,
        Status
    )
    VALUES
    (
        'Test Customer',
        'customer@gmail.com',
        'customer123',
        '01700000003',
        'Dhaka',
        'Customer',
        'Active'
    );
END
GO



-- 11. INSERT SAMPLE BOOKS


IF NOT EXISTS (SELECT * FROM Books WHERE Title = 'C# Programming Basics')
BEGIN
    INSERT INTO Books
    (
        Title,
        Author,
        Category,
        Price,
        Stock,
        Status
    )
    VALUES
    (
        'C# Programming Basics',
        'John Smith',
        'Programming',
        550.00,
        20,
        'Available'
    );
END
GO

IF NOT EXISTS (SELECT * FROM Books WHERE Title = 'Database Management System')
BEGIN
    INSERT INTO Books
    (
        Title,
        Author,
        Category,
        Price,
        Stock,
        Status
    )
    VALUES
    (
        'Database Management System',
        'Robert King',
        'Database',
        700.00,
        15,
        'Available'
    );
END
GO

IF NOT EXISTS (SELECT * FROM Books WHERE Title = 'Object Oriented Programming')
BEGIN
    INSERT INTO Books
    (
        Title,
        Author,
        Category,
        Price,
        Stock,
        Status
    )
    VALUES
    (
        'Object Oriented Programming',
        'Alice Brown',
        'Programming',
        650.00,
        25,
        'Available'
    );
END
GO

IF NOT EXISTS (SELECT * FROM Books WHERE Title = 'Software Engineering')
BEGIN
    INSERT INTO Books
    (
        Title,
        Author,
        Category,
        Price,
        Stock,
        Status
    )
    VALUES
    (
        'Software Engineering',
        'Ian Sommerville',
        'Software',
        850.00,
        10,
        'Available'
    );
END
GO

IF NOT EXISTS (SELECT * FROM Books WHERE Title = 'Computer Networks')
BEGIN
    INSERT INTO Books
    (
        Title,
        Author,
        Category,
        Price,
        Stock,
        Status
    )
    VALUES
    (
        'Computer Networks',
        'Andrew Tanenbaum',
        'Networking',
        900.00,
        12,
        'Available'
    );
END
GO



-- 12. INSERT INITIAL CHANGE LOG


IF NOT EXISTS (
    SELECT * FROM ChangeLogs 
    WHERE ActionType = 'Database Setup'
)
BEGIN
    INSERT INTO ChangeLogs
    (
        CreatedBy,
        ActionType,
        Description
    )
    VALUES
    (
        NULL,
        'Database Setup',
        'Initial database tables, default users, sample books, and payment support created.'
    );
END
GO


-- 13. CHECK FINAL DATA


SELECT * FROM Users;
SELECT * FROM Books;
SELECT * FROM Carts;
SELECT * FROM CartItems;
SELECT * FROM Orders;
SELECT * FROM OrderDetails;
SELECT * FROM Payments;
SELECT * FROM ChangeLogs;
GO