namespace TestingMauiAndroid.Pages;
using TestingMauiAndroid;
public partial class AndroidPage : ContentPage
{
	int count;
	public AndroidPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Platform.CurrentActivity.StartActivity(typeof(MainActivity));
        //App.Current.MainPage.DisplayAlert("Title", "Message", "Ok");
		//Toast.MakeText(Platform.CurrentActivity, $"{count++}", ToastLength.Long).Show();
	}
}