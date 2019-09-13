using System;
using System.Collections.Generic;
using System.Text;

namespace Octo.Net.Data
{
    public class ArtworkTag
    {
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public int TagId { get; set; }
    }
}
