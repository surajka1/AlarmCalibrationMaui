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
    //static System.Timers.Timer displayTimer = new System.Timers.Timer(300000);
    //string boardSelection = string.Empty;
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

        InputValidation inputValidation = ValueCalculation.ValidateInput(LVDPageInput.textBox_potvalue.Text, LVDPageInput.textBox_HigherOffset.Text, LVDPageInput.textBox_LowerOffset.Text, 1000);
        textBox_message.Text = inputValidation.errorMessage;
        if (inputValidation.validateStatus is false)
        {
            return;
        }

        if (string.IsNullOrEmpty(product?.ProductName))
        {
            textBox_message.Text = "Select LVD / AL106 !";
            return;
        }
        

        DisplayClass.KeepDisplayOn();

        //displayTimer.Elapsed -= onDisplayTimerElapsed;
        //displayTimer.Stop();
        //displayTimer.Start();
        //displayTimer.Elapsed += onDisplayTimerElapsed;
#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0612 // Type or member is obsolete
        //Device.StartTimer(TimeSpan.FromSeconds(300), () =>
        //{
        //    DeviceDisplay.KeepScreenOn = false;
        //    return false; // return true to repeat counting, false to stop timer
        //});
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS0618 // Type or member is obsolete

        textBox_Output.Text = ValueCalculation.GetOutputValuesForDisplay(inputValidation, product);
        //textBox_Output.Text += $"\r\n\r\nTotal Time required: {timer.ElapsedMilliseconds}ms";
        //timer.Stop();
    }

    //private void onDisplayTimerElapsed(object sender, ElapsedEventArgs e)
    //{
    //    Dispatcher.Dispatch(() =>
    //    {
    //        DeviceDisplay.KeepScreenOn = false;
    //        displayTimer.Stop();
    //    });
    //    displayTimer.Elapsed -= onDisplayTimerElapsed;
    //    //throw new NotImplementedException();
    //}
}