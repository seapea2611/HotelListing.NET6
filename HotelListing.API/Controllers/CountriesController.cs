using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using HotelListing.API.Model.Country;
using AutoMapper;
using HotelListing.API.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IMapper _mapper;

        public CountriesController( IMapper mapper, ICountriesRepository countriesRepository)
        {
            this._mapper = mapper;
            this._countriesRepository = countriesRepository;
        }

        //GET : api/COuntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var con = await _countriesRepository.GetAllAsync();
            var record = _mapper.Map<List<GetCountryDto>>(con);
            return Ok(record);
        }

        // GET: api/COuntries/5
        [HttpGet("{id}")]
  
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {

            var country = await _countriesRepository.GetDetail(id);
            if (country == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<CountryDto>(country);
            return Ok(record);
        }

        // PUT api/COuntries/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updatecountryDto)
        {
            if(id != updatecountryDto.Id)
            {
                return BadRequest();
            }
            /*_context.Entry(country).State = EntityState.Modified;*/

            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            _mapper.Map(updatecountryDto,country);

            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
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

        // GET: Countries/Create

      /*  public IActionResult Create()
        {
            return View();
        }*/

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        /* [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> PostCountry(CreateCountryDto countryDto)
        {
            
             var country = _mapper.Map<Country>(countryDto);
            await _countriesRepository.AddAsync(country);
                
            return CreatedAtAction("GetCountry", new { id = country.Id}, country);
        }

        // GET: Countries/Edit/5
        
      /*  public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
*/
        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
      /*  // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortName")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }*/

        // POST: Countries/Delete/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if(country == null)
            {
                return NotFound();
            }
            _countriesRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
