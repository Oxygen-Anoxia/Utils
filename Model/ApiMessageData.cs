using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApiMessageData<T>
    {
        public String message { get; set; }
        public int? totalItems { get; set; }
        public int? startIndex { get; set; }
        public int? itemsPerPage { get; set; }
        public List<T> items { get; set; }
    }

    public class ApiMessageData
    {
        public String message { get; set; }
        public int totalItems { get; set; }
        public int startIndex { get; set; }
        public int itemsPerPage { get; set; }
        public Object[] items { get; set; }

        public ApiMessageData()
        {
            message = "";
            totalItems = 0;
            startIndex = 0;
            itemsPerPage = 0;
            items = null;
        }

        public void setItems(Object amd)
        {
            items = new Object[1];
            items[0] = amd;
        }
        public void setItems(Object[] amd)
        {
            items = amd;
        }

        public void setItems()
        {
            items = new Object[0];
        }
    }
}
