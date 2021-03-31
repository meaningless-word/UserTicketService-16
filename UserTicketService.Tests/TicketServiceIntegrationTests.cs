using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UserTicketService.Tests
{
	/* Практика рекомендует для интеграционных тестов создавать отдельный класс, собственно, что мы и сделаем. 
	 * В проекте модульного теста UserTicketService.Tests создадим новый класс, который назовем TicketServiceIntegrationTests.
	 * Далее мы создадим интеграционный тест для функции SaveTicket службы TicketService.
	 * Логика интеграционного теста для функции SaveTicket будет следующей:
	 * 1. Сохраняем новый билет в коллекцию.
	 * 2. Проверяем наличие нового добавленного билета в коллекции.
	 * 3. Удаляем добавленный билет из коллекции.
	 * 4. Проверяем, что удаленный билет больше не находится в коллекции.
	 */
	[TestFixture]
	class TicketServiceIntegrationTests
	{
		[Test]
		public void SaveTicketMustAddTicketInBase()
		{
			var ticketServiceTest = new TicketService();
			var newTicket = new Ticket(300, "Test ticket", 1000);

			ticketServiceTest.SaveTicket(newTicket);

			var allTicketsAfterAddingNewTicket = ticketServiceTest.GetAllTickets();
			NUnit.Framework.CollectionAssert.Contains(allTicketsAfterAddingNewTicket, newTicket);

			// для тестирования методом Private Object метод DeleteTicket стал приватным и больше не виден здесь
			//ticketServiceTest.DeleteTicket(newTicket);
			// вместо него из фреймворка MSTest создаётся класс типа PrivateObject на основе ticketServiceTest
			PrivateObject obj = new PrivateObject(ticketServiceTest);
			obj.Invoke("DeleteTicket", newTicket);

			var allTicketsAfterDeletingNewTicket = ticketServiceTest.GetAllTickets();
			NUnit.Framework.CollectionAssert.DoesNotContain(allTicketsAfterDeletingNewTicket, newTicket);
		}
	}
}
