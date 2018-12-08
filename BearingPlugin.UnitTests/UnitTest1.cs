using System;
using BearingPlugin.UI;
using NUnit.Framework;

namespace BearingPlugin.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        private BearingParametrs _parameters;

        [SetUp]
        public void Test()
        {
            _parameters = new BearingParametrs(4.5, 2.7, 1.3, 3, true);
        }

        [Test(Description = "Позитивный тест коструктора класса ")]

        public void TestBearingParametrs_CorrectValue()
        {
            var expectedParameters = new BearingParametrs(4.5, 2.7, 1.3, 3, true);
            var actual = _parameters;

            Assert.AreEqual
                (expectedParameters.ExternalDiametrOutRim, actual.ExternalDiametrOutRim,
                "Некорректное значение ExternalDiametrOutRim");
            Assert.AreEqual
                (expectedParameters.ExternalDiametrInRim, actual.ExternalDiametrInRim,
                "Некорректное значение ExternalDiametrInRim");
            Assert.AreEqual
                (expectedParameters.InternalDiametrInRim, actual.InternalDiametrInRim,
                "Некорректное значение InternalDiametrInRim");
            Assert.AreEqual
                (expectedParameters.SupportShuft, actual.SupportShuft,
                "Некорректное значение ExternalDiametrOutRim");
            Assert.AreEqual
                (expectedParameters.WidthBearing, actual.WidthBearing,
                "Некорректное значение ExternalDiametrOutRim");
        }

        [TestCase(double.NaN, 2.1, 3.2, 2.2, "externalDiametrOutRim",
            TestName = "Негативный тест на Nan поля externalDiametrOutRim")]
        [TestCase(4.2, double.NaN, 3.2, 2.2, "externalDiametrInRim",
            TestName = "Негативный тест на Nan поля externalDiametrInRim")]
        [TestCase(4.2, 2.1, double.NaN, 2.2, "internalDiametrInRim",
            TestName = "Негативный тест на Nan поля internalDiametrInRim")]
        [TestCase(4.2, 2.1, 3.2, double.NaN, "widthBearing",
            TestName = "Негативный тест на Nan поля widthBearing")]

        public void TestBearingParamets_NanValue
            (double externalDiametrOutRim, double externalDiametrInRim, double internalDiametrInRim,
            double widthBearing, string attr)
        {
            Assert.Throws<ArgumentException>(
                () => {
                    var parameters = new BearingParametrs
                (externalDiametrOutRim, externalDiametrInRim, internalDiametrInRim, widthBearing, true);
                },
                "Возникнет исключение если в поле " + attr + " значение double.Nan");
        }

        [TestCase(5.1, 2.3, 1.1, 3, true, "externalDiametrOutRim",
            TestName = "Негативный тест поля externalDiametrOutRim если > 5")]
        [TestCase(4, 2.3, 1.1, 3, true, "externalDiametrOutRim",
            TestName = "Негативный тест поля externalDiametrOutRim если < externalDiametrInRim + 1.8")]
        [TestCase(4.5, 2.2, 1.1, 1.2, true, "externalDiametrInRim",
            TestName = "Негативный тест поля externalDiametrInRim если < internalDiametrInRim + 0.2")]
        [TestCase(4.5, 2.3, 1.2, 3, true, "internalDiametrInRim",
            TestName = "Негативный тест поля internalDiametrInRim если > externalDiametrInRim / 2")]
        [TestCase(4.5, 2.3, 0.9, 2, true, "internalDiametrInRim",
            TestName = "Негативный тест поля internalDiametrInRim если =< 1")]
        [TestCase(4.5, 2.3, 1.1, 0.9, true, "widthBearing",
            TestName = "Негативный тест поля widthBearing если =< 1")]
        [TestCase(4.5, 2.3, 1.1, 7, true, "widthBearing",
            TestName = "Негативный тест поля widthBearing если > 6")]
      

        public void TestBearingParametrs_ArgumentValue
        (double externalDiametrOutRim, double externalDiametrInRim, double internalDiametrInRim,
            double widthBearing, bool supportShuft, string attr)
        {
            Assert.Throws<ArgumentException>(
                () => {
                    var parameters = new BearingParametrs
                        (externalDiametrOutRim, externalDiametrInRim, internalDiametrInRim, widthBearing, true);
                },
                "Должно возникнуть исключение если значение поля "
                + attr + "выходит за диапозон доп-х значений");
        }
    }
}

