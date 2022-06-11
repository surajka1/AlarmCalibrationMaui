using MauiApp2.Models;

namespace MauiApp2;

public partial class MainTab : ContentPage
{
	public MainTab()
	{
		InitializeComponent();
	}

    string boardSelection = string.Empty;


    public void OnLVDSelected(object sender, EventArgs eventArgs)
    {
        button_AL106Select.BackgroundColor = Colors.LightGray;
        button_LVDSelect.BackgroundColor = Colors.LightGreen;
        boardSelection = "LVD";
    }
    public void OnAL106Selected(object sender, EventArgs eventArgs)
    {
        button_AL106Select.BackgroundColor = Colors.LightGreen;
        button_LVDSelect.BackgroundColor = Colors.LightGray;
        boardSelection = "AL106";
    }

    public void OnGoClicked(object sender, EventArgs eventArgs)
    {
        //var timer = new Stopwatch();
        //timer.Start();
        textBox_Output.Text = String.Empty;
        textBox_HigherOffset.Unfocus();
        textBox_LowerOffset.Unfocus();
        textBox_potvalue.Unfocus();
        long minToleranceFound = 0;
        long inputValue = 0;
        long lowerOffset = 0;
        long higherOffset = 0;
        long potMaxValue = 0;

        textBox_message.Text = String.Empty;
        textBox_message.TextColor = Colors.Red;
        if (!long.TryParse(textBox_LowerOffset.Text, out lowerOffset))
        {
            textBox_message.Text = "Error parsing lower offset value!";
            textBox_message.TextColor = Colors.Red;
            return;
        }
        if (!long.TryParse(textBox_potvalue.Text, out inputValue))
        {
            textBox_message.Text = "Error parsing POT maximum value!";
            return;
        }
        if (!long.TryParse(textBox_HigherOffset.Text, out potMaxValue))
        {
            textBox_message.Text = "Error parsing higher offset value!";
            return;
        }
        if (inputValue >= potMaxValue)
        {
            higherOffset = inputValue - potMaxValue;
        }
        else
        {
            textBox_message.Text = "Maximum Pot value and Higher Offset do not match.";
            return;
        }

        if (inputValue < 500 || inputValue > 1500 || potMaxValue < 500 || potMaxValue > 1500 || lowerOffset > 300)
        {
            textBox_message.Text = "Too bad a POT to calculate the values.";
            return;
        }

        long requiredResValue = 0;

        float multiplier_f = 1;
        if (boardSelection == "LVD")
        {
            multiplier_f = 7.07f;
        }
        else if (boardSelection == "AL106")
        {
            multiplier_f = 7.8F;
        }
        else
        {
            textBox_message.Text = "Select LVD / AL106 !";
            return;
        }

        requiredResValue = (long)((float)inputValue * multiplier_f);
        Dictionary<long, ResChildren> outputResistorList = ResistorManipulateClass.FindResistorValues(requiredResValue, higherOffset, out minToleranceFound);
        if (outputResistorList.Count > 0)
        {
            int i = 1;
            textBox_Output.Text += ($"Upper Values. Discrepancy : {minToleranceFound}E\r\n");//\r\n----------------------------------------------------\r\n");

            foreach (var item in outputResistorList)
            {
                textBox_Output.Text += ($"{i++}.  R20 = {ResistorManipulateClass.ResValueToString(item.Key)}   +   R4 = {ResistorManipulateClass.ResValueToString(item.Value.child1)}  ||  R14 = {ResistorManipulateClass.ResValueToString(item.Value.child2)} \r\n");
            }
            //textBox_Output.AppendText($"Minimum Discrepancy : {minToleranceFound}E\r\n");
        }


        textBox_Output.Text += ("\r\n*************************************\r\n\r\n");
        if (boardSelection == "LVD")
        {
            multiplier_f = 6.72f;
        }
        else if (boardSelection == "AL106")
        {
            multiplier_f = 7.7f;
        }

        requiredResValue = (long)((float)inputValue * multiplier_f);
        outputResistorList = ResistorManipulateClass.FindResistorValues(requiredResValue, lowerOffset, out minToleranceFound);
        if (outputResistorList.Count > 0)
        {
            int i = 1;
            textBox_Output.Text += ($"Lower Values. Discrepancy : {minToleranceFound}E\r\n");// Required is {requiredResValue}\r\n----------------------------------------------------\r\n");

            foreach (var item in outputResistorList)
            {
                textBox_Output.Text += ($"{i++}.  R16 = {ResistorManipulateClass.ResValueToString(item.Key)}   +   R8 = {ResistorManipulateClass.ResValueToString(item.Value.child1)}  ||  R15 = {ResistorManipulateClass.ResValueToString(item.Value.child2)} \r\n");
            }
            //textBox_Output.AppendText($"Minimum Discrepancy : {minToleranceFound}E\r\n");
        }

        //timer.Stop();
    }

}