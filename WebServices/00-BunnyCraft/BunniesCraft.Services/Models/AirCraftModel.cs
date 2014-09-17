namespace BunniesCraft.Services.Models
{
    using Antlr.Runtime.Misc;
    using BunniesCraft.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    public class AirCraftModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Model { get; set; }
    }
}