using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace broker.Models
{
    public class MasterContext:DbContext
    {
        public MasterContext()
            : base("MasterContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<broker.Models.brokerr> brokerrs { get; set; }

        public System.Data.Entity.DbSet<broker.Models.customer> customers { get; set; }

        public System.Data.Entity.DbSet<broker.Models.pointss> pointsses { get; set; }
    }
}