using System;
using System.Collections.Generic;
using System.Text;

namespace WorldEditor
{
    public class Trigger
    {
        public Trigger(string name)
        {
            this.Name = name;
            this.gameEventConditionList = new List<GameEventCondition>();
            this.GameEventAction = new GameEventAction();
        }

        public Trigger(GameEventType gameEventType, GameEventCondition[] gameEventConditionArray, GameEventAction gameEventAction)
        {
            this.GameEventType = gameEventType;
            this.GameEventAction = gameEventAction;
            this.GameEventConditionArray = gameEventConditionArray;
        }

        public GameEventType GameEventType;
        public GameEventCondition[] GameEventConditionArray;
        public GameEventAction GameEventAction;
        public bool On = true;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private List<GameEventCondition> gameEventConditionList;

        public List<GameEventCondition> GameEventConditionList
        {
            get { return gameEventConditionList; }
            set { gameEventConditionList = value; }
        }


        public GameEventAction CreateGameEventAction()
        {
            return GameEventAction.Clone();
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
