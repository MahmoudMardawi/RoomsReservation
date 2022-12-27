using AutoMapper;
using RoomsReservation.Db.Dtos; 
using RoomsReservation.Db.Models;
using RoomsReservation.Db.Repositories.IRepositories;
using RoomsReservation.Services.IServices;
using System.Collections.Generic;

namespace RoomsReservation.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagersRepository _managersRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly IMapper _mapper;

        public ManagerService(IManagersRepository managersRepository, IRoomsRepository roomsRepository, IMapper mapper)
        {
            _managersRepository = managersRepository;
            _roomsRepository = roomsRepository;
            _mapper = mapper;
        }

        public void Add(ManagerDto managerDto)
        {
            var manager = _mapper.Map<Manager>(managerDto);
            _managersRepository.Add(manager);
            _managersRepository.SaveChanges();
        }

        public void AddRoomToManager(int managerId, int roomId)
        {
            var manager = _managersRepository.GetById(managerId);
            var room = _roomsRepository.GetById(roomId);
            manager.RoomManagers.Add(new RoomManager { Manager = manager, Room = room });
            _managersRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _managersRepository.Delete(id);
            _managersRepository.SaveChanges();
        }

        public ManagerDto GetById(int id)
        {
            var manager = _managersRepository.GetById(id);
            return _mapper.Map<ManagerDto>(manager);
        }

        public ManagerDto GetByUsername(string username)
        {
            var manager = _managersRepository.GetByUsername(username);
            return _mapper.Map<ManagerDto>(manager);
        }

        public IEnumerable<ManagerDto> GetAll()
        {
            var managers = _managersRepository.GetAll();
            return _mapper.Map<IEnumerable<ManagerDto>>(managers);
        }

        public IEnumerable<RoomDto> GetRoomsForManager(int managerId)
        {
            var rooms = _managersRepository.GetRoomsForManager(managerId);
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public void RemoveRoomFromManager(int managerId, int roomId)
        {
            var manager = _managersRepository.GetById(managerId);
            var room = _roomsRepository.GetById(roomId);
            var roomManager = new RoomManager { Manager = manager, Room = room };
            manager.RoomManagers.Remove(roomManager);
            _managersRepository.SaveChanges();
        }

        public void Update(ManagerDto managerDto)
        {
            var manager = _mapper.Map<Manager>(managerDto);
            _managersRepository.Update(manager);
            _managersRepository.SaveChanges();
        }
    }
}