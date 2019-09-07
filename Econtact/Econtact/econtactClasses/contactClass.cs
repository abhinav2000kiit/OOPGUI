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
        public double ContactId { get; set; }
        public string Firsttname { get; set; }
        public string Lastname { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }


        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        

        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql1 = "SELECT * FROM tbl_contact";
                SqlCommand cmnd = new SqlCommand(sql1, con);
                SqlDataAdapter adpt = new SqlDataAdapter(cmnd);
                con.Open();
                adpt.Fill(dt);
            }
            catch(Exception e1)
            {

            }
            finally
            {
                con.Close();
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
                cmd.Parameters.AddWithValue("@FirstName",c.Firsttname);
                cmd.Parameters.AddWithValue("@LastName",c.Lastname);
                cmd.Parameters.AddWithValue("@ContactNo",c.ContactNo);
                cmd.Parameters.AddWithValue("@FAddress",c.Address);
                cmd.Parameters.AddWithValue("@FirstName",c.Gender);
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
            catch(Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSUCCESS;
        }
    } 

}


