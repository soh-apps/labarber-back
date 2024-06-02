namespace LaBarber.Application.Extensions
{
    public static class IntegerNullableExtensions
    {
        public static bool IsStrictlyPositive(this int? value)
        {
            if (value == null) return false;
            return value.Value > 0;
        }
    }
}
