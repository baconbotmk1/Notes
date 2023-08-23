using System.Globalization;
using System.Runtime.CompilerServices;

namespace Notes.Views;

public partial class TipCalc : ContentPage
{
    public TipCalc()
    {
        InitializeComponent();

        double value = Math.Round(MyTipSlider.Value, 0);

        TipPercentLabel.Text = String.Format($"{value}%");
        UpdateNumbers();
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        double value = args.NewValue;
        value = Math.Round(value, 0);
        TipPercentLabel.Text = String.Format($"{value}%");

        UpdateNumbers();
    }


    async void On15Clicked(object sender, EventArgs args)
    {
        MyTipSlider.Value = 15;
        await DisplayAlert("Normal tip", "You've selected normal tip... Cheapskate", "Ok");
    }
    async void On20Clicked(object sender, EventArgs args)
    {
        double tip = Math.Round(double.Parse(UserInput.Text) * (Math.Round(MyTipSlider.Value, 0) / 100), 2);

        bool answer = await DisplayAlert(tip < 100 ? "Cheapskate" : "Generous tip", tip < 100 ? "Waow.... Still a cheapskate... Wanna tip this?" : "Are you sure you want to tip this?", "Yes", "Si");

        if (answer)
        {
            MyTipSlider.Value = 20;
        }
    }
    void OnRoundUpClicked(object sender, EventArgs args)
    {
        RoundingUpdate(true);
    }
    void OnRoundDownClicked(object sender, EventArgs args)
    {
        RoundingUpdate(false);
    }

    private void RoundingUpdate(bool roundUp)
    {
        int af = 10; //Afrundingsfaktor

        string currTotal = TotalLabel.Text;
        string currCost = UserInput.Text;
        string currTotalTrimmed = currTotal.Replace(" kr.", string.Empty);
        double currTotalDbl = double.Parse(currTotalTrimmed.Replace(".", string.Empty).Replace(",", "."));

        double total = roundUp ? Math.Ceiling(currTotalDbl / af) * af : Math.Floor(currTotalDbl / af) * af;
        double cost = double.Parse(currCost);
        double tip = total - cost;
        double sliderValue = Math.Round((tip / cost) * 100, 2);

        TipLabel.Text = tip.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"));
        TotalLabel.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"));
        TipPercentLabel.Text = String.Format($"{sliderValue}%");
        MyTipSlider.Value = sliderValue;
    }

    private void UserInput_Changed(object sender, EventArgs e)
    {
        if (UserInput.Text.Count() > 0)
        {
            LCYBtn.IsEnabled = true;
        }
        else
        {
            LCYBtn.IsEnabled = false;
        }
        UpdateNumbers();
    }
    private void UpdateNumbers()
    {
        string cost = UserInput.Text;
        bool isNum = double.TryParse(cost, out double newCost);

        double tip = Math.Round(MyTipSlider.Value, 0);

        if (isNum)
        {
            UpdateTip(newCost, tip);
            UpdateTotal(newCost, tip);
        }
        else
        {
            UpdateTip(0, tip);
            UpdateTotal(0, tip);
        }
    }

    private void UpdateTip(double cost, double tipPercentage)
    {
        double tip = Math.Round(cost * (tipPercentage / 100), 2);
        TipLabel.Text = tip.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"));
    }
    private void UpdateTotal(double cost, double tipPercentage)
    {
        double total = Math.Round(cost * ((tipPercentage / 100) + 1), 2);
        TotalLabel.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"));
    }

    private async void ShowLCYClicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("LCY?", "Cancel", null, "DKK", "EURO", "USD");
        double totalDKK = Math.Round(double.Parse(UserInput.Text) * ((Math.Round(MyTipSlider.Value, 0) / 100)+1), 2);

        double DKKPerUSD = 6.9;
        double DKKPerEURO = 7.45;
        double DKKPerDKK = 1;

        double total = 0;
        string TotalToWrite = "";
        switch (action)
        {
            case "DKK":
                total = totalDKK / DKKPerDKK;
                TotalToWrite = total.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"));
                break;
            case "EURO":
                total = totalDKK / DKKPerEURO;
                TotalToWrite = total.ToString("C", CultureInfo.CreateSpecificCulture("de-DE"));
                break;
            case "USD":
                total = totalDKK / DKKPerUSD;
                TotalToWrite = total.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                break;
        }
        await DisplayAlert("Local Currency", $"{action}: {TotalToWrite}", "Ok");
    }
}