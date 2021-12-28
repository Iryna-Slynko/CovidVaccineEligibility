using FunctionalTesting.Support;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumTests.Hooks
{
    [Binding]
    internal sealed class TestExecutionHooks
    {
        [BeforeScenario]
        public void BeforeScenario(PageObject pageObject)
        {
            pageObject.WebAppURL = TestContext.Parameters["webAppUrl"];
            pageObject.GoHome();
        }
    }
}
