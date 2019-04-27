using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayerQuiz.Models
{
    public class QuestionOptionModel
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Option { get; set; }

        public bool IsAnswer { get; set; }
    }
}
