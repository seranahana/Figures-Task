SELECT Products.ProductName, Categories.CategoryName
FROM Products
LEFT JOIN Categories
ON Products.ProductID=Categories.ProductID
ORDER BY Products.ProductName;