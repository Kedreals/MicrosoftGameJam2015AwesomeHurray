using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Core
{
    interface IControlable
    {
        void OnKeyPress(object sender, KeyEventArgs e);
        void OnKeyRelease(object sender, KeyEventArgs e);

        void OnButtonPress(object sender, MouseButtonEventArgs e);
        void OnButtonRelease(object sender, MouseButtonEventArgs e);
    }
}
