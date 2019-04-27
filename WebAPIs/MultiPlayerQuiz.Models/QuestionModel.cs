using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayerQuiz.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Score { get; set; }

        public int Duration { get; set; }

        public List<QuestionOptionModel> QuestionOptions { get; set; }
    }
}
