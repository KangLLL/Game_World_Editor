using System;
using System.Collections.Generic;
using System.Text;

namespace WorldEditor
{
    public class GameEvent
    {
        public GameEvent(GameEventType gameEventType, object[] gameEventArgs)
        {
            this.GameEventType = gameEventType;
            this.GameEventArgs = gameEventArgs;
            
        }

        public GameEventType GameEventType;
        public object[] GameEventArgs;
        
    }
}
