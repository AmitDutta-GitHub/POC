using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using UnitySampleBL.Implements;

namespace UnityConsoleSample
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        private static readonly IUnityContainer unityContainer = GetUnityContainerViaConfig();

        static void Main(string[] args)
        {
            Logger.Debug("Start");
            InitializeProgram initializeProgram = unityContainer.Resolve<InitializeProgram>();
            initializeProgram.WhoCalledMe();
        }

        private static IUnityContainer GetUnityContainerViaConfig()
        {
            IUnityContainer container = new UnityContainer();

            try
            {
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

                if (section != null && section.Containers.Count > 0)
                {
                    try
                    {
                        section.Configure(container);
                    }
                    catch (Exception ex)
                    {
                        Logger.Fatal("Exception configuring Unity: ", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Fatal("Loading Unity configuration threw exception: ", ex);
                throw;
            }

            return container;
        }
    }
}
