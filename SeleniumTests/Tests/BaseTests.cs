using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Autofac;
using Autofac.Core.Lifetime;
using System.Threading;

using SeleniumTests.Pages;
using SeleniumTests.Helpers;
using SeleniumTests.Driver;

namespace SeleniumTests.Tests
{
    public abstract class BaseTests
    {
        protected IContainer Container;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            var builder = new ContainerBuilder();

            
            builder.RegisterType<GoogleFindPage>().AsSelf();
            builder.RegisterType<GoogleSearchResultPage>().AsSelf();
            
            builder.RegisterType<ClientDriver>().AsSelf().SingleInstance();
            builder.RegisterType<TestData>().AsSelf().SingleInstance();

            Container = builder.Build();
        }

        [OneTimeTearDown]
        public void OneTimeTearDownBase() {
            Container.Dispose();
        }

        [TearDown]
        public void TearDownBase() {
            var Driver = Container.Resolve<ClientDriver>();
            Driver?.Dispose();
        }

        public T GetObject<T>(){
            return Container.Resolve<T>();
        }
    }
}