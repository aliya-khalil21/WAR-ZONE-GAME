using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class HGhost : Ghost
    {
        
        //  GameDirection direction;
        /* public HGhost(GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
         {
             this.direction = direction;
             this.CurrentCell = startCell;
         }*/
        GameDirection direction;
        private int enemylives;
        public HGhost(GameDirection direction, Image image, GameCell startCell, int lives) : base(GameObjectType.ENEMY, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
        }
            public int EnemyLives { get => enemylives; set => enemylives = value; }
        public override GameCell move()
        {
           
            GameCell CurrentCell = this.CurrentCell;
            GameCell nextCell = CurrentCell.nextCell(direction);
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                GamePacManPlayer player = (GamePacManPlayer)nextCell.CurrentGameObject;
                if (player.Score < 10)
                {
                    player.Lives--;
                }
                if (player.Score > 10)
                {
                    CurrentCell.setGameObject(Game.getBlankGameObject());
                    player.Score -= 10;
                    this.EnemyLives--;
                }
            }
            this.CurrentCell = nextCell;
            if (CurrentCell == nextCell)
            {
                manageDirections();
            }
            if (CurrentCell != nextCell && (nextCell.CurrentGameObject?.GameObjectType != GameObjectType.WALL))
            {
                CurrentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;
        }

        public void manageDirections()
        {
            if (direction == GameDirection.Left)
            {
                direction = GameDirection.Right;
            }
            else if (direction == GameDirection.Right)
            {
                direction = GameDirection.Left;
            }
        }

    }
}
