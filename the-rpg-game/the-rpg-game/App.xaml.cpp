//
// App.xaml.cpp
// Implementace třídy App.
//

#include "pch.h"
#include "MainPage.xaml.h"

using namespace the_rpg_game;

using namespace Platform;
using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Interop;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

// Šablona "Blank Application" je popsána na adrese http://go.microsoft.com/fwlink/?LinkId=234227

/// <summary>
/// Inicializuje objekt aplikace typu singleton. Jedná se o první řádek spuštěného vytvořeného kódu,
/// který je proto logickým ekvivalentem metod main() a WinMain().
/// </summary>
App::App()
{
	InitializeComponent();
	Suspending += ref new SuspendingEventHandler(this, &App::OnSuspending);
}

/// <summary>
/// Vyvoláno při normálním spuštění aplikace koncovým uživatelem.  Ostatní vstupní body
/// budou použity například při spuštění aplikace za účelem otevřít konkrétní soubor.
/// </summary>
/// <param name="e">Podrobnosti o požadavku spuštění a procesu.</param>
void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ e)
{

#if _DEBUG
		// Zobrazovat během ladění informace o profilování grafiky.
		if (IsDebuggerPresent())
		{
			// Zobrazit počítadla aktuální frekvence snímků
			 DebugSettings->EnableFrameRateCounter = true;
		}
#endif

	auto rootFrame = dynamic_cast<Frame^>(Window::Current->Content);

	// Neopakovat inicializaci aplikace, pokud má objekt Window již obsah,
	// pouze zkontrolovat, zda je okno aktivní
	if (rootFrame == nullptr)
	{
		// Vytvořit Rámec sloužící jako navigační kontext a přiřadit jej ke
		// klíči SuspensionManager
		rootFrame = ref new Frame();

		// Nastavte výchozí jazyk.
		rootFrame->Language = Windows::Globalization::ApplicationLanguages::Languages->GetAt(0);

		rootFrame->NavigationFailed += ref new Windows::UI::Xaml::Navigation::NavigationFailedEventHandler(this, &App::OnNavigationFailed);

		if (e->PreviousExecutionState == ApplicationExecutionState::Terminated)
		{
			// TODO: Obnovit uložený stav relace pouze v případě potřeby a naplánovat
			// konečné kroky spuštění po dokončení obnovení

		}

		if (rootFrame->Content == nullptr)
		{
			// Není-li navigační zásobník obnoven, navigovat na první stránku
			// a nakonfigurovat novou stránku předáním požadovaných informací ve formě
			// parametru navigace
			rootFrame->Navigate(TypeName(MainPage::typeid), e->Arguments);
		}
		// Umístit rámec do aktuálního objektu Window
		Window::Current->Content = rootFrame;
		// Zkontrolovat, zda je aktuální okno aktivní
		Window::Current->Activate();
	}
	else
	{
		if (rootFrame->Content == nullptr)
		{
			// Navigovat na první stránku, není-li navigační zásobník obnoven,
			// konfigurující novou stránku předáním požadované informace jako navigační
			// parametr
			rootFrame->Navigate(TypeName(MainPage::typeid), e->Arguments);
		}
		// Zkontrolovat, zda je aktuální okno aktivní
		Window::Current->Activate();
	}
}

/// <summary>
/// Vyvoláno při pozastavení provádění aplikace. Stav aplikace je uložen,
/// aniž by bylo známo, zda bude aplikace ukončena, nebo zda bude obnovena
/// s neporušeným obsahem paměti.
/// </summary>
/// <param name="sender">Zdroj žádosti o pozastavení.</param>
/// <param name="e">Podrobnosti žádosti o pozastavení.</param>
void App::OnSuspending(Object^ sender, SuspendingEventArgs^ e)
{
	(void) sender;	// Nepoužitý parametr
	(void) e;	// Nepoužitý parametr

	//TODO: Uložit stav aplikace a ukončit jakékoli aktivity na pozadí
}

/// <summary>
/// Vyvoláno, když se nezdaří přechod na určitou stránku
/// </summary>
/// <param name="sender">Rámec, pro který se nezdařila navigace</param>
/// <param name="e">Podrobnosti o chybě navigace</param>
void App::OnNavigationFailed(Platform::Object ^sender, Windows::UI::Xaml::Navigation::NavigationFailedEventArgs ^e)
{
	throw ref new FailureException("Failed to load Page " + e->SourcePageType.Name);
}