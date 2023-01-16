using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Services;

namespace TestAPI.ViewModels
{
    public class CoinDetailsViewModel : BaseViewModel
    {
        private string coinLink;
        public string CoinLink
        {
            get
            {
                return "https://coinmarketcap.com/ru/currencies/" + coinLink;
            }
            set
            {
                if (coinLink == value)
                    return;

                coinLink = value;
                OnPropertyChanged("CoinLink");
            }
        }

        private CoinModel coin;
        public CoinModel Coin 
        {
            get
            {
                return coin;
            }
            set
            {
                if (coin == value)
                    return;

                coin = value;
                OnPropertyChanged("Coin");
            }
        }
        public CoinDetailsViewModel() { }   
        public CoinDetailsViewModel(CoinModel _coin)
        {
            Coin = _coin;
            CoinLink = Coin.Id;
        }

        private Command navigateToLink;
        public Command NavigateToLink
        {
            get
            {
                return navigateToLink ??
                  (navigateToLink = new Command(obj =>
                  {
                      Process.Start(new ProcessStartInfo(CoinLink));
                  }));
            }
        }
    }
}
