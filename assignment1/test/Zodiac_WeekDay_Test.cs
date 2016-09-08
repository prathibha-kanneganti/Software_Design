using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Mocks;
using ZodiacSign;

namespace ZodiacSign_Test
{
    [TestFixture]
    public class Zodiac_WeekDay_Test
    {
        Program pObj;
        [TestFixtureSetUp]
        public void Init()
        {
            pObj = new Program();
        }
        [TestFixtureTearDown]
        public void Dispose()
        {
            pObj = null;
        }
        [Test]
        public void TestValidDate()
        {
            Assert.AreEqual("Tuesday", pObj.ConverttoDate(10, 2, 1993));
        }
        [Test]
        public void TestValidZodiacSign()
        {
            Assert.AreEqual("Tuesday", pObj.GetZodiacSign(10, 2));
        }
    }
}