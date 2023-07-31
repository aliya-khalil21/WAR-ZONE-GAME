using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class Game
    {
        public static List<Bullet> bullets = new List<Bullet>();

        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, gamePacOop.Properties.Resources.simplebox);
            return blankGameObject;
        }

        public static GameObject getpalletGameObject()
        {
            GameObject palletGameObject = new GameObject(GameObjectType.REWARD, gamePacOop.Properties.Resources.pallet);
            return palletGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = null;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                img = gamePacOop.Properties.Resources.vertical;
            }

            if (displayCharacter == '#')
            {
                img = gamePacOop.Properties.Resources.horizontal;
            }

            if (displayCharacter == '.')
            {
                img = gamePacOop.Properties.Resources.pallet;
            }
            if (displayCharacter == 'P' || displayCharacter == 'p')
            {
                img = gamePacOop.Properties.Resources.pacman_open;
            }
            if (displayCharacter == 'H' || displayCharacter == 'h')
            {
                img = gamePacOop.Properties.Resources.ghost_blue;
            }
            if (displayCharacter == 'V' || displayCharacter == 'v')
            {
                img = gamePacOop.Properties.Resources.ghost_red;
            }


            if (displayCharacter == 'R' || displayCharacter == 'r')
            {
                img = gamePacOop.Properties.Resources.ghost_orange;
            }

            return img;
        }
    }
}
