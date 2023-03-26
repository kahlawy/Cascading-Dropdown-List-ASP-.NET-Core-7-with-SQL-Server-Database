using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress , ErrorMessage = "Please enter valid Email")]
        public string? Email { get; set; }

        [Required]
        [ForeignKey("Country")]
        [DisplayName("Country")]
        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        [Required]
        [ForeignKey("City")]
        [DisplayName("City")]
        public int CityId { get; set; }
        public virtual City? City { get; set; }

    }
}
