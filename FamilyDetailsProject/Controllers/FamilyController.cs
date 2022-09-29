using Microsoft.AspNetCore.Mvc;
using FamilyDetailsProject.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Dynamic;
using System.Data;
using FamilyDetailsProject.Bussiness_logic;
namespace FamilyDetailsProject.Controllers
{
    public class FamilyController : Controller
    {
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.AddressDetails = GetAddress();
            model.FamilyDetails = GetFamily();
            return View(model);
           }
     private static List<AddressDetails> GetAddress()
        {
            List<AddressDetails> customers = new List<AddressDetails>();
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_display_AddressDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(new AddressDetails
                        {
                            ID = Convert.ToInt32(sdr["ID"].ToString()),
                            State = sdr["State"].ToString(),
                            Mandal = sdr["Mandal"].ToString(),
                            District = sdr["District"].ToString(),
                            Street = sdr["Street"].ToString(),

                            Pincode = Convert.ToInt32(sdr["Pincode"].ToString())
                        });
                    }
                }
                con.Close();
                return customers;
            }
        }
        private static List<FamilyDetails> GetFamily()
        {
            List<FamilyDetails> Employees = new List<FamilyDetails>();
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_display_FamilyDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Employees.Add(new FamilyDetails
                        {

                            ID = Convert.ToInt32(sdr["ID"].ToString()),
                            Name = sdr["Name"].ToString(),
                            FatherName = sdr["FatherName"].ToString(),
                            MotherName = sdr["MotherName"].ToString(),
                            BrotherName = sdr["BrotherName"].ToString(),


                        });
                    }
                    con.Close();
                    return Employees;
                }
            }
        }
        [HttpGet]
        public IActionResult InsertAddress()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertAddress(AddressDetails obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Family_bl.Insertdata(obj);
                if (res == true)
                {
                    ViewData["AddressMessage"] = "Added successfully";
                    //ViewBag.msg = "Inserted Successfully!";
                    //return RedirectToAction("Index", "Family");
                    return View();
                }
                else
                {


                    return View(obj);
                }
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult InsertFamily()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertFamily(FamilyDetails obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Family_bl.Insert(obj);
                if (res == true)
                {
                    // return RedirectToAction("Index","Family");
                    //ViewBag.msg = "Inserted Successfully!";
                    ViewData["AddressMessage"] = "Added successfully";
                    return View();
                }
                else
                {
                    return View(obj);
                }
            }
            return View(obj);
        }
    } 
}


    



