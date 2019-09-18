using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsCommission { get; set; }
        public int TagId { get; set; }
        public int CollectionMessageId { get; set; }
    }
}
