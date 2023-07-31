using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class GameGrid
    {
        GameCell[,] cells;
        int rows;
        int cols;

        public GameGrid(String fileName, int rows, int cols)
        {
            //Numbers of rows and cols should load from the text file
            this.rows = rows;
            this.cols = cols;
            cells = new GameCell[rows, cols];
            this.loadGrid(fileName);
        }
        public GameCell getCell(int x, int y)
        {
            return cells[x, y];
        }
        public int Rows { get => rows; set => rows = value; }
        public int Cols { get => cols; set => cols = value; }

        void loadGrid(string fileName)
        {

            StreamReader fp = new StreamReader(fileName);
            string record;
            for (int row = 0; row < this.rows; row++)
            {
                record = fp.ReadLine();
                for (int col = 0; col < this.cols; col++)
                {
                    GameCell cell = new GameCell(row, col, this);
                    char displayCharacter = record[col];
                    GameObjectType type = GameObject.getGameObjectType(displayCharacter);
                    Image displayIamge = Game.getGameObjectImage(displayCharacter);
                    GameObject gameObject = new GameObject(type, displayIamge);
                    cell.setGameObject(gameObject);
                    cells[row, col] = cell;
                }
            }

            fp.Close();
        }

    }
}
