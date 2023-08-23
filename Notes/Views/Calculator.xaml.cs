namespace Notes.Views;

public partial class Calculator : ContentPage
{
	public Calculator()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}