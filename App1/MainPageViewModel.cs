using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App1
{
    public class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<WordCategory> WordCategories { get; set; } = new ObservableCollection<WordCategory>
        {
            new WordCategory{ Name = "Фрукты" },
            new WordCategory{ Name = "Овощи" },
            new WordCategory{ Name = "Улица" },
            new WordCategory{ Name = "Дом" }
        };

        public ICommand AddLetterCommand { get; }
        public ICommand ShowContentDialogCommand { get; }

        private string myText;
        public string MyText
        {
            get => myText;
            set => SetProperty(ref myText, value);
        }

        public MainPageViewModel()
        {
            AddLetterCommand = new RelayCommand(() => MyText += "s");

            ShowContentDialogCommand = new RelayCommand(async () =>
            {
                var contentDialog = new ContentDialog
                {
                    Title = "Рандомный",
                    Content = "Это рандомный диалог, можешь спокойно пользоваться дальеш приложением",
                    CloseButtonText = "Понял",
                    CloseButtonStyle = (Style)App.Current.Resources["ButtonRevealStyle"]
                };
                await contentDialog.ShowAsync();
            });
        }
    }
}
