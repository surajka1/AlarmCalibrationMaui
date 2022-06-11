using System.Text.Json;

namespace MauiApp2;

public partial class TabPage : TabbedPage
{
	public TabPage()
	{
		InitializeComponent();
        HashSet<long> _resistorvalues;
        bool needCreateFile = false;
        string jsonpath = AppDomain.CurrentDomain.BaseDirectory + "ResValues.json";
        if (File.Exists(jsonpath))
        {
            string jsonReadFromFile = File.ReadAllText(jsonpath);
            _resistorvalues = JsonSerializer.Deserialize<HashSet<long>>(jsonReadFromFile);
            if (!(_resistorvalues?.Count > 2))
            {
                needCreateFile = true;
            }
        }
        else
        {
            needCreateFile = true;
        }

        if (needCreateFile)
        {
            _resistorvalues = new HashSet<long>() {
                      2,
                      10,
                      100,
                      180,
                      220,
                      270,
                      330,
                      470,
                      680,
                      1000,
                      1800,
                      2200,
                      2700,
                      3300,
                      3900,
                      4700,
                      5600,
                      6800,
                      10000,
                      12000,
                      15000,
                      18000,
                      22000,
                      33000,
                      47000,
                      68000,
                      100000,
                      220000,
                      330000,
                      470000,
                      680000,
                      1000000
                };

            string jsontowrite = JsonSerializer.Serialize(_resistorvalues);  
            File.WriteAllText(jsonpath, jsontowrite);
        }
    }
}