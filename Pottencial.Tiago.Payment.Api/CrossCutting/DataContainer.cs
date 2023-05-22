namespace Pottencial.Tiago.Payment.Api.CrossCutting
{
    public class DataContainer
    {
        public DataContainer(object dataA, object dataB)
        {
            Product = dataA;
            Units = dataB;
        }

        public object Product { get; set; }
        public object Units { get; set; }
    }
}
