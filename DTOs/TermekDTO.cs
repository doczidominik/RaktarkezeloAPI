using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaktarkezeloAPI.DTOs
{
    public class TermekDTO
    {

        public TermekDTO(int id, int termekcsoportID, int raktarID,
            int ar, double afakulcs, string termekneve, double raktarkeszlet)
        {
            this.id = id;
            this.termekcsoportID = termekcsoportID;
            this.raktarID = raktarID;
            this.ar = ar;
            this.afakulcs = afakulcs;
            this.termekneve = termekneve;
            this.raktarkeszlet = raktarkeszlet;
        }
        public int id { get; set; }
        public int termekcsoportID { get; set; }
        public int raktarID { get; set; }
        public int ar { get; set; }
        public double afakulcs { get; set; }
        public string termekneve { get; set; }

        public double raktarkeszlet { get; set; }
    }
}
