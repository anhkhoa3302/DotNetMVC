using System;
using System.Collections.Generic;

namespace DotNetMVC.Models
{
    public partial class OderDetail
    {
        public OderDetail()
        {
            Oders = new HashSet<Oder>();
        }

        public int OderDetailsId { get; set; }
        public int ProId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Product Pro { get; set; } = null!;
        public virtual ICollection<Oder> Oders { get; set; }
    }
}
