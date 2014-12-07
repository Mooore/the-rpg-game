using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;

namespace RPG_game_GUI.Character
{
    /// <summary>
    /// Interaction logic for Talents.xaml
    /// </summary>
    public partial class Talents : UserControl
    {
        List<FrameworkElement> talentList = new List<FrameworkElement>();

        UIElement DraggedThumb;
        bool dragging = false;
        DropShadowEffect myGlowMain = new DropShadowEffect();
        DropShadowEffect myGlowMinor = new DropShadowEffect();

        public Talents()
        {
            InitializeComponent();

            InitGlow();
        }

        private void InitGlow()
        {
            myGlowMain.Color = Colors.Blue;
            myGlowMain.ShadowDepth = 0;
            myGlowMain.Opacity = 100;
            myGlowMain.BlurRadius = 30;

            myGlowMinor.Color = Colors.White;
            myGlowMinor.ShadowDepth = 0;
            myGlowMinor.Opacity = 100;
            myGlowMinor.BlurRadius = 30;
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            /*
             * Skrytí talentů
             */
            if (e.Key == Key.T || e.Key == Key.Tab)
            {
                (this.Parent as Viewbox).Visibility = Visibility.Hidden;
            }
        }

         /*
         * Zajišťuje, že je okno přetahovatelné a dá se volně umístit, kde uživatel chce.
         */
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Canvas.SetLeft(DraggedThumb, Canvas.GetLeft(DraggedThumb) + e.HorizontalChange);
            Canvas.SetTop(DraggedThumb, Canvas.GetTop(DraggedThumb) + e.VerticalChange);
        }

        private void stolek_Loaded(object sender, RoutedEventArgs e)
        {
            double left = (cnvtalents.ActualWidth - stolek.ActualWidth) / 2;
            Canvas.SetLeft(stolek, left);
        }

        private void TalentZone_Loaded(object sender, RoutedEventArgs e)
        {
            double left = (cnvtalents.ActualWidth - TalentZone.ActualWidth) / 2;
            Canvas.SetLeft(TalentZone, left);
        }


        private void Thumb_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            dragging = true;
            DraggedThumb = e.Source as UIElement;

            var element = DraggedThumb as FrameworkElement;

            if (DraggedThumb.Effect != null)
            {
                DraggedThumb.Effect = null;
                deleteTalent(element);
                ParentCheck(element);
            }
           
