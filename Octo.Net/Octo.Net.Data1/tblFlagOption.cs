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
    public class tblFlagOption
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
