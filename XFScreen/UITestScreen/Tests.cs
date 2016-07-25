using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestScreen
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            //app = AppInitializer.StartApp(platform);
            //IApp app = ConfigureApp.Android
            //    .ApkFile("../../../XFScreen.Droid/bin/Debug/XFScreen.Droid-Signed.apk").StartApp();
            app = ConfigureApp.Android
                .ApkFile("../../../XFScreen/XFScreen.Droid/bin/Release/XFScreen.Droid-Signed.apk")
                .EnableLocalScreenshots()
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            //app.Repl();
            app.Screenshot("First screen.");
        }
    }
}

