using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestAPI.Models;
using TestAPI.Services;

namespace TestAPI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
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
        public MainWindowViewModel()
        {
            handler = new MarketApiHandler();
            coinsData = new DataModel();
        }

        private Command getCoins;
        public Command GetCoins
        {
            get
            {
                return getCoins ??
                  (getCoins = new Command(async obj =>
                  {
                      CoinsData = await handler.GetCoins(20);
                  }));
            }
        }
    }
}
