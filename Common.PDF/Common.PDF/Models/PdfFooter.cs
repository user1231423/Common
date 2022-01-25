using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PDF.Models
{
    public class PdfFooter
    {
        public bool AddPageNumbers { get; set; } = false;
        public string FooterText { get; set; } = string.Empty;
    }
}
