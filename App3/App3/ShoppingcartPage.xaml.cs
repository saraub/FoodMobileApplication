using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingcartPage : ContentPage
    {
        string pathe = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db");
        Item item = new Item();
        public ShoppingcartPage()
        {

            InitializeComponent();

            var db = new SQLiteConnection(pathe);
            _listview.ItemsSource=db.Table<Item>();





           

          
           

           
            removeallbutton.Clicked += Removeallbutton_Clicked;














        }

        private async void Removeallbutton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(pathe);
            db.DeleteAll<Item>();
            await DisplayAlert("DONE SHOPPING!", "YOU HAVE EMPTIED THE SHOPPING CART!", "yeaa");
        }

        private void _listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            item = (Item)e.SelectedItem;

        }

       
    }
}