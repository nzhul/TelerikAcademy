namespace Cars.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class City
    {
        public int Id { get; set; }

        //[Index(IsUnique = true)]
        [MaxLength(11)]
        [Required]
        public string Name { get; set; }
    }
}
