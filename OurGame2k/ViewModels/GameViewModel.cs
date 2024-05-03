using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using OurGame2k.Blocks;
using OurGame2k.Commands;
using OurGame2k.GameUtils;
using OurGame2k.Models;

namespace OurGame2k.ViewModels
{
    public class GameViewModel
    {
        public ICommand LoadCanvasCommand { get; set; }

        public GameViewModel() 
        {
            LoadCanvasCommand = new RelayCommand(LoadCanvas, CanLoadCanvas);
        }

        private bool CanLoadCanvas(object obj)
        {
            return true;
        }
        private Image[,] imageCtrls;
        private TetrisBlock[,] tetrisBlocks;
        private void LoadCanvas(object obj)
        {
            imageCtrls = SetupGameCanvas(gameState.GameGrid, (Canvas)obj);
            Draw(gameState);
        }
        private readonly TetrisBlock[] tetrisBlocks =
        {
            new TetrisBlock(30, Brushes.Orange),
            new TetrisBlock(30, Brushes.Cyan),
            new TetrisBlock(30, Brushes.Green),
            new TetrisBlock(30, Brushes.Yellow),
            new TetrisBlock(30, Brushes.Red),
            new TetrisBlock(30, Brushes.Blue),
            new TetrisBlock(30, Brushes.Purple)
        };

        private readonly ImageSource[] _tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative)),
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative)),
        };

        private GameState gameState = new GameState();
        
        private Image[,] SetupGameCanvas(Game grid, Canvas gameCanvas)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;
            for (int r = 0; r < grid.Rows; r++) 
            { 
                for (int c = 0; c < grid.Columns; c++)
                {
                    //Image imageControl = new Image
                    //{
                    //    Width = cellSize,
                    //    Height = cellSize,
                    //};
                    //Rectangle rec = new Rectangle()
                    //{
                    //   Width = cellSize,
                    //    Height = cellSize,
                    //    Fill = Brushes.Green,
                    //    Stroke = Brushes.Red,
                    //    StrokeThickness = 2,
                    //};
                    TetrisBlock tetrisBlock = new TetrisBlock(30, Brushes.Black);
                    Canvas.SetTop(tetrisBlock, (r - 2) * cellSize);
                    Canvas.SetLeft(tetrisBlock, c * cellSize);
                    gameCanvas.Children.Add(tetrisBlock);
                    tetrisBlocks[r, c] = imageControl; 
                }
            }

            return tetrisBlocks;
        }

        private void DrawGrid(Game grid)
        {
            for (int r = 0; r < grid.Rows; r++) 
            { 
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    
                    //imageCtrls[r, c].Source = _tileImages[id];
                }
            }
        }

        private void DrawBlock(Block block) 
        {
            foreach (Position p in block.TilePositions())
            {
                //imageCtrls[p.Row, p.Column].Source = _tileImages[block.Id];
            }
        }



        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawBlock(gameState.CurrentBlock);
        }

        // private async Task GameLoop(object obj)
        // {
        //     // imageCtrls = SetupGameCanvas(gameState.GameGrid, (Canvas)obj);
        //     // await Task.Delay(10000);
        //     // Draw(gameState);

        //     while (!gameState.GameOver)
        //     {
        //         await Task.Delay(500);
        //         gameState.MoveBlockDown();
        //         Draw(gameState);
        //     }
        // }
    }
}
