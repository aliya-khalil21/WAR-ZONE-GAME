using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    class HorizontalBullet : Bullet
    {
        GameDirection direction;

        public HorizontalBullet(GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.BULLET, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;

        }

        public override GameCell move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            this.CurrentCell = nextCell;
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
            {

                nextCell.setGameObject(new GameObject(GameObjectType.NONE, Properties.Resources.simplebox));
               //GamePacManPlayer.Score++;
                this.CurrentCell = nextCell;

            }


            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            else if (currentCell == nextCell)
            {
                this.CurrentCell.setGameObject(Game.getBlankGameObject());

            }
            return nextCell;
        }
    }
}
