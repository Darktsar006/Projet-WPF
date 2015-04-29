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
    /// Logique d'interaction pour ShowEachQuestion.xaml
    /// </summary>
    public partial class ShowEachQuestion : UserControl
    {
        private DBA.DbaQuestion managerQuestion;

        private DBA.DbaCourse managerCourse;
        private List<Course> coursT;
        private ComboBoxItem item;

        private List<Question> questionV;

        public ShowEachQuestion()
        {
            InitializeComponent();

            questionV = new List<Question>();
            managerQuestion = new DBA.DbaQuestion();

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

            questionV = managerQuestion.QuestionOverview();
            questionView.ItemsSource = questionV;

            
        }

        public void updateSearch()
        {
            String text = (Courses.SelectedItem as ComboBoxItem).Content.ToString();
            int count = 0;
            for (int i = 0; i < coursT.Count; i++)
            {
                if (coursT[i].name.Equals(text))
                {
                    questionV = managerQuestion.QuestionFiltre(coursT[i].Id);
                    questionView.ItemsSource = questionV;
                    count++;
                }
            }
            if (count == 0)
            {
                questionV = managerQuestion.QuestionOverview();
                questionView.ItemsSource = questionV;
            }

        }

        public void goSearch(object sender, RoutedEventArgs e)
        {
            updateSearch();
        }
    }
}
