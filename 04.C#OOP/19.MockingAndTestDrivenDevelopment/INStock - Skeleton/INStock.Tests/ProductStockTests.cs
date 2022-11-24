namespace INStock.Tests
{
    using INStock.Contracts;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SetCounter()
        {
            Mock<IProductStock> mockProduct = new Mock<IProductStock>();
            mockProduct.SetupGet(x => x.Count).Returns(0);
            Assert.That(mockProduct.Object.Count, Is.EqualTo(0));
        }
    }
}
