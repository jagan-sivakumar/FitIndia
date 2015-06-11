using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FitIndia.Models
{
    public class DataContext : DbContext
    {
        public DbSet<User> UserDetails { get; set; }
        public DbSet<TreatmentReport> TreatmentReports { get; set; }
        public DbSet<BillReport> BillReports { get; set; }
    }
}