using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace APIPostsViewer.Tests
{
    [TestClass]
    public class ValidationRulesTests
    {
        [TestMethod]
        public void TestUrlValidationRule()
        {
            var rule = new UrlValidationRule();
            var result = rule.Validate("https://jsonplaceholder.typicode.com/posts", CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
            Assert.IsNull(result.ErrorContent);

            result = rule.Validate("54gs:/gfggf", CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.ErrorContent);
        }

        [TestMethod]
        public void TestGridValidationRule()
        {
            var rule = new GridValidationRule();
            var result = rule.Validate(10, CultureInfo.CurrentCulture);

            Assert.IsTrue(result.IsValid);
            Assert.IsNull(result.ErrorContent);

            result = rule.Validate(-10, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.ErrorContent);

            result = rule.Validate(60, CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.ErrorContent);

            result = rule.Validate("test", CultureInfo.CurrentCulture);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.ErrorContent);
        }
    }
}
