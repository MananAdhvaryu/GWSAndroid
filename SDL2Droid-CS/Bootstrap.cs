using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SDL2;

using System.Runtime.InteropServices;
using Android.Content.Res;
using Android.Util;

using MnM.GWS;
using MnM.GWS.StandardVersion;
using static MnM.GWS.Implementation;

namespace SDL2Droid_CS {
    delegate void Main();

    // Delegates for the example code
    delegate void DglClearColor(
        float red,
        float green,
        float blue,
        float alpha
    );
    delegate void DglClear(int mask);

    static class Bootstrap {

        private static IWindow window;

        //private static IFillStyle bg = Factory.newFillStyle(Gradient.Horizontal, Colour.Red, Colour.Blue, Colour.Green);

        public static void SDL_Main() 
        {
            Attach(SdlFactory.Instance);

            window = Factory.newWindow("GWS Android Window");

            window.ApplyBackground(Factory.newFillStyle(Gradient.Horizontal, Colour.Red, Colour.Blue, Colour.Green));

            window.DrawEllipse(10, 10, 100, 100);

            window.Submit();

            window.Show();

            Implementation.Run();

    
        }
        public static void SetupMain() {
            // Give the main library something to call in Mono-Land afterwards
            SetMain(SDL_Main);

            // Insert your own post-lib-load, pre-SDL2 code here.
        }

        [DllImport("main")]
        static extern void SetMain(Main main);

    }
}