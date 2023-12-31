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
    public class TipoMovimientoController : BaseApiController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly  IMapper mapper;
    
        public TipoMovimientoController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoMovimientoDto>>> Get()
        {
            var entidad = await unitofwork.TipoMovimientos.GetAllAsync();
            return mapper.Map<List<TipoMovimientoDto>>(entidad);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoMovimientoDto>> Get(int id)
        {
            var entidad = await unitofwork.TipoMovimientos.GetByIdAsync(id);
            if (entidad == null){
               return NotFound();
            }
            return this.mapper.Map<TipoMovimientoDto>(entidad);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoMovimiento>> Post(TipoMovimientoDto entidadDto)
        {
            var entidad = this.mapper.Map<TipoMovimiento>(entidadDto);
            this.unitofwork.TipoMovimientos.Add(entidad);
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
        
        public async Task<ActionResult<TipoMovimientoDto>> Put(int id, [FromBody]TipoMovimientoDto entidadDto){
           if(entidadDto== null)
           {
               return NotFound();
           }
            var entidad= this.mapper.Map<TipoMovimiento>(entidadDto);
            unitofwork.TipoMovimientos.Update(entidad);
            await unitofwork.SaveAsync();
            return entidadDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
           var entidad= await unitofwork.TipoMovimientos.GetByIdAsync(id);
           if(entidad== null)
           {
              return NotFound();
           }
           unitofwork.TipoMovimientos.Remove(entidad);
           await unitofwork.SaveAsync();
           return NoContent();
        }
    }