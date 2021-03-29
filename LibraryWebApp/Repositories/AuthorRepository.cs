using LibraryWebApp.Entities;
using LibraryWebApp.Services;
using LibraryWebApp.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryWebApp.Repositories
{ 
    public class AuthorRepository
    {
        private SqlConnection _connection;

        public AuthorRepository()
        {
            this._connection = DbUtils.GetConnection();
        }
        
        public void AddAuthor(Author author)
        {
            String sql =
                "INSERT INTO Authors (name) VALUES ('" + author.Name + "')";
            DbUtils.ExecuteNonQuery(_connection, sql);
        }

        public void RemoveAuthor(int authorId)
        {
            String sql = "DELETE FROM Authors WHERE author_id = '" + authorId.ToString() + "'";
            DbUtils.ExecuteNonQuery(_connection, sql);
        }

        public void UpdateAuthor(Author author)
        {
            String sql = "UPDATE Authors SET Name ='" + author.Name +
                         "' WHERE author_id ='" + author.Id.ToString() + "'";
            DbUtils.ExecuteNonQuery(_connection, sql);
        }

        public List<Author> SelectAllAuthors()
        {
            List<Author> authorList = new List<Author>();
            String sql = "SELECT * FROM Authors";
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authorList.Add(new Author(Int32.Parse(reader["author_id"].ToString()), reader["name"].ToString(), null));
                    }
                }


            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);

            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return authorList;
        }

        public Author SelectAuthorById(int id)
        {
            Author author = null;
            String sql = "SELECT * FROM Authors WHERE author_id = '" + id + "'";
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        author = new Author(Int32.Parse(reader["author_id"].ToString()), reader["name"].ToString(), null);
                    }
                }


            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);

            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return author;
        }

        public List<Author> SelectAuthorByBookInsb(Guid insb)
        {
            List<Author> authorList = new List<Author>();
            String sql = "SELECT * FROM Authors a INNER JOIN AuthorBooks ab ON a.author_id = ab.author_id WHERE ab.book_id = '" + insb.ToString() + "'";
             //          "SELECT * FROM Authors WHERE author_id IN (SELECT author_id FROM AuthorBooks WHERE book_id = insb)"  
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authorList.Add(new Author(Int32.Parse(reader["author_id"].ToString()), reader["name"].ToString()));
                    }
                }


            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);

            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return authorList;
        }

    }
}