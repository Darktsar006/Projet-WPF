using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test1.UI
{
    /// <summary>
    /// Logique d'interaction pour ShowEachTeacher.xaml
    /// </summary>
    public partial class ShowEachTeacher : UserControl
    {
        private List<Teacher> teacher;
        private int selecteurTeacher;

        private DBA.DbaTeacher manager;

        private List<ModelSpecial.Statistique> statistique;

        private List<Notation> listNote;
        private DBA.DbaNotation managerNotation;

        public ShowEachTeacher()
        {
            InitializeComponent();

            manager = new DBA.DbaTeacher();
            managerNotation = new DBA.DbaNotation();

            update();

            selecteurTeacher = 0;
        }

        public void updateNotation()
        {
            listNote = managerNotation.notationOverview(teacher[selecteurTeacher].Id);
            notationView.ItemsSource = listNote;
        }

        public void UpdateGeneral(object sender, RoutedEventArgs e)
        {
            update();
        }

        private void update()
        {
            teacher = manager.teacherOverview();
            if (manager.countTeacher() > 0)
            {
                setContent();

                updateTable();

                updateNotation();
            }
        }

        private void goSearch(object sender, RoutedEventArgs e)
        {
            String search = searchText.Text;
            teacher = manager.searchList(search);

            selecteurTeacher = 0;
            if (manager.countSearch(search) > 0)
            {
                setContent();
                updateTable();

                updateNotation();
            }
        }

        private void setContent()
        {
            idBooster.Content = teacher[selecteurTeacher].Id.ToString();
            lastname.Content = teacher[selecteurTeacher].name;
            firstname.Content = teacher[selecteurTeacher].firstname;
            email.Content = teacher[selecteurTeacher].email;
            campus.Content = teacher[selecteurTeacher].campus;
            promotion.Content = teacher[selecteurTeacher].current_promotion;

            page.Content = (selecteurTeacher + 1) + "/" + teacher.Count();
        }

        private void prevTeacher(object sender, RoutedEventArgs e)
        {
            if (selecteurTeacher > 0)
            {
                selecteurTeacher--;
                setContent();
                updateTable();

                updateNotation();
            }

        }

        private void nextTeacher(object sender, RoutedEventArgs e)
        {
            if (selecteurTeacher < teacher.Count - 1)
            {
                selecteurTeacher++;
                setContent();
                updateTable();

                updateNotation();
            }

        }


        private String[] decomposition(String chaine)
        {
            String[] split = chaine.Split(new char[] { ' ' });

            return split;
        }

        public void updateTable()
        {
            statistique = new List<ModelSpecial.Statistique>();

            String[] campusT = decomposition(teacher[selecteurTeacher].campus_would_teach);
            String[] campusAT = decomposition(teacher[selecteurTeacher].campus_already_teach);

            String[] courseT = decomposition(teacher[selecteurTeacher].courses_would_teach);
            String[] courseAT = decomposition(teacher[selecteurTeacher].courses_already_teach);

            if (campusAT.Length > courseAT.Length)
            {
                for (int i = 0; i < campusT.Length; i++)
                {
                    ModelSpecial.Statistique newStatique = new ModelSpecial.Statistique();
                    newStatique.campusT = campusT[i];

                    if (i < campusAT.Length)
                        newStatique.campusAT = campusAT[i];
                    if (i < courseT.Length)
                        newStatique.courseT = courseT[i];
                    if (i < courseAT.Length)
                        newStatique.courseAT = courseAT[i];

                    statistique.Add(newStatique);
                }
            }
            else
            {
                for (int i = 0; i < courseT.Length; i++)
                {
                    ModelSpecial.Statistique newStatique = new ModelSpecial.Statistique();
                    newStatique.courseT = courseT[i];

                    if (i < campusAT.Length)
                        newStatique.campusAT = campusAT[i];
                    if (i < campusT.Length)
                        newStatique.campusT = campusT[i];
                    if (i < courseAT.Length)
                        newStatique.courseAT = courseAT[i];

                    statistique.Add(newStatique);
                }
            }

            questionView.ItemsSource = statistique;
        }
    }
}
