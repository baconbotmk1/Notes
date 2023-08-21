namespace Notes.Views;

public partial class TipCalc : ContentPage
{
    public TipCalc()
    {
        InitializeComponent();
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        double value = args.NewValue;
        TipPercentLabel.Text = String.Format($"{value}%");
    }


    void On15Clicked(object sender, EventArgs args)
    {
        MyTipSlider.Value = 15;
    }
    void On20Clicked(object sender, EventArgs args)
    {
        MyTipSlider.Value = 20;
    }
    void OnRoundUpClicked(object sender, EventArgs args)
    {

    }
    void OnRoundDownClicked(object sender, EventArgs args)
    {

    }

    private void UserInput_Completed(object sender, EventArgs e)
    {
        var newTotal = "";

        


        TotalLabel.Text = newTotal;
    }

    private void UpdateTip()
    {

    }
    private void UpdateTotal()
    {

    }
}