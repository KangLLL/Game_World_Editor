using System;
using System.Collections.Generic;
using System.Text;

namespace WorldEditor
{
    public class EventVariable
    {
        public EventVariable()
        {
            this.name = "variable" + this.GetHashCode();
        }

        public EventVariable(string name, int value)
        {
            this.name = name;
            this.variableValue = value;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int variableValue;

        public int VariableValue
        {
            get { return variableValue; }
            set { variableValue = value; }
        }

        public override string ToString()
        {
            return this.name;
        }

    }
}
