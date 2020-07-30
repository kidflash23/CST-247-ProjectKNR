using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace MVCProject.Models
{
    public class GameBoardModel
    {
        [DefaultValue(10)]
        public int Width { get; set; }
        [DefaultValue(10)]
        public int Length { get; set; }
        [DefaultValue(10)]
        public int Mines { get; set; }
        public bool winCondition { get; set; }

        public GameBoardCellModel[,] board { get; set; }


        //With no argument's the default size will be 10x10
        public GameBoardModel()
        {
            this.Width = 10;
            this.Length = 10;
            this.board = new GameBoardCellModel[this.Width, this.Length];
            this.winCondition = false;
            int numCells = this.Width * this.Length;
            //int for numbering each cell, used for mine generation
            int cellIDNumber = 0;
            //Loop puts a cell object in each spot of the 2d array
            for(int i = 0; i < this.Width; i++)
            {
                for(int j= 0; j < this.Length; j++)
                {
                    cellIDNumber++;
                    this.board[i, j] = new GameBoardCellModel(cellIDNumber);
                }
            }
        }

        //Constructors
        //-------------------------------------------------------------------------------
        //Single Argument Constructor - for square game board
        public GameBoardModel(int sideLength)
        {
            this.Width = sideLength;
            this.Length = sideLength;
            this.board = new GameBoardCellModel[this.Width, this.Length];
            this.winCondition = false;
            int numCells = this.Width * this.Length;
            //int for numbering each cell, used for mine generation
            int cellIDNumber = 0;
            //Loop puts a cell object in each spot of the 2d array
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Length; j++)
                {
                    cellIDNumber++;
                    this.board[i, j] = new GameBoardCellModel(cellIDNumber);
                }
            }
            deployMines();
        }
        //Double Argument Constructor - for a game board with different side length's
        public GameBoardModel(int width, int length)
        {
            this.Width = width;
            this.Length = length;
            this.board = new GameBoardCellModel[this.Width, this.Length];
            this.winCondition = false;
            int numCells = this.Width * this.Length;
            //int for numbering each cell, used for mine generation
            int cellIDNumber = 0;
            //Loop puts a cell object in each spot of the 2d array
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Length; j++)
                {
                    cellIDNumber++;
                    this.board[i, j] = new GameBoardCellModel(cellIDNumber);
                }
            }
            deployMines();
        }
        //-------------------------------------------------------------------------------


        //Board Setup Functions
        //===============================================================================

        //Mine Deployment
        //-------------------------------------------------------------------------------
        //Default difficulty will be 20% mines
        public void deployMines()
        {
            int numberOfTotalCells = this.Width * this.Length;
            decimal difficulty = .2m;
            int numMines = (int)(numberOfTotalCells * difficulty);
            //Determine which cells should be mines and set them to be a mine
            for(int i = 0; i < numMines; i++)
            {
                //Generate a cellID to change to a mine
                Random r = new Random();
                int randomNumber = r.Next(1, numberOfTotalCells);
                //Now that you have the cellID to place a mine in, go do it
                for(int row = 0; row < this.Width; row++)
                {
                    for (int column = 0; column < this.Length; Length++)
                    {
                        //Check if this is the right cell
                        if(board[row,column].cellID == randomNumber)
                        {
                            //Change mine status to true
                            board[row, column].isMine = true;
                        }
                    }
                }
            }

        }
        //If difficulty is specified
        public void deployMines(decimal difficulty)
        {
            int numberOfTotalCells = this.Width * this.Length;
            decimal gameDifficulty = difficulty;
            int numMines = (int)(numberOfTotalCells * difficulty);
            //Determine which cells should be mines and set them to be a mine
            for (int i = 0; i < numMines; i++)
            {
                //Generate a cellID to change to a mine
                Random r = new Random();
                int randomNumber = r.Next(1, numberOfTotalCells);
                //Now that you have the cellID to place a mine in, go do it
                for (int row = 0; row < this.Width; row++)
                {
                    for (int column = 0; column < this.Length; Length++)
                    {
                        //Check if this is the right cell
                        if (board[row, column].cellID == randomNumber)
                        {
                            //Change mine status to true
                            board[row, column].isMine = true;
                        }
                    }
                }
            }

        }
        //-------------------------------------------------------------------------------


        //Count Live Neighbors - around a cell
        public int countLiveNeighbors(int row, int column)
        {
            int liveNeighbors = 0;

            //Check Top Left Cell
            if (row - 1 >= 0 && column - 1 >= 0)
            {
                if(this.board[row - 1, column - 1].isMine)
                {
                    liveNeighbors++;
                }
            }
            //Check Directly Above
            if (row - 1 >= 0)
            {
                if (this.board[row-1, column].isMine)
                {
                    liveNeighbors++;
                }
            }
            //Check Top Right Cell
            if (row + 1 <= this.Width && column - 1 >= 0)
            {
                if (this.board[row + 1, column - 1].isMine)
                {
                    liveNeighbors++;
                }
            }
            //Check Left Cell
            if (column - 1 >= 0)
            {
                if(this.board[row, column - 1].isMine)
                {
                    liveNeighbors++;
                }
            }
            //Check Right Cell
            if (column + 1 <= this.Width)
            {
                if (this.board[row, column + 1].isMine)
                {
                    liveNeighbors++;
                }
            }
            //Check Bottom Left Cell
            if (row - 1 >= 0 && column + 1 <= this.Length)
            {
                if (this.board[row - 1, column + 1].isMine)
                {
                    liveNeighbors++;
                }
            }
            //Check Directly Below
            if (row + 1 <= this.Length)
            {
                if (this.board[row + 1, column].isMine)
                {
                    liveNeighbors++;
                }
            }
            //Check Bottom Right Cell
            if (row + 1 <= this.Width && column + 1 <= this.Length)
            {
                if (this.board[row + 1, column - 1].isMine)
                {
                    liveNeighbors++;
                }
            }
            return liveNeighbors;
        }


        //Flood Fill Functions
        //-------------------------------------------------------------------------------
        public void floodFill(int row, int column)
        {
            //Boundary check
            if (row < 0 || row > this.Width)
            {
                return;
            }
            if (column < 0 || column > this.Length)
            {
                return;
            }
            if (isFillable(row, column))
            {
                this.board[row, column].revealed = true;
                if (this.board[row, column].surroundingMines > 0)
                    return;
                //continue flood to the right
                if (row + 1 < this.Width && this.board[row + 1, column].surroundingMines >= 0)
                {
                    floodFill(row + 1, column);
                }
                //continue flood to the left
                if (row - 1 >= 0 && this.board[row - 1, column].surroundingMines >= 0)
                {
                    floodFill(row - 1, column);
                }
                //continue flood up
                if (column - 1 >= 0 && this.board[row, column - 1].surroundingMines >= 0)
                {
                    floodFill(row, column - 1);
                }
                //continue flood down
                if (column + 1 < this.Length && this.board[row, column + 1].surroundingMines >= 0)
                {
                    floodFill(row , column + 1);
                }
            }
            else
            {
                return;
            }
        }
        public bool isFillable(int x, int y)
        {
            bool isFillable = false;
            //If the cell is not a mine and it hasn't already been revealed, then continue
            if (this.board[x, y].isMine == false && this.board[x, y].revealed == false)
            {
                isFillable = true;
            }
            return isFillable;
        }
        //-------------------------------------------------------------------------------


        //===============================================================================


    }
}