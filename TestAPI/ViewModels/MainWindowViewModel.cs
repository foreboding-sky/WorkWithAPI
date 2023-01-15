using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestAPI.Models;
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
                      Navigate("TopCoins");
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
                      Navigate("Search");
                  }));
            }
        }

        public void Navigate(string param = "", CoinModel coin = null)
        {
            switch(param)
            {
                case "Details":
                    if(coin != null)
                        CurrentPage = new CoinDetailsView(coin);
                    break;
                case "TopCoins":
                    CurrentPage = new TopCoinsView();
                    break;
                case "Search":
                    CurrentPage = new SearchView();
                    break;
                default:
                    CurrentPage = new TopCoinsView(); 
                    break;
            }
        }
    }
}
