using trivia_api.Models.Converters;
using trivia_dal.DataTransferObjects;
using trivia_dal.Interfaces;
using System.Collections.Generic;

namespace trivia_api.Models.Containers
{
    public class AccountContainer
    {
        private readonly IAccountContext context;

        public AccountContainer(IAccountContext givenContext)
        {
            this.context = givenContext;
        }

        public int Insert(Account current)
        {
            AccountDTOConverter dtoConverter = new AccountDTOConverter();
            AccountDTO dto = dtoConverter.ModelToDTO(current);

            return context.Insert(dto);
        }


        public bool Update(Account current)
        {
            AccountDTOConverter dtoConverter = new AccountDTOConverter();
            AccountDTO dto = dtoConverter.ModelToDTO(current);

            return context.Update(dto);
        }


        public bool Delete(Account current)
        {
            AccountDTOConverter dtoConverter = new AccountDTOConverter();
            AccountDTO dto = dtoConverter.ModelToDTO(current);

            return context.Delete(dto);
        }

        public Account GetById(Account account)
        {
            AccountDTOConverter dtoConverter = new AccountDTOConverter();
            AccountDTO returnAccount = context.GetById(account.Id);

            return dtoConverter.DtoToModel(returnAccount);
        }

        public Account GetByName(Account account)
        {
            AccountDTOConverter dtoConverter = new AccountDTOConverter();
            AccountDTO returnAccount = context.GetByName(dtoConverter.ModelToDTO(account));

            return dtoConverter.DtoToModel(returnAccount);
        }


        public List<Account> GetAll()
        {
            AccountDTOConverter dtoConverter = new AccountDTOConverter();
            List<Account> returnList = new List<Account>();
            foreach (AccountDTO dto in context.GetAll())
            {
                returnList.Add(dtoConverter.DtoToModel(dto));
            }

            return returnList;
        }
    }
}
