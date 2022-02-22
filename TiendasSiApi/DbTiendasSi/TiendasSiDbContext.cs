using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendasSiApi.Entities;

namespace TiendasSiApi.DbTiendasSi
{
    public class TiendasSiDbContext : DbContext
    {
        public TiendasSiDbContext(DbContextOptions options) : base(options){}
        public DbSet<TiendasSiProducto> TiendasSiProducto { get; set; }
        public DbSet<TiendasSiTipoProducto> TiendasSiTipoProducto { get; set; }
    }
}
