using Foundation;
using ICMSBulgaria.Models;
using Newtonsoft.Json.Linq;
using Parse;
using System;
using System.Collections.Generic;
using UIKit;

namespace ICMSBulgaria
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public AppDelegate()
        {
            // Initialize the Parse client with your Application ID and .NET Key found on
            // your Parse dashboard
            ParseClient.Initialize(new ParseClient.Configuration
            {
                ApplicationId = "yaZmx5u41I7ItuqrVM2eoAP4aeoySyMgrvr28zDG",
                WindowsKey = "1BVIj9kb8WIPiW2EQKjbCtrkU3UU6EwtWeZtJlrP",
                Server = "https://parseapi.back4app.com"
            });
        }
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            // Xamarin
            UIUserNotificationType notificationTypes = (UIUserNotificationType.Alert |
                                                        UIUserNotificationType.Badge |
                                                        UIUserNotificationType.Sound);
            var settings = UIUserNotificationSettings.GetSettingsForTypes(notificationTypes,
                                                                          new NSSet(new string[] { }));
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            // Handle Push Notifications
            ParsePush.ParsePushNotificationReceived += (object sender, ParsePushNotificationEventArgs args) =>
            {
                // Process Push Notification payload here.                
            };

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        // Xamarin
        public override void DidRegisterUserNotificationSettings(UIApplication application,
            UIUserNotificationSettings notificationSettings)
        {
            application.RegisterForRemoteNotifications();
        }

        public override void RegisteredForRemoteNotifications(UIApplication application,
            NSData deviceToken)
        {
            ParseInstallation installation = ParseInstallation.CurrentInstallation;
            installation.SetDeviceTokenFromData(deviceToken);

            installation.SaveAsync();
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            new UIAlertView("Registration failed", error.LocalizedDescription, null, "OK", null).Show();
        }

        public override void ReceivedRemoteNotification(UIApplication application,
            NSDictionary userInfo)
        {
            // We need this to fire userInfo into ParsePushNotificationReceived.
            ParsePush.HandlePush(userInfo);
        }
    }
}