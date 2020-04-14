using System;
using System.ComponentModel;

namespace Complete.Models
{
    class StatusBar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int numberOfElements;
        public DateTime LastModified { get; set; }
        public String StatusBarContent
        {
            get
            {
                return $"Amount of users in list: {NumberOfElements}";
            }
        }

        public String StatusBarLastLoaded
        {
            get
            {
                if (NumberOfElements == 0)
                {
                    return "No users loaded yet";
                }
                return LastModified.ToString();
            }
        }
        public int NumberOfElements
        {
            get
            {
                return numberOfElements;
            }
            set
            {
                numberOfElements = value;
                LastModified = DateTime.Now;
                Notify(nameof(StatusBarContent));
                Notify(nameof(StatusBarLastLoaded));
            }
        }

        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

