using CommandsLib.Memento;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsLib.Commands
{
    public class CM
    {
        #region Sinlgeton
        private static CM? _instance;
        private CM() 
        {
            _commands = new List<ICommand>();
            Backup();
        }
        public static CM Instance 
        {
            get 
            {
                if (_instance == null)
                    _instance = new CM();
                return _instance;
            }
        }
        #endregion
        private readonly long _timeout = (long)5e3;
        private readonly long _maxMemory = (long)1e7;
        private List<ICommand> _commands;
        private bool _block = false;
        private long _currentTime = 0;
        private List<long> _memory = new List<long>();
        public void Registry(ACommand command, long time = 0) 
        {
            if (_block) return;
            _commands.Add(command);
            CheckTime(time);
        }

        private bool RemoveCommand() 
        {
            var lastCommand = _commands.FindLastIndex((cmd) => cmd is not MementoCompositor);
            if (lastCommand == -1) return false;
            _commands.RemoveRange(lastCommand, _commands.Count - lastCommand);
            return true;
        }

        public void Undo() 
        {
            if (_commands.Count < 2 || !RemoveCommand()) return;

            var lastBackup = _commands.FindLastIndex((cmd) => cmd is MementoCompositor);
            _block = true;
            for (int i = lastBackup; i < _commands.Count; i++) 
            {
                _commands[i].Execute();
            }
            _block = false;
        }

        private void CheckTime(long time) 
        {
            _currentTime += time;
            if (_currentTime >= _timeout) 
            {
                Backup();
                _currentTime = 0;
            }
        }

        private void CheckMemory(long memory) 
        {
            _memory.Add(memory);
            while (_memory.Sum() >= _maxMemory) 
            {
                var secondBackup = _commands.FindIndex(1, (cmd) => cmd is MementoCompositor);
                if (secondBackup == -1) return;
                Debug.WriteLine(secondBackup);
                _commands.RemoveRange(1, secondBackup - 1);
                _commands.RemoveAt(0);
                _memory.RemoveAt(0);
            }
        }

        public void Backup() 
        {
            if (_commands.Count > 0 && _commands.Last() is MementoCompositor) 
            {
                _commands.RemoveAt(_commands.Count - 1);
            }
            var start = GC.GetTotalMemory(true);
            var backup = (ICommand)MementableSystem.Instance.CreateMemento();
            var total = GC.GetTotalMemory(false) - start;
            _commands.Add(backup);
            CheckMemory(total);
            
        }
    }
}
