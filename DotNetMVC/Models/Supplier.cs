using System;
using System.Collections.Generic;

namespace DotNetMVC.Models
{
    public partial class Supplier
    {
        public int SupId { get; set; }
        public string SupPhone { get; set; } = null!;
        public string SupName { get; set; } = null!;
        public string SupEmail { get; set; } = null!;
        public int AddId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Address Add { get; set; } = null!;
    }
}
