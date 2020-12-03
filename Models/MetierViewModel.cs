using System.ComponentModel;

namespace BidCardCoin.Models
{
    public class MetierViewModel : INotifyPropertyChanged
    {
        public int idMetier ;
        public string libMetier ;
        public MetierViewModel(int idMetier, string libMetier)
        {
            this.idMetier = idMetier;
            this.libMetier = libMetier;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                MetierORM.updateMetier(this);
            }
        }
        public string LibMetier
        {
            get{
                return libMetier;
            }
        }
    }
}
