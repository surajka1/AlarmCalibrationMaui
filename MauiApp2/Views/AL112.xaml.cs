namespace MauiApp2.Views;
using MauiApp2.Models;
using MauiApp2.ViewModels;
public partial class AL112 : ContentPage
{
	public AL112()
	{
		InitializeComponent();
	}
    ProductModel product;
    public void OnBatSelected(object sender, EventArgs eventArgs)
    {
        button_Temp.BackgroundColor = Colors.LightGray;
        button_Bat.BackgroundColor = Colors.LightGreen;
        product = Product.Al112Bat;
        textBox_message.Text = String.Empty;
        textBox_Output.Text = String.Empty;
    }
    public void OnTempSelected(object sender, EventArgs eventArgs)
    {
        button_Temp.BackgroundColor = Colors.LightGreen;
        button_Bat.BackgroundColor = Colors.LightGray;
        product = Product.Al112Temp;
        textBox_message.Text = String.Empty;
        textBox_Output.Text = String.Empty;
    }

    public void OnGoClicked(object sender, EventArgs eventArgs)
    {


        textBox_Output.Text = String.Empty;
        AL112PageInput.textBox_HigherOffset.Unfocus();
        AL112PageInput.textBox_LowerOffset.Unfocus();
        AL112PageInput.textBox_potvalue.Unfocus();


        textBox_message.Text = String.Empty;
        textBox_message.TextColor = Colors.Red;

        InputValidation inputValidation = ValueCalculation.ValidateInput(AL112PageInput.textBox_potvalue.Text, AL112PageInput.textBox_HigherOffset.Text, AL112PageInput.textBox_LowerOffset.Text, product.PotDefaultValue);
        textBox_message.Text = inputValidation.errorMessage;
        if (inputValidation.validateStatus is false)
        {
            return;
        }

        if (string.IsNullOrEmpty(product?.ProductName))
        {
            textBox_message.Text = "Select Battery / Temperature !";
            return;
        }


        DisplayClass.KeepDisplayOn();


        textBox_Output.Text = ValueCalculation.GetOutputValuesForDisplay(inputValidation, product);

    }
}