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
        [HttpGet("{id}",Name ="GetById")]
        public async Task<ActionResult<SamuraiDTO>> Get(int id)
        {
            var result = await _samurais.GetById(id);
            var output = _mapper.Map<SamuraiDTO>(result);
            if(output == null)
                return NotFound();
            else
                return Ok(output);
        }

        [HttpGet("Katana/{id}", Name = "GetKatanaById")]
        public async Task<ActionResult<KatanaDTO>> GetKatana(int id)
        {
            var result = await _samurais.GetKatanaById(id);
            var output = _mapper.Map<KatanaDTO>(result);
            if (output == null)
                return NotFound();
            else
                return Ok(output);
        }
        //Get Samurai with Katana
        [HttpGet("Samuka/{id}")]
        public async Task<ActionResult<SamuraiGetDTO>> GetSamurai(int id)
        {
            var getSamurai = await _samurais.GetSamurai(id);
            var output = _mapper.Map<SamuraiGetDTO>(getSamurai);
            if (output == null)
            {
                return NotFound();
            }
            else
            {
                 return Ok(output);
            }
                
        }
        //Get Samurai with Katana and Elemen
        [HttpGet("SKE/{id}")]
        public async Task<ActionResult<SamuraiGetDTO>> GetSamuraiElemen(int id)
        {
            var getSamurai = await _samurais.GetSamuraiElemen(id);
            var output = _mapper.Map<SamuraiGetDTO>(getSamurai);
            if (output == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(output);
            }

        }

        // POST api/<SamuraisController>
        [HttpPost]
        public async Task<ActionResult> Post(SamuraiCreateDTO samuraiCreateDTO)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurais.Insert(newSamurai);
                var samuraiDto = _mapper.Map<SamuraiDTO>(result);
                return CreatedAtRoute("GetById", new { id = result.Id }, samuraiDto); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Insert Samurai with Katana
        [HttpPost("SK")]
        public async Task<ActionResult> PostSamuraiKatana(SamuraiKatanaDTO samuraiKatanaDTO)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiKatanaDTO.SamuraiCreateDTOs);
                var result = await _samurais.Insert(newSamurai);
                var samuraiDto = _mapper.Map<SamuraiDTO>(result);
                foreach (var item in samuraiKatanaDTO.KatanaSamuraiDTOs)
                {
                    var newKatana = _mapper.Map<Katana>(item);
                    newKatana.SamuraiId = result.Id;
                    var results = await _samurais.Insert(newKatana);
                    var katanaDto = _mapper.Map<KatanaDTO>(results);
                }
                return CreatedAtRoute("GetById", new { id = result.Id }, samuraiDto);
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
        //Insert Katana
        [HttpPost("Katana")]
        public async Task<ActionResult> Insert(KatanaInsertDTO katanaInsertDTO)
        {
            try
            {
                var newKatana = _mapper.Map<Katana>(katanaInsertDTO);
                var result = await _samurais.Insert(newKatana);
                var katanaDTO = _mapper.Map<KatanaDTO>(result);
                return CreatedAtRoute("GetKatanaById", new { id = result.Id }, katanaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Insert Katana With Elemen
        [HttpPost("Elemen")]
        public async Task<ActionResult> InsertElemen(ElemenKatanaDTO elemenKatanaDTO)
        {

            try
            {
                List<int> elemenId = new List<int>();
                var newKatana = _mapper.Map<Katana>(elemenKatanaDTO.KatanaInsertDTO);
                var result = await _samurais.Insert(newKatana);
                var katanaDTO = _mapper.Map<KatanaDTO>(result);
                foreach (var item in elemenKatanaDTO.ElemenDTOs)
                {
                    var newElemen = _mapper.Map<Elemen>(item);
                    var elemen = await _samurais.Insert(newElemen);
                    var elemens = _mapper.Map<ElemenDTO>(elemen);
                    elemenId.Add(elemen.ElemenId);
                }
                foreach(var ele in elemenId)
                {
                    var elekata = new ElemenKatana
                    {
                        KatanaId = result.Id,
                        ElemenId = ele
                    };
                    await _samurais.Insert(elekata);
                }
                return CreatedAtRoute("GetKatanaById", new { id = result.Id }, katanaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
