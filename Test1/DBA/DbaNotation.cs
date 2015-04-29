using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.DBA
{
    class DbaNotation : DbaContext
    {
        public DbaNotation()
        {

        }

        public void createNotation(Notation note)
        {
            try
            {
                context.Notations.Add(note);
                context.SaveChanges();
            }catch(Exception eD)
            {

            }
        }

        public List<Notation> notationOverview(int n)
        {
            List<Notation> note = new List<Notation>();
            var query = from b in context.Notations
                        where b.TeacherId == n
                        select b;

            foreach(var item in query)
            {
                Notation temp = new Notation();
                temp.Id = item.Id;
                temp.matiere = item.matiere;
                temp.validation = item.validation;
                temp.certification = item.certification;

                note.Add(temp);
            }
            return note;
        }
    }
}
