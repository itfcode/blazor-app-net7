namespace ITFCode.Core.DTO.FilterValues.Base
{
    public class FilterValue
    {
        public string Label { get; set; } = string.Empty;

        public bool Included { get; set; } = true;
    }

    public abstract class FilterValue<T> : FilterValue
    {
        public T Value { get; set; }
    }
}
