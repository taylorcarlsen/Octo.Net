using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.Models
{
    public class ArtworkFlag
    {
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public int FlagId { get; set; }
        public string Comment { get; set; }
    }
}
