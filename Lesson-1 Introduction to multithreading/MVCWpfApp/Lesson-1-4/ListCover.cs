using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1_4
{
    public class ListCover<T>
    {       
        public List<T> MyProperty { get; set; }
        public ListCover()
        {
            MyProperty = new List<T>();
        }
        public void MyAdd(T item)
        {
            lock (MyProperty)
            {
                MyProperty.Add(item);
            }                       
        }
        public void MyDelete(T item)
        {
            lock (MyProperty)
            {
                MyProperty.Remove(item);
            }            
        }
    }
}
