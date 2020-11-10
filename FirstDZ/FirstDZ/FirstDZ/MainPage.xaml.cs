using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstDZ
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Pick.ItemsSource = itemsList.Select(a => { return a.Name; }).ToList();
            
        }

        List<MyItem> itemsList = new List<MyItem>()
        {

            new MyItem()
            {
                Name = "Item 1",
                Description = "Какое то описание первого айтема",
                picPath = "FirstDZ.shrek1.jpg"
            },

            new MyItem()
            {
                Name = "Item 2",
                Description = "А тут типа описание второго ну",
                picPath = "FirstDZ.shrek2.jpg"
            },

            new MyItem()
            {
                Name = "Item 3",
                Description = "Не сложно догадаться что тут третьего",
                picPath = "FirstDZ.shrek3.jpg"
            },

            new MyItem()
            {
                Name = "Item 4",
                Description = "Ну и последний, можно еще добавить",
                picPath = "FirstDZ.shrek4.jpg"
            }

        };

        public class MyItem
        {
            public string Name;
            public string Description;
            public string picPath;
        }

        private void Pick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Pick.SelectedItem != null)
            {
                desc.Text = itemsList[(sender as Picker).SelectedIndex]?.Description;

                if (Cart.goodsArr.ContainsKey(Pick.SelectedItem?.ToString()))
                    Amount.Text = Cart.goodsArr[Pick.SelectedItem?.ToString()].count.ToString();
                else
                    Amount.Text = "0";

                MainImage.Source = ImageSource.FromResource(itemsList[(sender as Picker).SelectedIndex]?.picPath);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Page cart = new Cart();

            Navigation.PushAsync(cart);

            Pick.SelectedItem = null;
            Amount.Text = "0";
            MainImage.Source = null;
            desc.Text = "Description";
        }

        private void addAmount (object sender, EventArgs e)
        {
            if (Pick.SelectedItem != null)
            {
                Amount.Text = (int.Parse(Amount.Text) + 1).ToString();
                Cart.goodsArr[Pick.SelectedItem?.ToString()] = new Good
                {
                    Name = Pick.SelectedItem?.ToString(),
                    count = int.Parse(Amount.Text)
                };
            }
        }

        private void reduceAmount (object sender, EventArgs e)
        {
            if (int.Parse(Amount.Text) > 0)
            {
                Amount.Text = (int.Parse(Amount.Text) - 1).ToString();
                Cart.goodsArr[Pick.SelectedItem?.ToString()] = new Good
                {
                    Name = Pick.SelectedItem?.ToString(),
                    count = int.Parse(Amount.Text)
                };
            }
            else
                DisplayAlert("Error", "АТЯТЯ", "Ладно");
        }
    }
}
