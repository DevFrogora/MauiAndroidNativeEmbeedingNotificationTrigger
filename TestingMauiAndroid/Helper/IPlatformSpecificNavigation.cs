

namespace PlatformSpecificImplemention
{
     public interface IPlatformSpecificNavigation
    {
        void GoToSecondActivity();
        void GoToMainActivity();
        void Output(string message);
        void NotificationTrigger();
    }
}
