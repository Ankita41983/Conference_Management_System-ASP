using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace BLL.Services
{
    public class AuditoriumService
    {
        
            private IMapper _mapper;

            public AuditoriumService(IMapper mapper)
            {
                _mapper = mapper;
            }

            public List<AuditoriumDTO> GetAll()
            {
                var data = DataAccess.AuditoriumData().Get();
                var AuditoriumDTOs = _mapper.Map<List<AuditoriumDTO>>(data);
                return AuditoriumDTOs;
            }

            public AuditoriumDTO GetById(int id, AuditoriumDTO auditoriumDTO)
            {
                var data = DataAccess.AuditoriumData().Get(id);
                var AuditoriumDTOs = _mapper.Map<AuditoriumDTO>(data);
            return auditoriumDTO;
            }

            public bool AddVenue(VenueDTO venueDTO)
            {
                var venue = _mapper.Map<Venue>(venueDTO);
                return DataAccess.VenueData().Add(venue);
            }

            public bool UpdateVenue(VenueDTO venueDTO)
            {
                var venue = _mapper.Map<Venue>(venueDTO);
                return UpdateVenue(venue);
            }

            private bool UpdateVenue(Venue venue)
            {
                throw new NotImplementedException();
            }

            public bool DeleteVenue(int id)
            {
                return DataAccess.VenueData().DELETE(id);
            }
        }

        internal class AService
    {
            private IMapper _mapper;
            private object venueDTO;

            internal AService(IMapper mapper)
            {
                _mapper = mapper;
            }

            internal List<AuditoriumDTO> Get()
            {
                var data = DataAccess.AuditoriumData().GetAll();
                var AuditoriumDTOs = _mapper.Map<List<AuditoriumDTO>>(data);
                return AuditoriumDTOs;
            }

            public AuditoriumDTO GetById(int id)
            {
                var data = DataAccess.AuditoriumData().Get(id);
                var AuditoriumDTO = _mapper.Map<AuditoriumDTO>(data);
                return AuditoriumDTO;
            }

            public bool AddAuditorium(AuditoriumDTO AuditoriumDTO)
            {
                var Auditorium = _mapper.Map<Auditorium>(AuditoriumDTO);
                return DataAccess.AuditoriumData().Add(Auditorium);
            }

        public bool UpdateAuditorium(AuditoriumDTO AuditoriumDTO)
            {
                var Auditorium = _mapper.Map<Auditorium>(AuditoriumDTO);
                return DataAccess.AuditoriumData().Update(Auditorium);
            }

            public bool DeleteAuditorium(int id)
            {
                return DataAccess.AuditoriumData().Delete(id);
            }
        }
    }
