using Notes.Models;
using System.Collections.ObjectModel;

namespace Notes.Views;

public partial class Restaurants : ContentPage
{
    public ObservableCollection<Restaurant> AllRestaurants { get; set; }
    public Restaurants()
    {
        CreateRestaurants();
        BindingContext = this;
        InitializeComponent();
    }

    void CreateRestaurants()
    {
        AllRestaurants = new ObservableCollection<Restaurant>
        {
            new Restaurant
            {
                Name = "Peking Restaurant",
                Location = "Jernbanegade 49, Sønderborg 6400 Danmark",
                ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/22/12/01/b9/peking-restaurant-sonderborg.jpg"
            },
            new Restaurant
            {
                Name = "Oyisi sushi",
                Location = "Perlegade 4, Sønderborg 6400 Danmark",
                ImageUrl = "https://oyisi.dk/soenderborg/wp-content/uploads/2022/05/banner_logo.png"
            },
            new Restaurant
            {
                Name = "Curry leaves",
                Location = "Norrebro 2, Sønderborg 6400 Danmark",
                ImageUrl = "https://www.curryleaves.dk/wp-content/themes/curryleaves/img/logo.png"
            }
        };
    }

    private void AddRestClicked(object sender, EventArgs e)
    {
        #region TotalRandom
        //string[] restNames = new string[]
        //{
        //    "Curry leaves",
        //    "Oyisi sushi",
        //    "Peking Restaurant",
        //    "Torvehallen",
        //    "Restaurant Colosseum",
        //    "Bone's"
        //};
        //string[] restLocation = new string[]
        //{
        //    "Norrebro 2, Sønderborg 6400 Danmark",
        //    "Perlegade 4, Sønderborg 6400 Danmark",
        //    "Jernbanegade 49, Sønderborg 6400 Danmark",
        //    "Noerre Havnegade 28, Sønderborg 6400 Danmark",
        //    "Sønder Havnegade 24, Sønderborg 6400 Danmark",
        //    "Stenager 17, Sønderborg 6400 Danmark"
        //};
        //string[] restImage = new string[]
        //{
        //    "https://www.curryleaves.dk/wp-content/themes/curryleaves/img/logo.png", 
        //    "https://oyisi.dk/soenderborg/wp-content/uploads/2022/05/banner_logo.png", 
        //    "https://media-cdn.tripadvisor.com/media/photo-s/22/12/01/b9/peking-restaurant-sonderborg.jpg", 
        //    "https://lirp.cdn-website.com/5e888099/dms3rep/multi/opt/5-1920w.png",
        //    "https://restaurant-colosseum.dk/wp-content/uploads/2022/04/Logo-e1649250157943.png",
        //    "https://bones.dk/assets/bones_logo.png"
        //};
        #endregion
        List<Restaurant> randomRest = new()
        {
            new Restaurant
            {
                Name = "Curry leaves",
                Location = "Norrebro 2, Sønderborg 6400 Danmark",
                ImageUrl = "https://www.curryleaves.dk/wp-content/themes/curryleaves/img/logo.png"
            },
            new Restaurant
            {
                Name = "Oyisi sushi",
                Location = "Perlegade 4, Sønderborg 6400 Danmark",
                ImageUrl = "https://oyisi.dk/soenderborg/wp-content/uploads/2022/05/banner_logo.png"
            },
            new Restaurant
            {
                Name = "Peking Restaurant",
                Location = "Jernbanegade 49, Sønderborg 6400 Danmark",
                ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/22/12/01/b9/peking-restaurant-sonderborg.jpg"
            },
            new Restaurant
            {
                Name = "Torvehallen",
                Location = "Noerre Havnegade 28, Sønderborg 6400 Danmark",
                ImageUrl = "https://lirp.cdn-website.com/5e888099/dms3rep/multi/opt/5-1920w.png"
            },
            new Restaurant
            {
                Name = "Restaurant Colosseum",
                Location = "Sønder Havnegade 24, Sønderborg 6400 Danmark",
                ImageUrl = "https://restaurant-colosseum.dk/wp-content/uploads/2022/04/Logo-e1649250157943.png"
            },
            new Restaurant
            {
                Name = "Bone's",
                Location = "Stenager 17, Sønderborg 6400 Danmark",
                ImageUrl = "https://bones.dk/assets/bones_logo.png"
            },
        };
        AllRestaurants.Add(randomRest[new Random().Next(randomRest.Count)]);
    }

    private void DelRestClicked(object sender, EventArgs e)
    {
        AllRestaurants.Remove(AllRestaurants.FirstOrDefault());
    }
}