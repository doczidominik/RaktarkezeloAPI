using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RaktarkezeloAPI.Models
{
    [Index(nameof(termekcsoportID), nameof(raktarID), Name = "TermékcsoportID")]
    [Index(nameof(raktarID), Name = "raktarID")]
    public partial class termek
    {
        public termek()
        {
            eladas = new HashSet<eladas>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Column(TypeName = "int(11)")]
        public int termekcsoportID { get; set; }
        [Column(TypeName = "int(11)")]
        public int raktarID { get; set; }
        [Column(TypeName = "int(11)")]
        public int ar { get; set; }
        public double afakulcs { get; set; }
        [Required]
        [StringLength(100)]
        public string termekneve { get; set; }
        public double raktarkeszlet { get; set; }

        [ForeignKey(nameof(raktarID))]
        [InverseProperty("termek")]
        public virtual raktar raktar { get; set; }
        [ForeignKey(nameof(termekcsoportID))]
        [InverseProperty("termek")]
        public virtual termekcsoport termekcsoport { get; set; }
        [InverseProperty("termek")]
        public virtual ICollection<eladas> eladas { get; set; }
    }
}
