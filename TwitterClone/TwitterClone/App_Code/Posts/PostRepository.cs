using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TwitterClone.App_Code.Posts
{
    public class PostRepository
    {
        public IEnumerable<Posts> GetAllPosts()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\it114l-b54-39\source\repos\TwitterClone\TwitterClone\App_Data\TwitterClone.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT * " +
                    "FROM Posts " +
                    "ORDER BY postedOn DESC";
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Posts()
                    {
                        Content = (string)row["content"],
                        PostedBy = (string)row["postedBy"]
                    })
                    .ToList();
            }
        }

         //return new List<Posts>
         //   {
         //       new Posts() { Content = "Hello World!", PostedBy = "joblipat" },
         //       new Posts() { Content = "Hello New World!", PostedBy = "joelee" },
         //       new Posts() { Content = "Hello New New World!", PostedBy = "jimlim" },
         //       new Posts() { Content = "Hi!", PostedBy = "joblipat" }
    };
}
