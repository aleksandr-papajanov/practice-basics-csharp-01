using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBasicsCSharp01
{
    internal class ConsoleUIMenuItem
    {
        public string Name { get; private set; }
        public Action Action { get; private set; }

        public ConsoleUIMenuItem(string name, Action action)
        {
            Name = name;
            Action = action;
        }
    }
}
