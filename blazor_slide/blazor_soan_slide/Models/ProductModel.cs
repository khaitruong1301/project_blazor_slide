using System.Collections.Generic;

public class ProductModel
{
   public long id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public long price { get; set; }
        public string description { get; set; }
        public string size { get; set; }
        public long[] sizes { get; set; }
        public string shortDescription { get; set; }
        public long quantity { get; set; }
        public bool deleted { get; set; }
        public string categories { get; set; }
        public string relatedProducts { get; set; }
        public bool feature { get; set; }
        public string image { get; set; }
        public string imgLink { get; set; }
}
