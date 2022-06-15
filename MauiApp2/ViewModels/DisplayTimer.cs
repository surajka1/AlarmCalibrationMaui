using Microsoft.Maui.Dispatching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MauiApp2.ViewModels
{

    public class DisplayClass
    {
        static System.Timers.Timer displayTimer = new System.Timers.Timer(30000);
        public static void KeepDisplayOn()
        {
            Application.Current.Dispatcher.Dispatch(()=>
            {
                DeviceDisplay.KeepScreenOn = true;
            });

            displayTimer.Elapsed -= onDisplayTimerElapsed;
            displayTimer.Stop();
            displayTimer.Start();
            displayTimer.Elapsed += onDisplayTimerElapsed;
        }
        private static void onDisplayTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Dispatch(() =>
            {
                DeviceDisplay.KeepScreenOn = false;
                displayTimer.Stop();
            });
            displayTimer.Elapsed -= onDisplayTimerElapsed;
            //throw new NotImplementedException();
        }
    }
}
