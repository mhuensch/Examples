using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.MsTest;

namespace CodeContracts.UnitTest.ForMyPocoController
{
	[TestClass, CategorizeByConventionClass(typeof(RemovePoco))]
	public class RemovePoco
	{
		[TestMethod, CategorizeByConvention]
		public void WhenPocoExists_ShouldRemovePoco()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedName = "SomePocoName";
			var expectedGuidOne = Guid.NewGuid();
			var expectedPoco = controller.CreatePoco(expectedGuidOne, expectedName);

			//Act
			controller.RemovePoco(expectedGuidOne);
			var result = controller.GetPoco(expectedGuidOne);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod, CategorizeByConvention]
		public void WhenPocoDoesNotExist_ShouldNotThrowException()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedGuidOne = Guid.NewGuid();

			//Act
			controller.RemovePoco(expectedGuidOne);
			var result = controller.GetPoco(expectedGuidOne);

			//Assert
			Assert.IsNull(result);
		}
	}
}
