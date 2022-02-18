using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Custom_TabControl : TabControl
    {
        public Custom_TabControl()
        {

        }
        public Custom_TabControl ShallowCopy()
        {
            return (Custom_TabControl)this.MemberwiseClone();
        }
    }
}
