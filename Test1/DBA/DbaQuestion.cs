using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.DBA
{
    class DbaQuestion : DbaContext
    {
        public DbaQuestion()
        {
        }


        public void createQuestion(Question question)
        {
            try
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
            catch(Exception e)
            {

            }
                
        }


        public List<Question> QuestionOverview()
        {
            // Phase 1 : Affichage de Tous les etudiants
            // On Charge tous les etudiants dans un object query
            var query = from b in context.Questions
                        orderby b.Id
                        select b;

            List<Question> newQuestion = new List<Question>();

            // Selection de l'ibBooster de letudiant
            foreach (var item in query)
            {
                Question question = new Question();
                try
                {
                    question.Id = item.Id;
                    question.content = item.content;
                    question.bonus = item.bonus;
                    
                    newQuestion.Add(question);
                }
                catch (Exception eD)
                {

                }

            }

            return newQuestion;
        }

        public List<Question> QuestionFiltre(int id)
        {
            // Phase 1 : Affichage de Tous les etudiants
            // On Charge tous les etudiants dans un object query
            var query = from b in context.Questions
                        where b.CourseId == id
                        select b;

            List<Question> newQuestion = new List<Question>();

            // Selection de l'ibBooster de letudiant
            foreach (var item in query)
            {
                Question question = new Question();
                try
                {
                    question.Id = item.Id;
                    question.content = item.content;
                    question.bonus = item.bonus;

                    newQuestion.Add(question);
                }
                catch (Exception eD)
                {

                }

            }

            return newQuestion;
        }

    }
}
