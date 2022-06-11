using MauiApp2.Models;

namespace MauiApp2;

public partial class ResistorList : ContentPage
{
	public ResistorList()
	{
		InitializeComponent();
        AddORemoveRes.SelectedIndex = 0;
        ResRangeSelect.SelectedIndex = 1;
        UpdateAllResistorsView();
    }
    public static readonly List<string> ResRange = new List<string>() { "E", "K" };
    public static readonly List<string> AddRemoveList = new List<string>() { "Add", "Remove" };
    public void SaveResistorValue_Click(object sender, EventArgs eventArgs)
    {
        long resvalueInput;
        ResPageTextbox.Text = "";
        ResPageTextbox.TextColor = Colors.Red;
        if (ResRangeSelect.SelectedIndex == 1)
        {
            if (float.TryParse(InputResistorValue.Text, out float InputVal))
            {
                resvalueInput = (long)(InputVal * 1000);
                if (AddORemoveRes.SelectedIndex == 0)
                {
                    ResistorManipulateClass.Add(resvalueInput);
                }
                else
                {
                    ResistorManipulateClass.Remove(resvalueInput);
                }

            }
            else
            {
                ResPageTextbox.Text = "Error in input value";
            }
        }
        else if (long.TryParse(InputResistorValue.Text, out resvalueInput))
        {
            if (AddORemoveRes.SelectedIndex == 0)
            {
                ResistorManipulateClass.Add(resvalueInput);
            }
            else
            {
                ResistorManipulateClass.Remove(resvalueInput);
            }
        }
        else
        {
            ResPageTextbox.Text = "Error in input value";
        }
        UpdateAllResistorsView();
    }

    private void UpdateAllResistorsView()
    {
        HashSet<long> allResvalues = ResistorManipulateClass.GetResValuesFromJson();
        Textbox_AllResistorView.Text = String.Empty;
        if (allResvalues?.Count > 0)
        {
            List<long> resvalues = new List<long>(allResvalues);
            resvalues.Sort();
            allResvalues.OrderBy(x => x);
            foreach (var item in resvalues)
            {
                Textbox_AllResistorView.Text += (ResistorManipulateClass.ResValueToString(item) + "\r\n");
            }
        }
    }
}