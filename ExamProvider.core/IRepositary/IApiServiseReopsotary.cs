using ExamProvider.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IRepositary
{
    public interface IApiServiseReopsotary
    {
        Task<List<ApiService>> get_all_APIS_SERVICES();
        Task<ApiService> gid_APIS_SERVICES_by_id(int id);
        Task create_APIS_SERVICES(ApiService apiservice);
        Task update_APIS_SERVICES(ApiService apiservice);
        Task delete_APIS_SERVICES(int id);

    } 
}