using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AttendanceSystem.Models;

namespace AttendanceSystem.Test
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void test()
        {
            var moqItem = new Mock<EmployeeView>();
            moqItem.SetupAllProperties();
            moqItem.SetupGet(p => p.Idpracownika).Returns(1); 
            moqItem.SetupGet(p => p.Imie).Returns("Adam"); 
            moqItem.SetupGet(p => p.Nazwisko).Returns("Trzmiel"); 
            moqItem.SetupGet(p => p.Stanowisko).Returns("IT"); 
            moqItem.SetupGet(p => p.Uprawnienia).Returns("None"); 
            moqItem.SetupGet(p => p.Telefon).Returns(111222333); 
            moqItem.SetupGet(p => p.Email).Returns("adam@example.com"); 
        }
    }
}
