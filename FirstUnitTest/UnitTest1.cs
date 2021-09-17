using System;
using FirstLib;
using Xunit;
namespace firstUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Bot r = new();
            Assert.Equal("Hi!", r.SayHi());
            Assert.Equal("Each groups can have 5 candies.", r.SplitCandies(10, 2));
            Assert.Equal("Each groups can have 4 candies. 1 candies remained.", r.SplitCandies(9, 2));
            Assert.Throws<DivideByZeroException>(() =>
            {
                r.SplitCandies(1, 0);
            });
        }
    }
}
