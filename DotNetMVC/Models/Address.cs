using System;
using System.Collections.Generic;

namespace DotNetMVC.Models
{
    public partial class Address
    {
        public Address()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int AddId { get; set; }
        public string AddName { get; set; } = null!;
        public string AddCity { get; set; } = null!;
        public string AddDistrict { get; set; } = null!;
        public string AddWard { get; set; } = null!;
        public string AddHouse { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
