using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class secondpage : ContentPage
    {
        string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db");
        public secondpage()
        {
            InitializeComponent();
            
            nextpagebutton.Clicked += Nextpagebutton_Clicked;
            searchbut.Clicked += Searchbut_Clicked;
            ShoppingCart.Clicked += ShoppingCart_Clicked;
            
            
            var db = new SQLiteConnection(path);

        }

        private async  void ShoppingCart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingcartPage());
        }

        private async void Searchbut_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void Nextpagebutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FoodLibrary());
        }

        
    }
}