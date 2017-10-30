using System;
using System.Collections.Generic;
using System.Text;

namespace WorldEditor
{
    public class GameUnit
    {
        public GameUnit(GameUnitType gameUnitType, string gameUnitName)
        {
            this.gameUnitType = gameUnitType;
            this.gameUnitName = gameUnitName;
        }

        private GameUnitType gameUnitType;

        public GameUnitType GameUnitType
        {
            get { return gameUnitType; }
            set { gameUnitType = value; }
        }

        private string gameUnitName;

        public string GameUnitName
        {
            get { return gameUnitName; }
            set { gameUnitName = value; }
        }

    }
}
