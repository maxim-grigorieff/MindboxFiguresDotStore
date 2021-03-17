using FiguresDotStore.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresDotStoreTests
{
    [TestClass]
    public class FiguresTest
    {
        [TestMethod]
        public void Circle_ValidatePositiveRadius()
        {
            var circle = new Circle(2);
            Assert.IsTrue(circle.Validate());
        }

        [TestMethod]
        public void Circle_ValidateNegativeRadius()
        {
            var circle = new Circle(-1);
            Assert.IsFalse(circle.Validate());
        }

    }
}
