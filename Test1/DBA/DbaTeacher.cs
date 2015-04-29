using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.DBA
{
    
    class DbaTeacher : DbaContext
    {
        public DbaTeacher()
        {

        }

        public void createTeacher(Teacher teacher)
        {
            try
            {
                context.Teachers.Add(teacher);
                context.SaveChanges();
             }catch(Exception eD)
            {

            }
        }

        public int countTeacher()
        {
            int count = (from b in context.Teachers
                         select b).Count();
            return count;
        }

        public List<Teacher> teacherOverview()
        {
            // Phase 1 : Affichage de Tous les etudiants
            // On Charge tous les etudiants dans un object query
            var query = from b in context.Teachers
                        orderby b.Id
                        select b;

            List<Teacher> newTeacher = new List<Teacher>();

            // Selection de l'ibBooster de letudiant
            foreach (var item in query)
            {
                Teacher teacher = new Teacher();
                try
                {
                    teacher.Id = item.Id;
                    teacher.name = item.name;
                    teacher.firstname = item.firstname;
                    teacher.campus = item.campus;
                    teacher.email = item.email;
                    teacher.current_promotion = item.current_promotion;

                    teacher.campus_already_teach = item.courses_already_teach;
                    teacher.campus_would_teach = item.campus_would_teach;

                    teacher.courses_already_teach = item.courses_already_teach;
                    teacher.courses_would_teach = item.courses_would_teach;

                    newTeacher.Add(teacher);
                }
                catch (Exception eD)
                {

                }

            }

            return newTeacher;
        }

        public int countSearch(String search)
        {
            int countQuery1 = (from b in context.Teachers
                               where b.current_promotion == search
                               select b).Count();

            int countQuery2 = (from b in context.Teachers
                               where b.campus == search
                               select b).Count();

            int countQuery3 = (from b in context.Teachers
                               where b.firstname == search
                               select b).Count();

            int countQuery4 = (from b in context.Teachers
                              where b.name == search
                              select b).Count();

            if (countQuery1 > 0) // Si jamais il y a un Trainer qui s'appelle B2, par exemple on va retourner tous les B2, en priorité
                return 1;
            else if (countQuery2 > 0) // La aussi on force le choix pour le nom du Campus.
                return 2;
            else if (countQuery3 > 0) // On privilegie le resultat de sortir plusieurs oumar, par exemple
                return 3;
            else if (countQuery4 > 0)
                return 4;

            return 0;
        }

        public List<Teacher> searchList(String search)
        {
            // Phase 1 : Affichage de Tous les etudiants
            // On Charge tous les etudiants dans un object query
            List<Teacher> newTeacher = new List<Teacher>();

            switch(countSearch(search))
            {
                case 1:
                    var query1 = from b in context.Teachers
                                 where b.current_promotion == search
                                 select b;

                    // Selection de l'ibBooster de letudiant
                    foreach (var item in query1)
                    {
                        Teacher teacher = new Teacher();
                        try
                        {
                            teacher.Id = item.Id;
                            teacher.name = item.name;
                            teacher.firstname = item.firstname;
                            teacher.campus = item.campus;
                            teacher.email = item.email;
                            teacher.current_promotion = item.current_promotion;

                            teacher.campus_already_teach = item.courses_already_teach;
                            teacher.campus_would_teach = item.campus_would_teach;

                            teacher.courses_already_teach = item.courses_already_teach;
                            teacher.courses_would_teach = item.courses_would_teach;

                            newTeacher.Add(teacher);
                        }
                        catch (Exception eD)
                        {

                        }

                    }

                    break;
                case 2:
                    var query2 = from b in context.Teachers
                                 where b.campus == search
                                 select b;
                    // Selection de l'ibBooster de letudiant
                    foreach (var item in query2)
                    {
                        Teacher teacher = new Teacher();
                        try
                        {
                            teacher.Id = item.Id;
                            teacher.name = item.name;
                            teacher.firstname = item.firstname;
                            teacher.campus = item.campus;
                            teacher.email = item.email;
                            teacher.current_promotion = item.current_promotion;

                            teacher.campus_already_teach = item.courses_already_teach;
                            teacher.campus_would_teach = item.campus_would_teach;

                            teacher.courses_already_teach = item.courses_already_teach;
                            teacher.courses_would_teach = item.courses_would_teach;

                            newTeacher.Add(teacher);
                        }
                        catch (Exception eD)
                        {

                        }

                    }

                    break;
                case 3:
                    var query3 = from b in context.Teachers
                                 where b.firstname == search
                                 select b;
                    // Selection de l'ibBooster de letudiant
                    foreach (var item in query3)
                    {
                        Teacher teacher = new Teacher();
                        try
                        {
                            teacher.Id = item.Id;
                            teacher.name = item.name;
                            teacher.firstname = item.firstname;
                            teacher.campus = item.campus;
                            teacher.email = item.email;
                            teacher.current_promotion = item.current_promotion;

                            teacher.campus_already_teach = item.courses_already_teach;
                            teacher.campus_would_teach = item.campus_would_teach;

                            teacher.courses_already_teach = item.courses_already_teach;
                            teacher.courses_would_teach = item.courses_would_teach;

                            newTeacher.Add(teacher);
                        }
                        catch (Exception eD)
                        {

                        }

                    }

                    break;
                case 4:
                    var query4 = from b in context.Teachers
                                where b.name == search
                                select b;
                    // Selection de l'ibBooster de letudiant
                    foreach (var item in query4)
                    {
                        Teacher teacher = new Teacher();
                        try
                        {
                            teacher.Id = item.Id;
                            teacher.name = item.name;
                            teacher.firstname = item.firstname;
                            teacher.campus = item.campus;
                            teacher.email = item.email;
                            teacher.current_promotion = item.current_promotion;

                            teacher.campus_already_teach = item.courses_already_teach;
                            teacher.campus_would_teach = item.campus_would_teach;

                            teacher.courses_already_teach = item.courses_already_teach;
                            teacher.courses_would_teach = item.courses_would_teach;

                            newTeacher.Add(teacher);
                        }
                        catch (Exception eD)
                        {

                        }

                    }

                    break;
                default : // On reaffiche les même élements
                    var query5 = from b in context.Teachers
                                orderby b.Id
                                select b;
                    // Selection de l'ibBooster de letudiant
                    foreach (var item in query5)
                    {
                        Teacher teacher = new Teacher();
                        try
                        {
                            teacher.Id = item.Id;
                            teacher.name = item.name;
                            teacher.firstname = item.firstname;
                            teacher.campus = item.campus;
                            teacher.email = item.email;
                            teacher.current_promotion = item.current_promotion;

                            teacher.campus_already_teach = item.courses_already_teach;
                            teacher.campus_would_teach = item.campus_would_teach;

                            teacher.courses_already_teach = item.courses_already_teach;
                            teacher.courses_would_teach = item.courses_would_teach;

                            newTeacher.Add(teacher);
                        }
                        catch (Exception eD)
                        {

                        }

                    }

                    break;
            }

            return newTeacher;
        }


    }
}
