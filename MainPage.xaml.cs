namespace Splitify;

public partial class MainPage : ContentPage
{
	// variables for making the calculations
	decimal bill;
	int tip;
	int noPersons = 1;

	public MainPage()
	{
		InitializeComponent();
	}

    private void entryBill_Completed(object sender, EventArgs e)
    {
		// in bill store entryBill.text, convert the string number to decimal
		bill = decimal.Parse(entryBill.Text);
        // invoce calc
        CalculateTotal();
    }

    private void CalculateTotal()
    {
		//Total tip
		//Multiply tip with bill, divide by 100
		var totalTip = (bill * tip) / 100;

		// tip for each person
		var tipByPerson = (totalTip / noPersons); // divide tip by persons
		labelTipByPerson.Text = $"{tipByPerson:C}";

		//Total, divide bill with number of persons
		var subtotal = (bill / noPersons);
		// change text to value of subtotal
		labelSubtotal.Text = $"{subtotal:C}";

		//Total by persons, bill + totaltip then divide by number of persons
		var totalByPerson = (bill + totalTip) / noPersons;
		// change text in total to value of totalByPersons
		labelTotal.Text = $"{totalByPerson:C}";

    }

    private void sliderTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		// store as int the value of the slider
		tip = (int)labelTip.Value;
		// show the data to the user
		tipVal.Text = $"Tip slider: {tip}%";
		// invoce calc
		CalculateTotal();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		// check conditions
		if(sender is Button)
		{
			var btn = (Button)sender;
			// replace the % with an empty string, instead get button text which equals the % value  
			var percentage = int.Parse(btn.Text.Replace("%", ""));
			// set the slider value to percentage, which is the value of the button that is clicked
			labelTip.Value = percentage;
		}
    }

    private void buttonMinus_Clicked(object sender, EventArgs e)
    {
		// check so persons is not less than 1.
		if(noPersons > 1)
		{
			noPersons--;
		}
		// parse to string
		labelNoPersons.Text = noPersons.ToString();
		// invoce calc
		CalculateTotal();
    }

    private void buttonPlus_Clicked(object sender, EventArgs e)
    {
		// if button + is pressed, ++ noPersons
		noPersons++;
		// change text in label to noPersons, comvert to string
        labelNoPersons.Text = noPersons.ToString();
		// Invoce calc
		CalculateTotal();
    }
}

