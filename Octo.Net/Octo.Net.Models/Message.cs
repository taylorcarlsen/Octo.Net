using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string Body { get; set; }
        public int CollectionId { get; set; }
        public DateTime DateTime { get; set; }
        public int CritiqueId { get; set; }
        public int Rating { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
