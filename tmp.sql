
    SELECT City, CompanyName Name, ContactName, 'Customer' Type
    FROM Customers
UNION
    SELECT City, CompanyName Name, ContactName, 'Supplier' Type
    FROM Suppliers
ORDER BY City, CompanyName, ContactName