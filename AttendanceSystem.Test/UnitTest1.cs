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
        [TestMethod]
        public void EmployeControllerTest()
        {
            EmployeeController controller = new EmployeeController();
            var resultCreateNew = controller.CreateNew() as ViewResult;
            Assert.IsNotNull(resultCreateNew);


            
        }
    }
}
