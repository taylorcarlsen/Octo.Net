using System;
using System.Collections.Generic;
using System.Text;

namespace Octo.Net.Data
{
    class Artwork
    {
        public int Id { get; set; }
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public bool IsCommission { get; set; }
        public int TagId { get; set; }
        public int CollectionMessageId { get; set; }
    }
}
