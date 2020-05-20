using Cooper.MotCheck.Models;
using Cooper.MotCheck.Models.Enumeration;
using Cooper.MotCheck.Services.Dto;
using Cooper.MotCheck.Services.Implementation.Mappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Services.Implementation
{
    public class MotCheckService : IMotCheckService
    {
        private readonly string serviceEndpoint = "https://service";
        private readonly IHttpService httpService;
        private readonly MotCheckServiceMapper mapper;

        public MotCheckService(IHttpService httpService, MotCheckServiceMapper mapper)
        {
            this.httpService = httpService;
            this.mapper = mapper;
        }

#pragma warning disable 168
        public async Task<MotCheckResponse> CheckVehicleMot(string registration)
        {
            try
            {
                var uri = new Uri($"{serviceEndpoint}/mot-status/{registration}");
                var response = await httpService.GetAsync(uri, CancellationToken.None);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<VehicleMotStatus>(content);
                var result = mapper.ToMotCheckResponse(dto);

                return result;
            }
            catch (Exception ex)
            {
                // Log failure
                return NotFoundResponse(registration);
            }

        }
#pragma warning restore

        private MotCheckResponse NotFoundResponse(string registration) => new MotCheckResponse
        {
            Registration = registration,
            Status = MotStatus.NotFound
        };

    }
}
