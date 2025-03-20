using TechTalk.SpecFlow;

namespace SpecFlowBasics.Hooks
{
    [Binding]
    public sealed class Testinitialize
    {
        [BeforeFeature]
        public static void BeforeFeature() => Console.WriteLine("This line is excuted from before Feature");
        [BeforeTestRun]
        public static void BeforeTest() => Console.WriteLine("This line is excuted from before Test");

        [BeforeScenario("mytag")]
        public void BeforeScenarioWithTag() => Console.WriteLine("This line is excuted from before senario with Tag");

       [AfterScenario]
        public void AfterScenario() => Console.WriteLine("This line is excuted from  after Scenario");
    }
}