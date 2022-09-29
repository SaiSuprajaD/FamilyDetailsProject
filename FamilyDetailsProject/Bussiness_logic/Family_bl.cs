using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using FamilyDetailsProject.Models;

namespace FamilyDetailsProject.Bussiness_logic
{
    public class Family_bl
    {

        public static bool Insertdata(AddressDetails obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))

            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("sp_AddressDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@State", obj.State);
                    cmd.Parameters.AddWithValue("@Mandal", obj.Mandal);
                    cmd.Parameters.AddWithValue("@District", obj.District);
                    cmd.Parameters.AddWithValue("@Street", obj.Street); 
                    cmd.Parameters.AddWithValue("@Pincode", obj.Pincode);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }
        public static bool Insert(FamilyDetails obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))

            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("sp_FamilyDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@FatherName", obj.FatherName);
                    cmd.Parameters.AddWithValue("@MotherName", obj.MotherName);
                    cmd.Parameters.AddWithValue("@BrotherName", obj.BrotherName);

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }
       
    }
}
    