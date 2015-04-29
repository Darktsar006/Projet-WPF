using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.DBA
{
    class DbaCourse : DbaContext
    {
        public DbaCourse()
        {

        }

       
        public void createCourse(Course cours)
        {
            try
            {
                context.Courses.Add(cours);
                context.SaveChanges();
            }
            catch (Exception eD)
            {

            }
        }

        public int countCourses()
        {
            int count = (from b in context.Courses
                         select b).Count();

            return count;
        }

        public List<Course> coursesOverview()
        {
            var query = from b in context.Courses
                        orderby b.Id
                        select b;

            List<Course> newCours = new List<Course>();

            foreach(var item in query)
            {
                Course cours = new Course();
                cours.name = item.name;
                cours.Id = item.Id;
                newCours.Add(cours);
            }


            return newCours;
        }

    }
}
