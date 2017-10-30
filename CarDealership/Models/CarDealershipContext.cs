using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class CarDealershipContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CarDealershipContext() : base("name=CarDealershipContext")
        {
        }

        public System.Data.Entity.DbSet<CarDealership.Models.Buyer> Buyers { get; set; }

        public System.Data.Entity.DbSet<CarDealership.Models.Car> Cars { get; set; }

        public System.Data.Entity.DbSet<CarDealership.Models.Car_Buyer> Car_Buyer { get; set; }
    }
}
