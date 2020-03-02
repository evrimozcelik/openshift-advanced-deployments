namespace Cloudy.Core.Common.Tests
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;
    using Ibm.Jtc.Common;

    public class StringExtensionsTests
    {
        [Fact]
        public void Should_Join_With_Seperator()
        {
            List<string> array = new List<string> { "foo", "bar" };
            array.JoinWith(':').Should().Be("foo:bar");
        }

        [Fact]
        public void Should_Join_With_Seperator_Get_Exception_List_Null()
        {
            List<string> array = null;
            Action act = () => array.JoinWith(':');
            
            act.Should().Throw<ArgumentException>();
        }


        [Fact]
        public void IsEmpty_Empty_String_Should_Be_True()
        {
            // Arrange
            string value = string.Empty;
            bool result;

            // Act
            result = value.IsEmpty();

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void IsNull_Null_String_Should_Be_True()
        {
            // Arrange
            string value = null;
            bool result;

            // Act
            result = value.IsNull();

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void IsNullOrEmpty_Empty_String_Should_Be_True()
        {
            // Arrange
            string value = string.Empty;
            bool result;

            // Act
            result = value.IsNullOrEmpty();

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void IsNullOrEmpty_Null_String_Should_Be_True()
        {
            // Arrange
            string value = null;
            bool result;

            // Act
            result = value.IsNullOrEmpty();

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void SafeIntParse_Int_Value_Should_Parse_To_Int()
        {
            // Arrange
            string value = "1";
            int result;

            // Act
            result = value.SafeIntParse();

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void SafeIntParse_Int_Value_Should_Get_Exception_Value_Null()
        {
            // Arrange
            string value = string.Empty;

            Action act = () => value.SafeIntParse();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void SafeIntParse_Long_Value_Should_Get_Exception_Value_Null()
        {
            // Arrange
            string value = string.Empty;

            Action act = () => value.SafeLongParse();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void SafeDoubleParse_Double_Value_Should_Parse_To_Double()
        {
            // Arrange
            string value = "1";
            double sonuc = 1;
            double result;

            // Act
            result = value.SafeDoubleParse();

            // Assert
            result.Should().Be(sonuc);
        }

        [Fact]
        public void SafeDoubleParse_String_Value_Should_Parse_To_Double()
        {
            // Arrange
            string value = "string";
            double result;

            // Act
            result = value.SafeDoubleParse();

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void SafeDoubleParse_Double_Value_Should_Get_Exception_Value_Null()
        {
            // Arrange
            string value = string.Empty;

            Action act = () => value.SafeDoubleParse();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void JoinWith_Long_Value_Should_Get_Exception_Value_Null()
        {
            // Arrange
            IList<string> value = null;

            Action act = () => value.JoinWith(':');

            act.Should().Throw<ArgumentException>();
        }
      
        [Fact]
        public void SafeIntParse_Bool_Value_Should_Get_Exception_Value_Null()
        {
            // Arrange
            string value = string.Empty;

            Action act = () => value.SafeBoolParse();

            act.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void SafeIntParse_Decimal_Value_Should_Parse_To_Int()
        {
            // Arrange
            string value = "90946";
            int result;

            // Act
            result = value.SafeIntParse();

            // Assert
            result.Should().Be(90946);
        }

        [Fact]
        public void SafeIntParse_Hexadecimal_Value_Should_Parse_To_Int()
        {
            // Arrange
            string value = "0x16342";
            int result;

            // Act
            result = value.SafeIntParse();

            // Assert
            result.Should().Be(default(int));
        }

        [Fact]
        public void SafeIntParse_Binary_Value_Should_Parse_To_Int()
        {
            // Arrange
            string value = "0b0001_0110_0011_0100_0010";
            int result;

            // Act
            result = value.SafeIntParse();

            // Assert
            result.Should().Be(default(int));
        }

        [Fact]
        public void SafeLongParse_Long_Value_Should_Parse_To_Long()
        {
            // Arrange
            string value = "1";
            long result;

            // Act
            result = value.SafeLongParse();

            // Assert
            result.Should().Be(1L);
        }

        [Fact]
        public void SafeLongParse_Decimal_Value_Should_Parse_To_Long()
        {
            // Arrange
            string value = "90946";
            long result;

            // Act
            result = value.SafeLongParse();

            // Assert
            result.Should().Be(90946L);
        }

        [Fact]
        public void SafeLongParse_Hexadecimal_Value_Should_Parse_To_Long()
        {
            // Arrange
            string value = "0x16342";
            long result;

            // Act
            result = value.SafeLongParse();

            // Assert
            result.Should().Be(default(long));
        }

        [Fact]
        public void SafeLongParse_Binary_Value_Should_Parse_To_Long()
        {
            // Arrange
            string value = "0b0001_0110_0011_0100_0010";
            long result;

            // Act
            result = value.SafeLongParse();

            // Assert
            result.Should().Be(default(long));
        }

        [Fact]
        public void SafeBoolParse_String_Value_Should_Be_True()
        {
            // Arrange
            string value = "true";
            bool result;

            // Act
            result = value.SafeBoolParse();

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void String_List_Should_Be_To_Quoted()
        {
            // Arrange
            IEnumerable<string> items = new List<string>() { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };
            IEnumerable<string> resultList;

            // Act
            resultList = items.Quote();

            // Assert
            resultList.Should().Equal("'Pazartesi'", "'Salı'", "'Çarşamba'", "'Perşembe'", "'Cuma'");
        }

        [Fact]
        public void GetBytes_Should_Be_To_True()
        {
            // Arrange
            string value = "Test";

            // Act
            var result = value.GetBytes();

            // Assert
            result.Length.Should().Be(8);
        }
        
    }
}
