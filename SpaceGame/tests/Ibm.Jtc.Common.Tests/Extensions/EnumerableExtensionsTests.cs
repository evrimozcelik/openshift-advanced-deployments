namespace Cloudy.Core.Common.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ibm.Jtc.Common;
    using FluentAssertions;
    using Xunit;

    public class EnumerableExtensionsTests
    {
        [Fact]
        public void IsNullOrEmpty_Null_EnumerableItems_Should_Be_True()
        {
            // Arrange
            IEnumerable<string> items = new List<string>();
            bool result;
            items = null;

            // Act
            result = items.IsNullOrEmpty();

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void IsNullOrEmpty_Empty_EnumerableItems_Should_Be_True()
        {
            // Arrange
            IEnumerable<string> items = new List<string>();
            bool result;

            // Act
            result = items.IsNullOrEmpty();

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void ForEach_Enumerable_Should_Be_Acted()
        {
            // Arrange
            IList<string> items = new List<string>() { "Pazartesi", "Salı" };
            string[] itemsCopy = new string[2];
            Action<string> printAction = (x) => items.CopyTo(itemsCopy, 0);

            // Act
            items.ForEach(printAction);

            // Assert
            itemsCopy.Should().Contain("Pazartesi");
        }

        [Fact]
        public void ForEach_Empty_Action_Should_Be_Acted()
        {
            // Arrange
            IList<string> items = new List<string>() { "Pazartesi", "Salı" };
            string[] itemsCopy = new string[2];
            // Act
            Action act = () => items.ForEach(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ForEach_Empty_Enumerable_Should_Be_Acted()
        {
            // Arrange
            IList<string> items = null;
            string[] itemsCopy = new string[2];
            Action<string> printAction = (x) => items.CopyTo(itemsCopy, 0);
            // Act
            Action act = () => items.ForEach(printAction);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAny_Enumerable_And_Item_Should_Be_True()
        {
            // Arrange
            IList<string> items = new List<string>() { "Pazartesi", "Salı" };
            string item = "Pazartesi";

            // Act
            var result= items.ContainsAny(item);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ContainsAny_Enumerable_And_Enumerable_Should_Be_False()
        {
            // Arrange
            IList<string> items = new List<string>() { "Pazartesi", "Salı" };
            IList<string> itemsAny = new List<string>() { "Perşembe", "Çarşamba" };

            // Act
            var result = items.ContainsAny(itemsAny);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Join_Enumerable_Should_Be_False()
        {
            // Arrange
            IList<string> items = new List<string>() { "Pazartesi", "Salı" };

            // Act
            var result = items.Join();

            // Assert
            result.Should().Be("Pazartesi,Salı");
        }

        [Fact]
        public void Join_Enumerable_By_Seperator_Should_Be_False()
        {
            // Arrange
            IList<string> items = new List<string>() { "Pazartesi", "Salı" };
            string seperator = "*";
            // Act
            var result = items.Join(seperator);

            // Assert
            result.Should().Be("Pazartesi*Salı");
        }

        [Fact]
        public void Join_Should_Get_Exception_Enumerable_Is_Null()
        {
            // Arrange
            IList<string> items = null;

            // Act
            Action act = () => items.Join();

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToReadOnlyCollection_Enumerable_Should_Be_True()
        {
            // Arrange
            IList<string> items = new List<string>() { "Pazartesi", "Salı" };
            
            // Act
            var readOnlyItem = items.ToReadOnlyCollection();

            var result = readOnlyItem.IsReadOnly;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ToStack_Enumerable_Should_Be_True()
        {
            // Arrange
            IList<string> items = new List<string>() { "Pazartesi", "Salı" };
      
            // Act
            var stack = items.ToStack();

            var result = stack.Count == items.Count;
            // Assert
            result.Should().BeTrue();
        }


        [Fact]
        public void ToStack_Enumerable_Should_Get_Exception_List_Null()
        {
            // Arrange
            IList<string> items = null;

            // Act
            Action act = () => items.ToStack();

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact] 
        public void ToQueue_Enumerable_Should_Be_True()
        {
            // Arrange
            IList<string> items = new List<string>() { "Pazartesi", "Salı" };

            // Act
            var queue = items.ToQueue();

            var result = queue.Count == items.Count;
            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ToQueue_Enumerable_Should_Get_Exception_List_Null()
        {
            // Arrange
            IList<string> items = null;

            // Act
            Action act = () => items.ToQueue();
            
            // Assert
            act.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void Partition_Enumerable_Should()
        {
            // Arrange
            IList<string> items = new List<string>() {"P", "S" ,"Ç","P","C","P"};
            int size = 2;
            int countItems = items.Count / size;
            // Act
            var partition = items.Partition(2).ToList();
            var result = countItems == partition.Count;
            // Assert
            result.Should().BeTrue();

        }
    }
}
