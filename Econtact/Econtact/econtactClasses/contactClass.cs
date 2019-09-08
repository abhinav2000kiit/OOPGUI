using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact.econtactClasses
{
    class contactClass
    {
        public double ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }


        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql1 = "SELECT * FROM tbl_contact";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool Insert(contactClass c)
        {
            bool isSUCCESS = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "INSERT INTO tbl_contact(FirstName,LastName,ContactNo,Address,Gender) VALUES (@FirstName,@LastName,@ContactNo,@Address,@Gender)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName",c.FirstName);
                cmd.Parameters.AddWithValue("@LastName",c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo",c.ContactNo);
                cmd.Parameters.AddWithValue("@Address",c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    isSUCCESS = true;
                }
                else
                {
                    isSUCCESS = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSUCCESS;
        }
    



        //Method to update Data in database from our application
        public bool Update (contactClass c)
        {
            //Create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection (myconnstrng);
            try
            {
                //SQL to update data in our database
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName, LastName=@LastName, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";

                //Created SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create parameters to add value
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("ConatctID", c.ContactID);
                //Open Database Connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if the query runs successfully then the value of rows will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return isSuccess;
        }


        //Method to delete data from database
        public bool Delete(contactClass c)
        {
            //create a default return value and set its value to false
            bool isSuccess = false;
            //create sql Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL to delete data
                string sql = "DELETE FROM tbl_contact WHERE ContactID=@ContactID";

                //Creating sql command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                //Open connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if the query runs successfully then the value of rows will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return isSuccess;


        }
    }
}
