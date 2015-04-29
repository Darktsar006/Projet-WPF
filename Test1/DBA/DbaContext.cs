using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.DBA
{
    class DbaContext
    {
        public Test1Container context;

        public DbaContext()
        {
            context = new Test1Container();
        }

        public bool ifCourse()
        {
            int nbCourses = (from b in context.Courses
                             select b).Count();

            // Si il n'y a aucun cours Pour cet Etudiant on lui affecte une matiere (Obligatoire)
            // Car chaque Matiere reference plusieurs question
            if (nbCourses > 0)
                return true;

            return false;
        }

    }
}