            Panel.SetZIndex(TalentZone, 10);
        }

        private void Thumb_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            dragging = false;
            DraggedThumb = null;
            Panel.SetZIndex(TalentZone, 0);
        }

        /// <summary>
        /// Odstraní talent ze seznamu používaných podle jm0na
        /// </summary>
        /// <param name="element">Talent, který má být odstraněn</param>
        private void deleteTalent(FrameworkElement element)
        {
            for (int i = 0; i < talentList.Count(); i++)
            {
                if (talentList[i].Name == element.Name)
                    talentList.RemoveAt(i);
            }
        }

        /// <summary>
        /// Kontrola možnosti použití minor talentu
        /// </summary>
        /// <param name="element">Minor talent, jehož využitelnost se bude kontrolovat</param>
        /// <returns>Index rodičovského talentu v seznamu použitých talentů</returns>
        private int minorCheck(FrameworkElement element)
        {
            for(int i = 0; i < talentList.Count(); i++)
            {
                if (talentList[i].Name == "xLekar" && (
                    element.Name == "Osetrovatel"))
                    return i;

                if (talentList[i].Name == "xChemik" && (
                    element.Name == "DNA"))
                    return i;

                if (talentList[i].Name == "xPistolnik" && (
                    element.Name == "Duelista"))
                    return i;

                if (talentList[i].Name == "xStrelec" && (
                    element.Name == "Dostrel"))
                    return i;

                if (talentList[i].Name == "xZamek" && (
                    element.Name == "Dvere" ||
                    element.Name == "Truhla" ||
                    element.Name == "Kosteny"))
                    return i;
                 
                if (talentList[i].Name == "xEnergeticke" && (
                    element.Name == "Sila" ||
                    element.Name == "Energie"))
                    return i;
                
            }
            return -1;
        }

        /// <summary>
        /// Kontroluje vzdálenost mezi talenty 
        /// </summary>
        /// <param name="parent">První prvek</param>
        /// <param name="child">Druhý prvek</param>
        /// <returns>Vrací true, při správné vzdlenosti</returns>
        private bool checkDistance(UIElement parent, UIElement child)
        {
            if (Math.Abs(Canvas.GetLeft(parent) - Canvas.GetLeft(child)) < 75 && Math.Abs(Canvas.GetTop(parent) - Canvas.GetTop(child)) < 75)
                return true;
            return false;
        }

        /// <summary>
        /// Zkontroluje, zda jsou všechny děti daného talentu odstraněny/rozsvíceny, pokud je hlavní talent oddělán/přidán.
        /// </summary>
        /// <param name="element">Hlavní talent</param>
        private void ParentCheck(FrameworkElement element)
        {
            UIElement child;
            UIElement parent = element as UIElement;
            Random random = new Random();

            if (element.Name.Substring(0, 1) == "x")
                for (int i = 0; i < talentList.Count(); i++)
                {
                    if (element.Name == "xLekar" &&
                        talentList[i].Name == "Osetrovatel")
                    {
                        child = talentList[i] as UIElement;
                        
                        // Ověření, zda je minor talent dost blízko svého rodiče
                        if (checkDistance(parent, child).ToString() == "True")
                        {
                            talentList.RemoveAt(i);
                            child.Effect = null;

                            Canvas.SetTop(child, ucTalents.ActualHeight - random.Next(60, 180));
                        }
                    }

                    if (element.Name == "xChemik" &&
                        talentList[i].Name == "DNA")
                    {
                        child = talentList[i] as UIElement;

                        // Ověření, zda je minor talent dost blízko svého rodiče
                        if (checkDistance(parent, child).ToString() == "True")
                        {
                            talentList.RemoveAt(i);
                            child.Effect = null;

                            Canvas.SetTop(child, ucTalents.ActualHeight - random.Next(60, 180));
                        }
                    }

                    if (element.Name == "xPistolnik" && (
                        talentList[i].Name == "Duelista"))
                    {
                        child = talentList[i] as UIElement;

                        // Ověření, zda je minor talent dost blízko svého rodiče
                        if (checkDistance(parent, child).ToString() == "True")
                        {
                            talentList.RemoveAt(i);
                            child.Effect = null;

                            Canvas.SetTop(child, ucTalents.ActualHeight - random.Next(60, 180));
                        }
                    }

                    if (element.Name == "xStrelec" && (
                        talentList[i].Name == "Dostrel"))
                    {
                        child = talentList[i] as UIElement;

                        // Ověření, zda je minor talent dost blízko svého rodiče
                        if (checkDistance(parent, child).ToString() == "True")
                        {
                            talentList.RemoveAt(i);
                            child.Effect = null;

                            Canvas.SetTop(child, ucTalents.ActualHeight - random.Next(60, 180));
                        }
                    }

                    if (element.Name == "xZamek" && (
                        talentList[i].Name == "Dvere" ||
                        talentList[i].Name == "Truhla" ||
                        talentList[i].Name == "Kosteny"))
                    {
                        child = talentList[i] as UIElement;

                        // Ověření, zda je minor talent dost blízko svého rodiče
                        if (checkDistance(parent, child).ToString() == "True")
                        {
                            talentList.RemoveAt(i);
                            child.Effect = null;

                            Canvas.SetTop(child, ucTalents.ActualHeight - random.Next(60, 180));
                        }
                    }

                    if (element.Name == "xEnergeticke" && (
                        talentList[i].Name == "Sila" ||
                        talentList[i].Name == "Energie"))
                    {
                        child = talentList[i] as UIElement;

                        // Ověření, zda je minor talent dost blízko svého rodiče
                        if (checkDistance(parent, child).ToString() == "True")
                        {
                            talentList.RemoveAt(i);
                            child.Effect = null;

                            Canvas.SetTop(child, ucTalents.ActualHeight - random.Next(60, 180));
                        }
                    }
                }
        }

        private void TalentZone_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            int position = -1;

            if (dragging.ToString() == "True")
            {

                var element = DraggedThumb as FrameworkElement;
                
                // Rodičovský talent má první písmeno x.
                if (element.Name.Substring(0, 1) == "x")
                {
                    DraggedThumb.Effect = myGlowMain;
                    talentList.Add(element);
                }
                else // minor talent
                {
                    position = minorCheck(element);

                    if (position != -1)
                    {
                        UIElement parent = talentList[position] as UIElement;

                        // Ověření, zda je minor talent dost blízko svého rodiče
                        if (checkDistance(parent, DraggedThumb).ToString() == "True")
                        {
                            DraggedThumb.Effect = myGlowMinor;
                            talentList.Add(element);
                        }
                    }
                }
            }
        }

        private void Thumb_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            UIElement element = e.Source as UIElement;
            Canvas.SetTop(element, ucTalents.ActualHeight - random.Next(60, 180));
        }

    }
}
