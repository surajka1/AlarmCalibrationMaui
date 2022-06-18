using MauiApp2.Models;
using MauiApp2.ViewModels;
using System.Diagnostics;
using System.Timers;
using MauiApp2.Resources.ResourceDictionaries; 

namespace MauiApp2;

public partial class MainTab : ContentPage
{
	public MainTab()
	{
		InitializeComponent();
	}
    ProductModel product;

    public void OnLVDSelected(object sender, EventArgs eventArgs)
    {
        button_AL106Select.BackgroundColor = Colors.LightGray;
        button_LVDSelect.BackgroundColor = Colors.LightGreen;
        product = Product.LVD;
        textBox_message.Text = String.Empty;
        textBox_Output.Text = String.Empty;
    }
    public void OnAL106Selected(object sender, EventArgs eventArgs)
    {
        button_AL106Select.BackgroundColor = Colors.LightGreen;
        button_LVDSelect.BackgroundColor = Colors.LightGray;
        product = Product.AL106;
        textBox_message.Text = String.Empty;
        textBox_Output.Text = String.Empty;
    }

    public void OnGoClicked(object sender, EventArgs eventArgs)
    {

        
        textBox_Output.Text = String.Empty;
        LVDPageInput.textBox_HigherOffset.Unfocus();
        LVDPageInput.textBox_LowerOffset.Unfocus();
        LVDPageInput.textBox_potvalue.Unfocus();


        textBox_message.Text = String.Empty;
        textBox_message.TextColor = Colors.Red;

        if (string.IsNullOrEmpty(product?.ProductName))
        {
            textBox_message.Text = "Select LVD / AL106 !";
            return;
        }

        InputValidation inputValidation = ValueCalculation.ValidateInput(LVDPageInput.textBox_potvalue.Text, LVDPageInput.textBox_HigherOffset.Text, LVDPageInput.textBox_LowerOffset.Text, product.PotDefaultValue);
        textBox_message.Text = inputValidation.errorMessage;
        if (inputValidation.validateStatus is false)
        {
            return;
        }


        DisplayClass.KeepDisplayOn();


        textBox_Output.Text = ValueCalculation.GetOutputValuesForDisplay(inputValidation, product);

    }

}