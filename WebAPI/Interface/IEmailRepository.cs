using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Interface
{
    public interface IEmailRepository
    {
        
        IQueryable<Email> GetEmailTracks();
        Task<IQueryable<Email>> GetEmailTracksAsync();
    }
}
