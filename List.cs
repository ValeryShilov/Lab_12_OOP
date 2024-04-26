using Lab_10_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_OOP
{
    public class HElement<TValue>: ICloneable
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

        public HElement(HElement<TValue> c)
        {
            if (c == null)
            {
                throw new NullReferenceException();
            }
            this.key = c.key;
            
            HElement<TValue> current = c;
            HElement<TValue> currentThis = this;

            while (current != null)
            {
                currentThis.Value = (TValue)((ICloneable)current.Value).Clone();
                currentThis.key = current.key;
                if (current.next != null)
                {
                    current = current.next;
                    currentThis.next = new HElement<TValue>();
                    currentThis = currentThis.next;
                }
                else break;
            }
            currentThis.next = null;
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

        public object Clone()
        {
            return new HElement<TValue>(this);
        }
    }
}
