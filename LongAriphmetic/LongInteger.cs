using System;
using System.Linq;

namespace LongAriphmetic
{
    public class LongInteger
    {
        #region Fields

        private const string Chars = "1234567890";
        private const string Zero = "0";
        private readonly string _value;
        private bool _isPositive = true;

        #endregion

        #region .ctor

        public LongInteger()
        {
            _value = Zero;
        }

        public LongInteger(string longint)
        {
            if (longint.StartsWith("-"))
            {
                longint = longint.Remove(0, 1);
                _isPositive = false;
            }

            if (longint.StartsWith("+"))
            {
                longint = longint.Remove(0, 1);
            }

            foreach (var s in longint.ToArray())
            {
                var c = s;
                if (!Chars.Any(x => x == c))
                {
                    throw new ArgumentException();
                }
            }

            _value = longint.TrimStart('0');

            if (_value == string.Empty)
            {
                _value = Zero;
            }

            if (_value == Zero)
            {
                _isPositive = true;
            }
        }

        #endregion

        #region Operations

        public LongInteger Sub(LongInteger toSub)
        {
            string num1;
            string num2;

            GetEqualLenghtStrings(this, toSub, out num1, out num2);

            if (_isPositive && !toSub._isPositive)
            {
                var tmp = new LongInteger(toSub._value)
                {
                    _isPositive = true
                };
                return SumLogic(tmp);
            }

            if (!_isPositive && toSub._isPositive)
            {
                var a = new LongInteger(_value) { _isPositive = true };
                var b = new LongInteger(toSub._value) { _isPositive = true };
                var res = a.SumLogic(b);
                res._isPositive = false;

                return res;
            }

            if (!_isPositive && !toSub._isPositive)
            {
                var a = new LongInteger(_value);
                var b = new LongInteger(toSub._value);
                var res = b.SubLogic(a);

                return res;
            }

            return SubLogic(toSub);
        }

        public LongInteger Sum(LongInteger toSum)
        {
            string num1;
            string num2;

            GetEqualLenghtStrings(this, toSum, out num1, out num2);

            if (_isPositive && !toSum._isPositive)
            {
                var tmp = new LongInteger(toSum._value)
                {
                    _isPositive = true
                };
                return Sub(tmp);
            }

            if (!_isPositive && toSum._isPositive)
            {
                var a = new LongInteger(_value) { _isPositive = true };
                var b = new LongInteger(toSum._value) { _isPositive = true };
                var res = a.Sub(b);
                res._isPositive = false;

                return res;
            }

            if (!_isPositive && !toSum._isPositive)
            {
                var a = new LongInteger(_value);
                var b = new LongInteger(toSum._value);
                var res = b.SumLogic(a);
                res._isPositive = false;

                return res;
            }

            return SumLogic(toSum);
        }

        public LongInteger Mul(LongInteger toMul)
        {
            if ((_value == Zero) || (toMul._value == Zero))
            {
                return new LongInteger();
            }

            var result = new LongInteger() ;
            var res = new LongInteger();

            for (var i = 0; i < _value.Length; i++)
            {
                for (var j = 0; j < int.Parse(_value[i].ToString()); j++)
                {
                    res = new LongInteger(res.SumLogic(toMul)._value);
                }

                for (var j = 0; j < _value.Length - i - 1; j++)
                {
                    res = new LongInteger(res._value + Zero);
                }

                result = result.SumLogic(res);
                res = new LongInteger();
            }

            result._isPositive = !_isPositive ^ toMul._isPositive;

            return result;
        }

