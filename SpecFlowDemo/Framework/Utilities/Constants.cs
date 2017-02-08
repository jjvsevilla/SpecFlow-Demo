using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utilities
{
    public static class Constants
    {
        public static string ChromeDriver = @"chromedriver.exe"; 
        public static string TestPath = "\\Test\\";
        public static string FrameworkPath = "\\Framework\\";
        public static int LoadPageTimeOut = 10;
        public static int AjaxSearchCruiseTimeOut = 5;

        public static string SearchCruisePageTitle = @"Cruises | Carnival Cruise Deals: Caribbean, The Bahamas, Alaska, and Mexico";
        public enum FindBy
        {
            ClassName = 1,
            CssSelector = 2,
            Id = 3,
            LinkText = 4,
            Name = 5,
            PartialLinkText = 6,
            TagName = 7,
            XPath = 8,
        }

        public enum SailTo
        {
            ALASKA = 1, //*[@id="sailTo"]/ul/li[1]/button
            THE_BAHAMAS = 2, //*[@id="sailTo"]/ul/li[2]/button
            BERMUDA = 3,//*[@id="sailTo"]/ul/li[3]/button
            CANADA_AND_NEW_ENGLAND = 4,//*[@id="sailTo"]/ul/li[4]/button
            CARIBBEAN = 5,//*[@id="sailTo"]/ul/li[5]/button
            EUROPE = 6,//*[@id="sailTo"]/ul/li[6]/button
            HAWAII = 7,//*[@id="sailTo"]/ul/li[7]/button
            MEXICO = 8,//*[@id="sailTo"]/ul/li[8]/button
            PANAMA_CANAL = 9,//*[@id="sailTo"]/ul/li[9]/button
            TRANSATLANTIC = 10,//*[@id="sailTo"]/ul/li[10]/button
        }

        public enum SailFrom
        {
            BALTIMORE = 1, //*[@id="sailFrom"]/div[1]/ul/li[1]/button
            CHARLESTON = 2, //*[@id="sailFrom"]/div[1]/ul/li[2]/button
            FORT_LAUDERDALE = 3, //*[@id="sailFrom"]/div[1]/ul/li[3]/button
            GALVESTON = 4, //*[@id="sailFrom"]/div[1]/ul/li[4]/button
            JACKSONVILLE = 5, //*[@id="sailFrom"]/div[1]/ul/li[5]/button
            LONG_BEACH = 6, //*[@id="sailFrom"]/div[1]/ul/li[6]/button
            MIAMI = 7, //*[@id="sailFrom"]/div[1]/ul/li[7]/button
            NEW_ORLEANS = 8, //*[@id="sailFrom"]/div[1]/ul/li[8]/button
            PORT_CANAVERAL = 9, //*[@id="sailFrom"]/div[1]/ul/li[9]/button
            TAMPA = 10, //*[@id="sailFrom"]/div[1]/ul/li[10]/button
        }
    }
}
