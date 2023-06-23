using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.Core.App;
using TestingMauiAndroid;
using TestingMauiAndroid.Platforms.Android;
using Android;

namespace PlatformSpecificImplemention;
public class PlatformSpecificNavigation : IPlatformSpecificNavigation
{
    //Context context = Android.App.Application.Context;
    public PlatformSpecificNavigation()
    {
        CreateNotificationChannel();
    }
    public void GoToMainActivity()
    {
        //Intent intent = new Intent(Platform.CurrentActivity, typeof(MainActivity));
        Platform.CurrentActivity.StartActivity(typeof(MainActivity));
    }

    public void GoToSecondActivity()
    {
        //Intent intent = new Intent(Platform.CurrentActivity, typeof(SecondActivity));
        Platform.CurrentActivity.StartActivity(typeof(SecondActivity));
    }
    string ChannelId ="1";
    string ChannelName = "TodoChannel";
    string ChannelDescription = "it is used to notify todo item";
    void CreateNotificationChannel()
    {
        if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
        {
            NotificationChannel notificationChannel = new NotificationChannel(ChannelId,
                ChannelName,
                Android.App.NotificationImportance.Default);
            notificationChannel.Description = ChannelDescription;
            notificationChannel.SetShowBadge(true);
            NotificationManager notificationManager = (NotificationManager)
                Android.App.Application.Context.GetSystemService(Context.NotificationService);
            notificationManager.CreateNotificationChannel(notificationChannel);
        }
    }
    public async void NotificationTrigger()
    {
        Intent intent = new Intent(Platform.CurrentActivity,typeof(SecondActivity));
        intent.SetFlags(ActivityFlags.NewTask| ActivityFlags.ClearTask);
        //PendingIntent pendingIntent = PendingIntent.GetActivity(Platform.CurrentActivity, 0, intent, 0);
        PendingIntent pendingIntent = null;
        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.S)
        {
            pendingIntent = PendingIntent.GetActivity
                   (Platform.CurrentActivity, 0, intent, PendingIntentFlags.Mutable);
        }
        else
        {
            pendingIntent = PendingIntent.GetActivity(Platform.CurrentActivity, 0, intent, PendingIntentFlags.OneShot);
        }

        NotificationCompat.Builder builder = new NotificationCompat.Builder(Platform.CurrentActivity,
        ChannelId)
            .SetSmallIcon(TestingMauiAndroid.Resource.Drawable.noti_icon)
            .SetContentTitle("My Todo Title")
            .SetContentText("Your Todo is ticked")
            .SetContentIntent(pendingIntent)
            .SetChannelId(ChannelId)
            .SetAutoCancel(true);
        NotificationManagerCompat notificationManagerCompat = NotificationManagerCompat.From(Platform.CurrentActivity.ApplicationContext);
        notificationManagerCompat.Notify(1, builder.Build());
    }

    public void Output(string message)
    {
        Toast toast = Toast.MakeText(Platform.CurrentActivity , message, ToastLength.Long);
        toast.Show();
    }
}

