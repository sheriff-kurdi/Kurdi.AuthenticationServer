using System;
using Kurdi.AuthenticationService.Core.Entities;
using Xunit;

namespace Kurdi.AuthenticationServer.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("INVENTORY", "PRODUCTS", "CREATE")]
        [InlineData("INVENTORY", "PRODUCTS", "READ")]
        [InlineData("INVENTORY", "PRODUCTS", "EDIT")]
        [InlineData("INVENTORY", "PRODUCTS", "DELETE")]
        public void TestGetAuthority(string ProjectsIdentifier, string moduleName, string action)
        {
            //arrange
            Authority authority = new Authority
            {
                ProjectsIdentifier = ProjectsIdentifier,
                ModuleName = moduleName,
                Action = action
            };

            //action
            string actualAuthorityName = authority.GetAuthority();
            string expectedAuthorityName = $"{ProjectsIdentifier}:{moduleName}:{action}";

            //assert
            Assert.Equal(expectedAuthorityName, actualAuthorityName);
        }
    }
}
