using Cooper.MotCheck.Models;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services
{
    public interface IMotCheckService
    {
        Task<MotCheckResponse> CheckVehicleMot(string registration);
    }
}
