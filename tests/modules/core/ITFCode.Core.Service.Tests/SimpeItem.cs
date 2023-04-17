namespace ITFCode.Core.Service.Tests
{
    public class SimpeItem
    {
        public bool BoolProp { get; set; }

        public bool? BoolNullableProp { get; set; }

        public string StringProp { get; set; }
        
        public DateTime DateProp { get; set; }
        
        public DateTime? DateNullableProp { get; set; }
       
        public double NumericProp { get; set; }
        
        public double? NumericNullableProp { get; set; }

        // byte, short, int, long, float, decimal

        public byte ByteProp { get; set; }
        public byte? ByteNullableProp { get; set; }

        public short ShortProp { get; set; }
        public short? ShortNullableProp { get; set; }

        public int IntProp { get; set; }
        public int? IntNullableProp { get; set; }

        public long LongProp { get; set; }
        public long? LongNullableProp { get; set; }

        public double DoubleProp { get; set; }
        public double? DoubleNullableProp { get; set; }

        public float FloatProp { get; set; }
        public float? FloatNullableProp { get; set; }

        public decimal DecimalProp { get; set; }
        public decimal? DecimalNullableProp { get; set; }

        public Guid GuidProp { get; set; }

        public Guid? GuidNullableProp { get; set; }
    }
}