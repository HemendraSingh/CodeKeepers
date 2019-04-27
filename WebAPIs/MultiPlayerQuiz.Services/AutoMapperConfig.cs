using AutoMapper;
using MultiPlayerQuiz.Models;
using MultiPlayerQuiz.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayerQuiz.Services
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<QuestionModel, Question>().ReverseMap();
                config.CreateMap<QuestionOptionModel, QuestionOption>().ReverseMap();

            });
        }
    }
}
