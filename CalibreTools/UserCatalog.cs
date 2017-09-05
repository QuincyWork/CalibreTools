using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalibreTools
{
    class CatalogItem
    {        
        public string name;
        public string value;
        public int index;
    }
    
    class UserCatalog
    {       
        public Dictionary<string, List<CatalogItem>> catalogs = new Dictionary<string,List<CatalogItem>>();
    }

    class CatalogTreeItemTag
    {
        public string key;
        public bool bfilter;
    }
}
