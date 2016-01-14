using GongSolutions.Shell;
using GongSolutions.Shell.Interop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WorkFlowMenagementMDI.Tracking.Methods
{
    public sealed class ShellNetworkComputers :IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            ShellItem folder = new ShellItem((Environment.SpecialFolder)CSIDL.NETWORK);
            IEnumerator<ShellItem> e = folder.GetEnumerator(SHCONTF.FOLDERS);

            while (e.MoveNext())
            {
                Debug.Print(e.Current.ParsingName);
                yield return e.Current.ParsingName;

                Console.WriteLine(e.Current.ParsingName);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
