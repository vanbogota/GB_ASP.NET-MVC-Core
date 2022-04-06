using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1_4
{
    public class ListCover<T>
    {       
        public List<T> ThreadList { get; set; }
        public ListCover()
        {
            ThreadList = new List<T>();
        }
        public void MyAdd(T item)
        {
            lock (ThreadList)
            {
                ThreadList.Add(item);
            }                       
        }
        public void MyDelete(T item)
        {
            lock (ThreadList)
            {
                ThreadList.Remove(item);
            }            
        }
    }
}
