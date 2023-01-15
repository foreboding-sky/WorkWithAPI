using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestAPI.Models;
using TestAPI.Services;
using System.Windows.Interactivity;
using System.Windows;

namespace TestAPI.ViewModels
{
    public class TopCoinsViewModel : BaseViewModel
    {
        private MarketApiHandler handler;
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

        public async void PageLoaded()
        {
            await Task.Run(() => GetCoinsFromApi());
        }

        private Command getCoins;
        public Command GetCoins
        {
            get
            {
                return getCoins ??
                  (getCoins = new Command(async obj =>
                  {
                      await Task.Run(() => GetCoinsFromApi());
                  }));
            }
        }

        private Command showDetails;
        public Command ShowDetails
        {
            get
            {
                return showDetails ??
                  (showDetails = new Command( obj =>
                  {
                      CoinModel coin = obj as CoinModel;
                      if(coin != null)
                      {
                          var window = Window.GetWindow(App.Current.MainWindow) as MainWindow;
                          MainWindowViewModel vm = window.DataContext as MainWindowViewModel;
                          vm.Navigate("Details", coin);
                      }
                  }));
            }
        }
        public TopCoinsViewModel()
        {
            handler = new MarketApiHandler();
            coinsData = new DataModel();
        }

        private async void GetCoinsFromApi()
        {
            CoinsData = await handler.GetCoins(20);
        }
    }
}
