//
// App.xaml.h
// Deklarace třídy App.
//

#pragma once

#include "App.g.h"

namespace the_rpg_game
{
	/// <summary>
	/// Poskytuje chování specifické pro aplikaci, doplňující výchozí třídu Application.
	/// </summary>
	ref class App sealed
	{
	protected:
		virtual void OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ e) override;

	internal:
		App();

	private:
		void OnSuspending(Platform::Object^ sender, Windows::ApplicationModel::SuspendingEventArgs^ e);
		void OnNavigationFailed(Platform::Object ^sender, Windows::UI::Xaml::Navigation::NavigationFailedEventArgs ^e);
	};
}
