using System;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
namespace Problem2
{
    class Program
    {
       string connString = @"Data Source=PRATIKPC\SQLEXPRESS;Initial Catalog=Problem2Db;Integrated Security=true";
        SqlDataReader reader;
        SqlCommand command;
        int UserId;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Menu();
        }

        public void Menu()
        {
            int ip;
            Console.WriteLine("Press 1 to show category ,2 for add item to cart,4 to exit");
            ip = Convert.ToInt32(Console.ReadLine());
            switch (ip)
            {
                case 1:
                    ShowItems();                    
                    break;               

                case 2:
                    Console.WriteLine("enter product id to add cart");
                    ip = Convert.ToInt32(Console.ReadLine());
                    
                    Menu();
                    break;

                case 4:
                    break;
            }
        }

        public void ShowItems()
        {

            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand("select * from ProductCategories",cnn);
            reader = c.ExecuteReader();
            while (reader.Read())
            {
                
            }
            reader.Close();
            Console.WriteLine("Enter id u want to but product :>  ");
            int cId = Int32.Parse(Console.ReadLine());
            c.Connection = cnn;
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "spProducts";

            c.Parameters.Add(new SqlParameter("@CategoryId",SqlDbType.VarChar)).Value = cId;
            reader = c.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            
        }

        public void Insert()
        {
            string cmd = "";
            string userName, Password, Mobile, Email;
            Console.WriteLine("Enter uname");
            userName = Console.ReadLine();

            Console.WriteLine("Password:");
            Password = Console.ReadLine();

            Console.WriteLine("Mobile");
            Mobile = Console.ReadLine();

            Console.WriteLine("EMail");
            Email = Console.ReadLine();


            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Users(UserName,Password,MobileNumber,Email)values('{userName}','{Password}','{Mobile}','{Email}')", cnn);
            c.ExecuteNonQuery();


        }
        public void Select()
        {

            string userName, Password;
            Console.WriteLine("Enter Username:");
            userName = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            Password = Console.ReadLine();

            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"select * from Users where userId = {userName} and password = {Password}", cnn);
            reader = c.ExecuteReader();
            while (reader.Read())
            {
                UserId = reader.GetInt32(0);
            }
        }
    }



    class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    class Invoice
    {
        public int InvoiceId { get; set; }
        public int CartId { get; set; }
        public DateTime DateTime { get; set; }
        public int TotalPrice { get; set; }
    }

    class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
    }

    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
    class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }

    class vCart
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public int UserId { get; set; }
    }
}
