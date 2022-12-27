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
    public class ManagerRepository : IManagersRepository
    {
        private readonly RoomsReservationDbContext _context;

        public ManagerRepository(RoomsReservationDbContext context)
        {
            _context = context;
        }

        public Manager GetById(int id)
        {
            return _context.Managers.Find(id);
        }

        public Manager GetByUsername(string username)
        {
            return _context.Managers.FirstOrDefault(x => x.Username == username);
        }

        public IEnumerable<Manager> GetAll()
        {
            return _context.Managers.ToList();
        }

        public void Add(Manager manager)
        {
            try
            {
                _context.Managers.Add(manager);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // handle unique constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }

        public void Update(Manager manager)
        {
            try
            {
                _context.Managers.Update(manager);
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
            var manager = _context.Managers.Find(id);
            if (manager != null)
            {
                try
                {
                    _context.Managers.Remove(manager);
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
        public void AddRoomToManager(int managerId, int roomId)
        {
            var manager = _context.Managers.Find(managerId);
            var room = _context.Rooms.Find(roomId);
            if (manager == null || room == null)
            {
                return;
            }
            manager.RoomManagers.Add(new RoomManager
            {
                Manager = manager,
                ManagerId = manager.Id,
                Room = room,
                RoomId = room.Id
            });
            _context.SaveChanges();
        }
        public IEnumerable<Room> GetRoomsForManager(int managerId)
        {
            var rooms = from rm in _context.RoomManagers
                        where rm.ManagerId == managerId
                        select rm.Room;
            return rooms;
        }
        public void RemoveRoomFromManager(int managerId, int roomId)
        {
            var roomManager = (from rm in _context.RoomManagers
                               where rm.ManagerId == managerId && rm.RoomId == roomId
                               select rm).FirstOrDefault();
            if (roomManager == null)
            {
                return;
            }
            _context.RoomManagers.Remove(roomManager);
            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

