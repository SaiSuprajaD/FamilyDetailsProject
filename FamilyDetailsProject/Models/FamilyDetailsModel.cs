using FamilyDetailsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDetailsProject.Models
{
    public class FamilyDetailsModel
    {
       
    }
           public class AddressDetails
           {
            public int ID { get; set; }
            public string State { get; set; }
          
            public string Mandal { get; set; }
            public string District { get; set; }
            public string Street { get; set; }
            public int Pincode { get; set; }

        }
        public class FamilyDetails
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string FatherName { get; set; }
            public string MotherName { get; set; }
            public string BrotherName { get; set; }


        }
    }

