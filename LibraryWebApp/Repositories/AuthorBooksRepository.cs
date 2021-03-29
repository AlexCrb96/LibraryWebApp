using LibraryWebApp.Entities;
using LibraryWebApp.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryWebApp.Repositories
{
    public class AuthorBooksRepository
    {
        /*  tabel de legatura cu 2 chei straine */
        private SqlConnection _connection;

        public AuthorBooksRepository()
        {
            this._connection = DbUtils.GetConnection();
        }

        public void AddAuthorBook(AuthorBooks authorBooks)
        {
            String sql =
               "INSERT INTO AuthorBooks (author_id, book_id) VALUES ('" + authorBooks.AuthorId.ToString() + "','" + authorBooks.BookId.ToString() + "')";
            DbUtils.ExecuteNonQuery(_connection, sql);
        }

        public void RemoveAuthorBook(AuthorBooks authorBooks)
        {
            String sql = "DELETE FROM AuthorBooks WHERE author_id = '" + authorBooks.AuthorId.ToString() + "' AND book_id = '" + authorBooks.BookId.ToString() + "'";
            DbUtils.ExecuteNonQuery(_connection, sql);
        }

        public IEnumerable<AuthorBooks> SelectAuthorBookByBookID(int bookId)
        {
            List<AuthorBooks> authorBooksList = new List<AuthorBooks>();
            String sql = "SELECT * FROM AuthorBooks WHERE book_id = '" + bookId + "'";
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authorBooksList.Add(new AuthorBooks(Int32.Parse(reader["author_id"].ToString()), Int32.Parse(reader["book_id"].ToString())));
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

            return authorBooksList;
        }

        public IEnumerable<AuthorBooks> SelectAuthorBookByAuthor(int authorId)
        {
            List<AuthorBooks> authorBooksList = new List<AuthorBooks>();
            String sql = "SELECT * FROM AuthorBooks WHERE author_id = '" + authorId + "'";
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authorBooksList.Add(new AuthorBooks(Int32.Parse(reader["author_id"].ToString()), Int32.Parse(reader["book_id"].ToString())));
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

            return authorBooksList;
        }
    }
}