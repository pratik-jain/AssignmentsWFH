using System;
using System.Data.SqlClient;

namespace Project6
{
    class Program
    {
        int choice;

        string connString = @"Data Source=PRATIKPC\SQLEXPRESS;Initial Catalog=Problem6Db;Integrated Security=true";
        SqlDataReader reader;
        SqlCommand command;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Menu();
        }

        public void Menu()
        {
            Console.WriteLine("Press 1 for Movies,2 for Actors ,3 for select view 4.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Movie();
                    Menu();
                    break;

                case 2:
                    Actor();
                    Menu();
                    break;
                case 3:
                    View();
                    Menu();
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        public void Movie()
        {
            Console.WriteLine("Press 1 for Add Movies,2 for Delete Movie 3.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddMovie();
                    Menu();
                    break;

                case 2:
                    Console.WriteLine("enter Movieid to delete");
                    choice = Convert.ToInt32(Console.ReadLine());
                    DeleteMovie(choice);

                    Menu();
                    break;

                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        public void AddMovie()
        {
            string movieName;
            int actorId;
            Console.WriteLine("Enter Movie Name");
            movieName = Console.ReadLine();
            Console.WriteLine("Enter Actor Id");
            actorId = Convert.ToInt32(Console.ReadLine());
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Movies(MovieName,ActorId)values('{movieName}','{actorId}')", cnn);
            c.ExecuteNonQuery();
        }
        public void DeleteMovie(int choice)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Movies where MovieId = " + choice;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();

        }
        public void Actor()
        {
            Console.WriteLine("Press 1 for Add Actors,2 for Delete Actor 3.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddActor();
                    Menu();
                    break;

                case 2:
                    Console.WriteLine("enter ActorId to delete");
                    choice = Convert.ToInt32(Console.ReadLine());
                    DeleteActor(choice);

                    Menu();
                    break;

                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
        public void AddActor()
        {
            string actorName;
          
            Console.WriteLine("Enter Actor Name");
            actorName = Console.ReadLine();
           
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Actors(ActorName)values('{actorName}')", cnn);
            c.ExecuteNonQuery();
        }
        public void DeleteActor(int choice)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Actors where ActorId = " + choice;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();
        }

        public void View()
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"select * from vMovieDetails ", cnn);
            reader = c.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine( "Actor Name"+reader.GetString(2));
                Console.WriteLine("MovieName"+reader.GetString(1));
            }
        }
    }
}
