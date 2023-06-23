using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using TestingMauiAndroid.Pages;

namespace TestingMauiAndroid.Platforms.Android;

[Activity(Theme = "@style/Maui.SplashTheme" )]
public class SecondActivity : AppCompatActivity
{
    public MauiContext _mauiContext;
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Toast toast = Toast.MakeText(Platform.CurrentActivity, "Current Activty : " + Platform.CurrentActivity, ToastLength.Long);
        toast.Show();
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
        MauiApp mauiApp = builder.Build();
        _mauiContext = new MauiContext(mauiApp.Services, this);
        AndroidPage myMauiPage = new AndroidPage();
        SetContentView( myMauiPage.ToPlatform(_mauiContext));
        //var icon = Resource.Mipmap.ic_launcher;

    }
}