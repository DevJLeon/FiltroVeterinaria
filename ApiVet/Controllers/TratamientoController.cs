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
    public class TratamientoController : BaseApiController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly  IMapper mapper;
    
        public TratamientoController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TratamientoDto>>> Get()
        {
            var entidad = await unitofwork.TratamientoMedicos.GetAllAsync();
            return mapper.Map<List<TratamientoDto>>(entidad);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TratamientoDto>> Get(int id)
        {
            var entidad = await unitofwork.TratamientoMedicos.GetByIdAsync(id);
            if (entidad == null){
               return NotFound();
            }
            return this.mapper.Map<TratamientoDto>(entidad);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TratamientoMedico>> Post(TratamientoDto varDto)
        {
            var var = this.mapper.Map<TratamientoMedico>(varDto);
            this.unitofwork.TratamientoMedicos.Add(var);
            await unitofwork.SaveAsync();
            if(var == null)
            {
                return BadRequest();
            }
            varDto.Id = var.Id;
            return CreatedAtAction(nameof(Post), new {id = varDto.Id}, varDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<ActionResult<TratamientoDto>> Put(int id, [FromBody]TratamientoDto entidadDto){
           if(entidadDto== null)
           {
               return NotFound();
           }
            var entidad= this.mapper.Map<TratamientoMedico>(entidadDto);
            unitofwork.TratamientoMedicos.Update(entidad);
            await unitofwork.SaveAsync();
            return entidadDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
           var entidad= await unitofwork.TratamientoMedicos.GetByIdAsync(id);
           if(entidad== null)
           {
              return NotFound();
           }
           unitofwork.TratamientoMedicos.Remove(entidad);
           await unitofwork.SaveAsync();
           return NoContent();
        }
    }