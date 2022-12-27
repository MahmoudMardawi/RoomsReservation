using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoomsReservation.Db.Dtos;
using RoomsReservation.Db.Models;
using RoomsReservation.Db.Repositories.IRepositories;
using RoomsReservation.Services.IServices;

namespace RoomsReservation.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationsRepository _reservationsRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationsRepository reservationsRepository, IMapper mapper)
        {
            _reservationsRepository = reservationsRepository;
            _mapper = mapper;
        }

        public void Add(ReservationDto reservation)
        {
            var reservationToAdd = _mapper.Map<Reservation>(reservation);
            try
            {
                _reservationsRepository.Add(reservationToAdd);
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
            var reservation = _reservationsRepository.GetById(id);
            if (reservation == null)
            {
                return;
            }
            try
            {
                _reservationsRepository.Delete(id);
            }
            catch (DbUpdateException ex)
            {
                // handle foreign key constraint violation
                Console.WriteLine(ex);
                throw;
            }
        }

        public ReservationDto Get(int id)
        {
            var reservation = _reservationsRepository.GetById(id);
            return _mapper.Map<ReservationDto>(reservation);
        }

        public IEnumerable<ReservationDto> GetAll()
        {
            var reservations = _reservationsRepository.GetAll();
            return reservations.Select(r => _mapper.Map<ReservationDto>(r));
        }

        public void Update(ReservationDto reservation)
        {
            var reservationToUpdate = _mapper.Map<Reservation>(reservation);
            try
            {
                _reservationsRepository.Update(reservationToUpdate);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // handle concurrency conflict
                Console.WriteLine(ex);
                throw;
            }
        }

        public IEnumerable<ReservationDto> GetByMemberId(int memberId)
        {
            var reservations = _reservationsRepository.GetByMemberId(memberId);
            return reservations.Select(r => _mapper.Map<ReservationDto>(r));
        }

        public IEnumerable<ReservationDto> GetByRoomId(int roomId)
        {
            var reservations = _reservationsRepository.GetByRoomId(roomId);
            return reservations.Select(r => _mapper.Map<ReservationDto>(r));
        }

    }
}
