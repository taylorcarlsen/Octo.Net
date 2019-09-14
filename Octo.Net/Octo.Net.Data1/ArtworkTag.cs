namespace Octo.Net.Data1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ArtworkTag
    {
        public int Id { get; set; }

        public int? ArtworkId { get; set; }

        public int? TagId { get; set; }
    }
}
