namespace HotelProject.WebUI.Dtos.BookingDto
{
    public class UpdateBookingDto
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string AdultCount { get; set; }
        public string ChildCount { get; set; }
        public int RoomCount { get; set; }
        public int SpecialRequest { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
