using Complete.Models;
using Complete.Utility;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace Initial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<User> usersList = new ObservableCollection<User>();
        private readonly StatusBar statusBar = new StatusBar();

        public MainWindow()
        {
            InitializeComponent();
            LoadInfo.DataContext = statusBar;
            listBox.ItemsSource = usersList;
        }

        private void listBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UserGrid.DataContext = listBox.SelectedItem;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            UserParser parser = new UserParser();

            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        try
                        {
                            usersList.Add(parser.Parse(reader.ReadLine()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show($"Failed to parse content in file, {openFileDialog.FileName}");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            MessageBox.Show($"Failed to parse content in file, {openFileDialog.FileName}");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show($"Could not open file, {openFileDialog.FileName}");
                        }
                    }
                }
                statusBar.NumberOfElements = usersList.Count;
            }
        }
    }
}
