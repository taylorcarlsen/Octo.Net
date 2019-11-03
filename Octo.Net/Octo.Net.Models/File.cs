using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.Models
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ArtworkId { get; set; }
        public virtual Artwork Artwork { get; set; }
    }
}
