using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayerQuiz.Models
{
    public class QuizModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public string QuizType { get; set; }

        public virtual List<QuestionModel> Question { get; set; }
    }
}
