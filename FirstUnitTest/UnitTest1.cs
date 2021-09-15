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
            Robot r = new();
            Assert.Equal("Hi!", r.Greeting());
            Assert.Equal(5, r.Split(10, 2));
            Assert.Throws<DivideByZeroException>(() =>
            {
                r.Split(1, 0);
            });

        }
    }
}
