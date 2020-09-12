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
        public EmployeeControllerTest()
        {
        }

        [TestMethod]
        public void CreateNewTest()
        {
            var DBContextTest = new Mock<EwidencjaContext>();
            
            EmployeeController controller = new EmployeeController(DBContextTest.Object);
            var resultCreateNew = controller.CreateNew() as ViewResult;
            
            Assert.IsNotNull(resultCreateNew);
            Assert.IsInstanceOfType(resultCreateNew, typeof(ViewResult));
        }
        [TestMethod]
        public void IndexTetst()
        {
            var DBContextTest = new Mock<EwidencjaContext>();
            EmployeeController controller = new EmployeeController(DBContextTest.Object);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


    }
}
