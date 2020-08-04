using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db");
       
        public Food food = new Food();
       
        
        public SearchPage()
        {
            InitializeComponent();
            if (DesignMode.IsDesignModeEnabled)
            {
                return;
            }


            var db = new SQLiteConnection(path);
           

        }

        public async void _listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
            food = (Food)e.Item;



            await DisplayAlert("Ingredience", food.Note, "GOT IT");

        }




        private void _listview_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            food = (Food)e.SelectedItem;
        }

        private void _searchbar_SearchButtonPressed_1(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(path);

            var keyword = _searchbar.Text;
            var suggestion = db.Table<Food>().Where(c => c.Name.ToLower().Contains(keyword));
            _listview.ItemsSource = suggestion;

        }
    }
}