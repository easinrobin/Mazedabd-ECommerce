using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.Models
{
    public class ImageGallery
    {
        public long Id { get; set; }
        public string ImageTitle { get; set; }
        public string ImagePath { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
