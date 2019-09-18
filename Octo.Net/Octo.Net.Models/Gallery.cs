using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GalleryName { get; set; }
        public string GalleryDescription { get; set; }
    }
}
