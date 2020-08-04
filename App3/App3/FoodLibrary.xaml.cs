using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodLibrary : ContentPage
    {
        
        string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db");
        Food food = new Food();
        
        
        public FoodLibrary()
        {
            InitializeComponent();
            
            var db = new SQLiteConnection(path);
            db.CreateTable<Food>();
           
            addbutton.Clicked += Addbutton_Clicked;
            gobackpagebutton.Clicked += Gobackpagebutton_Clicked;
            
            deletebutton.Clicked += Deletebutton_Clicked;
            expand.Clicked += Expand_Clicked;

            _listview.ItemsSource = db.Table<Food>().OrderBy(c => c.Name).ToList();
        }

        private async void Expand_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new expansion(food));
            
        }

        private async void Gobackpagebutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new secondpage());
        }

        private async void Addbutton_Clicked(object sender, EventArgs e)
        {
            if (tagentry.Text != null)
            {
                var db = new SQLiteConnection(path);
                db.CreateTable<Food>();
                var pkmax = db.Table<Food>().OrderByDescending(x => x.ID).FirstOrDefault();

                Food newfood = new Food()
                {

                    Name = foodentry.Text,
                    ID = (pkmax == null ? 1 : pkmax.ID + 1),
                    Note = tagentry.Text,
                };
                db.Insert(newfood);
                await DisplayAlert("Success", "You have added a new item in the library", "COOL");
            }
            else
            {
                await DisplayAlert("Note!", "You must fill all the area in order to add an item!", "OK");
            }

            
            
        }

    

       

        private async void Deletebutton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(path);
            db.Delete(food);
            await DisplayAlert("Romoved!", $"You have removed {food.Name} from the library!", "Cool");



        }
        
        private void _listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            expand.IsVisible = true;
            food=(Food)e.SelectedItem;

            

        }
        public Food getfood()
        {
            return food;
        }
        
       
    }
}