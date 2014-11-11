using the_rpg_game.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Šablona položky základní stránky je zdokumentována na adrese http://go.microsoft.com/fwlink/?LinkId=234237

namespace the_rpg_game
{
    /// <summary>
    /// Základní stránka poskytující vlastnosti společné většině aplikací.
    /// </summary>
    public sealed partial class GamePage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// To lze změnit na model zobrazení se silnými typy.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Třída NavigationHelper se používá na každé stránce pro výpomoc s navigací a 
        /// správa životnosti procesu
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public GamePage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Naplní stránku obsahem předaným při navigaci. Jakýkoliv uložený stav je při
        /// opětovném vytváření stránky z předchozí relace také poskytnut.
        /// </summary>
        /// <param name="sender">
        /// Zdroj události, obvykle <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Data události poskytující navigační parametr předaný
        /// <see cref="Frame.Navigate(Type, Object)"/> při prvním požadavku na tuto stránku a
        /// slovník stavů zachovaný touto stránkou během dřívější
        /// relace. Při první návštěvě stránky bude mít stav hodnotu null.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Zachovává stav přiřazení k této stránce pro případ, že je aplikace pozastavena nebo
        /// stránka vyřazena z navigační mezipaměti. Hodnoty musí odpovídat požadavkům
        /// na serializaci <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">Zdroj události, obvykle <see cref="NavigationHelper"/></param>
        /// <param name="e">Data události poskytující prázdný slovník, který má být naplněn
        /// serializovatelným stavem</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region Registrace NavigationHelper

        /// Metody poskytnuté v tomto oddíle se používají jednoduše pro umožnění
        /// třídě NavigationHelper odpovídat na metody navigace stránky.
        /// 
        /// Logika specifická pro stránku by měla být umístěna v obslužných rutinách událostí pro  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// a <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// Navigační parametr je k dispozici v metodě LoadState 
        /// spolu se stavem stránky zachovaným během dřívější relace.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
