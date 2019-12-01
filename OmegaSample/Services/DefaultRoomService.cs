﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OmegaSample.Models;

namespace OmegaSample.Services
{
    public class DefaultRoomService : IRoomService
    {
        private readonly OmegaApiContext _context;
        private readonly IMapper _mapper;

        public DefaultRoomService(OmegaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Room> GetRoomAsync(Guid id, CancellationToken ct)
        {
            var entity = await _context.Rooms.SingleOrDefaultAsync(r => r.Id == id, ct);
            if (entity == null) return null; //NotFound();
            
            return _mapper.Map<Room>(entity);
        }

        public async Task<PagedResults<Room>> GetRoomsAsync(PagingOptions pagingOptions, SortOptions<Room, RoomEntity> sortOptions,
            SearchOptions<Room, RoomEntity> searchOptions,CancellationToken ct)
        {
            IQueryable<RoomEntity> query = _context.Rooms;
            query = searchOptions.Apply(query);
            query = sortOptions.Apply(query);

            var size = await query.CountAsync(ct);

            var items = await query
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value)
                .ProjectTo<Room>(_mapper.ConfigurationProvider)
                .ToArrayAsync(ct);

            return new PagedResults<Room>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}
