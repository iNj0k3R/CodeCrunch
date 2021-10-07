using CodeCrunch.Contracts.NASA;

namespace CodeCrunch.Services.NASA
{
    public interface INASAService
    {
        Task<APOD> GetAPOD(string date);
        Task<APOD[]> GetAPODOfMonth(string year, string month);
        Task<EPIC[]> GetEPIC(string date);
    }
}
