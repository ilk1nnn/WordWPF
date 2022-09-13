using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace WordWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string filename { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SaveBtnFunct(string data)
        {
            var save = new SaveFileDialog();
            save.Filter = "Txt Files (*.txt)| *.txt";

            if (save.ShowDialog() == true)
            {
            FileInfo file = new FileInfo(filename);
            filename = GetFilePath(file.FullName);
            File.WriteAllText(file.FullName, data);
            }
        }

        private string GetFilePath(string filePath)
        {

            return filePath.EndsWith(".txt") ? filePath : filePath;

        }

        public void AutoSaveBtnFunct(string data)
        {
            if (String.IsNullOrWhiteSpace(filename))
            {
                return;
            }
            File.WriteAllText(filename, data);

        }

        public string OpenBtnFunct()
        {
            var open = new OpenFileDialog();
            open.Filter = "Txt Files (*.txt)| *.txt";
            if (open.ShowDialog() != true) 
            {
                return String.Empty;
            }
            filename = open.FileName;
            return File.ReadAllText(filename);
        }

        private void cutbtn_Click(object sender, RoutedEventArgs e)
        {
            txtbox.Cut();
        }

        private void copybtn_Click(object sender, RoutedEventArgs e)
        {
            txtbox.Copy();
        }
        private void pastebtn_Click(object sender, RoutedEventArgs e)
        {
            txtbox.Paste();
        }
        private void selectallbtn_Click(object sender, RoutedEventArgs e)
        {
            txtbox.SelectAll();
        }


        private void openbtn_Click(object sender, RoutedEventArgs e)
        {
            txtbox.Text = OpenBtnFunct();
            filepath.Text = filename;
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            SaveBtnFunct(txtbox.Text);
        }

        private void AutoSave_Checked(object sender, RoutedEventArgs e)
        {
            AutoSaveBtnFunct(txtbox.Text);
        }

    }
}
