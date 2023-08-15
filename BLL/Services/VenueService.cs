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
    public class VenueService
    {
        private IMapper _mapper;

        public VenueService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<VenueDTO> GetAll()
        {
            var data = DataAccess.VenueData().Get();
            var venueDTOs = _mapper.Map<List<VenueDTO>>(data);
            return venueDTOs;
        }

        public VenueDTO GetById(int id)
        {
            var data = DataAccess.VenueData().Get(id);
            var venueDTO = _mapper.Map<VenueDTO>(data);
            return venueDTO;
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

    public class CommentService
    {
        private IMapper _mapper;
        private object venueDTO;

        public CommentService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<VenueDTO> GetAll()
        {
            var data = DataAccess.VenueData().GetAll();
            var venueDTOs = _mapper.Map<List<VenueDTO>>(data);
            return venueDTOs;
        }

        public VenueDTO GetById(int id)
        {
            var data = DataAccess.VenueData().Get(id);
            var venueDTO = _mapper.Map<VenueDTO>(data);
            return venueDTO;
        }

        public bool AddVenue(VenueDTO venueDTO)
        {
            var venue = _mapper.Map<Venue>(venueDTO);
            return DataAccess.VenueData().Add(venue);
        }

        public bool UpdateVenue(VenueDTO VenueDTO)
        {
            var venue = _mapper.Map<Venue>(venueDTO);
            return DataAccess.VenueData().Update(venue);
        }

        public bool DeleteVenue(int id)
        {
            return DataAccess.VenueData().Delete(id);
        }
    }
}
