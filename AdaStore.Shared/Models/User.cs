﻿using AdaStore.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdaStore.Shared.Models
{
    public class User : IdentityUser<int>
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(12, ErrorMessage = "12 caracteres máximo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(30, ErrorMessage = "30 caracteres máximo")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$", ErrorMessage = "El formato es incorrecto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(16, ErrorMessage = "16 caracteres máximo")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(60, ErrorMessage = "60 caracteres máximo")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(20, ErrorMessage = "20 caracteres máximo")]
        public string Document { get; set; }
        public Profiles Profile { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public string Password { get; set; }
    }
}