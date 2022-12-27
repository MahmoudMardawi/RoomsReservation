using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RoomsReservation.Db.Contexts;
using RoomsReservation.Db.Models;
using RoomsReservation.Db.Repositories.IRepositories;

namespace RoomsReservation.Db.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {

        private readonly RoomsReservationDbContext _context;

        public ReservationsRepository(RoomsReservationDbContext context)
        {
            _context = context;
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations.Find(id);
        }

        public IEnumerable<Reservation> GetByManagerId(int managerId)
        {
            return _context.Reservations.Where(x => x.ManagerId == managerId).ToList();
        }
        public IEnumerable<Reservation> GetByMemberId(int memberId)
        {
            return _context.Reservations.Where(x => x.MemberId == memberId).ToList();
        }
        public void Add(Reservation reservation)
        {
            try
            {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // handle unique constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }
        public void Update(Reservation reservation)
        {
            try
            {
                _context.Entry(reservation).State = EntityState.Modified;
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
            var reservation = _context.Reservations.Find(id);
            if (reservation == null)
            {
                return;
            }
            try
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // handle foreign key constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }
        public IEnumerable<Reservation> GetByRoomId(int roomId)
        {
            return _context.Reservations.Where(x => x.RoomId == roomId).ToList();
        }

    }
}
