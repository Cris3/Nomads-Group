using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumericSequenceCalculatorUITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class EndToEndCodedUITest
    {
        public EndToEndCodedUITest()
        {
        }

        [TestMethod]
        public void EndToEndTest()
        {
            this.UIMap.AddedFirstNumber_Valid();
            this.UIMap.AddedSecondNumber_Invalid();
            this.UIMap.AddedThirdNumber_Valid();
            this.UIMap.AddedFourthNumber_Valid();
            this.UIMap.ClearedLists();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
