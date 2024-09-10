using System;
using System.Data.SQLite;

internal class DBWork
{
    static public string CreateStoreDB(string _dbname = "Store.db")
    {
        string path = $"Data Source=\"{_dbname}\";";
        string init_db = @"
        CREATE TABLE IF NOT EXISTS ProductCategory (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name VARCHAR
        );
        
        CREATE TABLE IF NOT EXISTS Product (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name VARCHAR,
            Price DECIMAL,
            CategoryId INTEGER,
            FOREIGN KEY (CategoryId) REFERENCES ProductCategory(Id)
        );

        CREATE TABLE IF NOT EXISTS Customer (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name VARCHAR,
            Gender VARCHAR,
            Age INTEGER
        );

        CREATE TABLE IF NOT EXISTS Purchase (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            ProductId INTEGER,
            CustomerId INTEGER,
            Quantity INTEGER,
            PurchaseDate DATE,
            FOREIGN KEY (ProductId) REFERENCES Product(Id),
            FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
        );";

        using (SQLiteConnection conn = new SQLiteConnection(path))
        {
            SQLiteCommand cmd = new SQLiteCommand(init_db, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        return "База данных и таблицы созданы";
    }

    static public void InitializeData(string _dbname = "Store.db")
    {
        string path = $"Data Source=\"{_dbname}\";";
        using (SQLiteConnection conn = new SQLiteConnection(path))
        {
            conn.Open();

            string insertCategories = @"
            INSERT INTO ProductCategory (Name) VALUES 
            ('Часы'), 
            ('Кулоны'),
            ('Браслеты');";

            string insertProducts = @"
            INSERT INTO Product (Name, Price, CategoryId) VALUES 
            ('Часы Smart', 299.99, 1), 
            ('Кулон Сердце', 150.00, 2),
            ('Браслет Ремень', 99.99, 3);";

            string insertCustomers = @"
            INSERT INTO Customer (Name, Gender, Age) VALUES 
            ('Иван', 'М', 30),
            ('Анна', 'Ж', 25),
            ('Олег', 'М', 35);";

            string insertPurchases = @"
            INSERT INTO Purchase (ProductId, CustomerId, Quantity, PurchaseDate) VALUES 
            (1, 1, 1, '2023-12-31'), 
            (2, 2, 2, '2023-02-14'),
            (1, 3, 1, '2023-11-10');";

            using (SQLiteCommand cmd = new SQLiteCommand(insertCategories, conn))
            {
                cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(insertProducts, conn))
            {
                cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(insertCustomers, conn))
            {
                cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(insertPurchases, conn))
            {
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
}
static public int CountCustomersWhoBoughtWatchesIn2023(string _dbname = "Store.db")
{
    string path = $"Data Source=\"{_dbname}\";";
    string query = @"
    SELECT COUNT(DISTINCT c.Id) 
    FROM Customer c
    JOIN Purchase p ON c.Id = p.CustomerId
    JOIN Product prod ON p.ProductId = prod.Id
    JOIN ProductCategory pc ON prod.CategoryId = pc.Id
    WHERE pc.Name = 'Часы' AND strftime('%Y', p.PurchaseDate) = '2023';";
    using (SQLiteConnection conn = new SQLiteConnection(path))
    {
        SQLiteCommand cmd = new SQLiteCommand(query, conn);
        conn.Open();
        return Convert.ToInt32(cmd.ExecuteScalar());
    }
}

static public double AverageAgeOfCustomersWhoBoughtPendantOnFebruary14(string _dbname = "Store.db")
{
    string path = $"Data Source=\"{_dbname}\";";
    string query = @"
    SELECT AVG(c.Age) 
    FROM Customer c
    JOIN Purchase p ON c.Id = p.CustomerId
    JOIN Product prod ON p.ProductId = prod.Id
    JOIN ProductCategory pc ON prod.CategoryId = pc.Id
    WHERE pc.Name = 'Кулоны' AND p.PurchaseDate = '2023-02-14';";

    using (SQLiteConnection conn = new SQLiteConnection(path))
    {
        SQLiteCommand cmd = new SQLiteCommand(query, conn);
        conn.Open();
        return Convert.ToDouble(cmd.ExecuteScalar());
    }
}

static public decimal AverageCheckOnDecember31(string _dbname = "Store.db")
{
    string path = $"Data Source=\"{_dbname}\";";
    string query = @"
    SELECT AVG(p.Quantity * prod.Price)
    FROM Purchase p
    JOIN Product prod ON p.ProductId = prod.Id
    WHERE p.PurchaseDate = '2023-12-31';";

    using (SQLiteConnection conn = new SQLiteConnection(path))
    {
        SQLiteCommand cmd = new SQLiteCommand(query, conn);
        conn.Open();
        return Convert.ToDecimal(cmd.ExecuteScalar());
    }
}

