using System;
using LongAriphmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{

    [TestClass]
    public class TestLongInteger
    {
        [TestMethod]
        public void TestValidNum()
        {
            var a = new LongInteger("+123");
            Assert.AreEqual("123", a.ToString());
        }

        [TestMethod]
        public void TestValidNum4()
        {
            var a = new LongInteger("-123");
            Assert.AreEqual("-123", a.ToString());
        }

        [TestMethod]
        public void TestCompare()
        {
            var a = new LongInteger("120");
            var b = new LongInteger("90");

            var r = LongInteger.Compare(a, b);

            Assert.AreEqual(1, r);

            a = new LongInteger("1110");
            b = new LongInteger("1120");

            r = LongInteger.Compare(a, b);

            Assert.AreEqual(-1, r);

            a = new LongInteger("1110");
            b = new LongInteger("1110");

            r = LongInteger.Compare(a, b);

            Assert.AreEqual(0, r);

            a = new LongInteger("-120");
            b = new LongInteger("90");

            r = LongInteger.Compare(a, b);

            Assert.AreEqual(-1, r);

            a = new LongInteger("120");
            b = new LongInteger("-290");

            r = LongInteger.Compare(a, b);

            Assert.AreEqual(1, r);

            a = new LongInteger("-320");
            b = new LongInteger("-290");

            r = LongInteger.Compare(a, b);

            Assert.AreEqual(-1, r);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidNum1()
        {
            new LongInteger("234687-1345231");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidNum2()
        {
            new LongInteger("2asd1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidNum3()
        {
            new LongInteger("3534%2134");
        }

        [TestMethod]
        public void TestSum()
        {
            var a = new LongInteger("120");
            var b = new LongInteger("90");

            var c = a.Sum(b);

            Assert.AreEqual("120", a.ToString());
            Assert.AreEqual("90", b.ToString());
            Assert.AreEqual("210", c.ToString());

            a = new LongInteger("120020");
            b = new LongInteger("90");

            c = a.Sum(b);

            Assert.AreEqual("120020", a.ToString());
            Assert.AreEqual("90", b.ToString());
            Assert.AreEqual("120110", c.ToString());

            a = new LongInteger("20");
            b = new LongInteger("90");

            c = a.Sum(b);

            Assert.AreEqual("20", a.ToString());
            Assert.AreEqual("90", b.ToString());
            Assert.AreEqual("110", c.ToString());

            a = new LongInteger("20000000000000000000000000000000000000000000000000000000000000000");
            b = new LongInteger("90000000000000000000000000000000000000000000000000000000000000000");

            c = a.Sum(b);

            Assert.AreEqual("110000000000000000000000000000000000000000000000000000000000000000", c.ToString());

            a = new LongInteger("-120");
            b = new LongInteger("90");

            c = a.Sum(b);

            Assert.AreEqual("-120", a.ToString());
            Assert.AreEqual("90", b.ToString());
            Assert.AreEqual("-30", c.ToString());

            a = new LongInteger("-120");
            b = new LongInteger("-90");

            c = a.Sum(b);

            Assert.AreEqual("-120", a.ToString());
            Assert.AreEqual("-90", b.ToString());
            Assert.AreEqual("-210", c.ToString());


            a = new LongInteger("120");
            b = new LongInteger("-90");

            c = a.Sum(b);

            Assert.AreEqual("120", a.ToString());
            Assert.AreEqual("-90", b.ToString());
            Assert.AreEqual("30", c.ToString());


            a = new LongInteger("-60");
            b = new LongInteger("-90");

            c = a.Sum(b);

            Assert.AreEqual("-60", a.ToString());
            Assert.AreEqual("-90", b.ToString());
            Assert.AreEqual("-150", c.ToString());


            a = new LongInteger("-60");
            b = new LongInteger("-60");

            c = a.Sum(b);

            Assert.AreEqual("-60", a.ToString());
            Assert.AreEqual("-60", b.ToString());
            Assert.AreEqual("-120", c.ToString());

            a = new LongInteger("-0");
            b = new LongInteger("120");

            c = a.Sum(b);

            Assert.AreEqual("0", a.ToString());
            Assert.AreEqual("120", b.ToString());
            Assert.AreEqual("120", c.ToString());
        }

        [TestMethod]
        public void TestSub()
        {
            var a = new LongInteger("120");
            var b = new LongInteger("90");

            var c = a.Sub(b);

            Assert.AreEqual("120", a.ToString());
            Assert.AreEqual("90", b.ToString());
            Assert.AreEqual("30", c.ToString());

            a = new LongInteger("-120");
            b = new LongInteger("90");

            c = a.Sub(b);

            Assert.AreEqual("-120", a.ToString());
            Assert.AreEqual("90", b.ToString());
            Assert.AreEqual("-210", c.ToString());

            a = new LongInteger("-120");
            b = new LongInteger("-90");

            c = a.Sub(b);

            Assert.AreEqual("-120", a.ToString());
            Assert.AreEqual("-90", b.ToString());
            Assert.AreEqual("-30", c.ToString());


            a = new LongInteger("120");
            b = new LongInteger("-90");

            c = a.Sub(b);

            Assert.AreEqual("120", a.ToString());
            Assert.AreEqual("-90", b.ToString());
            Assert.AreEqual("210", c.ToString());


            a = new LongInteger("-60");
            b = new LongInteger("-90");

            c = a.Sub(b);

            Assert.AreEqual("-60", a.ToString());
            Assert.AreEqual("-90", b.ToString());
            Assert.AreEqual("30", c.ToString());


            a = new LongInteger("-60");
            b = new LongInteger("-60");

            c = a.Sub(b);

            Assert.AreEqual("-60", a.ToString());
            Assert.AreEqual("-60", b.ToString());
            Assert.AreEqual("0", c.ToString());

            a = new LongInteger("90");
            b = new LongInteger("120");

            c = a.Sub(b);

            Assert.AreEqual("90", a.ToString());
            Assert.AreEqual("120", b.ToString());
            Assert.AreEqual("-30", c.ToString());

            a = new LongInteger();
            b = new LongInteger("120");

            c = a.Sub(b);

            Assert.AreEqual("0", a.ToString());
            Assert.AreEqual("120", b.ToString());
            Assert.AreEqual("-120", c.ToString());

            a = new LongInteger("-0");
            b = new LongInteger("120");

            c = a.Sub(b);

            Assert.AreEqual("0", a.ToString());
            Assert.AreEqual("120", b.ToString());
            Assert.AreEqual("-120", c.ToString());
        }

        [TestMethod]
        public void TestMul()
        {
            var a = new LongInteger("2");
            var b = new LongInteger("3");

            var c = a.Mul(b);

            Assert.AreEqual("2", a.ToString());
            Assert.AreEqual("3", b.ToString());
            Assert.AreEqual("6", c.ToString());

            a = new LongInteger("-2");
            b = new LongInteger("3");

            c = a.Mul(b);

            Assert.AreEqual("-2", a.ToString());
            Assert.AreEqual("3", b.ToString());
            Assert.AreEqual("-6", c.ToString());

            a = new LongInteger("2");
            b = new LongInteger("-3");

            c = a.Mul(b);

            Assert.AreEqual("2", a.ToString());
            Assert.AreEqual("-3", b.ToString());
            Assert.AreEqual("-6", c.ToString());


            a = new LongInteger("11");
            b = new LongInteger("11");

            c = a.Mul(b);

            Assert.AreEqual("11", a.ToString());
            Assert.AreEqual("11", b.ToString());
            Assert.AreEqual("121", c.ToString());

            a = new LongInteger("123456789");
            b = new LongInteger("32165487");

            c = a.Mul(b);

            Assert.AreEqual("123456789", a.ToString());
            Assert.AreEqual("32165487", b.ToString());
            Assert.AreEqual("3971047741641243", c.ToString());

            a = new LongInteger("-123456789");
            b = new LongInteger("-32165487");

            c = a.Mul(b);

            Assert.AreEqual("-123456789", a.ToString());
            Assert.AreEqual("-32165487", b.ToString());
            Assert.AreEqual("3971047741641243", c.ToString());

            a = new LongInteger("0");
            b = new LongInteger("-32165487");

            c = a.Mul(b);

            Assert.AreEqual("0", a.ToString());
            Assert.AreEqual("-32165487", b.ToString());
            Assert.AreEqual("0", c.ToString());
        }

        [TestMethod]
        public void TestDiv()
        {
            var a = new LongInteger("12");
            var b = new LongInteger("3");

            var c = a.Div(b);

            Assert.AreEqual("12", a.ToString());
            Assert.AreEqual("3", b.ToString());
            Assert.AreEqual("4", c.ToString());

            a = new LongInteger("-12");
            b = new LongInteger("3");

            c = a.Div(b);

            Assert.AreEqual("-12", a.ToString());
            Assert.AreEqual("3", b.ToString());
            Assert.AreEqual("-4", c.ToString());


            a = new LongInteger("11");
            b = new LongInteger("11");

            c = a.Div(b);

            Assert.AreEqual("11", a.ToString());
            Assert.AreEqual("11", b.ToString());
            Assert.AreEqual("1", c.ToString());

            a = new LongInteger("-11");
            b = new LongInteger("-11");

            c = a.Div(b);

            Assert.AreEqual("-11", a.ToString());
            Assert.AreEqual("-11", b.ToString());
            Assert.AreEqual("1", c.ToString());

            a = new LongInteger("100");
            b = new LongInteger("3");

            c = a.Div(b);

            Assert.AreEqual("100", a.ToString());
            Assert.AreEqual("3", b.ToString());
            Assert.AreEqual("33", c.ToString());

            a = new LongInteger("100");
            b = new LongInteger("200");

            c = a.Div(b);

            Assert.AreEqual("100", a.ToString());
            Assert.AreEqual("200", b.ToString());
            Assert.AreEqual("0", c.ToString());

            a = new LongInteger("10000000000000000000000000000000000000000000000000000000000000000000000000");
            b = new LongInteger("2000000000000000000000000000000000000000000000000000000000000000000000000");

            c = a.Div(b);

            Assert.AreEqual("10000000000000000000000000000000000000000000000000000000000000000000000000", a.ToString());
            Assert.AreEqual("2000000000000000000000000000000000000000000000000000000000000000000000000", b.ToString());
            Assert.AreEqual("5", c.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivZero()
        {
            var a = new LongInteger("12");
            var b = new LongInteger("-0");

            a.Div(b);
        }

        [TestMethod]
        public void TestFactorial()
        {
            var a = new LongInteger("9");

            var c = a.Factorial();

            Assert.AreEqual("9", a.ToString());
            Assert.AreEqual("362880", c.ToString());

            a = new LongInteger("100");

            c = a.Factorial();

            Assert.AreEqual("100", a.ToString());
            Assert.AreEqual("93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000", c.ToString());

            a = new LongInteger("0");

            c = a.Factorial();

            Assert.AreEqual("0", a.ToString());
            Assert.AreEqual("1", c.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFactorialNegative()
        {
            var a = new LongInteger("-453453456366656456");

            a.Factorial();

            Assert.AreEqual("-453453456366656456", a.ToString());

        }

        [TestMethod]
        public void TestPow()
        {
            var a = new LongInteger("10");

            var c = a.Pow(2);

            Assert.AreEqual("10", a.ToString());
            Assert.AreEqual("100", c.ToString());

            a = new LongInteger("11");

            c = a.Pow(8);

            Assert.AreEqual("11", a.ToString());
            Assert.AreEqual("214358881", c.ToString());

            a = new LongInteger("-11");

            c = a.Pow(2);

            Assert.AreEqual("-11", a.ToString());
            Assert.AreEqual("121", c.ToString());

            a = new LongInteger("-11");

            c = a.Pow(3);

            Assert.AreEqual("-11", a.ToString());
            Assert.AreEqual("-1331", c.ToString());

            a = new LongInteger("23");

            c = a.Pow(0);

            Assert.AreEqual("23", a.ToString());
            Assert.AreEqual("1", c.ToString());


            a = new LongInteger("23");

            c = a.Pow(1);

            Assert.AreEqual("23", a.ToString());
            Assert.AreEqual("23", c.ToString());
        }

        [TestMethod]
        public void TestAryphOperations()
        {
            var a = new LongInteger("25");
            var b = new LongInteger("5");

            var c = a * b;

            Assert.AreEqual("25", a.ToString());
            Assert.AreEqual("5", b.ToString());
            Assert.AreEqual("125", c.ToString());

            c = a + b;

            Assert.AreEqual("25", a.ToString());
            Assert.AreEqual("5", b.ToString());
            Assert.AreEqual("30", c.ToString());

            c = a - b;

            Assert.AreEqual("25", a.ToString());
            Assert.AreEqual("5", b.ToString());
            Assert.AreEqual("20", c.ToString());

            c = a / b;

            Assert.AreEqual("25", a.ToString());
            Assert.AreEqual("5", b.ToString());
            Assert.AreEqual("5", c.ToString());

            c = a ^ 2;

            Assert.AreEqual("25", a.ToString());
            Assert.AreEqual("625", c.ToString());

            var d = a > b;

            Assert.AreEqual("25", a.ToString());
            Assert.AreEqual("5", b.ToString());
            Assert.AreEqual(true, d);

            d = a < b;

            Assert.AreEqual("25", a.ToString());
            Assert.AreEqual("5", b.ToString());
            Assert.AreEqual(false, d);

            d = a == b;

            Assert.AreEqual("25", a.ToString());
            Assert.AreEqual("5", b.ToString());
            Assert.AreEqual(false, d);

            b = new LongInteger("25");

            d = a == b;

            Assert.AreEqual("25", a.ToString());
            Assert.AreEqual("25", b.ToString());
            Assert.AreEqual(true, d);
        }

        [TestMethod]
        public void TestTypeCasting()
        {
            var a = new LongInteger("123");
            long b = a;

            Assert.AreEqual(b, 123);

            a = new LongInteger("-123");
            b = a;

            Assert.AreEqual(b, -123);
        }

        [TestMethod]
        public void TestTypeCastingImplicit()
        {
            var a = new LongInteger("123");
            var b = (long)a;

            Assert.AreEqual(b, 123);

            a = new LongInteger("-123");
            b = a;

            Assert.AreEqual(b, -123);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestTypeCastOverflow()
        {
            var a = new LongInteger("1230000000000000000000000000000000000000000000000000000000000000000000000000000");
            var b = (long)a;
        }
    }
}
