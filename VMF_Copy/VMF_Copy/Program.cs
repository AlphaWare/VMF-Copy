using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VMF_Copy
{
    /*
     * VMF Copy version 0.4
     * Written by AlphaWare141
     * Debugged by SharpOB
     * 
     * This version only copies texture maps
     * Bump, Normal, etc.. should be added!
     */

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //new VMF_COPY().Run(args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new wfMain());
        }
    }

}
