using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsLib.Commands
{
    public abstract class ACommand : ICommand
    {
        public void Execute()
        {
            var sw = new Stopwatch();
            sw.Start();
            DoExecute();
            sw.Stop();
            CM.Instance.Registry(this, sw.ElapsedMilliseconds);
        }

        protected abstract void DoExecute();
    }
}
