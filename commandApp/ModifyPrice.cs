using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace commandApp
{
    internal class ModifyPrice
    {
        private readonly List<IProductCommand> _commands;
        private IProductCommand _command;

        public ModifyPrice()
        {
            _commands = new List<IProductCommand>();
        }

        public void SetCommand(IProductCommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _commands.Add(_command);
            _command.Execute();
        }
    }
}
