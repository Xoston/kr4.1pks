#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kr4._1pks.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название города обязательно")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Регион обязателен")]
        [StringLength(100)]
        public string Region { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Население должно быть положительным")]
        public int Population { get; set; }

        [StringLength(2000)]
        public string? History { get; set; }

        [Url(ErrorMessage = "Некорректный URL герба")]
        public string? CoatOfArmsUrl { get; set; }

        [Url(ErrorMessage = "Некорректный URL фотографии")]
        public string? PhotoUrl { get; set; }

        public List<Attraction> Attractions { get; set; } = new List<Attraction>();
    }
}