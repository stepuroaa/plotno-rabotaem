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


namespace Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 1, prog;
        OleDbConnection con1, con2;
        OleDbDataReader myReader = null;
        OleDbCommand myCommand;


        public MainWindow()
        {
            InitializeComponent();
            con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Users\\Настя\\Desktop\\вип проект\\memword\\words.accdb'");
            ;
            con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Users\\Настя\\Desktop\\вип проект\\memword\\words.accdb'");
            ;
            GetWord();
        }
        private void GetWord()
        {

            con1.Open();
            myCommand = new OleDbCommand($"select * from Words where IDword = " + i.ToString(), con1);

            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                word_TB.Text = myReader.GetValue(1).ToString();

            }
            con1.Close();
        }

        private void answer_BT_Click(object sender, RoutedEventArgs e)
        {
            con1.Open();
            myCommand = new OleDbCommand($"select * from Words where IDWord = " + i.ToString(), con1);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                word_TB.Text = myReader.GetValue(2).ToString();
            }
            con1.Close();
        }

        private void not_ok_BT_Click(object sender, RoutedEventArgs e)
        {
            i++;
            GetWord();
        }

        private void exit_BT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ok_BT_Click(object sender, RoutedEventArgs e)
        {
            Change_Progress(i);
            i++;
            
            GetWord();
        }

        private void Change_Progress(int i)
        {
            con1.Open();
            myCommand = new OleDbCommand($"select * from Words where IDword = " + i.ToString(), con1);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                prog = Convert.ToInt32(myReader.GetValue(4));
            }
            con1.Close();
            con1.Open();
            myCommand = new OleDbCommand($"update Words set [Progress] = " + (prog+15).ToString() + " where IDWord = " + i.ToString(), con1);
            if (prog + 15 <100) myCommand.ExecuteNonQuery();
            con1.Close();
        }
    }

    
}
