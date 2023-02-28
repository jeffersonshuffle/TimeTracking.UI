using AutoMapper;
using TimeTracking.Abstractions;
using TimeTracking.DAL;
using TimeTracking.DataModels;
using TimeTracking.Shared.DTOs;

namespace TimeTracking.AppCore.DayMarks
{
    internal class DayMarksQueryService : IDayMarksQueryService, ISelfRegisteredService<IDayMarksQueryService>
    {
        private readonly IQueryableDataAdapter<DayMark> _dayMarks;
        private readonly IMapper _mapper;
        public DayMarksQueryService(IQueryableDataAdapter<DayMark> dayMarks, IMapper mapper) 
        {
            _dayMarks = dayMarks; 
            _mapper = mapper;
        }
        public async Task<DayMarkDetails[]> ListAllAsync(CancellationToken token = default)
        {
            var marks = await _dayMarks.AsQueryable().ToPageAsync(m => m.Short, token);
            return _mapper.Map<DayMarkDetails[]>(marks);
        }
    }
}
