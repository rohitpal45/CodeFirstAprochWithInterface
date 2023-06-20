using RohitDI_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RohitDI_Mvc.DAL
{
    public class DataAccess:DbContext
    {
        public DataAccess()
          : base("name=DataAccess")
        {
        }
        public DbSet<Registration> Registration { get; set; }

    }
}