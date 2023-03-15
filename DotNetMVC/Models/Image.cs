using System;
using System.Collections.Generic;

namespace DotNetMVC.Models
{
    public partial class Image
    {
        public Image()
        {
            Products = new HashSet<Product>();
        }

        public int ImgId { get; set; }
        public string ImgUrl { get; set; } = null!;
        public string ImgThumb { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
