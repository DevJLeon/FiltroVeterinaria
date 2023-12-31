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
    public class PropietarioController : BaseApiController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly  IMapper mapper;
    
        public PropietarioController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PropietarioDto>>> Get()
        {
            var entidad = await unitofwork.Propietarios.GetAllAsync();
            return mapper.Map<List<PropietarioDto>>(entidad);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PropietarioDto>> Get(int id)
        {
            var entidad = await unitofwork.Propietarios.GetByIdAsync(id);
            if (entidad == null){
               return NotFound();
            }
            return this.mapper.Map<PropietarioDto>(entidad);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Propietario>> Post(PropietarioDto entidadDto)
        {
            var entidad = this.mapper.Map<Propietario>(entidadDto);
            this.unitofwork.Propietarios.Add(entidad);
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
        
        public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody]PropietarioDto entidadDto){
           if(entidadDto== null)
           {
               return NotFound();
           }
            var entidad= this.mapper.Map<Propietario>(entidadDto);
            unitofwork.Propietarios.Update(entidad);
            await unitofwork.SaveAsync();
            return entidadDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
           var entidad= await unitofwork.Propietarios.GetByIdAsync(id);
           if(entidad== null)
           {
              return NotFound();
           }
           unitofwork.Propietarios.Remove(entidad);
           await unitofwork.SaveAsync();
           return NoContent();
        }

        [HttpGet("Consulta4A")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> Consulta2A()
        {
            var nameVar = await unitofwork.Propietarios.Consulta2A();
            return mapper.Map<List<object>>(nameVar);
        }
    }