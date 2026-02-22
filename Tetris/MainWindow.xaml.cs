using System.Text;
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
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("TetrisAssets/TileEmpty.png", UriKind.Relative)), //ID 0
            new BitmapImage(new Uri("TetrisAssets/TileCyan.png", UriKind.Relative)), //ID 1
            new BitmapImage(new Uri("TetrisAssets/TileBlue.png", UriKind.Relative)), //ID 2
            new BitmapImage(new Uri("TetrisAssets/TileOrange.png", UriKind.Relative)), //ID 3
            new BitmapImage(new Uri("TetrisAssets/TileYellow.png", UriKind.Relative)), //ID 4
            new BitmapImage(new Uri("TetrisAssets/TilePurple.png", UriKind.Relative)), //ID 5
            new BitmapImage(new Uri("TetrisAssets/TileGreen.png", UriKind.Relative)), //ID 6
            new BitmapImage(new Uri("TetrisAssets/TileRed.png", UriKind.Relative)), //ID 7

        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("TetrisAssets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-Z.png", UriKind.Relative)),
        };

        private readonly Image[,] imageControls; //one image control for every cell in the game grid

        private GameState gameState = new GameState();

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);

        }

        private Image[,] SetupGameCanvas(GameGrid grid) //setting the images in canvas
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Cols];
            int cellSize = 25; //pixels

            for(int r = 0; r < grid.Rows; r++)
            {
                for(int c = 0; c < grid.Cols; c++)
                {
                    Image imageControl = new Image()
                    {
                        Width = cellSize,
                        Height = cellSize,
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize); //-2 is to push the top hidden rows up so that they're not inside canvas
                    Canvas.SetLeft(imageControl, c * cellSize); //distance from the left side of canvas to the left side of image

                    GameCanvas.Children.Add(imageControl); //image the child of canvas  
                    imageControls[r,c] = imageControl; //edit to array
                }
            }

            return imageControls;
        }

        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0;r < grid.Rows; r++)
            {
                for (int c = 0;c < grid.Cols; c++)
                {
                    int id = grid[r,c];
                    imageControls[r,c].Source = tileImages[id]; //set the image based on id
                }
            }
        }

        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePositions())
            {
                imageControls[p.Row, p.Col].Source = tileImages[block.ID];
            }
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawBlock(gameState.CurrentBlock);
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Draw(gameState);
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}