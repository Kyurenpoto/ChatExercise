using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Threading;

namespace ChatExercise.Test
{
    [TestClass]
    public class RunApp
    {
        [TestMethod, TestCategory("RunApp")]
        public void GUI_Should_Visible_When_App_Run()
        {
            var appDomain = AppDomain.CreateDomain("GUI_Should_Visible_" +
                                                   "When_App_Run",
                            AppDomain.CurrentDomain.Evidence,
                            AppDomain.CurrentDomain.SetupInformation);

            appDomain.SetData("GuiVisible", false);

            appDomain.DoCallBack(() => {
                var app = new App();

                app.InitializeComponent();
                app.Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
                    new Action(() => {
                        AppDomain.CurrentDomain.SetData("GuiVisible", true);
                        app.Shutdown();
                    }));
                app.Run();
            });

            Assert.AreEqual(true, (bool)appDomain.GetData("GuiVisible"));

            AppDomain.Unload(appDomain);
        }
    }
}
