using trivia_view.Models.DetailViewModels;
using System.Collections.Generic;

namespace trivia_view.Models
{
    public class QuestionViewModel
    {
        public string CurrentCategoryId { get; set; }
        public string CurrentAccountId { get; set; }
        public CategoryDetailViewModel categoryDetailViewModel { get; set; }
        public List<QuestionDetailViewModel> questionsViewModels { get; set; }


        public QuestionViewModel(string categoryId, string accountId)
        {
            this.CurrentCategoryId = categoryId;
            this.CurrentAccountId = accountId;
        }
    }
}
