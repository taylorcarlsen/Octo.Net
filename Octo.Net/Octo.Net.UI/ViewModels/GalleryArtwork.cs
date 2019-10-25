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
    public class GalleryArtwork
    {
        public List<Net.Models.Gallery> Gallery { get; set; }
        public List<Net.Models.Artwork> Artwork { get; set; }
    }
}