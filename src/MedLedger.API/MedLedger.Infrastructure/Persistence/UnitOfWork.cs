using MedLedger.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLedger.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedLegderDbContext _context;
        public UnitOfWork(MedLegderDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
