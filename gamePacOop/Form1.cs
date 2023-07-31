using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using gamePacOop.GameGL;

namespace gamePacOop
{
    public partial class Form1 : Form
    {
        GamePacManPlayer pacman;
        HGhost ghostH1;
        VGhost ghostV1;
        RGhost ghostR1;
      

        List<Ghost> ghosts = new List<Ghost>();
        List<Bullet> bullets = new List<Bullet>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameGrid grid = new GameGrid("maze.txt", 13, 23);
            Image pacManImage = GameGL.Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(8, 10);
            pacman = new GamePacManPlayer(pacManImage, startCell,10,0);

            Image ghostH1Img = GameGL.Game.getGameObjectImage('H');
            GameCell startH1 = grid.getCell(7, 13);
            ghostH1 = new HGhost(GameDirection.Left, ghostH1Img, startH1, 3);

            Image ghostV1Img = GameGL.Game.getGameObjectImage('V');
            GameCell startV1 = grid.getCell(6, 8);
            ghostV1 = new VGhost(GameDirection.Up, ghostV1Img, startV1);

            Image ghostR1Img = GameGL.Game.getGameObjectImage('R');
            GameCell startR1 = grid.getCell(4, 9);
            ghostR1 = new RGhost( ghostR1Img, startR1);


            ghosts.Add(ghostH1);
            ghosts.Add(ghostV1);
            ghosts.Add(ghostR1);
          

            printMaze(grid);
        }

        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {

                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                    //        printCell(cell);
                }

            }
        }
        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pacman.move(GameDirection.Left);
            }
            else if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                pacman.move(GameDirection.Right);
            }
            else if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                pacman.move(GameDirection.Up);
            }
            else if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                pacman.move(GameDirection.Down);
            }
            else if (Keyboard.IsKeyPressed(Key.Space))
            {
                generateBullet();
            }

            //ghost movement
            foreach (Ghost g in ghosts)
            {

                g.move();
            }

           foreach (Bullet b in Game.bullets)
            {
                b.move();
            }
            /*//live , scores view
            liveLbl.Text = "Lives: " + pacman.getLives();
            scoreLbl.Text = "Scores: " + pacman.getScores();*/


        }
        void generateBullet()
        {
            Bullet b;
            Image bullet = GameGL.Game.getGameObjectImage('.');
            GameCell startBullet = pacman.CurrentCell.nextCell(GameDirection.Right);
            b = new HorizontalBullet(GameDirection.Right, bullet, startBullet);

            Game.bullets.Add(b);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
