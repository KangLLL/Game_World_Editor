using System;
using System.Collections.Generic;
using System.Text;

namespace WorldEditor
{
    public class Command
    {
        public CommandType TypeID;
        public object[] CommandArgs;
        public object[] CommandVars;

        public Command(CommandType typeID, object[] commandArgs)
        {
            this.TypeID = typeID;
            this.CommandArgs = commandArgs;

            //��ʼ��CommandVars
            switch (this.TypeID)
            {
                case CommandType.CreateGameUnit:
                    {

                    }
                    break;

            }
        }
    }
}
