using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    abstract class Bullet : GameObject
    {
        public Bullet(GameObjectType gameObjectType, Image image) : base(GameObjectType.BULLET, image)
        {

        }

        public abstract GameCell move();
    }
}
