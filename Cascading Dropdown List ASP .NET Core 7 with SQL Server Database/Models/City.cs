using Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string? CityName { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country? country { get; set; }


    }
}
