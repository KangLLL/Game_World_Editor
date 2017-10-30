using System;
using System.Drawing;
using System.Collections.Generic;

namespace WorldEditor
{
    class MapData
    {
        public MapData(string name,int logicWidth,int logicHeight)
        {
            this.name = name;
            //this.bgmID = bgmID;
            this.visualLayerDataList = new List<VisualLayerData>();
            this.triggerList = new List<Trigger>();
            this.logicLayer = new LogicLayerData(logicWidth, logicHeight);

            this.GameUnitList = new List<GameUnit>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private LogicLayerData logicLayer;
        public LogicLayerData LogicLayer
        {
            get
            {
                return this.logicLayer;
            }
        }

        private List<VisualLayerData> visualLayerDataList;
        public List<VisualLayerData> VisualLayerDataList
        {
            get
            {
                return this.visualLayerDataList;
            }
        }

        private List<Trigger> triggerList;
        public List<Trigger> TriggerList
        {
            get
            {
                return this.triggerList;
            }
        }

        private List<GameUnit> gameUnitList;

        public List<GameUnit> GameUnitList
        {
            get { return gameUnitList; }
            set { gameUnitList = value; }
        }


        //private List<string> playerList;
        //public List<string> PlayerList
        //{
        //    get
        //    {
        //        return this.playerList;
        //    }
        //}

        //private List<string> bossList;
        //public List<string> BossList
        //{
        //    get
        //    {
        //        return this.bossList;
        //    }
        //}

        //private List<string> mummyList;
        //public List<string> MummyList
        //{
        //    get
        //    {
        //        return this.mummyList;
        //    }
        //}

        //private List<string> batList;
        //public List<string> BatList
        //{
        //    get
        //    {
        //        return this.batList;
        //    }
        //}

        //private List<string> ravenList;
        //public List<string> RavenList
        //{
        //    get
        //    {
        //        return this.ravenList;
        //    }
        //}

        //private List<string> monkeyList;
        //public List<string> MonkeyList
        //{
        //    get
        //    {
        //        return this.monkeyList;
        //    }
        //}

        //private List<string> mushroomList;
        //public List<string> MushroomList
        //{
        //    get
        //    {
        //        return this.mushroomList;
        //    }
        //}

        //private List<string> ufoList;
        //public List<string> UFOList
        //{
        //    get
        //    {
        //        return this.ufoList;
        //    }
        //}

        //private List<string> laserRobotList;
        //public List<string> LaserRobotList
        //{
        //    get
        //    {
        //        return this.laserRobotList;
        //    }
        //}

        //private List<string> bitRobotList;
        //public List<string> BitRobotList
        //{
        //    get
        //    {
        //        return this.bitRobotList;
        //    }
        //}

        //private List<string> corpseList;
        //public List<string> CorpseList
        //{
        //    get
        //    {
        //        return this.corpseList;
        //    }
        //}

        //private List<string> kingKongList;
        //public List<string> KingKongList
        //{
        //    get
        //    {
        //        return this.kingKongList;
        //    }
        //}

        //private List<string> crystalList;
        //public List<string> CrystalList
        //{
        //    get
        //    {
        //        return this.crystalList;
        //    }
        //}

        //private List<string> flightVehicleList;
        //public List<string> FlightVehicleList
        //{
        //    get
        //    {
        //        return this.flightVehicleList;
        //    }
        //}

        private Color backColor;

        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        private bool isFillBackColor;

        public bool IsFillBackColor
        {
            get { return isFillBackColor; }
            set { isFillBackColor = value; }
        }


        //private int bgmID;
        //public int BgmID
        //{
        //    get
        //    {
        //        return this.bgmID;
        //    }
        //    set
        //    {
        //        this.bgmID = value;
        //    }
        //}


        public override string ToString()
        {
            return this.name;
        }

        public void ClipVisualLayer(int clipMode, int newWidth, int newHeight, int layerID)
        {
            VisualLayerData operationLayer = this.visualLayerDataList[layerID];

            if (operationLayer.HorizontalTileCount == newWidth && operationLayer.VerticalTileCount == newHeight)
            {
                return;
            }

            switch (clipMode)
            {
                case 0:
                    {
                        operationLayer.ResizeLayerTable(0, 0, 0, 0, newWidth, newHeight);
                    }
                    break;
                case 1:
                    {
                        if (operationLayer.HorizontalTileCount > newWidth)
                        {
                            operationLayer.ResizeLayerTable(operationLayer.HorizontalTileCount - newWidth, 0, 0, 0, newWidth, newHeight);
                        }
                        else
                        {
                            operationLayer.ResizeLayerTable(0, 0, newWidth - operationLayer.HorizontalTileCount, 0, newWidth, newHeight);
                        }
                    }
                    break;
                case 2:
                    {
                        if (operationLayer.VerticalTileCount > newHeight)
                        {
                            operationLayer.ResizeLayerTable(0, operationLayer.VerticalTileCount - newHeight, 0, 0, newWidth, newHeight);
                        }
                        else
                        {
                            operationLayer.ResizeLayerTable(0, 0, 0, newHeight - operationLayer.VerticalTileCount, newWidth, newHeight);
                        }
                    }
                    break;
                case 3:
                    {
                        int x1, x2, y1, y2;
                        if (operationLayer.HorizontalTileCount > newWidth)
                        {
                            x1 = operationLayer.HorizontalTileCount - newWidth;
                            x2 = 0;
                        }
                        else
                        {
                            x1 = 0;
                            x2 = newWidth - operationLayer.HorizontalTileCount;
                        }
                        if (operationLayer.VerticalTileCount > newHeight)
                        {
                            y1 = operationLayer.VerticalTileCount - newHeight;
                            y2 = 0;
                        }
                        else
                        {
                            y1 = 0;
                            y2 = newHeight - operationLayer.VerticalTileCount;
                        }
                        operationLayer.ResizeLayerTable(x1, y1, x2, y2, newWidth, newHeight);
                    }
                    break;
                default:
                    break;
            }
        }

        public void ClipLogicLayer(int clipMode, int newWidth, int newHeight)
        {
            if (this.logicLayer.HorizontalTileCount == newWidth && this.logicLayer.VerticalTileCount == newHeight)
            {
                return;
            }

            switch (clipMode)
            {
                case 0:
                    {
                        this.logicLayer.ResizeLayerTable(0, 0, 0, 0, newWidth, newHeight);
                    }
                    break;
                case 1:
                    {
                        if (this.logicLayer.HorizontalTileCount > newWidth)
                        {
                            this.logicLayer.ResizeLayerTable(this.logicLayer.HorizontalTileCount - newWidth, 0, 0, 0, newWidth, newHeight);
                        }
                        else
                        {
                            this.logicLayer.ResizeLayerTable(0, 0, newWidth - this.logicLayer.HorizontalTileCount, 0, newWidth, newHeight);
                        }
                    }
                    break;
                case 2:
                    {
                        if (this.logicLayer.VerticalTileCount > newHeight)
                        {
                            this.logicLayer.ResizeLayerTable(0, this.logicLayer.VerticalTileCount - newHeight, 0, 0, newWidth, newHeight);
                        }
                        else
                        {
                            this.logicLayer.ResizeLayerTable(0, 0, 0, newHeight - this.logicLayer.VerticalTileCount, newWidth, newHeight);
                        }
                    }
                    break;
                case 3:
                    {
                        int x1, x2, y1, y2;
                        if (this.logicLayer.HorizontalTileCount > newWidth)
                        {
                            x1 = this.logicLayer.HorizontalTileCount - newWidth;
                            x2 = 0;
                        }
                        else
                        {
                            x1 = 0;
                            x2 = newWidth - this.logicLayer.HorizontalTileCount;
                        }
                        if (this.logicLayer.VerticalTileCount > newHeight)
                        {
                            y1 = this.logicLayer.VerticalTileCount - newHeight;
                            y2 = 0;
                        }
                        else
                        {
                            y1 = 0;
                            y2 = newHeight - this.logicLayer.VerticalTileCount;
                        }
                        this.LogicLayer.ResizeLayerTable(x1, y1, x2, y2, newWidth, newHeight);
                    }
                    break;
                default:
                    break;
            }
        }

        public bool CheckNameValid(GameUnitType type, string name)
        {
            foreach (GameUnit gameUnit in this.gameUnitList)
            {
                if (gameUnit.GameUnitType == type && gameUnit.GameUnitName == name)
                {
                    return false;
                }
            }
            return true;
        }

        public void DelCreatedGameUnit(GameUnitType type, string name)
        {
            for (int i = this.gameUnitList.Count - 1; i >= 0; i--)
            {
                GameUnit gameUnit = this.gameUnitList[i];
                if (gameUnit.GameUnitType == type && gameUnit.GameUnitName == name)
                {
                    this.gameUnitList.Remove(gameUnit);
                }
            }
        }

        public VisualLayerData SearchVisualLayerData(string name)
        {
            for (int i = 0; i < this.visualLayerDataList.Count; i++)
            {
                if (this.visualLayerDataList[i].Name == name)
                {
                    return this.visualLayerDataList[i];
                }
            }
            return null;
        }

        public void FixVisualLayerData(int oldID, int newID)
        {
            foreach (Trigger trigger in this.triggerList)
            {
                foreach (Command command in trigger.GameEventAction.CommandList)
                {
                    if (command.TypeID == CommandType.ShowVisualLayer || command.TypeID == CommandType.HideVisualLayer)
                    {
                        if ((int)(command.CommandArgs[0]) == oldID)
                        {
                            command.CommandArgs[0] = newID;
                        }
                        else if ((int)(command.CommandArgs[0]) == newID)
                        {
                            command.CommandArgs[0] = oldID;
                        }
                    }
                }
            }
        }

        //public VisualLayerData ChangeToNextLayer(int i)
        //{
            
        //    return this.visualLayerDataList[i + 1];
        //}
    }
}
