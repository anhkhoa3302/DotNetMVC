using System;
using System.Collections.Generic;

namespace DotNetMVC.Models
{
    public partial class Oder
    {
        public int OderId { get; set; }
        public string UserId { get; set; } = null!;
        public int OderStatus { get; set; }
        public int OderDetailId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual OderDetail OderDetail { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}
