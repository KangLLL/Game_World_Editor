using System;
using System.Collections.Generic;
using System.Text;

namespace WorldEditor
{
    public class GameEventAction
    {

        private Command[] commandArray;
        private List<Command> commandList;
        private int currentCommandIndex = -1;

        public List<Command> CommandList
        {
            get
            {
                return this.commandList;
            }
        }

        public GameEventAction()
        {
            this.commandList = new List<Command>();
        }

        public GameEventAction(Command[] commandArray)
        {
            this.commandArray = commandArray;
        }

        public bool HasNextCommand()
        {
            return this.currentCommandIndex < commandArray.Length-1;
        }

        public Command NextCommand()
        {
            this.currentCommandIndex++;
            return this.commandArray[this.currentCommandIndex];
        }

        public Command GetCurrentCommand()
        {
            return this.commandArray[this.currentCommandIndex];
        }

        public GameEventAction Clone()
        {
            Command[] commandArray = new Command[this.commandArray.Length];
            for (int i = 0; i < commandArray.Length; i++)
            {
                commandArray[i] = new Command(this.commandArray[i].TypeID, this.commandArray[i].CommandArgs);
            }
            return new GameEventAction(commandArray);
        }
    }
}
