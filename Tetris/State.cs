using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class State
    {
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        public Grid GameGrid { get;  }
        public Queue GameQueue { get; }
        public bool GameOver { get; private set; }

        public int Score { get; private set; }

        public State()
        {
            GameGrid = new Grid(22, 10);
            GameQueue = new Queue();
            CurrentBlock = GameQueue.GetAndUpdate();
        }

        private bool BlockFits()
        {
            foreach(Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }

            return true;
        }

        public void RotateBlockCW()
        {
            CurrentBlock.Rotate();

            if (!BlockFits())
            {
                CurrentBlock.RotateCounterClockWise();
            }
        }

        public void RotateBlockCounterClockWise()
        {
            CurrentBlock.RotateCounterClockWise();

            if (!BlockFits())
            {
                CurrentBlock.Rotate();
            }
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0,1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0,-1);
            }
        }

        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        /*Sets block into position and checks for gameover states. Since rows will not all be visable to player (IE top two)*/
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            /*Clear any potential full rows then check if the game is over*/
            Score += GameGrid.ClearRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = GameQueue.GetAndUpdate();
            }
            
        }

        public void MoveD()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1,0);
                
                PlaceBlock();
            }
        }

        
    }
}
