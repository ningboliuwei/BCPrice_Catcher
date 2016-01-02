using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPrice_Catcher.Model
{
    public class AccountInfo
    {
        public double Total { get; set; }
        public double NetAsset { get; set; }
        public double AvailableCny { get; set; }
        public double AvailableBtc { get; set; }
    }
}