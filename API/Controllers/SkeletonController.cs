/* using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

// Entity1, entity2, Entities3, entities4

public class Entity1Controller : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Entity1Controller(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Entity1Dto>>> Get()
    {
        var entities4 = await _unitOfWork.Entities3.GetAllAsync();
        return _mapper.Map<List<Entity1Dto>>(entities4);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Entity1Dto>>> Get11([FromQuery] Params entity2Params)
    {
        var entity2 = await _unitOfWork.Entities3.GetAllAsync(entity2Params.PageIndex,entity2Params.PageSize,entity2Params.Search);
        var lstEntities3Dto = _mapper.Map<List<Entity1Dto>>(entity2.registros);
        return new Pager<Entity1Dto>(lstEntities3Dto,entity2.totalRegistros,entity2Params.PageIndex,entity2Params.PageSize,entity2Params.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Entity1Dto>> Get(int id)
    {
        var entity2 = await _unitOfWork.Entities3.GetByIdAsync(id);
        if (entity2 == null){
            return NotFound();
        }
        return _mapper.Map<Entity1Dto>(entity2);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Entity1>> Post(Entity1Dto entity2Dto){
        var entity2 = _mapper.Map<Entity1>(entity2Dto);
        this._unitOfWork.Entities3.Add(entity2);
        await _unitOfWork.SaveAsync();
        if (entity2 == null)
        {
            return BadRequest();
        }
        entity2Dto.Id = entity2.Id;
        return CreatedAtAction(nameof(Post),new {id= entity2Dto.Id}, entity2Dto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Entity1Dto>> Put(int id, [FromBody]Entity1Dto entity2Dto){
        if(entity2Dto == null)
            return NotFound();
        var entities4 = _mapper.Map<Entity1>(entity2Dto);
        _unitOfWork.Entities3.Update(entities4);
        await _unitOfWork.SaveAsync();
        return entity2Dto;
        
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entity2 = await _unitOfWork.Entities3.GetByIdAsync(id);
        if(entity2 == null){
            return NotFound();
        }
        _unitOfWork.Entities3.Remove(entity2);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
} */