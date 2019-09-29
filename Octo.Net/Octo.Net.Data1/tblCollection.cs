namespace Octo.Net.Data1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCollection
    {
        public int Id { get; set; }

        public int MessageId { get; set; }

        public int? MessageTypeId { get; set; }
    }
}
