using Moq;
using NUnit.Framework;

namespace UserTicketService.Tests
{
	[TestFixture]
	public class TicketPriceTests
	{
        [Test]
        public void TicketPriceMustReturnNotNullableTicket()
        {
            // Данной строкой мы создали moq-объект с типом ITicketService
            var mockTicketService = new Mock<ITicketService>();
            // Данные строки выполняют конфигурацию нашего объекта moq. Конкретнее, они устанавливают возвращаемое значение при определенных запросах:
            mockTicketService.Setup(p => p.GetTicketPrice(1)).Returns(100);
            mockTicketService.Setup(p => p.GetTicketPrice(2)).Returns(500);
            mockTicketService.Setup(p => p.GetTicketPrice(3)).Returns(7800);

            var ticketPriceTest = new TicketPrice(mockTicketService.Object);
            Assert.That(ticketPriceTest.MakeTicketPrice(3) == 7800);
        }
    }
}
