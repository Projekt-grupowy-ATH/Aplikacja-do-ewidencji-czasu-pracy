using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AttendanceSystem.Models;
using AttendanceSystem.Models.DB;
using AttendanceSystem.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceSystem.Test
{
    [TestClass]
    public class EmployeeControllerTest
    {
        public readonly Mock<EwidencjaContext> _connection;
        public EmployeeControllerTest()
        {
           _connection  = new Mock<EwidencjaContext>();

        }
        [TestMethod]
        public void CreateNewTest()
        {
            EmployeeController controller = new EmployeeController(_connection.Object);
            var resultCreateNew = controller.CreateNew() as ViewResult;
            
            Assert.IsNotNull(resultCreateNew);
            Assert.IsInstanceOfType(resultCreateNew, typeof(ViewResult));
        }
        [TestMethod]
        public void IndexTetst()
        {
            EmployeeController controller = new EmployeeController(_connection.Object);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


    }
}
