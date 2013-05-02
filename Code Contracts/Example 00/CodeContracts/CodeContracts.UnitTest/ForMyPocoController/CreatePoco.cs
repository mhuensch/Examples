using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.MsTest;
using System;

namespace CodeContracts.UnitTest.ForMyPocoController
{
	[TestClass, CategorizeByConventionClass(typeof(CreatePoco))]
	public class CreatePoco
	{
		[TestMethod, CategorizeByConvention]
		public void WhenIdAndNameAreGiven_ShouldReturnPoco()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();
			var expectedName = "SomePocoName";

			//Act
			var result = controller.CreatePoco(expectedId, expectedName);

			//Assert
			Assert.IsNotNull(result);
		}

		[TestMethod, CategorizeByConvention]
		public void WhenIdAndNameAreGiven_ShouldReturnPocowithGivenId()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();
			var expectedName = "SomePocoName";

			//Act
			var result = controller.CreatePoco(expectedId, expectedName);

			//Assert
			Assert.AreEqual(expectedId, result.Id);
		}

		[TestMethod, CategorizeByConvention]
		public void WhenIdAndNameAreGiven_ShouldReturnPocowithGivenName()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();
			var expectedName = "SomePocoName";

			//Act
			var result = controller.CreatePoco(expectedId, expectedName);

			//Assert
			Assert.AreEqual(expectedName, result.Name);
		}

		[TestMethod, CategorizeByConvention]
		public void WhenNameIsNull_ShouldThrow()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();

			//Act
			var exception = ExceptionTest.Catch(() => controller.CreatePoco(Guid.Empty, null));

			//Assert
			Assert.AreEqual(typeof(ArgumentNullException), exception.GetType());
			Assert.AreEqual("Value cannot be null.\r\nParameter name: name", exception.Message);
		}

		[TestMethod, CategorizeByConvention]
		public void WhenIdIsDuplicate_ShouldThrow()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();
			var expectedName = "SomePocoName";
			var poco = controller.CreatePoco(expectedId, expectedName);

			//Act
			var exception = ExceptionTest.Catch(() => controller.CreatePoco(poco.Id, poco.Name));

			//Assert
			Assert.AreEqual(typeof(InvalidOperationException), exception.GetType());
			Assert.AreEqual("Duplicate value for id not allowed.", exception.Message);
		}

	}
}