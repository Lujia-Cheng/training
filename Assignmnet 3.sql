USE Northwind
-- 1.      List all cities that have both Employees and Customers.
SELECT DISTINCT e.City
FROM Employees e
    JOIN Customers c ON e.City = c.City
-- 2.      List all cities that have Customers but no Employee.
-- a.      Use sub-query
SELECT DISTINCT c.City
FROM Customers c
WHERE c.City NOT IN (
    SELECT DISTINCT e.City
FROM Employees e
)
-- b.      Do not use sub-query
SELECT DISTINCT c.City
FROM Customers c
    LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL
-- 3.      List all products and their total order quantities throughout all orders.
SELECT p.ProductName, sum(od.Quantity) TotalOrderQuantities
FROM Products p
    JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName, p.ProductID
-- 4.      List all Customer Cities and total products ordered by that city.
SELECT c.City, sum(od.Quantity) TotalProductsOrdered
FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
-- 5.      List all Customer Cities that have at least two customers.
SELECT c.City, count(c.CustomerID) CustomerCount
FROM Customers c
GROUP BY c.City
HAVING count(c.CustomerID) >= 2
-- 6.      List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City, count(DISTINCT od.ProductID) ProductCount
FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING count(DISTINCT od.ProductID) >= 2
-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT c.ContactName
FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City <> o.ShipCity
-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
SELECT TOP 5
    p.ProductName, avg(p.UnitPrice) AveragePrice, c.City
FROM Products p
    JOIN [Order Details] od ON p.ProductID = od.ProductID
    JOIN Orders o ON od.OrderID = o.OrderID
    JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY p.ProductName, c.City
ORDER BY sum(od.Quantity) DESC
-- 9.      List all cities that have never ordered something but we have employees there.
-- a.      Use sub-query
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City NOT IN (
    SELECT DISTINCT c.City
FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
)
-- b.      Do not use sub-query
SELECT DISTINCT e.City
FROM Employees e
    LEFT JOIN Customers c ON e.City = c.City
WHERE c.City IS NULL
-- 10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
SELECT TOP 1
    eo.City, eo.OrderCount, cp.City, cp.TotalProductsOrdered
FROM
    (SELECT e.City, count(o.OrderID) OrderCount
    FROM Employees e
        JOIN Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY e.City) eo
    JOIN
    (SELECT c.City, sum(od.Quantity) TotalProductsOrdered
    FROM Customers c
        JOIN Orders o ON c.CustomerID = o.CustomerID
        JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY c.City) cp
    ON eo.City = cp.City
ORDER BY eo.OrderCount DESC, cp.TotalProductsOrdered DESC
-- 11. How do you remove the duplicates record of a table?
SELECT DISTINCT *
FROM Orders