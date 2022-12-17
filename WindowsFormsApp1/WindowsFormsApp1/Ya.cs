using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Ya
    {
        private bool b = true;
        public (float, float) st11;
        public (float, float) st12;
        public (float, float) st21;
        public (float, float) st22;
        public (float, float) ug;
        public bool Toggle
        {
            get { return b; }
            set { b = value; }
        }
        public Ya((float,float)c11, (float, float)c12, (float, float) c21, (float, float) c22,(float, float)ugl)
        {

             st11 = c11;
             st12 = c12;
             st21 = c21;
             st22 = c22;
             ug = ugl;
        }
    }
}
