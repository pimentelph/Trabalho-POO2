using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Space_Invaders_Game_WPF_MOO_ICT
{
    /// <summary>
    /// Lógica interna para JanelaInimigos.xaml
    /// </summary>
    public partial class JanelaInimigos : Window
    {
        public JanelaInimigos()
        {
            InitializeComponent();
        }

        // Evento que intercepta a entrada de texto
        private void InputTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Verifica se o texto inserido é um número
            Regex regex = new Regex("[^0-9]+"); // Aceita apenas números de 0 a 9
            e.Handled = regex.IsMatch(e.Text);
        }

        // Evento para tratar o "Ctrl+V" (colagem)
        private void InputTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se o usuário está tentando colar (Ctrl + V)
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                e.Handled = true; // Impede a colagem
            }
        }

        private void IniciarJogo(object sender, RoutedEventArgs e)
        {
            MainWindow telaJogo = new MainWindow();

            // Tenta converter o valor do TextBox para inteiro
            if (int.TryParse(textBoxNumero.Text, out int valor))
            {
            
                telaJogo.AtualizarNumero(valor);

                telaJogo.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, insira um número válido.");
            }


        }

    }
}
