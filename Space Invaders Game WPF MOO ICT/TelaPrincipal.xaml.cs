using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Space_Invaders_Game_WPF_MOO_ICT
{
    /// <summary>
    /// Lógica interna para TelaPrincipal.xaml
    /// </summary>
    public partial class TelaPrincipal : Window
    {

        private MediaPlayer backgroundMusicPlayer = new MediaPlayer();


        public TelaPrincipal()
        {
            InitializeComponent();

            string caminhoArquivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "music", "Odyssey-John-Tasoulas.wav");

            backgroundMusicPlayer.Open(new Uri(caminhoArquivo));
            backgroundMusicPlayer.Volume = 0.5; // Ajusta o volume se necessário
            backgroundMusicPlayer.MediaEnded += (s, e) => backgroundMusicPlayer.Position = TimeSpan.Zero; // Reinicia quando terminar
            backgroundMusicPlayer.Play();
        }


        private void IniciarJogo(object sender, RoutedEventArgs e)
        {
            JanelaInimigos novaTelaInimigos = new JanelaInimigos();

            novaTelaInimigos.Show();

            this.Close();
        }

        private void FecharJogo(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
