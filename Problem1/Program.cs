using System;
using System.Data.SqlClient;
using Problem1.Models;
namespace Problem1
{
    class Program
    {
        int ip;
        User user;
        string connString = @"Data Source=PRATIKPC\SQLEXPRESS;Initial Catalog=Problem1Db;Integrated Security=true";
        SqlDataReader reader;
        SqlCommand command;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Menu();        
        }

        public void Menu()
        {
            Console.WriteLine("Press 1 for New User,2 for Existing User");
            ip = Convert.ToInt32(Console.ReadLine());
            switch (ip)
            {
                case 1 :
                    Insert();
                    Menu();
                    break;

                case 2:
                    Select();
                    Menu();
                    break;

                case 3:
                    Console.WriteLine("enetr userid to delete");
                    ip = Convert.ToInt32(Console.ReadLine());
                    Delete(ip);
                    Menu();
                    break;

                case 4:
                    break;
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
            SqlCommand c = new SqlCommand($"select * from Users where userId = {userName} and password = {Password}",cnn);
            reader = c.ExecuteReader();
            while (reader.Read())
            {
                
            }
        }

        public void Delete(int ip)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Users where UserId = "+ip;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();
        }
    }
}
