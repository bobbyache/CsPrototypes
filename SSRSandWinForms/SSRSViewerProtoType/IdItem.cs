using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRSViewerProtoType
{
    public class IdItem
    {
        public int Id { get; private set; }
        public string Title { get; private set; }

        public IdItem(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
