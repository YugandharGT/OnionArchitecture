﻿using Entities;
using WebAPI.Data;
using WebAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Business
{
    public class EmailRepository : IEmailRepository
    {
        private readonly CoreDbContext db;

        public EmailRepository(CoreDbContext context)
        {
            db = context;
        }

        public IQueryable<Email> GetEmailTracks()
        {
            if (db != null)
            {
                return db.Set<Email>().AsQueryable();
            }
            return null;
        }

        public async Task<IQueryable<Email>> GetEmailTracksAsync()
        {
            if (db != null)
            {
                return await Task.Run( () => db.Set<Email>());
            }
            return null;
        }
    }
}
