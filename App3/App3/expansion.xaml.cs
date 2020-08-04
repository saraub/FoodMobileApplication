using Plugin.InputKit.Shared.Controls;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class expansion : ContentPage
    {
        public List<Item> shopinglist = new List<Item>();
        
        string pathe = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db");
        string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db");
        public expansion( Food food)
        {
            
            InitializeComponent();
            
            _label.Text = food.Name;

            
      
            string newnote= food.Note.Replace(' ', ',');
            
            List<string> notelist = newnote.Split(',').ToList();

            

            shopbut.Clicked += Shopbut_Clicked;
            
               
            for (int i = 0; i < notelist.Count; i++)
            {
                Switch ck = new Switch();
               
                
                Label lb = new Label();

                lb.Text = notelist[i];
                ck.Scale = 1.5;
                ck.Margin = new Thickness(0, 7, 0, 0);

               
                
              

                ck.VerticalOptions = LayoutOptions.Center;
                ck.HorizontalOptions = LayoutOptions.Center;
                lb.TextColor = Color.WhiteSmoke;
                ck.IsToggled = false;
                lb.FontSize = 22;


                


                secondstack.Children.Add(ck);
                _s.Children.Add(lb);
                
                var dbd = new SQLiteConnection(pathe);


                var pkmax = dbd.Table<Food>().OrderByDescending(x => x.ID).FirstOrDefault();

                Item item = new Item()
                {

                    Name = notelist[i],
                    ID = (pkmax == null ? 1 : pkmax.ID + 1),
                    
                };
                ck.Toggled += (sender, e) => Ck_Toggled1(sender, e, item, ck);
                /* var keywprd = item.Name;
                 ck.Toggled += (sender, e) => Ck_Toggled1(sender, e, item);
                 if (dbc.Table<Item>().Any(x => x.Name.Contains(keywprd))){
                     return;
                 }
                 else
                 {
                     switch (ck.IsToggled)
                     {
                         case true:
                             dbc.Insert(item);
                             break;
                         case false:
                             dbc.Delete(item);
                             break;
                         default:
                             break;





                     }
                 }

                 */





            }
            
            

        
    }

        private  void Ck_Toggled1(object sender, ToggledEventArgs e,Item item, Switch ch)
        {
         
            var dbd = new SQLiteConnection(pathe);
            dbd.CreateTable<Item>();
            
            var keywprd = item.Name;
            if(dbd.Table<Item>().Any(x => x.Name.Contains(keywprd)))
            {
                return;
            }
            else
            {
                if (ch.IsToggled)
                {

                    dbd.Insert(item);
                }
                else
                {
                    dbd.Delete(item);
                }
            }
          
        }
        

       

        private async void Shopbut_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new ShoppingcartPage());
        }

        
    }
}