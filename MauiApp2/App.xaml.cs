namespace MauiApp2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		//Console.WriteLine("Working Upto before calling tabbed page");
		MainPage = new TabPage();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        if (window != null)
        {
            window.Title = "Alarm Calibration Tool";
        }

        return window;
    }
}
