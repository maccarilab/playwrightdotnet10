using Microsoft.Playwright;

namespace TestProject1
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [Test]
        public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

            // create a locator
            var getStarted = Page.Locator("text=Get Started");

            // Expect an attribute "to be strictly equal" to the value.
            await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

            // Click the get started link.
            await getStarted.ClickAsync();

            // Expects the URL to contain intro.
            await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        }
        [Test]
        public async Task SitoConScreenshot()
        {

            await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://www.pendolariumbri.it/");
   //         await page.GotoAsync("https://maccarilab.github.io/");           
            
            await page.WaitForTimeoutAsync(3000);

        //    var mypath0 = TestContext.CurrentContext.WorkDirectory;
          //  var newdir = Directory.CreateDirectory("Screenshot1");
           // mypath = mypath.ToString() + newdir.ToString();
          //  var mypathdemoNew = Path.Combine(mypath, "demo.png");


            await page.ScreenshotAsync(new()
            {
                Path = "./../../../Screenshot/HomeScreenshot1.jpg",
               // Path = "demo.png",
                FullPage = true
            });

        }
    }
}
