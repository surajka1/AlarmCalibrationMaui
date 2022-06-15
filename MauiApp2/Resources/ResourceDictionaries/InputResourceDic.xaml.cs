namespace MauiApp2.Resources.ResourceDictionaries;

public partial class PresetInputField : StackLayout
{
	public PresetInputField()
	{
		InitializeComponent();
		textBox_HigherOffset.PlaceholderColor = Colors.LightGray;
		textBox_HigherOffset.Placeholder = "Higher Offset";
		textBox_LowerOffset.PlaceholderColor = Colors.LightGray;
		textBox_LowerOffset.Placeholder = "Lower Offset";
		textBox_potvalue.PlaceholderColor = Colors.LightGray;
		textBox_potvalue.Placeholder = "Maximum Pot Value";
	}
}