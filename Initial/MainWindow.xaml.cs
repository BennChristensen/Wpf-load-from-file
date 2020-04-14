using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Initial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> usersList = new List<User>();
        private String[] stringList;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void listBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            idTextBox.DataContext = listBox.SelectedItem;
            nameTextBox.DataContext = listBox.SelectedItem;
            ageTextBox.DataContext = listBox.SelectedItem;
            scoreTextBox.DataContext = listBox.SelectedItem;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var currentUsers = new List<User>();

            if (openFileDialog.ShowDialog() == true)
            {
                stringList = File.ReadAllLines(openFileDialog.FileName);
                for (int i = 0; i < stringList.Length; i++)
                {
                    usersList.Add(new User(stringList[i]));
                }
                currentUsers.AddRange(usersList);
                listBox.ItemsSource = currentUsers;
                listCounter.Content = "Users in list: " + currentUsers.Count;
                lastLoadTimer.Content = DateTime.Now;
            }
        }
    }

    public class User : INotifyPropertyChanged
    {
        private int id;
        private String name;
        private int age;
        private int score;

        public User(string data)
        {
            var L = data.Split(';');
            Id = int.Parse(L[0]);
            Name = L[1];
            Age = int.Parse(L[2]);
            Score = int.Parse(L[3]);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id {
            get { return id; }
            set
            {
                if (this.id == value) { return; }
                id = value;
                this.Notify(nameof(id));
            }
        }
        public String Name { get { return name; }
            set 
            {
                if (this.name == value) { return; }
                name = value;
                this.Notify(nameof(name));
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (this.age == value) { return; }
                age = value;
                this.Notify(nameof(age));
            }
        }
        public int Score
        {
            get { return score; }
            set
            {
                if (this.score == value) { return; }
                score = value;
                this.Notify(nameof(score));
            }
        }
        private void Notify(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return String.Format(" Name: {0} \n ID: {1}", Name, Id);
        }
    }
}
