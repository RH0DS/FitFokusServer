

using FitfokusServer.Models.DomainObjects;

namespace FitFokusServerTests
{
    public class ModelTests
    {
        [Fact]
        public void ValidateDefaultIdForNewUserResponse()
        {
            // Arrange
            var user = new User();

            // Act
            var id = user.Id;

            // Assert
            Assert.Equal(0, id);

        }

        [Fact]
        public void ValidateEmptyUserNameForNewUserResponse()
        {
            // Arrange
            var user = new User();

            // Act
            var userName = user.Name;

            // Assert
            Assert.Null(userName);

        }

        [Fact]
        public void ValidateEmptyEmailForNewUserResponse()
        {
            // Arrange
            var user = new User();

            // Act
            var email = user.Email;

            // Assert
            Assert.Empty(email);

        }
    }
}