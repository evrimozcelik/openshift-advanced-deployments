using Ibm.Jtc.Common;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cloudy.Core.Common.Tests
{
    public class EnsureTests
    {
        [Fact]
        public void Ensure_That_NotNull_Should_Not_Throw_ArgumentNullException_For_NotNull_Object()
        {
            var customerSample = new CustomerSample
            {
                Id = 1,
                FullName = "Bünyamin Aslan",
                AccountNumbers = new List<long> { 4073, 13, 4, 9, 36, 41, 44 },
                Balance = 1000.01M
            };
           
            var customerSampleList = new List<CustomerSample>
            {
                new CustomerSample{
                    Id = 1,
                    FullName = "Bünyamin Aslan",
                    AccountNumbers = new List<long> { 4073, 13, 4, 9, 36, 41, 44 },
                    Balance = 1000.01M
                }
            };

            Ensure.That("customerSampleList", customerSampleList).Is.NotNull().Value.Should().Equal(customerSampleList);
        }

        [Fact]
        public void Ensure_That_NotNull_Should_Throw_ArgumentNullException_For_Null_Object()
        {
            CustomerSample customerSample = null;

            Action act = () => Ensure.That("customerSample", customerSample).Is.NotNull();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Ensure_That_NotEmpty_Should_Not_Throw_ArgumentException_For_NotEmpty_String()
        {
            string testString = "Halkbank";

            Ensure.That("testString", testString).Is.NotEmpty().Value.Should().Be("Halkbank");
        }
        [Fact]
        public void Ensure_That_NotEmpty_Should_Throw_ArgumentException_For_Empty_String()
        {
            string testString = string.Empty;
            Action act = ()=> Ensure.That("testString", testString).Is.NotEmpty();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Ensure_That_NotNullOrEmpty_Should_Not_Throw_ArgumentNullException_For_NotEmpty_String()
        {
            string testString = "Halkbank";

            Action act = () => Ensure.That("testString", testString).Is.NotNullOrEmpty();

            act.Should().NotThrow();
        }

        [Fact]
        public void Ensure_That_NotNullOrEmpty_Should_Throw_ArgumentNullException_For_Empty_String()
        {
            string testString = string.Empty;
            Action act = () => Ensure.That("testString", testString).Is.NotNullOrEmpty();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Ensure_That_NotZero_Should_Throw_ArgumentException_For_ZeroValue_Int()
        {
            int count = 0;

            Action act = () => Ensure.That("count", count).Is.NotZero();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Ensure_That_NotNegative_Should_Not_Throw_ArgumentException_For_NegativeValue_Int()
        {
            int count = 1987;
            Action act = () => Ensure.That("count", count).Is.NotNegative();

            act.Should().NotThrow();

            count = 0;
            Action anotherAct = () => Ensure.That("count", count).Is.NotNegative();

            anotherAct.Should().NotThrow();
        }

        [Fact]
        public void Ensure_That_NotNegative_Should_Throw_ArgumentException_For_NotNegativeValue_Int()
        {
            int count = -1;

            Action act = () => Ensure.That("count", count).Is.NotNegative();

            act.Should().Throw<ArgumentException>(); 
        }

        [Fact]
        public void Ensure_That_Positive_Should_Not_Throw_ArgumentException_For_PositiveValue_Int()
        {
            int count = 1987;
            Action act = () => Ensure.That("count", count).Is.Positive();

            act.Should().NotThrow();
        }

        [Fact]
        public void Ensure_That_Positive_Should_Throw_ArgumentException_For_Not_PositiveValue_Int()
        {
            int count = -1;

            Action act = () => Ensure.That("count", count).Is.Positive();

            act.Should().Throw<ArgumentException>();

            count = 0;

            Action act2 = () => Ensure.That("count", count).Is.Positive();

            act2.Should().Throw<ArgumentException>();
        }


        [Fact]
        public void Ensure_That_GreaterThanOrEqualTo_Should_Not_Throw_ArgumentOutOfRangeException_For_GreaterThanOrEqualToValue_Int()
        {
            Validation<int> result;

            int count = 1987;
            result = Ensure.That("count", count).Is.GreaterThanOrEqualTo(1987);
            Assert.True(result.Value == count);

            count = 100;
            result = Ensure.That("count", count).Is.GreaterThanOrEqualTo(99);
            Assert.True(result.Value == count);

            count = -3;
            result = Ensure.That("count", count).Is.GreaterThanOrEqualTo(-5);
            Assert.True(result.Value == count);
        }

        [Fact]
        public void Ensure_That_GreaterThanOrEqualTo_Should_Throw_ArgumentOutOfRangeException_For_LowerThanToValue_Int()
        {
            int count = 100;

            Action act = () => Ensure.That("count", count).GreaterThanOrEqualTo(101);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Ensure_That_GreaterThanTo_Should_Not_Throw_ArgumentOutOfRangeException_For_GreaterToValue_Int()
        {
            int count = 100;
            
            Action act = () => Ensure.That("count", count).GreaterThan(99);

            act.Should().NotThrow();

            count = -3;
            Action act2 = () => Ensure.That("count", count).GreaterThan(-5);

            act2.Should().NotThrow();
        }

        [Fact]
        public void Ensure_That_GreaterThan_Should_Throw_ArgumentOutOfRangeException_For_LowerThanEqualToValue_Int()
        {
            int count = 100;
            Action act1 = () => Ensure.That("count", count).GreaterThan(101);
            act1.Should().Throw<ArgumentOutOfRangeException>();

            count = 100;
            Action act2 = () => Ensure.That("count", count).GreaterThan(100);
            act2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Ensure_That_LessThan_Should_Not_Throw_ArgumentOutOfRangeException_For_LowerToValue_Int()
        {
            Validation<int> result;

            int count = 100;
            result = Ensure.That("count", count).LessThan(150);
            Assert.True(result.Value == count);

            count = -3;
            result = Ensure.That("count", count).LessThan(-1);
            Assert.True(result.Value == count);
        }

        [Fact]
        public void Ensure_That_LessThan_Should_Throw_ArgumentOutOfRangeException_For_GreaterThanEqualToValue_Int()
        {

            int count = 100;
            Action act1 = () => Ensure.That("count", count).LessThan(100);
            act1.Should().Throw<ArgumentOutOfRangeException>();

            count = 100;
            Action act2 = () => Ensure.That("count", count).LessThan(10);
            act2.Should().Throw<ArgumentOutOfRangeException>();
        }

        public class CustomerSample
        {
            public int Id { get; set; }
            public List<long> AccountNumbers { get; set; }
            public string FullName { get; set; }
            public decimal Balance { get; set; }
        }
    }
}
