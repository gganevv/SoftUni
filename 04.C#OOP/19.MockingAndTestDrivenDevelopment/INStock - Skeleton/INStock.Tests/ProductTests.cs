namespace INStock.Tests
{
    using INStock.Contracts;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void SetLabel()
        {
            Mock<IProduct> mockProduct = new Mock<IProduct>();
            mockProduct.SetupGet(x => x.Label).Returns("Lyutenica");
            Assert.That(mockProduct.Object.Label, Is.EqualTo("Lyutenica"));
        }

        [Test]
        public void SetPrice()
        {
            Mock<IProduct> mockProduct = new Mock<IProduct>();
            mockProduct.SetupGet(x => x.Price).Returns(5.5m);
            Assert.That(mockProduct.Object.Price, Is.EqualTo(5.5));
        }

        [Test]
        public void SetQuantity()
        {
            Mock<IProduct> mockProduct = new Mock<IProduct>();
            mockProduct.SetupGet(x => x.Quantity).Returns(3);
            Assert.That(mockProduct.Object.Quantity, Is.EqualTo(3));
        }
    }
}