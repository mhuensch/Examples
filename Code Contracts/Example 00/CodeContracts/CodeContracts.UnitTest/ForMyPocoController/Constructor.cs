using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.MsTest;

namespace CodeContracts.UnitTest.ForMyPocoController
{
	[TestClass, CategorizeByConventionClass(typeof(CreatePoco))]
	public class Constructor
	{
		[TestMethod, CategorizeByConvention]
		public void WhenNoParametersAreGiven_ShouldReturnInstance()
		{
			//Act
			var controller = new MyPocoController();

			//Assert
			Assert.IsNotNull(controller);
		}
	}
}
