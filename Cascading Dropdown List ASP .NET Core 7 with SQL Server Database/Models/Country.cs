using System.ComponentModel.DataAnnotations;

namespace Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string? countryName { get; set; }



    }
}
