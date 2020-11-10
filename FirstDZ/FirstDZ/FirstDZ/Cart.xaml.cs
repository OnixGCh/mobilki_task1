using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstDZ
{
    public class Good
    {
        public string Name { get; set; }
        public int count { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {

        public static SortedDictionary<string, Good> goodsArr = new SortedDictionary<string, Good>();
        public Cart()
        {
            InitializeComponent();

            GoodsView.ItemsSource = goodsArr.Select((a) => { return a.Value; }).ToList();
        }

        private void deleteItem (object sender, EventArgs e)
        {
            goodsArr.Remove((sender as Button)?.CommandParameter.ToString());

            GoodsView.ItemsSource = goodsArr.Select((a) => { return a.Value; }).ToList();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Order", "Уверен?", "Офк", "Падажжи"))
            {
                goodsArr.Clear();
                GoodsView.ItemsSource = goodsArr.Select((a) => { return a.Value; }).ToList();
            }
        }
    }
}