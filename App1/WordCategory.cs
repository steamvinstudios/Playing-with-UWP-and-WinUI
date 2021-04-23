using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1
{
    public class WordCategory : ObservableObject
    {
        public ICommand UpProgressCommand { get; }
        public ICommand DownProgressCommand { get; }
        public string ImageURL { get; } = $"https://picsum.photos/{new Random().Next(200, 400)}";
        public static int id = 0;
        public string Id { get; }
        public string Name { get; set; }
        private int progress;

        public int Progress
        {
            get => progress;
            set => SetProperty(ref progress, value);
        }

        public WordCategory()
        {
            Id = id.ToString();
            id++;
            UpProgressCommand = new RelayCommand(() => Progress += 10);
            DownProgressCommand = new RelayCommand(() => Progress -= 10);
        }
    }
}
