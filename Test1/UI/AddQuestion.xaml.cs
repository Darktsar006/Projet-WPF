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
    /// Logique d'interaction pour AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : UserControl
    {
        private DBA.DbaCourse managerCourse;
        private List<Course> coursT;

        private DBA.DbaQuestion managerQuestion;

        private Question question;
        private Course coursR;

        ComboBoxItem item;

        public AddQuestion()
        {
            InitializeComponent();
            updateCoursesComboBox();
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

        private void setKeyCourse()
        {
            for (int i = 0; i < coursT.Count; i++)
            {
                if (coursR.name.Equals(coursT[i].name))
                {
                    question.CourseId = coursT[i].Id;
                }
            }
        }

        public void createQuestionSubmit(object sender, RoutedEventArgs e)
        {
            question = new Question();
            coursR = new Course();

            managerQuestion = new DBA.DbaQuestion();

            question.content = content.Text;
            question.bonus = (bonus.SelectedItem as ComboBoxItem).Content.ToString();

            coursR.name = (Courses.SelectedItem as ComboBoxItem).Content.ToString();



            setKeyCourse();

            managerQuestion.createQuestion(question);

        }
    }
}
