using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.MsTest;

namespace CodeContracts.UnitTest.ForMyPocoController
{
	[TestClass, CategorizeByConventionClass(typeof(GetPoco))]
	public class GetPoco
	{
		[TestMethod, CategorizeByConvention]
		public void WhenPocoDoesNotExist_ShouldReturnNull()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedGuidOne = Guid.NewGuid();

			//Act
			var result = controller.GetPoco(expectedGuidOne);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod, CategorizeByConvention]
		public void WhenPocoExists_ShouldReturnMatchingPoco()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedName = "SomePocoName";
			var expectedGuidOne = Guid.NewGuid();
			var expectedPoco = controller.CreatePoco(expectedGuidOne, expectedName);

			//Act
			var result = controller.GetPoco(expectedGuidOne);

			//Assert
			Assert.AreEqual(expectedPoco, result);
		}
	}
}
