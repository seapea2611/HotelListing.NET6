using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Contracts;
using AutoMapper;
using HotelListing.API.Model.Hotels;
using HotelListing.API.Data;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : Controller
    {
        
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelsController( IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            this._mapper = mapper;
        }

        // GET: Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotel = await _hotelRepository.GetAllAsync();
            return Ok(_mapper.Map<List<HotelDto>>(hotel));
        }

        // GET: Hotels/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _hotelRepository.GetAsync(id); 
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<HotelDto>(hotel));
        }

        // GET: Hotels/Create
        /*public IActionResult Create()
        {
            return View();
        }*/

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, HotelDto hotelDto)
        {
            if (id != hotelDto.Id)
            {
                return NotFound();
            }

            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
            { 
                return NotFound();
            }

            _mapper.Map(hotelDto, hotel);
            try
            {
                await _hotelRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(hotel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostHotel(CreateHotelDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            await _hotelRepository.AddAsync(hotel);
            
            return CreatedAtAction("GetHotel", new {id = hotel.Id}, hotel);
        }

        // GET: Hotels/Edit/5
       /* public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }*/

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: Hotels/Delete/5
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }*/

        // POST: Hotels/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)

        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel != null)
            {
                _hotelRepository.DeleteAsync(id);
            }
            else
                return NotFound();
            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelRepository.Exists(id);
        }
    }
}
