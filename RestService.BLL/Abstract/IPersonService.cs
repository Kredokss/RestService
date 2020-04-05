using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestService.DAL.Entities;

namespace RestService.BLL.Abstract
{
    public interface IPersonService
    {
        Task<DataTransferPerson> Get(int id);
        IEnumerable<DataTransferPerson> Get();
        Task<DataTransferPerson> Add(DataTransferPerson person);
        Task<DataTransferPerson> Update(DataTransferPerson person);
        Task<bool> Delete(int id);
    }
}
