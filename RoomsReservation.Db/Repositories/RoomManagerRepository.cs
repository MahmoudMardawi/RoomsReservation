using RoomsReservation.Db.Contexts;
using RoomsReservation.Db.Models;
using RoomsReservation.Db.Repositories.IRepositories;

namespace RoomsReservation.Db.Repositories
{
    public class RoomManagerRepository : IRoomManagerRepository
    {
        private readonly RoomsReservationDbContext _dbContext;

        public RoomManagerRepository(RoomsReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RoomManager GetById(int id)
        {
            return _dbContext.RoomManagers.Find(id);
        }

        public IEnumerable<RoomManager> GetAll()
        {
            return _dbContext.RoomManagers;
        }

        public void Add(RoomManager roomManager)
        {
            _dbContext.RoomManagers.Add(roomManager);
            _dbContext.SaveChanges();
        }

        public void Update(RoomManager roomManager)
        {
            _dbContext.RoomManagers.Update(roomManager);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var roomManager = _dbContext.RoomManagers.Find(id);
            _dbContext.RoomManagers.Remove(roomManager);
            _dbContext.SaveChanges();
        }
    }

}
