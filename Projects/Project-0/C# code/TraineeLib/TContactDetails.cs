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
            return $"   Mobile number - {Num} \n   Email ID - {Email} \n   Address Lane - {Address} \n   City - {City} \n   State - {State} \n   Zipcode - {Zipcode}";
        }
    }
}