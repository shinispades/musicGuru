using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using courseAssessment2.Models;
using Newtonsoft.Json;
using System.Data.Common;

namespace courseAssessment2.Controllers
{
    public class HomeController : Controller
    {
       readonly sampleEntities db = new sampleEntities();

        [HttpGet]
        public ActionResult Index()
        {

            //var sampleText = new Assessment
            //{
            //       questionTexts = new List<QuestionTextModel> { 

            //           new QuestionTextModel
            //           {
            //               qText = "Who am I?",

            //               Answers = new List<AnswerModel>
            //               {
            //                   new AnswerModel{qAnswer = "Jacob"},
            //                   new AnswerModel{qAnswer = "Lyle"},
            //                   new AnswerModel{qAnswer = "Jeffrey"}
            //               }
            //           },

            //           new QuestionTextModel{
            //           qText = "Who are you?",

            //               Answers = new List<AnswerModel>
            //               {
            //                   new AnswerModel{qAnswer = "Jacob1"},
            //                   new AnswerModel{qAnswer = "Lyle2"},
            //                   new AnswerModel{qAnswer = "Jeffrey3"}
            //               }
            //           }

            //       }
            //};

            //return View(sampleText);

            return View();
        }
        [HttpPost]
        public ActionResult Index(Assessment model)
        {
            var data = JsonConvert.SerializeObject(model);
            var assessment = new COURSE_ASSESSMENT
            {
                id = db.COURSE_ASSESSMENT.Select(m => m.id).DefaultIfEmpty(0).Max() + 1,
                serializedData = data
            };  

            db.COURSE_ASSESSMENT.Add(assessment);
            db.SaveChanges();
            

            return RedirectToAction("About");
        }


        public ActionResult About()
        {

            var data = db.COURSE_ASSESSMENT.Find(db.COURSE_ASSESSMENT.Select(m => m.id).DefaultIfEmpty(0).Max()).serializedData;
            var newData = new Assessment();
            if(data != null)
            {
                newData = JsonConvert.DeserializeObject<Assessment>(data);
                

            }
            else
            {
                Response.Write("<script>alert('entity not valid')</script>");
            }

            

           

            return View(newData);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}