using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public DateTime JoinDate { get; set; }
        [DisplayName("Commission Active")]
        public bool CommissionActive { get; set; }
        //public virtual ICollection<File> Files { get; set; }

    }
}
