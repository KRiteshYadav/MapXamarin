using System;
using System.Collections.Generic;
using System.Text;

namespace Maps.Models
{
    public class StoreInfo
    {
        public virtual long StoreId { get; set; }
        public virtual string StoreName { get; set; }
        public virtual string Phone { get; set; }
        
        public List<ItemCatalogueModel> ListItems { set; get; }
    }
}

