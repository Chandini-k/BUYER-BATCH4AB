using System;
using System.Collections.Generic;
using System.Text;

namespace BUYERDBENTITY.Models
{
    public class ProductSubCategory
    {
        public string subCategoryName { get; set; }
        public int subCategoryId { get; set; }
        public int? categoryId { get; set; }
        public string subCategoryDetails { get; set; }
        public int? gst { get; set; }
        public string categoryName { get; set; }
    }
}
