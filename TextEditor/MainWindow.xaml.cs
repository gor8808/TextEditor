using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows;
namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string CurrrentFilePath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        { 
            Editor.Text = string.Empty;
            CurrrentFilePath = string.Empty;
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            if (SaveFileDialog.ShowDialog() == true)
            {
                WriteToFile(SaveFileDialog.FileName, string.Empty);
            }
            CurrrentFilePath = SaveFileDialog.FileName;
            string ResultFromTxtFileReading = string.Empty;
            this.Title = SaveFileDialog.FileName;

        }



        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialogOpenFile = new CommonOpenFileDialog();
            dialogOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dialogOpenFile.ShowDialog() == CommonFileDialogResult.Ok)
            {
                CurrrentFilePath = dialogOpenFile.FileName;
                string ResultFromTxtFileReading = GetDataFromFile(dialogOpenFile.FileName); ;
                Editor.Text = ResultFromTxtFileReading;
                this.Title = dialogOpenFile.FileName;

            }
        }

        private string GetDataFromFile(string fileName)
        {
            using (StreamReader streamOpennedFile = File.OpenText(fileName))
            {
                return streamOpennedFile.ReadToEnd();
            }
        }
        private void WriteToFile(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrrentFilePath != string.Empty)
            {
                WriteToFile(CurrrentFilePath, Editor.Text);
                MessageBox.Show("Successfully saved in: " + CurrrentFilePath);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                    WriteToFile(saveFileDialog.FileName, Editor.Text);
                CurrrentFilePath = saveFileDialog.FileName;
                this.Title = saveFileDialog.FileName;
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
