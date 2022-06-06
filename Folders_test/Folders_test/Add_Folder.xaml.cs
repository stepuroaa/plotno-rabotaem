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
using System.IO;
using System.Data;

namespace Folders_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
           
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Users\\Настя\\Desktop\\вип проект\\memword\\words.accdb'");
            con1.Open();
            OleDbCommand command = new OleDbCommand($"INSERT INTO Folders (NameFolder) VALUES ('{TB_1.Text}')", con1);
            MessageBox.Show(command.ExecuteNonQuery().ToString());
            con1.Close();
        }
    }
}