        public LongInteger Div(LongInteger toDiv)
        {
            if (toDiv == new LongInteger())
            {
                throw new DivideByZeroException();
            }

            if (Compare(new LongInteger(_value), new LongInteger(toDiv._value)) == 0)
            {
                return new LongInteger("1");
            }

            if (Compare(new LongInteger(_value), new LongInteger(toDiv._value)) < 0)
            {
                return new LongInteger();
            }

            var result = new LongInteger();
            var res = new LongInteger();
            var num = new LongInteger(_value);
            LongInteger res1;
            int j;

            for (int i = 0; i <= _value.Length - toDiv._value.Length;i++ )
            {
                if (Compare(new LongInteger(num._value), new LongInteger(toDiv._value)) >= 0)
                {
                    for (int k = 0; k < toDiv._value.Length; k++)
                    {
                        res = new LongInteger(res._value + num._value[k]);
                    }
                    if (res._value.Length < num._value.Length)
                    {
                        res = new LongInteger(res._value + num._value[res._value.Length]);
                        i++;
                    }
                    for (int k = 0; k < toDiv._value.Length; k++)
                    {
                        if (Compare(new LongInteger(res._value), new LongInteger(toDiv._value)) < 0)
                        {
                            if (res._value.Length < num._value.Length)
                            {
                                res = new LongInteger(res._value + num._value[res._value.Length]);
                                i++;
                                result = new LongInteger(result._value + Zero);
                            }
                        }
                    }

                }
                for (j = 0; j < 9; j++)
                {
                    if (Compare(new LongInteger(res._value), new LongInteger(toDiv._value)) < 0)
                    {
                        break;
                    }

                    res = res.SubLogic(toDiv);
                }

                res1 = toDiv.Mul(new LongInteger(j.ToString()));

                for (var k = 0; k < _value.Length - toDiv._value.Length - 1; k++)
                {
                    res1 = new LongInteger(res1._value + Zero);
                }

                num = num.SubLogic(res1);
                result = new LongInteger(result._value + j);
                res = new LongInteger();
            }

            result._isPositive = !_isPositive ^ toDiv._isPositive;

            return result;
        }

        public LongInteger Factorial()
        {
            if (Compare(this, new LongInteger()) < 0)
            {
                throw new ArgumentException();
            }

            if (Compare(this, new LongInteger()) == 0)
            {
                return new LongInteger("1");
            }

            var result = new LongInteger(_value);

            for (var i = new LongInteger("1"); Compare(i, this) != 0; i = i.Sum(new LongInteger("1")))
            {
                result = result.Mul(i);
            }

            return result;
        }

        public LongInteger Pow(int x)
        {
            var result = new LongInteger("1");
            
            for (var i = 1; i <= x; i++)
            {
                result = result.Mul(this);
            }

            return result;
        }

        #endregion

        #region Operators

        public static LongInteger operator + (LongInteger left, LongInteger right)
        {
            return left.Sum(right);
        }

        public static LongInteger operator - (LongInteger left, LongInteger right)
        {
            return left.Sub(right);
        }

        public static LongInteger operator * (LongInteger left, LongInteger right)
        {
            return left.Mul(right);
        }

        public static LongInteger operator / (LongInteger left, LongInteger right)
        {
            return left.Div(right);
        }

        public static LongInteger operator ^ (LongInteger left, int right)
        {
            return left.Pow(right);
        }

        public static bool operator > (LongInteger left, LongInteger right)
        {
            if (Compare(left,right)>0) return true;
            return false;
        }

        public static bool operator == (LongInteger left, LongInteger right)
        {
			if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            {
                return true;
            }

			if (ReferenceEquals(left, null))
            {
                return right.Equals(left);
            }

            return left.Equals(right);
        }

        public static bool operator != (LongInteger left, LongInteger right)
        {
            return !(left == right);
        }

        public static bool operator < (LongInteger left, LongInteger right)
        {
            if (Compare(left, right) < 0) return true;
            return false;
        }

