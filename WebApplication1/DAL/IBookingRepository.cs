using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int MaBooking);
        void InsertBooking(Booking MaBooking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int MaDv);
        void Save();
    }
}
