﻿namespace Maps.Models
{
    public class ItemCatalogueModel
    {
        public virtual long ItemId { get; set; }
        public virtual string ItemName { get; set; }
        public virtual float Price { get; set; }
        public virtual string ItemDescription { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual long Quantity { get; set; }
        public virtual byte[] ItemImage { get; set; }
    }
}