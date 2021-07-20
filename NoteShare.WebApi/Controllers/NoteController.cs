using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NoteShare.WebApi.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        public NoteController()
        {

        }

        private Note CreateNote()
        {
            return null;
        }

        [HttpGet]
        public Note[] Get()
        {
            List<Note> notes = new List<Note>();
            string connectionString;
            SqlConnection conn;
            SqlCommand command;
            SqlDataReader dataReader;
            string query;

            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NoteShare";
            conn = new SqlConnection(connectionString);

            conn.Open();
            query = "Select * From Note";

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                notes.Add(new Note
                {
                    Id = (int)dataReader.GetValue(0),
                    Author = (string)dataReader.GetValue(1),
                    Content = (string)dataReader.GetValue(2),
                    Course = (string)dataReader.GetValue(3)
                });
            }
            command.Dispose();
            conn.Close();
            return notes.ToArray();
        }

        [HttpGet]
        public Note[] GetById(int id)
        {
            List<Note> notes = new List<Note>();
            string connectionString;
            SqlConnection conn;
            SqlCommand command;
            SqlDataReader dataReader;
            string query;

            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NoteShare";
            conn = new SqlConnection(connectionString);

            conn.Open();
            query = "Select * From Note Where Id = " + id;

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                notes.Add(new Note
                {
                    Id = (int)dataReader.GetValue(0),
                    Author = (string)dataReader.GetValue(1),
                    Content = (string)dataReader.GetValue(2),
                    Course = (string)dataReader.GetValue(3)
                });
            }
            command.Dispose();
            conn.Close();
            return notes.ToArray();
        }

        [HttpPost]
        public IActionResult Post(Note note)
        {

            string connectionString;
            SqlConnection conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string query;

            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NoteShare";
            conn = new SqlConnection(connectionString);

            conn.Open();
            query = "Insert into Note (Author, Content, Course) Values('"+note.Author+"','"+note.Content+"','"+note.Course+"')";

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

            return Ok();
        }
        [HttpGet]
        public Note[] Search(string name)
        {
            return null;
        }


    }
}
