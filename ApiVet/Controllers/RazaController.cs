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
    public class RazaController : BaseApiController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly  IMapper mapper;
    
        public RazaController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RazaDto>>> Get()
        {
            var entidad = await unitofwork.Razas.GetAllAsync();
            return mapper.Map<List<RazaDto>>(entidad);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RazaDto>> Get(int id)
        {
            var entidad = await unitofwork.Razas.GetByIdAsync(id);
            if (entidad == null){
               return NotFound();
            }
            return this.mapper.Map<RazaDto>(entidad);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Raza>> Post(RazaDto entidadDto)
        {
            var entidad = this.mapper.Map<Raza>(entidadDto);
            this.unitofwork.Razas.Add(entidad);
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
        
        public async Task<ActionResult<RazaDto>> Put(int id, [FromBody]RazaDto entidadDto){
           if(entidadDto== null)
           {
               return NotFound();
           }
            var entidad= this.mapper.Map<Raza>(entidadDto);
            unitofwork.Razas.Update(entidad);
            await unitofwork.SaveAsync();
            return entidadDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
           var entidad= await unitofwork.Razas.GetByIdAsync(id);
           if(entidad== null)
           {
              return NotFound();
           }
           unitofwork.Razas.Remove(entidad);
           await unitofwork.SaveAsync();
           return NoContent();
        }
    }