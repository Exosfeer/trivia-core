using trivia_dal.DataTransferObjects;

namespace trivia_api.Models.Converters
{
    public class AccountDTOConverter
    {
        public Account DtoToModel(AccountDTO dto)
        {
            Account model = new Account()
            {
                Id = dto.Id,
                Email = dto.Email,
                Password = dto.Password,
                CreatedAt = dto.CreatedAt,
                LastLogin = dto.LastLogin,
                Username = dto.Username,
            };

            return model;
        }

        public AccountDTO ModelToDTO(Account model)
        {
            AccountDTO dto = new AccountDTO(model.Id)
            {
                Email = model.Email,
                Password = model.Password,
                CreatedAt = model.CreatedAt,
                LastLogin = model.LastLogin,
                Username = model.Username,
            };

            return dto;
        }

    }
}
