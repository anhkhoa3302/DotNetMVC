using System;
using System.Collections.Generic;

namespace DotNetMVC.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            OderDetails = new HashSet<OderDetail>();
        }

        public int ProId { get; set; }
        public string ProName { get; set; } = null!;
        public int? CateId { get; set; }
        public int? ImgId { get; set; }
        public string? ProDescription { get; set; }
        public decimal ProPrice { get; set; }
        public int ProStock { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Category? Cate { get; set; }
        public virtual Image? Img { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OderDetail> OderDetails { get; set; }
    }
}
