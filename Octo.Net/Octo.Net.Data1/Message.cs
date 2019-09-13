using System;
using System.Collections.Generic;
using System.Text;

namespace Octo.Net.Data
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public DateTime DateTime { get; set; }
        public int CritiqueId { get; set; }
        public int Rating { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
