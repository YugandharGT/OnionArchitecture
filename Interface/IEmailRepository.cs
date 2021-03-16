using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Interface
{
    public interface IEmailRepository
    {
        
        IQueryable<Email> GetEmailTracks();
        Task<IQueryable<Email>> GetEmailTracksAsync();
    }
}
