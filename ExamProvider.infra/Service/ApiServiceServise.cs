using ExamProvider.core.Data;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class ApiServiceServise : IApiServiceServise
    {
        private readonly IApiServiseReopsotary _iapiservicereopsotary;

        public ApiServiceServise(IApiServiseReopsotary iapiserviceservise)
        {
            _iapiservicereopsotary = iapiserviceservise;
        }

        public async Task create_APIS_SERVICES(ApiService apiservice)
        {
            await _iapiservicereopsotary.create_APIS_SERVICES(apiservice);
        }

        public async Task delete_APIS_SERVICES(int id)
        {
            await _iapiservicereopsotary.delete_APIS_SERVICES(id);
        }

        public async Task<List<ApiService>> get_all_APIS_SERVICES()
        {
            return await _iapiservicereopsotary.get_all_APIS_SERVICES();
        }

        public async Task<ApiService> gid_APIS_SERVICES_by_id(int id)
        {
            return await _iapiservicereopsotary.gid_APIS_SERVICES_by_id(id);
        }

        public async Task update_APIS_SERVICES(ApiService apiservice)
        {
            await _iapiservicereopsotary.update_APIS_SERVICES(apiservice);

        }
    }
}
