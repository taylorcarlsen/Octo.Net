namespace Octo.Net.Data1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string Body { get; set; }

        public DateTime? DateTime { get; set; }

        public int? CritiqueId { get; set; }

        public int? Rating { get; set; }

        public int? X { get; set; }

        public int? Y { get; set; }
    }
}
