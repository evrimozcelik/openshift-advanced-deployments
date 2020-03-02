using System;
using Xunit;
using Ibm.Jtc.Common;
using FluentAssertions;

namespace Cloudy.Core.Common.Tests
{
    public class RubyLikeDataTimeExtensionsTests
    {
        [Fact]
        public void OneWeek_Should_Return_Week_In_Timespan()
        {
            var oneweek = 1.Week();

            oneweek.Should().Be(new TimeSpan(7,0,0,0,0));
        }

        [Fact]
        public void TwoWeek_Should_Return_Week_In_Timespan()
        {
            var oneweek = 2.Weeks();

            oneweek.Should().Be(new TimeSpan(14, 0, 0, 0, 0));
        }

        [Fact]
        public void OneDay_Should_Return_Day_In_Timespan()
        {
            var oneweek = 1.Day();

            oneweek.Should().Be(new TimeSpan(1, 0, 0, 0, 0));
        }

        [Fact]
        public void TwoDays_Should_Return_Day_In_Timespan()
        {
            var oneweek = 2.Days();

            oneweek.Should().Be(new TimeSpan(2, 0, 0, 0, 0));
        }

        [Fact]
        public void OneHour_Should_Return_OneHour_In_Timespan()
        {
            var oneweek = 1.Hour();

            oneweek.Should().Be(new TimeSpan(0, 1, 0, 0, 0));
        }

        [Fact]
        public void TwoHour_Should_Return_TwoHours_In_Timespan()
        {
            var oneweek = 2.Hours();

            oneweek.Should().Be(new TimeSpan(0, 2, 0, 0, 0));
        }

        [Fact]
        public void OneMinute_Should_Return_OneMinute_In_Timespan()
        {
            var oneweek = 1.Minute();

            oneweek.Should().Be(new TimeSpan(0, 0, 1, 0, 0));
        }

        [Fact]
        public void TwoMinutes_Should_Return_TwoMinutes_In_Timespan()
        {
            var oneweek = 2.Minutes();

            oneweek.Should().Be(new TimeSpan(0, 0, 2, 0, 0));
        }

        [Fact]
        public void OneSecond_Should_Return_OneSecond_In_Timespan()
        {
            var oneweek = 1.Second();

            oneweek.Should().Be(new TimeSpan(0, 0, 0, 1, 0));
        }

        [Fact]
        public void TwoSeconds_Should_Return_TwoSeconds_In_Timespan()
        {
            var oneweek = 2.Seconds();

            oneweek.Should().Be(new TimeSpan(0, 0, 0, 2, 0));
        }

        [Fact]
        public void OneMilliSecond_Should_Return_OneMilliSecond_In_Timespan()
        {
            var oneweek = 1.Millisecond();

            oneweek.Should().Be(new TimeSpan(0, 0, 0, 0, 1));
        }

        [Fact]
        public void TwoMilliSeconds_Should_Return_TwoMilliSeconds_In_Timespan()
        {
            var oneweek = 2.Milliseconds();

            oneweek.Should().Be(new TimeSpan(0, 0, 0, 0, 2));
        }
    }
}
