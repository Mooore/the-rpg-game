using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Šablona "Blank Application" je popsána na adrese http://go.microsoft.com/fwlink/?LinkId=234227

namespace the_rpg_game
{
    /// <summary>
    /// Poskytuje chování specifické pro aplikaci, doplňující výchozí třídu Application.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Inicializuje objekt aplikace typu singleton. Jedná se o první řádek spuštěného vytvořeného kódu,
        /// který je proto logickým ekvivalentem metod main() a WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Vyvoláno při normálním spuštění aplikace koncovým uživatelem.  Ostatní vstupní body
        /// budou použity například při spuštění aplikace za účelem otevřít konkrétní soubor.
        /// </summary>
        /// <param name="e">Podrobnosti o požadavku spuštění a procesu.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Neopakovat inicializaci aplikace, pokud má objekt Window již obsah,
            // pouze zkontrolovat, zda je okno aktivní
            if (rootFrame == null)
            {
                // Vytvořit objekt Frame, který bude fungovat jako kontext navigace, a spustit procházení první stránky
                rootFrame = new Frame();
                // Nastavte výchozí jazyk.
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Načíst stav z dříve pozastavené aplikace
                }

                // Umístit rámec do aktuálního objektu Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // Není-li navigační zásobník obnoven, navigovat na první stránku
                // a nakonfigurovat novou stránku předáním požadovaných informací ve formě
                // parametru navigace
                rootFrame.Navigate(typeof(MenuPage), e.Arguments);
            }
            // Zkontrolovat, zda je aktuální okno aktivní
            Window.Current.Activate();
        }

        /// <summary>
        /// Vyvoláno, když se nezdaří přechod na určitou stránku
        /// </summary>
        /// <param name="sender">Rámec, pro který se nezdařila navigace</param>
        /// <param name="e">Podrobnosti o chybě navigace</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Vyvoláno při pozastavení provádění aplikace. Stav aplikace je uložen,
        /// aniž by bylo známo, zda bude aplikace ukončena, nebo zda bude obnovena
        /// s neporušeným obsahem paměti.
        /// </summary>
        /// <param name="sender">Zdroj žádosti o pozastavení.</param>
        /// <param name="e">Podrobnosti žádosti o pozastavení.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Uložit stav aplikace a ukončit jakékoli aktivity na pozadí
            deferral.Complete();
        }
    }
}
