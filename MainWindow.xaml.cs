using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace molodykh_notepad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string file_path = openFileDialog.FileName;

            RichTextBox richTextBox = new RichTextBox();

            var massive_file_path = file_path.Split('\\');

            mainTabControl.Items.Add(new TabItem
            {
                Header = massive_file_path[massive_file_path.Length - 1],
                Content = richTextBox
            });

            using (var sr = new StreamReader(file_path, Encoding.Default))
            {
                richTextBox.Document.Blocks.Clear();
                richTextBox.Document.Blocks.Add(new Paragraph(new Run(sr.ReadLine())));
                dataText.Text = $"Кодировка: {sr.CurrentEncoding.EncodingName}";
            }
        }

        private void createFileButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
