using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articles.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
