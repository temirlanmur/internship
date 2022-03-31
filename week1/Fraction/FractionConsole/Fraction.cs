namespace FractionConsole
{
    public class Fraction
    {
        private int _numerator;
        private int _denominator;

        public int Numerator 
        {
            get => _denominator < 0 ? -_numerator : _numerator;
        }
        
        public int Denominator
        {
            get => _denominator < 0 ? -_denominator : _denominator;            
        }

        private Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        /// <summary>
        /// Static method to create a new Fraction object.
        /// Throws exception, if provided denominator value is equal to 0
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Fraction Create(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Fraction denominator cannot be equal to 0", nameof(denominator));

            if (numerator == 0)
                return new Fraction(0, 1);

            (numerator, denominator) = Reduce(numerator, denominator);            

            return new Fraction(numerator, denominator);
        }

        public override string ToString() => $"{Numerator}/{Denominator}";
        

        // Operations

        /// <summary>
        /// Adds fraction to the current fraction and returns result
        /// </summary>
        /// <param name="fraction">Fraction to add</param>
        /// <returns></returns>
        public Fraction Add(Fraction fraction)
        {
            int numerator = this.Numerator * fraction.Denominator + fraction.Numerator * this.Denominator;
            int denominator = this.Denominator * fraction.Denominator;

            (numerator, denominator) = Reduce(numerator, denominator);

            return new Fraction(numerator, denominator);
        }

        /// <summary>
        /// Substracts fraction from the current fraction and returns result
        /// </summary>
        /// <param name="fraction">Fraction to substract</param>
        /// <returns></returns>
        public Fraction Substract(Fraction fraction) => Add(fraction.UnaryMinus());

        /// <summary>
        /// Returns fraction that is opposite of the current
        /// </summary>
        /// <returns></returns>
        public Fraction UnaryMinus() => new Fraction(-_numerator, _denominator);

        /// <summary>
        /// Multiplies current fraction by another and returns result
        /// </summary>
        /// <param name="fraction">Fraction by which to multiply</param>
        /// <returns></returns>
        public Fraction Multiply(Fraction fraction)
        {
            int numerator = this.Numerator * fraction.Numerator;
            int denominator = this.Denominator * fraction.Denominator;

            (numerator, denominator) = Reduce(numerator, denominator);

            return new Fraction(numerator, denominator);
        }

        /// <summary>
        /// Divides current fraction by another and returns result.
        /// Throws exception, if divisor is equal to 0
        /// </summary>
        /// <param name="fraction">Fraction by which to divide</param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException"></exception>
        public Fraction Divide(Fraction fraction)
        {
            if (fraction.Numerator == 0)
                throw new DivideByZeroException();

            int numerator = this.Numerator * fraction.Denominator;
            int denominator = this.Denominator * fraction.Numerator;

            (numerator, denominator) = Reduce(numerator, denominator);

            return new Fraction(numerator, denominator);
        }

        /// <summary>
        /// Returns the value of the fraction converted to double
        /// </summary>
        /// <returns></returns>
        public double ToDouble() => (double)this.Numerator / this.Denominator;
        
        public override int GetHashCode() => this.ToDouble().GetHashCode();        

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            var objectType = obj.GetType();

            if (objectType == typeof(int) 
                || objectType == typeof(double) 
                || objectType == typeof(float)
                || objectType == typeof(decimal))
            {
                var objectAsDouble = Convert.ToDouble(obj);
                var objectHash = objectAsDouble.GetHashCode();
                return this.GetHashCode() == objectHash;
            }  
            
            if (objectType == typeof(Fraction))
                return this.GetHashCode() == obj.GetHashCode();

            return false;
        }


        // Utils

        /// <summary>
        /// Reduces numerator & denominator of the fraction
        /// </summary>
        /// <param name="numerator">Fraction numerator</param>
        /// <param name="denominator">Fraction denominator</param>
        /// <returns></returns>
        private static (int reducedNumerator, int reducedDenominator) Reduce(int numerator, int denominator)
        {                    
            var divisor = GCD(numerator, denominator);                       

            return (numerator / divisor, denominator / divisor);
        }

        /// <summary>
        /// Returns gcd of two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int GCD(int a, int b)
        {
            if (a == 0)
                return b;

            return GCD(b % a, a);
        }
    }

}
