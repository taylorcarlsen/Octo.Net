namespace Octo.Net.Data1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artwork
    {
        public int Id { get; set; }

        public int? GalleryId { get; set; }

        [StringLength(25)]
        public string Title { get; set; }

        public decimal? Price { get; set; }

        public bool? IsCommission { get; set; }

        public int? TagId { get; set; }

        public int? CollectionMessageId { get; set; }
    }
}
