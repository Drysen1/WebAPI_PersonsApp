using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using WebAPI_XamarinDemo.Models;

namespace WebAPI_XamarinDemo.Data
{
    public class PersonData
    {        
        MySqlConnection conn = new MySqlConnection("YOUR DATABASE CONNECTION GOES HERE"); //You db connection goes here.

        //Get all persons.
        public List<PersonModel> GetAllPersons()
        {
            List<PersonModel> personList = new List<PersonModel>();

            try
            {
                string sql = "SELECT * FROM persons; ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    PersonModel person = new PersonModel(); //When adding to a list have to create a new instance for each source article.
                    person.IDPerson = int.Parse(row["id_persons"].ToString());
                    person.FirstName = row["firstname"].ToString();
                    person.LastName = row["lastname"].ToString();
                    person.Age = int.Parse(row["age"].ToString());

                    personList.Add(person);
                }

                return personList;
            }
            catch (MySqlException ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //db connection to get a specific fly me
        public PersonModel GetOnePerson(int id)
        {
            string sql = "SELECT * FROM persons WHERE id_persons = @id; ";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                PersonModel person = new PersonModel();
                if (dt.Rows.Count <= 0)
                {
                    person = null;
                }
                else
                {
                    person.IDPerson = int.Parse(dt.Rows[0]["id_persons"].ToString());
                    person.FirstName = dt.Rows[0]["firstname"].ToString();
                    person.LastName = dt.Rows[0]["lastname"].ToString();
                    person.Age = int.Parse(dt.Rows[0]["age"].ToString());
                }

                return person;
            }
            catch (MySqlException ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //Db insert 
        public bool InsertNewPerson(PersonModel person)
        {
            bool ok = false;
            string sql = " INSERT INTO persons (firstname, lastname, age) " +
                         " VALUES(@firstname, @lastname, @age); ";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstname", person.FirstName);
                cmd.Parameters.AddWithValue("@lastname", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);
                cmd.ExecuteNonQuery();

                ok = true;
                return ok;
            }
            catch (MySqlException ex)
            {
                return ok;
            }
            finally
            {
                conn.Close();
            }
        }

        //db update
        public bool UpdatePerson(PersonModel person)
        {
            bool ok = false;
            string sql = "UPDATE persons SET firstname = @firstname, lastname = @lastname, age = @age WHERE id_persons = @idperson;";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idperson", person.IDPerson);
                cmd.Parameters.AddWithValue("@firstname", person.FirstName);
                cmd.Parameters.AddWithValue("@lastname", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);
                cmd.ExecuteNonQuery();

                ok = true;
                return ok;
            }
            catch (MySqlException ex)
            {
                return ok;
            }
            finally
            {
                conn.Close();
            }
        }

        //db Delete Hard delete, should probably implement soft delete in a real application.
        public bool DeletePerson(int id)
        {
            bool ok = false;
            string sql = "DELETE FROM persons WHERE id_persons = @idperson; ";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idperson", id);
                cmd.ExecuteNonQuery();

                ok = true;
                return ok;
            }
            catch (MySqlException ex)
            {
                return ok;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}