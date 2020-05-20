using Cooper.MotCheck.Models;
using Cooper.MotCheck.Models.Enumeration;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services.Implementation
{
    public class MockMotCheckService : IMotCheckService
    {
        public async Task<MotCheckResponse> CheckVehicleMot(string registration)
        {
            try
            {
                await Task.Delay(1000);
                var flag = registration.Substring(0, 1);

                if (string.Compare(flag, "E", StringComparison.OrdinalIgnoreCase) == 0)
                    return ExpiredResponse(registration);

                if (string.Compare(flag, "R", StringComparison.OrdinalIgnoreCase) == 0)
                    return NotRequiredResponse(registration);

                if (string.Compare(flag, "F", StringComparison.OrdinalIgnoreCase) == 0)
                    return NotFoundResponse(registration);

                return ValidResponse(registration);
            }
            catch (Exception)
            {
                return NotFoundResponse(registration);
            }
        }

        private MotCheckResponse ValidResponse(string registration) => new MotCheckResponse
        {
            Registration = registration,
            Manufacturer = "Mini",
            Model = "Cooper JCW",
            MotExpiryDate = DateTime.Today.AddMonths(8).AddDays(9),
            Status = MotStatus.Valid
        };

        private MotCheckResponse ExpiredResponse(string registration) => new MotCheckResponse
        {
            Registration = registration,
            Manufacturer = "Mini",
            Model = "Cooper JCW",
            MotExpiryDate = DateTime.Today.AddMonths(-8).AddDays(9),
            Status = MotStatus.Expired
        };

        private MotCheckResponse NotRequiredResponse(string registration) => new MotCheckResponse
        {
            Registration = registration,
            Manufacturer = "Mini",
            Model = "Cooper JCW",
            Status = MotStatus.NotRequired
        };

        private MotCheckResponse NotFoundResponse(string registration) => new MotCheckResponse
        {
            Registration = registration,
            Status = MotStatus.NotFound
        };
    }
}
