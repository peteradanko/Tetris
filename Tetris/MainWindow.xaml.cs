using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*Order of declaration is set to match id of blocks*/
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Images/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/TileRed.png", UriKind.Relative))
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Images/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Images/Block-Z.png", UriKind.Relative))
        };

        private readonly Image[,] imageControls;

        private State gameState = new State();

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);
        }
        /*Two dimensional array with one image per cell*/
        private Image[,] SetupGameCanvas(Grid gameGrid)
        {
            Image[,] imageControls = new Image[gameGrid.row, gameGrid.column];
            int cellSize = 25;

            for(int i = 0; i < gameGrid.row; i++)
            {
                for (int y = 0; y < gameGrid.column; y++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };
                    /*Reading from the top of the canvis down*/
                    Canvas.SetTop(imageControl, (i - 2) * cellSize);
                    Canvas.SetLeft(imageControl, (y * cellSize));
                    /*Set the canvis to the child of the array*/
                    GameCanvas.Children.Add(imageControl);
                    imageControls[i, y] = imageControl;
                } 
            }
            return imageControls;
        }

        private void DrawGrid(Grid gameGrid)
        {
            for(int r = 0; r < gameGrid.row; r++)
            {
                for (int c = 0; c < gameGrid.column; c++)
                {
                    int id = gameGrid[r, c];
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }

        private void DrawBlock(Block gameBlock)
        {
            foreach (Position p in gameBlock.TilePositions())
            {
                imageControls[p.Row, p.Column].Source = tileImages[gameBlock.Id];

            }
        }

        private void DrawNextBlock(Queue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
            
        }

        private void Draw(State gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.GameQueue);
            ScoreText.Text = $"Score: {gameState.Score}";
        }

        /*Wait 500ms then redraw bock one square down*/
        private async Task GameLoop()
        {
            Draw(gameState);

            while (!gameState.GameOver)
            {
                /*The await operator suspends evaluation of the enclosing async method until the asynchronous operation represented by its operand completes.*/
                await Task.Delay(500);
                gameState.MoveD();
                Draw(gameState);
            }

            GameOverMenu.Visibility = Visibility.Visible;
            FinalScore.Text = $"Score: {gameState.Score}";
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    gameState.MoveD();
                    break;
                case Key.Up:
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    gameState.RotateBlockCounterClockWise();
                    break;
                default:
                    return;

            }

            Draw(gameState);
        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }

        private async void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            gameState = new State();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }
    }
}
