using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.MsTest;
using System;
using System.Linq;

namespace CodeContracts.UnitTest.ForMyPocoController
{
	[TestClass, CategorizeByConventionClass(typeof(FindPocoByName))]
	public class FindPocoByName
	{
		[TestMethod, CategorizeByConvention]
		public void WhenNameDoesNotExist_ShouldReturnEmptyList()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();
			var expectedName = "SomePocoName";

			//Act
			var result = controller.FindPocoByName(expectedName);

			//Assert
			Assert.AreEqual(0, result.Count());
		}

		[TestMethod, CategorizeByConvention]
		public void WhenNameExists_ShouldReturnOneResult()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();
			var expectedName = "SomePocoName";

			var expectedPoco = controller.CreatePoco(expectedId, expectedName);

			//Act
			var result = controller.FindPocoByName(expectedName);

			//Assert
			Assert.AreEqual(1, result.Count());
		}

		[TestMethod, CategorizeByConvention]
		public void WhenNameExists_ShouldReturnExpectedResult()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedId = Guid.NewGuid();
			var expectedName = "SomePocoName";

			var expectedPoco = controller.CreatePoco(expectedId, expectedName);

			//Act
			var result = controller.FindPocoByName(expectedName);

			//Assert
			Assert.AreEqual(expectedId, result.ElementAt(0).Id);
		}

		[TestMethod, CategorizeByConvention]
		public void WhenNameExistsMultipleTimes_ShouldReturnMultipleResults()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedName = "SomePocoName";
			var expectedGuidOne = Guid.NewGuid();
			var expectedGuidTwo = Guid.NewGuid();

			controller.CreatePoco(expectedGuidOne, expectedName);
			controller.CreatePoco(expectedGuidTwo, expectedName);

			//Act
			var result = controller.FindPocoByName(expectedName);

			//Assert
			Assert.IsTrue(result.Count() > 1);
		}

		[TestMethod, CategorizeByConvention]
		public void WhenNameExistsMultipleTimes_ShouldReturnExpectedResults()
		{
			//Arrange
			var controller = new MyPocoController();
			var expectedName = "SomePocoName";
			var expectedGuidOne = Guid.NewGuid();
			var expectedGuidTwo = Guid.NewGuid();

			controller.CreatePoco(expectedGuidOne, expectedName);
			controller.CreatePoco(expectedGuidTwo, expectedName);

			//Act
			var result = controller.FindPocoByName(expectedName);

			//Assert
			Assert.AreEqual(expectedGuidOne, result.ElementAt(0).Id);
			Assert.AreEqual(expectedGuidTwo, result.ElementAt(1).Id);
		}

	}
}
