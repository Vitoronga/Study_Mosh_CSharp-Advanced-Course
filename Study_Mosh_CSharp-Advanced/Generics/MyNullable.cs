namespace Study_Mosh_CSharp_Advanced.Generics
{
    public class MyNullable<T> where T : struct
    {
        private object _value;

        public MyNullable()
        {

        }

        public MyNullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueOrDefault()
        {
            if (HasValue) return (T)_value;

            return default;
        }
    }
}
