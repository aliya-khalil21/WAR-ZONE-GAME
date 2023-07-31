using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    class VGhost : Ghost
    {
        GameDirection direction;
        public VGhost(GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
        }

        public override GameCell move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            GameObject previousObject = nextCell.CurrentGameObject;
            this.CurrentCell = nextCell;
              if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
            {
                this.CurrentCell = nextCell; 
                nextCell.setGameObject(new GameObject(GameObjectType.NONE, Properties.Resources.simplebox)); // Set the next cell to empty (nullify the enemy object)
                return nextCell;
            }
            if (currentCell == nextCell)
            {
                manageDirections();
            }

            if (currentCell != nextCell)
            {
                currentCell.setGameObject(previousObject);

            }
            return nextCell;
        }

        public void manageDirections()
        {
            if (direction == GameDirection.Up)
            {
                direction = GameDirection.Down;
            }
            else if (direction == GameDirection.Down)
            {
                direction = GameDirection.Up;
            }
        }
    }
}
