using trivia_dal.DataTransferObjects;

namespace trivia_api.Models.Converters
{
    public class CategoryDTOConverter
    {
        public Category DtoToModel(CategoryDTO dto)
        {
            Category model = new Category(dto.Id)
            {
                Name = dto.Name,
                Description = dto.Description,
                Poster = dto.Poster,
                Published = dto.Published,
                Updated = dto.Updated,

            };

            return model;
        }

        public CategoryDTO ModelToDTO(Category model)
        {
            CategoryDTO dto = new CategoryDTO(model.Id)
            {
                Name = model.Name,
                Description = model.Description,
                Poster = model.Poster,
                Published = model.Published,
                Updated = model.Updated,
            };

            return dto;
        }
    }
}