        public static implicit operator long(LongInteger d)
        {
            try
            {
                var l = long.Parse(d._value);
                return d._isPositive ? l : -l;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        public static implicit operator double(LongInteger d)
        {
            try
            {
                var l = double.Parse(d._value);
                return d._isPositive ? l : -l;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        #endregion

        #region Logic

        public static int Compare(LongInteger a, LongInteger b)
        {
            if (a == null && b == null)
            {
                return 0;
            }

            if (a == null)
            {
                return -1;
            }

            if (b == null)
            {
                return 1;
            }

            if (a._isPositive && !b._isPositive)
            {
                return 1;
            }

            if (!a._isPositive && b._isPositive)
            {
                return -1;
            }

            if (!a._isPositive && !b._isPositive)
            {
                var aa = new LongInteger(a._value);
                var bb = new LongInteger(b._value);

                return Compare(bb, aa);
            }

            if (a._value.Length > b._value.Length)
            {
                return 1;
            }

            if (a._value.Length < b._value.Length)
            {
                return -1;
            }

            if (a._value.Length == b._value.Length)
            {
                if (a._value == b._value) return 0;

                for (var i = 0; i < a._value.Length; i++)
                {
                    var aVal = int.Parse(a._value[i].ToString());
                    var bVal = int.Parse(b._value[i].ToString());

                    var compare = aVal.CompareTo(bVal);

                    var isEqual = compare == 0;

                    if (!isEqual)
                    {
                        return compare;
                    }
                }
            }

            throw new ArgumentException();
        }

        private LongInteger SumLogic(LongInteger longint2)
        {
            var result = string.Empty;
            var d = 0;
            string num1;
            string num2;
            GetEqualLenghtStrings(this, longint2, out num1, out num2);

            for (var i = num1.Length - 1; i >= 0; i--)
            {
                var firstSumming = int.Parse(num1[i].ToString());
                var secondSumming = int.Parse(num2[i].ToString());

                var sum = firstSumming + secondSumming + d;
                d = 0;
                if (sum > 9)
                {
                    d = sum / 10;
                    sum = sum % 10;
                }

                result = sum + result;
            }

            if (d != 0)
            {
                result = d + result;
            }

            return new LongInteger(result);
        }

        private LongInteger SubLogic(LongInteger toSub)
        {
            string num1;
            string num2;
            var d = 0;
            var result = string.Empty;

            GetEqualLenghtStrings(this, toSub, out num1, out num2);

            if (Compare(new LongInteger(_value), new LongInteger(toSub._value)) < 0)
            {
                var a = new LongInteger(_value);
                var b = new LongInteger(toSub._value);
                var res = b.Sub(a);
                res._isPositive = !res._isPositive;

                return res;
            }

            for (var i = num1.Length - 1; i >= 0; i--)
            {
                var chislo = int.Parse(num1[i].ToString());
                var vichitaemoe = int.Parse(num2[i].ToString());
                var sub = chislo - vichitaemoe + d;

                d = 0;

                if (sub < 0)
                {
                    d = -1;
                    sub = sub + 10;
                }

                result = sub + result;
            }


            result = result.TrimStart('0');

            return new LongInteger(result);
        }

        private static void GetEqualLenghtStrings(
           LongInteger longint1,
           LongInteger longint2,
           out string num1,
           out string num2)
        {
            num1 = string.Empty;
            num2 = string.Empty;

            var difLen = Math.Abs(longint1._value.Length - longint2._value.Length);

            if (longint1._value.Length > longint2._value.Length)
            {
                num1 = longint1._value;
                for (var j = 0; j < difLen; j++)
                {
                    num2 += Zero;
                }

                num2 += longint2._value;
            }
            else
            {
                num2 = longint2._value;
                for (var j = 0; j < difLen; j++)
                {
                    num1 += Zero;
                }

                num1 += longint1._value;
            }
        }

        #endregion

        #region System.Object

        public override string ToString()
        {
            return _isPositive ? _value : "-" + _value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof (LongInteger) && Equals((LongInteger) obj);
        }

        public bool Equals(LongInteger other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._value, _value) && other._isPositive.Equals(_isPositive);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0)*397) ^ _isPositive.GetHashCode();
            }
        }

        #endregion
    }
}
