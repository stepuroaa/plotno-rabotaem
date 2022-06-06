using System;
using System.Collections.Generic;
using System.Data.OleDb;
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


namespace memword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Memword_maket : Window
    {
        int click = 0;
        int m_top = -150;
        int s = 0;
        //OleDbConnection con1 = ;
        //OleDbCommand myCommand;
        //OleDbDataReader myReader = null;
        public Memword_maket()
        {
            InitializeComponent();
            settings_SP.Visibility = Visibility.Hidden;
            this.WindowState = WindowState.Maximized;
            
        }

        private void plus_BT_Click(object sender, RoutedEventArgs e)
        {
            if (click == 11 && s == 4) MessageBox.Show("Вы достигли лимита папок.");
            else
            {
                Button button = new Button();
                StackPanel stackPanel = new StackPanel();
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Subject";
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                button.Height = 150;
                button.Width = 100;
                button.HorizontalAlignment = HorizontalAlignment.Left;
                folder_SP.Children.Add(button);
                if (click < 2 && s == 0) button.Margin = new Thickness(120 * click, m_top * (click), 0, 0);
                else if (click == 1) button.Margin = new Thickness(120 * click, -150, 0, 0);
                else if (click >= 2 && click <= 10) button.Margin = new Thickness(120 * click, -150, 0, 0);
                else
                {
                    s++;
                    click = 0;
                    m_top *= 2;
                    button.Margin = new Thickness(120 * click, 0, 0, 0);
                }
                button.Content = stackPanel;
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("C:\\Users\\Настя\\Desktop\\вип проект\\memword\\pics\\folder.png"));
                stackPanel.Children.Add(image);
                stackPanel.Children.Add(textBlock);
                click++;
                Console.WriteLine(click);
            }

            
        }

        private void B_Settings_Click(object sender, RoutedEventArgs e)
        {
            settings_SP.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            settings_SP.Visibility = Visibility.Hidden;
        }
    }
}
