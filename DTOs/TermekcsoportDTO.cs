using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaktarkezeloAPI.DTOs
{
    public class TermekcsoportDTO
    {
        public TermekcsoportDTO(int id, string termekcsoportnev)
        {
            this.id = id;
            this.termekcsoportnev = termekcsoportnev;
        }

        public int id { get; set; }

        public string termekcsoportnev { get; set; }
    }
}
