using System;
using System.Data.SqlClient;

namespace MovieApplication
{
    class Program
    {
        int id;

        string connString = "Data Source=PRATIKPC\\SQLEXPRESS;Initial Catalog=ProblemDb;Integrated Security=true";
        SqlDataReader reader;
        SqlCommand command;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Menu();
        }

        public void Menu()
        {
            Console.WriteLine("Press 1 for Movies,2 for Actors,3.Exit");
            id = Convert.ToInt32(Console.ReadLine());
            switch (id)
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
                    break;

                default:
                    Console.WriteLine("Invalid id");
                    break;
            }
        }

        public void Movie()
        {
            Console.WriteLine("Press 1 for Add Movies,2 for Delete Movie 3.Exit");
            id = Convert.ToInt32(Console.ReadLine());
            switch (id)
            {
                case 1:
                    AddMovie();
                    Menu();
                    break;

                case 2:
                    Console.WriteLine("enter Movieid to delete");
                    id = Convert.ToInt32(Console.ReadLine());
                    DeleteMovie(id);
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

            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Movies(MovieName)values('{movieName}')", cnn);
            c.ExecuteNonQuery();
        }
        public void DeleteMovie(int Choice)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Movies where MovieId = " + Choice;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();

        }
        public void Actor()
        {
            Console.WriteLine("Press 1 for Add Actors,2 for Delete Actor 3.Exit");
            id = Convert.ToInt32(Console.ReadLine());
            switch (id)
            {
                case 1:
                    AddActor();
                    Menu();
                    break;

                case 2:
                    Console.WriteLine("enter ActorId to delete");
                    id = Convert.ToInt32(Console.ReadLine());
                    DeleteActor(id);

                    Menu();
                    break;

                case 3:
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
        public void DeleteActor(int id)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Actors where ActorId = " + id;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();
        }
    }

    public class Actor
    {
        public int ActorId { get; set; }
        public string ActorName{ get; set; }
    }

    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
    }

    public class MovieActor
    {
        public int MovieActorId { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
}
