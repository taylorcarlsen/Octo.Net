namespace Octo.Net.Data1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblMessageType
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Description { get; set; }
    }
}
