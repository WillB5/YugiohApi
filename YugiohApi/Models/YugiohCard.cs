using System.ComponentModel.DataAnnotations;

namespace YugiohApi.Models
{
    public class YugiohCard
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; } 
        public CardType CardType { get; set; }

    }

    public enum CardType
    {
        Monster, Spell, Trap
    }
}
