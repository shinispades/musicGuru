using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace courseAssessment2.Models
{
    public class Assessment
    {
        public List<QuestionTextModel> questionTexts { get; set; }
    }
    
    public class QuestionTextModel
    {

        public string SelectedOption { get; set; }
        public string qText { get; set; }
        
        public List<AnswerModel> Answers { get; set; }

        public QuestionTextModel()  
        {
            Answers = new List<AnswerModel>();
        }
    }
    public class AnswerModel
    {
        public string qAnswer { get; set; }
    }


}