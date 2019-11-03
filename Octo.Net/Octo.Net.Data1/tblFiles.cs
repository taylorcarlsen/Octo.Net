using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Octo.Net.Data1
{
    public class tblFiles
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public tblFileType FileType { get; set; }
        public int UserId { get; set; }
        public virtual tblUser User { get; set; }
        public int ArtworkId { get; set; }
        public virtual tblArtwork Artwork { get; set; }
    }
}
