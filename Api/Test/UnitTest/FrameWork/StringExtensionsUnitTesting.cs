using Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace UnitTest.FrameWork
{

    public class StringExtensionsUnitTesting
    {
        [Fact]
        public void Contvert_String_ToInt32_Success()
        {
            // Arrange
            const string intString = "6";
            var valueToTest = intString.ToInt32();
            // Act
            var result = 6;
            //Assert
            Assert.Equal(valueToTest, result);
        }
        [Fact]
        public void Contvert_String_IntHasDecimal_ToInt32_Success()
        {
            // Arrange
            const string intString = "6.00";
            // Act
            var ex = Assert.Throws<InvalidCastException>(() => intString.ToInt32());

            Assert.Equal("Specified cast is not valid.", ex.Message);
        }
        [Fact]
        public void Contvert_String_ToInt32_ThrowInvalidCastException()
        {
            // Arrange
            const string intString = "ddf3";
            var ex = Assert.Throws<InvalidCastException>(() => intString.ToInt32());

            Assert.Equal("Specified cast is not valid.", ex.Message);

        }

        [Fact]
        public void Encrypt_String_Success()
        {
            const string key = "testing";
            const string stringToEncrypt = "h12sdf";
            //arrange
            var ecryptValue = stringToEncrypt.Encrypt(key);
            //act
            var decrtyptValue = ecryptValue.Decrypt(key);
            //assert 
            Assert.Equal(decrtyptValue, stringToEncrypt);
        }

        [Fact]
        public void Encrypt_String_Fauilre()
        {
            const string key = "testing";
            const string key2 = "testing2";
            const string stringToEncrypt = "h12sdf";
            //arrange
            var ecryptValue = stringToEncrypt.Encrypt(key);
            //act
            
          var ex =  Assert.Throws<CryptographicException>(() => ecryptValue.Decrypt(key2));
            //assert 
  

            Assert.Equal("Padding is invalid and cannot be removed.", ex.Message);
        }
    }
}
