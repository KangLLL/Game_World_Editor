using System;
using System.Collections.Generic;
using System.Text;

namespace WorldEditor
{
    public class GameEventCondition
    {
        public GameEventCondition(GameEventConditionType gameEventConditionType, object[] gameEventConditionArgs)
        {
            this.GameEventConditionType = gameEventConditionType;
            this.GameEventConditionArgs = gameEventConditionArgs;
        }

        public GameEventConditionType GameEventConditionType;
        public object[] GameEventConditionArgs;

        public bool CalculateResult()
        {
            switch (this.GameEventConditionType)
            {
                case GameEventConditionType.VariableCompareValue:
                    {
                    }
                    return false;

                case GameEventConditionType.VariableCompareVariable:
                    {
                    }
                    return false;
            }
            return false;
        }
    }
}
