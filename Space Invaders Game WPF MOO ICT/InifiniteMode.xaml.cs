using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Space_Invaders_Game_WPF_MOO_ICT
{
    /// <summary>
    /// Lógica interna para InifiniteMode.xaml
    /// </summary>
    public partial class InfiniteMode : Window
    {
        bool goLeft, goRight;

        private MediaPlayer backgroundMusicPlayer = new MediaPlayer();

        List<Rectangle> itemsToRemove = new List<Rectangle>();

        int enemyImages = 0;
        int bulletTimer = 0;
        int bulletTimerLimit = 90;
        int totalEnemies = 0;
        int enemySpeed = 6;
        bool gameOver = false;
        int QuantidadeInimigos = 10;
        private int initialEnemyCount = 0;   // Número inicial de inimigos
        private int enemiesKilled = 0;       // Quantidade de inimigos mortos
        private double tenPercentEnemies;    // 10% do número inicial de inimigos

        DispatcherTimer gameTimer = new DispatcherTimer();
        ImageBrush playerSkin = new ImageBrush();

        public InfiniteMode()
        {
            InitializeComponent();

            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();

            playerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/player.png"));
            player.Fill = playerSkin;

            myCanvas2.Focus();

            string caminhoArquivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "music", "AdhesiveWombat-Night-Shade.wav");

            // Configurar e iniciar o MediaPlayer para tocar em loop
            backgroundMusicPlayer.Open(new Uri(caminhoArquivo));
            backgroundMusicPlayer.Volume = 0.7;
            backgroundMusicPlayer.MediaEnded += (s, e) => backgroundMusicPlayer.Position = TimeSpan.Zero; // Reinicia quando terminar
            backgroundMusicPlayer.Play();

            makeEnemies(QuantidadeInimigos);
        }

   
        private void GameLoop(object sender, EventArgs e)
        {
            Rect playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
            enemiesLeft.Content = "Enemies Left: " + totalEnemies;

            if (goLeft == true && Canvas.GetLeft(player) > 0)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - 10);
            }
            if (goRight == true && Canvas.GetLeft(player) + 80 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + 10);
            }

            bulletTimer -= 3;

            if (bulletTimer < 0)
            {
                enemyBulletMaker(Canvas.GetLeft(player) + 20, 10);
                bulletTimer = bulletTimerLimit;
            }

            foreach (var x in myCanvas2.Children.OfType<Rectangle>())
            {
                if (x is Rectangle && (string)x.Tag == "bullet")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);

                    if (Canvas.GetTop(x) < 10)
                    {
                        itemsToRemove.Add(x);
                    }

                    Rect bullet = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    foreach (var y in myCanvas2.Children.OfType<Rectangle>())
                    {
                        if (y is Rectangle && (string)y.Tag == "enemy")
                        {
                            Rect enemyHit = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);

                            if (bullet.IntersectsWith(enemyHit))
                            {
                                itemsToRemove.Add(x);
                                itemsToRemove.Add(y);
                                totalEnemies -= 1;
                                enemiesKilled += 1;

                                
                                if (enemiesKilled >= 20)
                                {
                                    enemySpeed += 1;
                                    enemiesKilled = 0;
                                }
                            }
                        }
                    }
                }

                if (x is Rectangle && (string)x.Tag == "enemy")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) + enemySpeed);

                    if (Canvas.GetLeft(x) > 820)
                    {
                        Canvas.SetLeft(x, -80);
                        Canvas.SetTop(x, Canvas.GetTop(x) + (x.Height + 10));
                    }

                    Rect enemyHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(enemyHitBox))
                    {
                        showGameOver("You were killed by the invaders!!");
                    }
                }

                if (x is Rectangle && (string)x.Tag == "enemyBullet")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + 10);

                    if (Canvas.GetTop(x) > 480)
                    {
                        itemsToRemove.Add(x);
                    }

                    Rect enemyBulletHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(enemyBulletHitBox))
                    {
                        showGameOver("You were killed by the invader bullet!!");
                    }
                }
            }

            foreach (Rectangle i in itemsToRemove)
            {
                myCanvas2.Children.Remove(i);
            }

            if (totalEnemies < 1)
            {
                showGameOver("You Win, you saved the world!");
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = true;
            }
            if (e.Key == Key.Right)
            {
                goRight = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
            }
            if (e.Key == Key.Right)
            {
                goRight = false;
            }

            if (e.Key == Key.Space)
            {
                Rectangle newBullet = new Rectangle
                {
                    Tag = "bullet",
                    Height = 20,
                    Width = 5,
                    Fill = Brushes.White,
                    Stroke = Brushes.Red
                };

                Canvas.SetTop(newBullet, Canvas.GetTop(player) - newBullet.Height);
                Canvas.SetLeft(newBullet, Canvas.GetLeft(player) + player.Width / 2);

                myCanvas2.Children.Add(newBullet);

                string caminhoArquivo2 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "music", "retro-laser-1-236669.wav");

                SoundPlayer playerMusicGun = new SoundPlayer(caminhoArquivo2);
                playerMusicGun.Load();
                playerMusicGun.Play();

                QuantidadeInimigos++;

                makeEnemies(QuantidadeInimigos);
            }

            if (e.Key == Key.Enter && gameOver == true)
            {
                backgroundMusicPlayer.Stop();

                TelaPrincipal telaPrincipal = new TelaPrincipal();
                telaPrincipal.Show();

                this.Close();
            }
        }

        private void enemyBulletMaker(double x, double y)
        {
            Rectangle enemyBullet = new Rectangle
            {
                Tag = "enemyBullet",
                Height = 40,
                Width = 15,
                Fill = Brushes.Yellow,
                Stroke = Brushes.Black,
                StrokeThickness = 5
            };

            Canvas.SetTop(enemyBullet, y);
            Canvas.SetLeft(enemyBullet, x);

            myCanvas2.Children.Add(enemyBullet);
        }

        private void makeEnemies(int limit)
        {
            int left = 0;
            totalEnemies = limit;

            // Inicialize a contagem de inimigos
            initialEnemyCount = totalEnemies;
            tenPercentEnemies = initialEnemyCount * 0.1;

            for (int i = 0; i < limit; i++)
            {
                ImageBrush enemySkin = new ImageBrush();
                Rectangle newEnemy = new Rectangle
                {
                    Tag = "enemy",
                    Height = 45,
                    Width = 45,
                    Fill = enemySkin
                };

                Canvas.SetTop(newEnemy, 30);
                Canvas.SetLeft(newEnemy, left);
                myCanvas2.Children.Add(newEnemy);
                left -= 60;

                enemyImages++;

                if (enemyImages > 8)
                {
                    enemyImages = 1;
                }

                switch (enemyImages)
                {
                    case 1:
                        enemySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/invader1.gif"));
                        break;
                    case 2:
                        enemySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/invader2.gif"));
                        break;
                    case 3:
                        enemySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/invader3.gif"));
                        break;
                    case 4:
                        enemySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/invader4.gif"));
                        break;
                    case 5:
                        enemySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/invader5.gif"));
                        break;
                    case 6:
                        enemySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/invader6.gif"));
                        break;
                    case 7:
                        enemySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/invader7.gif"));
                        break;
                    case 8:
                        enemySkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/invader8.gif"));
                        break;
                }
            }
        }

        private void showGameOver(string message)
        {
            gameOver = true;
            gameTimer.Stop();
            enemiesLeft.Content = message;
        }
    }
}
