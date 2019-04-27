using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayerQuiz.Models
{
    class UserQuizModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int QuizId { get; set; }

        public DateTime Registeredon { get; set; }

        public QuizModel Quiz { get; set; }

        //  public UserModel User { get; set; }
    }
}
