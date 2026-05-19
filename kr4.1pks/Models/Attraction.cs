#nullable enable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kr4._1pks.Models
{
    public class Attraction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(2000)]
        public string? History { get; set; }

        [Url(ErrorMessage = "Некорректный URL фото")]
        public string? PhotoUrl { get; set; }

        [StringLength(100)]
        public string? OpeningHours { get; set; }

        [StringLength(100)]
        public string? EntranceFee { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City? City { get; set; }
    }
}