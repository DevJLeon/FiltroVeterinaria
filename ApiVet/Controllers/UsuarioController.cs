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
    public class UsuarioController : BaseApiController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly  IMapper mapper;
    
        public UsuarioController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
        {
            var entidad = await unitofwork.Usuarios.GetAllAsync();
            return mapper.Map<List<UsuarioDto>>(entidad);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            var entidad = await unitofwork.Usuarios.GetByIdAsync(id);
            if (entidad == null){
               return NotFound();
            }
            return this.mapper.Map<UsuarioDto>(entidad);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Usuario>> Post(UsuarioDto entidadDto)
        {
            var entidad = this.mapper.Map<Usuario>(entidadDto);
            this.unitofwork.Usuarios.Add(entidad);
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
        
        public async Task<ActionResult<UsuarioDto>> Put(int id, [FromBody]UsuarioDto entidadDto){
           if(entidadDto== null)
           {
               return NotFound();
           }
            var entidad= this.mapper.Map<Usuario>(entidadDto);
            unitofwork.Usuarios.Update(entidad);
            await unitofwork.SaveAsync();
            return entidadDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
           var entidad= await unitofwork.Usuarios.GetByIdAsync(id);
           if(entidad== null)
           {
              return NotFound();
           }
           unitofwork.Usuarios.Remove(entidad);
           await unitofwork.SaveAsync();
           return NoContent();
        }
    }