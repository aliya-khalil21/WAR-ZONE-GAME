using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    class Ghost : GameObject
    {
        public Ghost(GameObjectType gameObjectType, Image image) : base(GameObjectType.ENEMY, image)
        {

        }

        public virtual GameCell move()
        {
            GameCell a = new GameCell();
            return a;

        }


    }
}
