using Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }



    }
}
