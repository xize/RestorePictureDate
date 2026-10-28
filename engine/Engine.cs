using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RestorePictureDate.engine
{
    internal interface Engine
    {

        String Name { get; }

        Task AsyncRun(Window win);

    }
}