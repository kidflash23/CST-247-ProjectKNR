using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class GameBoardCellModel
    {
        public int cellID { get; set; }
        public bool isMine { get; set; }
        public bool revealed { get; set; }
        public bool isFlagged { get; set; }
        public int surroundingMines { get; set; }


        public GameBoardCellModel(int id)
        {
            this.cellID = id;
            this.isMine = false;
            this.isFlagged = false;
            this.revealed = false;
            this.surroundingMines = 0; 
        }

        
    }
}