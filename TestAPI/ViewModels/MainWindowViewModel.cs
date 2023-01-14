using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestAPI.Services;
using TestAPI.Views;

namespace TestAPI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Page _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public MainWindowViewModel()
        {
            CurrentPage = new TopCoinsView();
        }

        private Command showTopCoins;
        public Command ShowTopCoins
        {
            get
            {
                return showTopCoins ??
                  (showTopCoins = new Command(obj =>
                  {
                      CurrentPage = new TopCoinsView();
                  }));
            }
        }

        private Command showSearch;
        public Command ShowSearch
        {
            get
            {
                return showSearch ??
                  (showSearch = new Command(obj =>
                  {
                      CurrentPage = new SearchView();
                  }));
            }
        }
    }
}
