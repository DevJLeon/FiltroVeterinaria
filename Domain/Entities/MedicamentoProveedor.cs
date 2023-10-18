using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MedicamentoProveedor
{
    public int MedicamentoIdFk {get;set;}
    public Medicamento Medicamento {get;set;}
    public int ProveedorIdFk {get;set;}
    public Proveedor Proveedor {get;set;}
}