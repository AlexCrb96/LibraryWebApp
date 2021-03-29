using LibraryWebApp.Entities;
using LibraryWebApp.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace LibraryWebApp.Repositories
{
    public class RatingAndReviewRepository
    {
        private SqlConnection _connection;

        public RatingAndReviewRepository()
        {
            this._connection = Utils.DbUtils.GetConnection();
        }

        public void AddReview(RatingAndReview review)
        {
            String sql =
                "INSERT INTO Reviews (rating, review, book_id) VALUES ('" + review.Rating.ToString() + "','" + review.Review + "','" + review.BookId.ToString() + "')";
            DbUtils.ExecuteNonQuery(_connection, sql);
        }

        public void RemoveReview(int id)
        {
            String sql = "DELETE FROM Reviews WHERE review_id = '" + id.ToString() + "'";
            DbUtils.ExecuteNonQuery(_connection, sql);
        }

        public void UpdateReview(int id, RatingAndReview review)
        {
            String sql = "UPDATE Reviews SET Rating ='" + review.Rating +
                         "' , Review = '" + review.Review +
                         "' WHERE review_id ='" + id.ToString() + "'";
            DbUtils.ExecuteNonQuery(_connection, sql);
        }

        public List<RatingAndReview> SelectAllReviewsByBookInsb(Guid insb)
        {

            List<RatingAndReview> reviewList = new List<RatingAndReview>();
            String sql = "SELECT * FROM Reviews WHERE book_id = '" + insb.ToString() + "'";
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reviewList.Add(new RatingAndReview(Int32.Parse(reader["review_id"].ToString()), Int32.Parse(reader["Rating"].ToString()), reader["review"].ToString(), Guid.Parse(reader["book_id"].ToString())));
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

            return reviewList;
        }

        public List<RatingAndReview> SelectAllReviews()
        {

            List<RatingAndReview> reviewList = new List<RatingAndReview>();
            String sql = "SELECT * FROM Reviews";
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reviewList.Add(new RatingAndReview(Int32.Parse(reader["review_id"].ToString()), Int32.Parse(reader["Rating"].ToString()), reader["review"].ToString(), Guid.Parse(reader["book_id"].ToString())));
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

            return reviewList;
        }

        public RatingAndReview SelectReviewById(int id)
        {
            RatingAndReview review = null;
            String sql = "SELECT * FROM Reviews WHERE review_id = '" + id + "'";
            SqlCommand command = new SqlCommand(sql, _connection);

            try
            {
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        review = new RatingAndReview(Int32.Parse(reader["review_id"].ToString()), Int32.Parse(reader["rating"].ToString()), reader["review"].ToString(), Guid.Parse(reader["book_id]"].ToString()));
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
            return review;
        }
    }
}