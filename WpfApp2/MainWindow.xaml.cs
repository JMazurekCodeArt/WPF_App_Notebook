using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace TextEditor
{
    public partial class MainWindow : Window
    {
        private string _currentFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    _currentFilePath = openFileDialog.FileName;
                    txtEditor.Text = File.ReadAllText(_currentFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy otwieraniu pliku\n" + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                SaveFileAs_Click(sender, e);
                return;
            }

            try
            {
                File.WriteAllText(_currentFilePath, txtEditor.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przy zapisie pliku.\n" + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveFileAs_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    _currentFilePath = saveFileDialog.FileName;
                    File.WriteAllText(_currentFilePath, txtEditor.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy zapisie pliku.\n" + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            _currentFilePath = null;
            txtEditor.Clear();
        }
    }
}
