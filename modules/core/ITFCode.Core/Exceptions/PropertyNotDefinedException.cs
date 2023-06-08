namespace ITFCode.Core.Exceptions
{
    public class PropertyNotDefinedException : Exception
    {
        public PropertyNotDefinedException(string propertyName) : base($"Property '{propertyName}' not defined")
        {
        }
    }
}
