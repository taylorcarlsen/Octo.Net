using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int FollowerId { get; set; }
    }
}
