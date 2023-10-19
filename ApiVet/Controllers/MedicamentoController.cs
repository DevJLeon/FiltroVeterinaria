using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiVet.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVet.Controllers;
public class MedicamentoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public MedicamentoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
    {
        var entidad = await unitofwork.Medicamentos.GetAllAsync();
        return mapper.Map<List<MedicamentoDto>>(entidad);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoDto>> Get(int id)
    {
        var entidad = await unitofwork.Medicamentos.GetByIdAsync(id);
        if (entidad == null){
           return NotFound();
        }
        return this.mapper.Map<MedicamentoDto>(entidad);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medicamento>> Post(MedicamentoDto entidadDto)
    {
        var entidad = this.mapper.Map<Medicamento>(entidadDto);
        this.unitofwork.Medicamentos.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<ActionResult<MedicamentoDto>> Put(int id, [FromBody]MedicamentoDto entidadDto){
       if(entidadDto== null)
       {
           return NotFound();
       }
        var entidad= this.mapper.Map<Medicamento>(entidadDto);
        unitofwork.Medicamentos.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var entidad= await unitofwork.Medicamentos.GetByIdAsync(id);
       if(entidad== null)
       {
          return NotFound();
       }
       unitofwork.Medicamentos.Remove(entidad);
       await unitofwork.SaveAsync();
       return NoContent();
    }
    [HttpGet("Consulta2A")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> Consulta2A()
    {
        var nameVar = await unitofwork.Medicamentos.Consulta2A();
        return mapper.Map<List<object>>(nameVar);
    }
}