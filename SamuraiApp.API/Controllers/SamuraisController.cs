using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.API.DTO;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamuraiApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samurais;
        private readonly IMapper _mapper;

        public SamuraisController(ISamurai samurais, IMapper mapper)
        {
            _samurais = samurais;
            _mapper = mapper;

        }
        // GET: api/<SamuraisController>
        [HttpGet]
        public async Task<IEnumerable<SamuraiDTO>> Get()
        {
           var results = await _samurais.GetAll();
            var output = _mapper.Map<IEnumerable<SamuraiDTO>>(results);
           return output;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SamuraiDTO>> Get(int id)
        {
            var result = await _samurais.GetById(id);
            var output = _mapper.Map<SamuraiDTO>(result);
            if(output == null)
                return NotFound();
            else
                return Ok(output);
        }

        // POST api/<SamuraisController>
        [HttpPost]
        public async Task<IActionResult> Post(SamuraiCreateDTO samuraiCreateDTO)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurais.Insert(newSamurai);
                var samuraiDto = _mapper.Map<SamuraiDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, samuraiDto); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT api/<SamuraisController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, SamuraiCreateDTO samuraiCreateDTO)
        {
            try
            {
                var updateSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurais.Update(id, updateSamurai);
                var samuraiDTO = _mapper.Map<SamuraiDTO>(result);
  
                return Ok(samuraiDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SamuraisController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _samurais.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Tugas
        [HttpPost("Katana")]
        public async Task<IActionResult> Insert(KatanaInsertDTO katanaInsertDTO)
        {
            try
            {
                var newKatana = _mapper.Map<Katana>(katanaInsertDTO);
                var result = await _samurais.Insert(newKatana);
                var katanaDTO = _mapper.Map<KatanaDTO>(result);
                return CreatedAtAction("GetKatanaById", new { id = result.Id }, katanaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Elemen")]
        public async Task<ActionResult> InsertElemen(KatanaInsertDTO katanaInsertDTO)
        {
            try
            {
                var newKatana = _mapper.Map<Katana>(katanaInsertDTO);
                var result = await _samurais.Insert(newKatana);
                var katanaDTO = _mapper.Map<KatanaDTO>(result);
                return CreatedAtAction("GetKatanaById", new { id = result.Id }, katanaDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
