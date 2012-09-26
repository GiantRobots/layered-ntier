using Contracts;
using Contracts.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Contracts
{
    [TestFixture]
    public class IdentifierTest
    {
        [Test]
        public void CreateNewIdentifier()
        {
            var id = new Identifier();
            Assert.IsNotNull(id);
            Assert.IsNotNullOrEmpty(id.ToString());
        }
        [Test]
        public void CreateIdentifierFromGuid()
        {
            var guid = Guid.NewGuid();
            var guidValue = guid.ToString();

            var id = new Identifier(guid);
            Assert.IsNotNull(id);
            Assert.IsNotNullOrEmpty(id.ToString());

            // make sure the string value of the identifier is the same as the guid's string value
            Assert.AreEqual(id.ToString(), guidValue);
        }
        [Test]
        public void CreateIdentifierFromString()
        {
            var guidValue = Guid.NewGuid().ToString();

            var id = new Identifier(guidValue);
            Assert.IsNotNull(id);
            Assert.IsNotNullOrEmpty(id.ToString());

            // make sure the string value of the identifier is the same as the guid's string value
            Assert.AreEqual(id.ToString(), guidValue);
            Debug.WriteLine("{0} == {1}", id.ToString(), guidValue);
        }
    }
}
