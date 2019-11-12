using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Tests
{
    [TestClass()]
    public class ReadFileTests
    {
        ReadFile _readFile;
        const String FILE_PATH = "../../Data Info.ini";

        [TestInitialize]
        public void Initialize()
        {
            _readFile = new ReadFile(FILE_PATH);
        }

        [TestMethod()]
        public void ReadTest()
        {
            Assert.AreEqual(_readFile.Read("_motherBoardItem1Page1", "type"), "主機板");
        }

        [TestMethod()]
        public void GetAllSectionsTest()
        {
            Assert.AreEqual(_readFile.GetAllSections().Count, 42);
        }

        [TestMethod()]
        public void GetNameTest()
        {
            Assert.AreEqual(_readFile.GetName("_motherBoardItem1Page1"), "ROG STRIX Z390-E GAMING");
        }

        [TestMethod()]
        public void GetDetailTest()
        {
            Assert.AreEqual(_readFile.GetDetail("_motherBoardItem1Page1"), "Intel Z390 LGA 1151 ATX 電競主機板搭載 Aura Sync、802.11ac Wi-Fi、支援 DDR4 4266 MHz+、雙 M.2 含散熱片、SATA 6Gbps、HDMI 及 USB 3.1 Gen 2");
        }

        [TestMethod()]
        public void GetCategoryTest()
        {
            Assert.AreEqual(_readFile.GetCategory("_motherBoardItem1Page1"), "主機板");
        }

        [TestMethod()]
        public void GetPriceTest()
        {
            Assert.AreEqual(_readFile.GetPrice("_motherBoardItem1Page1"), "6990");
        }

        [TestMethod()]
        public void GetStockTest()
        {
            Assert.AreEqual(_readFile.GetStock("_motherBoardItem1Page1"), "5");
        }

        [TestMethod()]
        public void GetPicturePathTest()
        {
            Assert.AreEqual(_readFile.GetPicturePath("_motherBoardItem1Page1"), "../../Resources/_motherBoardPage1Item1.jpg");
        }
    }
}