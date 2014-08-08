namespace Core.CM
{
    public class OrderAddress
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { set; get; }

        public string Zip { set; get; }

        public string Phone { set; get; }

        public string AddressType { get; set; }
        public int? CodeVal { get; set; }
    }
}
