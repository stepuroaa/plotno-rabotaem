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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GetWord()
        {
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Users\\Настя\\Desktop\\вип проект\\memword\\words.accdb'");
            
            con1.Open();
            OleDbDataReader myReader = null;
            OleDbCommand myCommand = new OleDbCommand($"select * from Words where IDword = " + i.ToString(), con1);

            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                Text1.Text = myReader.GetValue(1).ToString();
                Text2.Text = myReader.GetValue(2).ToString();
                //Console.WriteLine("yep");
            }
            
            
            con1.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (i == 1) i = 5;
            i -= 1;
            GetWord();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (i == 4) i = 0;
            i += 1;
            GetWord();
        }

       
    }
}
