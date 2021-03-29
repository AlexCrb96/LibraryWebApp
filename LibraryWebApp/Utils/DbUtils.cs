using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryWebApp.Utils
{
    public class DbUtils
    {
        private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=Library;Trusted_Connection=True";
        private static SqlConnection sqlConnection = new SqlConnection(ConnectionString);
        private static Boolean tablesCreated = false;
        public static SqlConnection GetConnection()
        {
            CreateTables();
            return new SqlConnection(ConnectionString); ;
        }
        public static void ExecuteNonQuery(SqlConnection myConn, string str)
        {
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();

            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        public static void CreateTables()
        {
            if (!tablesCreated)
            {
                try
                {
                    ExecuteNonQuery(sqlConnection,
                                    "CREATE TABLE Books " +
                                    "(insb varchar (1024) PRIMARY KEY," +
                                    " title varchar (1024)," +
                                    " creationDate datetime," +
                                    " numberOfPages int," +
                                    " price float, " +
                                    " stock int)");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);

                }

                try
                {
                    ExecuteNonQuery(sqlConnection,
                                   "CREATE TABLE Authors " +
                                   "(author_id int IDENTITY(1,1) NOT NULL PRIMARY KEY," +
                                   "name varchar (1024) NOT NULL)");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);

                }

                try
                {
                    ExecuteNonQuery(sqlConnection,
                                    "CREATE TABLE Reviews " +
                                    "(review_id int IDENTITY(1,1) NOT NULL PRIMARY KEY," +
                                    "rating int," +
                                    "review varchar (1024)," +
                                    "book_id varchar (1024) NOT NULL FOREIGN KEY References Books(insb))");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);

                }

                try
                {
                    ExecuteNonQuery(sqlConnection,
                                    "CREATE TABLE AuthorBooks " +
                                    "(author_id int NOT NULL FOREIGN KEY REFERENCES Authors(author_id)," +
                                    "book_id varchar (1024) NOT NULL FOREIGN KEY REFERENCES Books(insb))");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            tablesCreated = true;
        }
    }
}