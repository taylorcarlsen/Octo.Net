namespace Octo.Net.Data1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gallery
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        [StringLength(25)]
        public string GalleryName { get; set; }

        [StringLength(120)]
        public string GalleryDescription { get; set; }
    }
}
