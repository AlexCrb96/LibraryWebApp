using LibraryWebApp.Entities;
using LibraryWebApp.Services;
using LibraryWebApp.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryWebApp.Repositories
{
    public class BookRepository
    {
        private SqlConnection _connection;

        public BookRepository()
        {
            this._connection = DbUtils.GetConnection();

        }

        public void AddBook(Book b)
        {
            String sql =
                "INSERT INTO Books (insb, title, creationDate, numberOfPages, price, stock) VALUES ('" +
                b.Insb.ToString() + "','" + b.Title + "','" + b.CreationDate.ToString() + "','" +
                b.NumberOfPages.ToString() + "','" + b.Price.ToString() + "','" + b.StockAvailable.ToString() + "')";
            DbUtils.ExecuteNonQuery(_connection, sql);

            b.AuthorsId.ForEach(authorId =>
            {
                sql = "INSERT INTO AuthorBooks (author_id, book_id) VALUES ('" + authorId + "','" + b.Insb + "')";
                DbUtils.ExecuteNonQuery(_connection, sql);
            });


        }

        public void RemoveBook(Guid insb)
        {
            String sql = "DELETE FROM AuthorBooks WHERE book_id = '" + insb.ToString() + "'";
            DbUtils.ExecuteNonQuery(_connection, sql);
            sql = "DELETE FROM Books WHERE insb = '" + insb.ToString() + "'";
            DbUtils.ExecuteNonQuery(_connection, sql);
        }

        public void UpdateBook(Book b)
        {
            String sql = "UPDATE Books SET Title ='" + b.Title +
                         "' , CreationDate = '" + b.CreationDate.ToString() +
                         "' , NumberOfPages = '" + b.NumberOfPages.ToString() +
                         "' WHERE Insb ='" + b.Insb.ToString() + "'";
            DbUtils.ExecuteNonQuery(_connection, sql);

            if (b.AuthorsId != null)
            {
                sql = "DELETE FROM AuthorBooks WHERE book_id = '" + b.Insb + "'";

                b.AuthorsId.ForEach(authorId =>
                {
                    sql = "INSERT INTO AuthorBooks (author_id, book_id) VALUES ('" + authorId + "','" + b.Insb + "')";
                    DbUtils.ExecuteNonQuery(_connection, sql);
                });
            }
        }

        public Book SelectBookByInsb(Guid insb)
        {
            Book book = null;
            String sql = "SELECT * FROM Books WHERE insb = '" + insb.ToString() + "'";
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        book = new Book(new Guid(reader["insb"].ToString()), reader["title"].ToString(),
                            null, DateTime.Parse(reader["creationDate"].ToString()),
                            Int32.Parse(reader["numberOfPages"].ToString()),
                            null, Double.Parse(reader["price"].ToString()), Int32.Parse(reader["stock"].ToString()));



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

            return book;
        }

        public List<Book> SelectAllBooks()
        {
            List<Book> booksList = new List<Book>();
            String sql = "SELECT * FROM Books";
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        booksList.Add(new Book(new Guid(reader["insb"].ToString()), reader["title"].ToString(),
                            null, DateTime.Parse(reader["creationDate"].ToString()),
                            Int32.Parse(reader["numberOfPages"].ToString()),
                            null, Double.Parse(reader["price"].ToString()), Int32.Parse(reader["stock"].ToString())));


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

            return booksList;
        }

        public List<Book> SelectBooksByAuthor(int authorId)
        {
            List<Book> booksList = new List<Book>();
            String sql = "SELECT * FROM Books INNER JOIN AuthorBooks ON insb = book_id WHERE author_id = '" + authorId + "'";
            SqlCommand command = new SqlCommand(sql, _connection);

            List<Author> authors = new List<Author>();
            List<RatingAndReview> reviews = new List<RatingAndReview>();

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        booksList.Add(new Book(new Guid(reader["insb"].ToString()), reader["title"].ToString(),
                            authors, DateTime.Parse(reader["creationDate"].ToString()),
                            Int32.Parse(reader["numberOfPages"].ToString()),
                            reviews, Double.Parse(reader["price"].ToString()), Int32.Parse(reader["stock"].ToString())));


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

            return booksList;
        }
    }
}