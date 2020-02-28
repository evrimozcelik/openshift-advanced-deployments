namespace Cloudy.Core.Common.Tests
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;
    using Ibm.Jtc.Common;

    public class CollectionExtensionsTests
    {
        [Fact]
        public void AddIf_Item_Should_Be_AddIf_Predicate()
        {
            // Arrange
            ICollection<int> items = new List<int>() { 1, 2, 3 };
            int item = 4;
            Func<int, bool> predicate = new Func<int, bool>(this.Hesapla);

            // Act
            items.AddIf(item, predicate);

            // Assert
            items.Should().Equal(new List<int> { 1, 2, 3, 4 });
        }

        [Fact]
        public void AddRange_Items_Should_Be_Add()
        {
            // Arrange
            ICollection<int> collection = new List<int>() { 1, 2, 3 };
            IEnumerable<int> items = new List<int>() { 4, 5, 6 };

            // Act
            collection.AddRange(items);

            // Assert
            collection.Should().Equal(new List<int> { 1, 2, 3, 4, 5, 6 });
        }

        [Fact]
        public void AddRange_ParamItems_Should_Be_Add()
        {
            // Arrange
            ICollection<int> collection = new List<int>() { 1, 2, 3 };
            int[] items = { 5, 6 };

            // Act
            collection.AddRange(items);

            // Assert
            collection.Should().Equal(new List<int> { 1, 2, 3, 5, 6 });
        }

        [Fact]
        public void RemoveRange_Items_Should_Be_Remove()
        {
            // Arrange
            ICollection<int> collection = new List<int>() { 1, 2, 3, 4, 5, 6 };
            IEnumerable<int> items = new List<int>() { 4, 5, 6 };

            // Act
            collection.RemoveRange(items);

            // Assert
            collection.Should().Equal(new List<int> { 1, 2, 3 });
        }

        [Fact]
        public void RemoveRange_ParamItems_Is_Null_Should_Be_Remove()
        {
            // Arrange
            ICollection<int> collection = new List<int>() { 1, 2, 3, 4, 5, 6 };
            int[] items = null;
            
            // Act
            collection.RemoveRange(items);

            // Assert
            collection.Should().Equal(new List<int> { 1, 2, 3, 4, 5, 6});
        }


        public bool Hesapla(int i)
        {
            return i > 0;
        }
    }
}
