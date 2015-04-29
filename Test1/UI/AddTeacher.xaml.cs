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
    /// Logique d'interaction pour AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : UserControl
    {
        private int countCourse;
        private int countCampu;

        private String courseList;
        private String campusList;

        private Teacher teacher;

        private DBA.DbaTeacher manager;

        private DBA.DbaCourse managerCourse;
        public List<Course> coursT;

        ComboBoxItem item;

        public AddTeacher()
        {
            InitializeComponent();
            countCampu = 0;
            countCourse = 0;

            updateCoursesComboBox();
            updateCampusComboBox();
        }

        public void updateCampusComboBox()
        {
            List<String> campusT = new List<string>();
            campusT.Add("Conakry");
            campusT.Add("Kindia");
            campusT.Add("Toulouse");
            campusT.Add("Labé");
            campusT.Add("Montpellier");
            campusT.Add("Paris");
            campusT.Add("Lyon");




            for (int i = 0; i < campusT.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = campusT[i];

                Campus.Items.Add(item);
            }
            Campus.SelectedIndex = 0;
        }

        public void UpdateGeneral(object sender, RoutedEventArgs e)
        {
            managerCourse = new DBA.DbaCourse();
            coursT = managerCourse.coursesOverview();

            for (int i = 0; i < coursT.Count; i++)
            {
                item = new ComboBoxItem();
                item.Content = coursT[i].name;

                Courses.Items.Add(item);
            }
            Courses.SelectedIndex = 0;
        }

        public void updateCoursesComboBox()
        {

            managerCourse = new DBA.DbaCourse();

            coursT = managerCourse.coursesOverview();
            for (int i = 0; i < coursT.Count; i++)
            {
                item = new ComboBoxItem();
                item.Content = coursT[i].name;

                Courses.Items.Add(item);
            }
            Courses.SelectedIndex = 0;
        }

        private void addCourses(object sender, RoutedEventArgs e)
        {
            countCourse++;
            countCourses.Text = countCourse.ToString();

            courseList = courseList + " " + (Courses.SelectedItem as ComboBoxItem).Content.ToString();
        }

        private void addCampus(object sender, RoutedEventArgs e)
        {
            countCampu++;
            countCampus.Text = countCampu.ToString();

            campusList = campusList + " " + (Campus.SelectedItem as ComboBoxItem).Content.ToString();
        }

        private void createTeacherSubmit(object sender, RoutedEventArgs e)
        {
            countCourse = 0;
            countCampu = 0;
            countCampus.Text = countCampu.ToString();
            countCourses.Text = countCourse.ToString();

            manager = new DBA.DbaTeacher();
            teacher = new Teacher();

            teacher.name = name.Text;
            teacher.firstname = firstname.Text;
            teacher.email = teacher.firstname + "." + teacher.name + "@supinfo.com";

            teacher.campus = (campusY.SelectedItem as ComboBoxItem).Content.ToString();

            teacher.current_promotion = (promotion.SelectedItem as ComboBoxItem).Content.ToString();

            teacher.campus_would_teach = campusList;
            teacher.courses_would_teach = courseList;

            teacher.comments = "None";
            teacher.campus_already_teach = "None";
            teacher.courses_already_teach = "None";

            if (!teacher.name.Equals(""))
            {
                if (!teacher.firstname.Equals(""))
                {
                    manager.createTeacher(teacher);
                    name.Text = "";
                    firstname.Text = "";
                }
                else
                    firstname.Text = "Set Something";
                
            }
            else
                name.Text = "Set Something";
        }
    }
}
