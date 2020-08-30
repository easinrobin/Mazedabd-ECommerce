using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.Models
{
    public class VideoGallery
    {
        public long Id { get; set; }
        public string VideoTitle { get; set; }
        public string VideoPath { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
