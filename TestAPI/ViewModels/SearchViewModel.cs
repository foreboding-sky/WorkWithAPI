using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestAPI.Models;
using TestAPI.Services;

namespace TestAPI.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private MarketApiHandler handler;
        private string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                if (searchText == value)
                    return;

                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        private DataModel coinsData;
        public DataModel CoinsData
        {
            get
            {
                return coinsData;
            }
            set
            {
                if (coinsData == value)
                    return;

                coinsData = value;
                OnPropertyChanged("CoinsData");
            }
        }

        public SearchViewModel()
        {
            handler = new MarketApiHandler();
        }

        private Command showDetails;
        public Command ShowDetails
        {
            get
            {
                return showDetails ??
                  (showDetails = new Command(obj =>
                  {
                      CoinModel coin = obj as CoinModel;
                      if (coin != null)
                      {
                          var window = Window.GetWindow(App.Current.MainWindow) as MainWindow;
                          MainWindowViewModel vm = window.DataContext as MainWindowViewModel;
                          vm.Navigate("Details", coin);
                      }
                  }));
            }
        }

        private Command searchCoin;
        public Command SearchCoin
        {
            get
            {
                return searchCoin ??
                  (searchCoin = new Command(async obj =>
                  {
                      await Task.Run(() => GetCoinsFromApi());
                  }));
            }
        }
        private async void GetCoinsFromApi()
        {
            CoinsData = await handler.SearchCoin(SearchText);
        }
    }
}
