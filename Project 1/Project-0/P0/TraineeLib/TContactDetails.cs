namespace Trainer
{
    public class TContactDetails
    { 
        public long Num { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public string? Email { get; set; }
        public int Tid { get; set; }

        public TContactDetails() { }

        public override string ToString()
        {
            return $"Mobile number - {Num} \nEmail ID - {Email} \nAddress Lane - {Address} \nCity - {City} \nState - {State} \nZipcode - {Zipcode}";
        }
    }
}