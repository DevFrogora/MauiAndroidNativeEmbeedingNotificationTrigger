using PlatformSpecificImplemention;

namespace TestingMauiAndroid;

public partial class MainPage : ContentPage
{

	IPlatformSpecificNavigation PlatformSpecificNavigation { get; set; }
	public MainPage()
	{
		InitializeComponent();
		PlatformSpecificNavigation = new PlatformSpecificNavigation();
	}


    private void Button_Clicked(object sender, EventArgs e)
    {
		PlatformSpecificNavigation.Output("Current Activty : "+Platform.CurrentActivity);
    }

    private void SecondActivty_Clicked(object sender, EventArgs e)
    {
        PlatformSpecificNavigation.GoToSecondActivity();

    }
    private void MainActivty_Clicked(object sender, EventArgs e)
    {
        PlatformSpecificNavigation.GoToMainActivity();

    }

    private void Notification_Clicked(Object sender, EventArgs e)
    {
        PlatformSpecificNavigation.NotificationTrigger();
    }
}

