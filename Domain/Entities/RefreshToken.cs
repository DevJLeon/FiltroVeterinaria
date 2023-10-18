using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class RefreshToken:BaseEntity
{
    public int UsuarioIdFk {get;set;}
    public Usuario Usuario {get;set;}
    public string Token {get;set;}
    public DateTime Expires {get;set;}
    public DateTime Created {get;set;}
    public DateTime? Revoked {get;set;}
    public bool IsExpired => DateTime.UtcNow >= Expires;
    public bool IsActive => Revoked == null && !IsExpired;
}