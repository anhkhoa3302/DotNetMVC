using System;
using System.Collections.Generic;

namespace DotNetMVC.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int ProId { get; set; }
        public int CartQuantity { get; set; }
        public int CartTotle { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Product Pro { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}
