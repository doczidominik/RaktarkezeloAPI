using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RaktarkezeloAPI.Models
{
    public partial class raktar
    {
        public raktar()
        {
            termek = new HashSet<termek>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string raktarnev { get; set; }
        [Required]
        [StringLength(100)]
        public string raktarhely { get; set; }

        [InverseProperty("raktar")]
        public virtual ICollection<termek> termek { get; set; }
    }
}
