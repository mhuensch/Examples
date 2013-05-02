using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.MsTest;

namespace CodeContracts.UnitTest.ForMyPocoController
{
	[TestClass, CategorizeByConventionClass(typeof(UpdatePoco))]
	public class UpdatePoco
	{
		[TestMethod, CategorizeByConvention]
		public void WhenPocoDoesNotExist_ShouldAddPoco()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();
			var expectedName = "SomePocoName";

			var newPoco = new MyPoco() { Id = expectedId, Name = expectedName };

			//Act
			controller.UpdatePoco(newPoco);

			//Assert
			Assert.IsNotNull(controller.GetPoco(expectedId));
		}

		[TestMethod, CategorizeByConvention]
		public void WhenPocoExist_ShouldUpdatePoco()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();
			var expectedName = "All Mine!";
			var poco = controller.CreatePoco(expectedId, "SomePocoName");

			poco.Name = expectedName;

			//Act
			controller.UpdatePoco(poco);

			//Assert
			Assert.AreEqual(expectedName, controller.GetPoco(expectedId).Name);
		}
	}
}
