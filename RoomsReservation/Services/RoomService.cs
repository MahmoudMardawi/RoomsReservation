using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoomsReservation.Db.Dtos;
using RoomsReservation.Db.Models;
using RoomsReservation.Db.Repositories.IRepositories;
using RoomsReservation.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomsReservation.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomsRepository _roomsRepository;
        private readonly IManagersRepository _managersRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomsRepository roomsRepository, IManagersRepository managersRepository, IMapper mapper)
        {
            _roomsRepository = roomsRepository;
            _managersRepository = managersRepository;
            _mapper = mapper;
        }

        public void Add(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            try
            {
                _roomsRepository.Add(room);
            }
            catch (DbUpdateException ex)
            {
                // handle unique constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {
                _roomsRepository.Delete(id);
            }
            catch (DbUpdateException ex)
            {
                // handle foreign key constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }
      
        public RoomDto Get(int id)
        {
            try
            {
                var room = _roomsRepository.GetById(id);
                return _mapper.Map<RoomDto>(room);
            }
            catch (DbUpdateException ex)
            {
                // handle unique constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }
        public void Update(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            try
            {
                _roomsRepository.Update(room);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // handle concurrency conflict
                Console.WriteLine(ex);
                throw;
            }
        }

        public IEnumerable<RoomDto> GetAll()
        {
            var rooms = _roomsRepository.GetAll();
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }
        public IEnumerable<ManagerDto> GetManagersForRoom(int id)
        {
            var managers = _roomsRepository.GetRoomsForManager(id);
            return _mapper.Map<IEnumerable<ManagerDto>>(managers);
        }
        public void AddManagerToRoom(int roomId, int managerId)
        {
            try
            {
                var room = _roomsRepository.GetById(roomId);
                var manager = _managersRepository.GetById(managerId);

                _roomsRepository.AddRoomToManager(room, manager);
            }
            catch (DbUpdateException ex)
            {
                // handle unique constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }
        public void RemoveManagerFromRoom(int roomId, int managerId)
        {
            try
            {
                var room = _roomsRepository.GetById(roomId);
                var manager = _managersRepository.GetById(managerId);
                _roomsRepository.RemoveRoomFromManager(room, manager);
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