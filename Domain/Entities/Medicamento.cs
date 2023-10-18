using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Medicamento:BaseEntity
{
    public string Nombre {get;set;}
    public int Cantidad {get;set;}
    public double Precio {get;set;}
    public int LaboratorioIdFk {get;set;}
    public Laboratorio Laboratorio {get;set;}
    public ICollection<MedicamentoProveedor> MedicamentoProveedores {get;set;}
    public ICollection<Proveedor> Proveedores {get;set;}
    public ICollection<DetalleMovimiento> DetalleMovimientos {get;set;}
    public ICollection<TratamientoMedico> TratamientosMedicos {get;set;}
}