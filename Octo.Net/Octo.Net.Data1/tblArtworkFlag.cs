using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Octo.Net.Data1
{
    public class tblArtworkFlag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public int UserId { get; set; }
        public int FlagId { get; set; }
        [StringLength(500)]
        public string Comment { get; set; }
    }
}
