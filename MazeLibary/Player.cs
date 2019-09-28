using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Cells;

namespace MazeLibrary
{
    public class Player : BaseCell
    {
        #region Singleton
        private static Player _player;
        public static Player GetPlayer
        {
            get
            {
                return _player ?? (_player = new Player());
            }
        }

        private Player() : base(0,0, '@') { }

        #endregion


        public override bool TryToStep()
        {
            throw new Exception("Its not allowed");
        }
    }
}
