using Microsoft.EntityFrameworkCore;
using RoomsReservation.Db.Contexts;
using RoomsReservation.Db.Models;
using RoomsReservation.Db.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsReservation.Db.Repositories
{
    public class MemberRepository : IMembersRepository
    {
        private readonly RoomsReservationDbContext _context;
        public MemberRepository(RoomsReservationDbContext context)
        {
            _context = context;
        }

        public Member GetById(int id)
        {
            return _context.Members.Find(id);
        }

        public Member GetByUsername(string username)
        {
            return _context.Members.FirstOrDefault(x => x.Username == username);
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members.ToList();
        }

        public void Add(Member member)
        {
            try
            {
                _context.Members.Add(member);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // handle unique constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }

        public void Update(Member member)
        {
            try
            {
                _context.Members.Update(member);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // handle concurrency conflict
                Console.WriteLine(ex);
                throw;
            }
        }
        public void Delete(int id)
        {
            var member = _context.Members.Find(id);
            if (member == null)
            {
                return;
            }
            try
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // handle foreign key constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }




    }
}
