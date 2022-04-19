using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RaktarkezeloAPI.Models
{
    [Index(nameof(termekID), Name = "TermékID")]
    public partial class eladas
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Column(TypeName = "int(11)")]
        public int termekID { get; set; }
        [Column(TypeName = "int(11)")]
        public int mennyiseg { get; set; }
        [Column(TypeName = "date")]
        public DateTime datum { get; set; }

        [ForeignKey(nameof(termekID))]
        [InverseProperty("eladas")]
        public virtual termek termek { get; set; }
    }
}
