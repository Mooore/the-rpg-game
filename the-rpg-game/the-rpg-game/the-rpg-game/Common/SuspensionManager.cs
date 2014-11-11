using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace the_rpg_game.Common
{
    /// <summary>
    /// Objekt SuspensionManager zaznamenává globální stav relace a zjednodušuje tak proces správy životního cyklu
    /// aplikace. Stav relace bude automaticky smazán v celé řadě
    /// situací a měl by být použit pouze pro ukládání informací, které je vhodné
    /// přenášet napříč relacemi, ale měly by být zrušeny, když v aplikaci dojde k chybě nebo je
    /// upgradována.
    /// </summary>
    internal sealed class SuspensionManager
    {
        private static Dictionary<string, object> _sessionState = new Dictionary<string, object>();
        private static List<Type> _knownTypes = new List<Type>();
        private const string sessionStateFilename = "_sessionState.xml";

        /// <summary>
        /// Poskytuje přístup ke globálnímu stavu relace pro aktuální relaci. Tento stav je
        /// serializován pomocí metody <see cref="SaveAsync"/> a obnoven pomocí metody
        /// <see cref="RestoreAsync"/>. Hodnoty proto musí být možné serializovat pomocí
        /// objektu <see cref="DataContractSerializer"/> a měly by být co nejkompaktnější. Důrazně se doporučuje používat
        /// řetězce nebo jiné nezávislé datové typy.
        /// </summary>
        public static Dictionary<string, object> SessionState
        {
            get { return _sessionState; }
        }

        /// <summary>
        /// Seznam vlastních typů předaných objektu <see cref="DataContractSerializer"/> při
        /// čtení nebo zápisu stavu relace. Na počátku je prázdný. Přidáním dalších typů
        /// je možné přizpůsobit proces serializace.
        /// </summary>
        public static List<Type> KnownTypes
        {
            get { return _knownTypes; }
        }

        /// <summary>
        /// Uloží aktuální objekt <see cref="SessionState"/>. Všechny instance <see cref="Frame"/>
        /// zaregistrované pomocí metody <see cref="RegisterFrame"/> si také uchovají svůj aktuální
        /// navigační zásobník. Díky tomu budou mít jejich aktivní objekty <see cref="Page"/> příležitost
        /// uložit svůj stav.
        /// </summary>
        /// <returns>Asynchronní úloha, která zohledňuje, kdy byl stav relace uložen</returns>
        public static async Task SaveAsync()
        {
            try
            {
                // Uloží navigační stav pro všechny zaregistrované rámce
                foreach (var weakFrameReference in _registeredFrames)
                {
                    Frame frame;
                    if (weakFrameReference.TryGetTarget(out frame))
                    {
                        SaveFrameNavigationState(frame);
                    }
                }

                // Synchronní serializace stavu relace, která umožňuje vyhnout se asynchronnímu přístupu ke sdílenému
                // stavu
                MemoryStream sessionData = new MemoryStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, object>), _knownTypes);
                serializer.WriteObject(sessionData, _sessionState);

                // Získá výstupní datový proud pro soubor SessionState a provede synchronní zápis stavu
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(sessionStateFilename, CreationCollisionOption.ReplaceExisting);
                using (Stream fileStream = await file.OpenStreamForWriteAsync())
                {
                    sessionData.Seek(0, SeekOrigin.Begin);
                    await sessionData.CopyToAsync(fileStream);
                }
            }
            catch (Exception e)
            {
                throw new SuspensionManagerException(e);
            }
        }

        /// <summary>
        /// Obnoví dříve uložený objekt <see cref="SessionState"/>. Všechny instance <see cref="Frame"/>
        /// zaregistrované pomocí metody <see cref="RegisterFrame"/> si také uchovají svůj předchozí navigační
        /// stav. Díky tomu budou mít jejich aktivní objekty <see cref="Page"/> příležitost k obnovení svého
        /// aplikace.
        /// </summary>
        /// <returns>Asynchronní úloha, která zohledňuje, kdy byl stav relace načten. Na obsah
        /// objektu <see cref="SessionState"/> byste se neměli spoléhat, dokud tato úloha
        /// neskončí.</returns>
        public static async Task RestoreAsync()
        {
            _sessionState = new Dictionary<String, Object>();

            try
            {
                // Získá vstupní datový proud pro soubor SessionState
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(sessionStateFilename);
                using (IInputStream inStream = await file.OpenSequentialReadAsync())
                {
                    // Deserializuje stav relace
                    DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, object>), _knownTypes);
                    _sessionState = (Dictionary<string, object>)serializer.ReadObject(inStream.AsStreamForRead());
                }

                // Obnoví uložený stav všech případných zaregistrovaných objektů Frame
                foreach (var weakFrameReference in _registeredFrames)
                {
                    Frame frame;
                    if (weakFrameReference.TryGetTarget(out frame))
                    {
                        frame.ClearValue(FrameSessionStateProperty);
                        RestoreFrameNavigationState(frame);
                    }
                }
            }
            catch (Exception e)
            {
                throw new SuspensionManagerException(e);
            }
        }

        private static DependencyProperty FrameSessionStateKeyProperty =
            DependencyProperty.RegisterAttached("_FrameSessionStateKey", typeof(String), typeof(SuspensionManager), null);
        private static DependencyProperty FrameSessionStateProperty =
            DependencyProperty.RegisterAttached("_FrameSessionState", typeof(Dictionary<String, Object>), typeof(SuspensionManager), null);
        private static List<WeakReference<Frame>> _registeredFrames = new List<WeakReference<Frame>>();

        /// <summary>
        /// Zaregistrujte instanci <see cref="Frame"/>, aby bylo možné její navigační historii uložit do
        /// a obnovit z objektu <see cref="SessionState"/>. Objekty Frame by měly být zaregistrovány jednou
        /// ihned po vytvoření, pokud budou zapojeny do správy stavu relace. Po
        /// bude okamžitě obnovena navigační historie,
        /// pokud již byl obnoven stav pro určený klíč. Navigační historii obnoví také
        /// následná volání metody <see cref="RestoreAsync"/>.
        /// </summary>
        /// <param name="frame">Instance, jejíž navigační historii by měl spravovat objekt
        /// <see cref="SuspensionManager"/></param>
        /// <param name="sessionStateKey">Jedinečný klíč v objektu <see cref="SessionState"/>, pomocí něhož
        /// lze obnovit informace související s navigací.</param>
        public static void RegisterFrame(Frame frame, String sessionStateKey)
        {
            if (frame.GetValue(FrameSessionStateKeyProperty) != null)
            {
                throw new InvalidOperationException("Frames can only be registered to one session state key");
            }

            if (frame.GetValue(FrameSessionStateProperty) != null)
            {
                throw new InvalidOperationException("Frames must be either be registered before accessing frame session state, or not registered at all");
            }

            // Klíč relace přidružte k objektu Frame pomocí vlastnosti závislosti a udržujte seznam objektů Frame, jejichž
            // navigační stav má být spravován
            frame.SetValue(FrameSessionStateKeyProperty, sessionStateKey);
            _registeredFrames.Add(new WeakReference<Frame>(frame));

            // Zkontroluje, zda je možné obnovit navigační stav
            RestoreFrameNavigationState(frame);
        }

        /// <summary>
        /// Zruší přidružení objektu <see cref="Frame"/>, který byl zaregistrován pomocí metody <see cref="RegisterFrame"/>,>
        /// k objektu <see cref="SessionState"/>. Jakýkoli dříve zaznamenaný navigační stav bude
        /// odebrán.
        /// </summary>
        /// <param name="frame">Instance, jejíž navigační historie už nemá být
        /// spravována.</param>
        public static void UnregisterFrame(Frame frame)
        {
            // Odebere stav relace a odebere objekt Frame ze seznamu objektů Frame, jejichž navigační
            // stav bude ukládán (spolu se všemi slabými odkazy, které už nejsou dostupné)
            SessionState.Remove((String)frame.GetValue(FrameSessionStateKeyProperty));
            _registeredFrames.RemoveAll((weakFrameReference) =>
            {
                Frame testFrame;
                return !weakFrameReference.TryGetTarget(out testFrame) || testFrame == frame;
            });
        }

        /// <summary>
        /// Poskytuje úložiště pro stav relace přidružený k určenému objektu <see cref="Frame"/>.
        /// Pro objekty Frame, které byly zaregistrovány pomocí metody <see cref="RegisterFrame"/>, je
        /// jejich stav relace ukládán a obnovován automaticky v rámci globálního objektu
        /// <see cref="SessionState"/>. Nezaregistrované rámce jsou v přechodném stavu,
        /// který přesto může být užitečný při obnovování stránek odstraněných
        /// z navigační mezipaměti.
        /// </summary>
        /// <remarks>Aplikace se mohou spolehnout na třídu <see cref="NavigationHelper"/> pro správu
        /// a mohou se namísto toho spolehnout na objekt </remarks>
        /// <param name="frame">Instance, jejíž stav relace je požadován</param>
        /// <returns>Kolekce stavů využívající stejný mechanismus serializace jako objekt
        /// <see cref="SessionState"/></returns>
        public static Dictionary<String, Object> SessionStateForFrame(Frame frame)
        {
            var frameState = (Dictionary<String, Object>)frame.GetValue(FrameSessionStateProperty);

            if (frameState == null)
            {
                var frameSessionKey = (String)frame.GetValue(FrameSessionStateKeyProperty);
                if (frameSessionKey != null)
                {
                    // Zaregistrované rámce zohledňují příslušný stav relace
                    if (!_sessionState.ContainsKey(frameSessionKey))
                    {
                        _sessionState[frameSessionKey] = new Dictionary<String, Object>();
                    }
                    frameState = (Dictionary<String, Object>)_sessionState[frameSessionKey];
                }
                else
                {
                    // Nezaregistrované rámce jsou v přechodném stavu
                    frameState = new Dictionary<String, Object>();
                }
                frame.SetValue(FrameSessionStateProperty, frameState);
            }
            return frameState;
        }

        private static void RestoreFrameNavigationState(Frame frame)
        {
            var frameState = SessionStateForFrame(frame);
            if (frameState.ContainsKey("Navigation"))
            {
                frame.SetNavigationState((String)frameState["Navigation"]);
            }
        }

        private static void SaveFrameNavigationState(Frame frame)
        {
            var frameState = SessionStateForFrame(frame);
            frameState["Navigation"] = frame.GetNavigationState();
        }
    }
    public class SuspensionManagerException : Exception
    {
        public SuspensionManagerException()
        {
        }

        public SuspensionManagerException(Exception e)
            : base("SuspensionManager failed", e)
        {

        }
    }
}
