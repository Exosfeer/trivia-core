using trivia_dal.DataTransferObjects;
using System.Collections.Generic;

namespace trivia_dal.Interfaces
{
    public interface IAccountContext
    {
        AccountDTO GetById(string id);
        AccountDTO GetByName(AccountDTO account);
        List<AccountDTO> GetAll();
        int Insert(AccountDTO account);
        bool Update(AccountDTO account);
        bool Delete(AccountDTO account);
    }
}
