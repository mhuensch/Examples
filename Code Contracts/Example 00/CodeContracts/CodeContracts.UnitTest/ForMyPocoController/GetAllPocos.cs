using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.MsTest;
using System.Linq;

namespace CodeContracts.UnitTest.ForMyPocoController
{
	[TestClass, CategorizeByConventionClass(typeof(GetAllPocos))]
	public class GetAllPocos
	{
		[TestMethod, CategorizeByConvention]
		public void WhenMultiplePocosExist_ShouldReturnExpectedResults()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedName = "SomePocoName";
			var expectedGuidOne = Guid.NewGuid();
			var expectedGuidTwo = Guid.NewGuid();

			controller.CreatePoco(expectedGuidOne, expectedName);
			controller.CreatePoco(expectedGuidTwo, expectedName);

			//Act
			var result = controller.GetAllPocos();

			//Assert
			Assert.AreEqual(expectedGuidOne, result.ElementAt(0).Id);
			Assert.AreEqual(expectedGuidTwo, result.ElementAt(1).Id);
		}

		[TestMethod, CategorizeByConvention]
		public void WhenNoPocosExist_ShouldReturnEmptyList()
		{
			//Arrange
			var controller = new MyPocoController();

			//Act
			var result = controller.GetAllPocos();

			//Assert
			Assert.AreEqual(0, result.Count());
		}
	}
}
