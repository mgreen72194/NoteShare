using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NoteShare.WebApi
{
    public class InitialDbSetup
    {

        public InitialDbSetup()
        {

        }


        public void createData()
        {
            string connectionString;
            SqlConnection conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string query;

            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NoteShare";
            conn = new SqlConnection(connectionString);
            conn.Open();
            query = "Insert Into Note (Author, Content, Course) Values ('Matt','This is a Note','Operation Systems')";
            command = new SqlCommand(query, conn);
            adapter.InsertCommand = command;
            try
            {
                adapter.InsertCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {

            }
            query = "Insert Into Note (Author, Content, Course) Values ('Student','This is another Note','Operation Systems')";
            command = new SqlCommand(query, conn);
            adapter.InsertCommand = command;
            try
            {
                adapter.InsertCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {

            }
            command.Dispose();
            conn.Close();
        }
    }
}
