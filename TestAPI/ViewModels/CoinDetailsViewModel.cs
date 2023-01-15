using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.ViewModels
{
    public class CoinDetailsViewModel : BaseViewModel
    {
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
        }
    }
}
