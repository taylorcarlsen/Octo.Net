using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Octo.Net.BL;
using Octo.Net.Models;

namespace Octo.Net.UI.ViewModels
{
    public class UserGalleryArtworkFile
    {
        public Net.Models.User User { get; set; }
        public List<Net.Models.Gallery> Galleries { get; set; }
        public List<Net.Models.Artwork> Artworks { get; set; }
        public List<Net.Models.File> Files { get; set; }
    }
}