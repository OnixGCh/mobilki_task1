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

        public static Dictionary<string, Good> goodsArr = new Dictionary<string, Good>();
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
            var button = sender as Button;
            button.IsEnabled = false;

            if (goodsArr.Count == 0)
            {
                await DisplayAlert("Ошибка", "Корзина пустая", "Ok");
                
            }
            else if (await DisplayAlert("Order", "Точно?", "Да", "Нет"))
            {
                goodsArr.Clear();
                GoodsView.ItemsSource = goodsArr.Select((a) => { return a.Value; }).ToList();
            }

            button.IsEnabled = true;
        }
    }
}