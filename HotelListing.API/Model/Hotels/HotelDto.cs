using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Model.Hotels
{
    public class HotelDto : BaseHotelDto
    {
        public int Id { get; set; }
       
    }
}
