namespace MauiApp2;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		//ma = TabPage;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count*2} time";
		else
			CounterBtn.Text = $"Clicked {count*2} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

