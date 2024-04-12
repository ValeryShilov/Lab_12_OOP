using Lab_10_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_OOP
{
    public class HElement<TValue>
    {
        public int key;
        private TValue val;
        public HElement<TValue> next;

        public TValue Value 
        {
            get { return val; }
            set { val = value; }
        }

        public HElement()
        {
            
        }

        public HElement(TValue v)
        {
            Value = v;
            key = GetHashCode();
            next = null;
        }

        public override int GetHashCode()
        {
            int code = 0;
            foreach (char c in Value.ToString())
            {
                code = (code * 3) + c;
            }
            return code;

        }

        public override string ToString()
        {
            return key + ":" + Value.ToString();
        }

        public override bool Equals(object? obj)
        {
            HElement<TValue> hElement = obj as HElement<TValue>;
            if (hElement != null)
            {
                return key == hElement.key && Value.Equals(hElement.Value);
            }
            return false;
        }
    }
}
