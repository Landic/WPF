using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_15
{
    public class ImageModel
    {
        public string Name, Date, Author, Path;
        public List<KeyValue> Ratings;
        public ImageModel()
        {
            Name = Date = Author = Path = null;
            Ratings = new List<KeyValue>();
        }
    }
}
