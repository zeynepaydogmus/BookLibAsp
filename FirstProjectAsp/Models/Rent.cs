﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProjectAsp.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OgrenciId { get; set; }

        [ValidateNever]

        public int BookId { get; set; }
        [ForeignKey("BookId")]


        [ValidateNever]
        public Book Book { get; set; }


    }
}
