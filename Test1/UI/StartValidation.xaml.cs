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
    /// Logique d'interaction pour StartValidation.xaml
    /// </summary>
    public partial class StartValidation : UserControl
    {
        private DBA.DbaTeacher managerTeacher;
        private List<Teacher> teacher;

        private DBA.DbaCourse managerCourse;
        public List<Course> coursT;

        private List<Question> questionV;

        private Notation notationFinal;

        private ModelSpecial.NoteTemporaire tempNotation;
        private DBA.DbaNotation managerNotation;

        public StartValidation()
        {
            InitializeComponent();
            updateTeacherComboBox();
            updateCoursesComboBox();
        }

        public void updateTeacherComboBox()
        {

            managerTeacher = new DBA.DbaTeacher();

            teacher = managerTeacher.teacherOverview();

            for (int i = 0; i < teacher.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = teacher[i].Id;

                idBooster.Items.Add(item);
            }
            idBooster.SelectedIndex = 0;
        }

        public void updateCoursesComboBox()
        {

            managerCourse = new DBA.DbaCourse();

            coursT = managerCourse.coursesOverview();
            for (int i = 0; i < coursT.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = coursT[i].name;

                Courses.Items.Add(item);
            }
            Courses.SelectedIndex = 0;
        }

        public void startValid(object sender, RoutedEventArgs e)
        {
            load.Visibility = Visibility.Hidden;
            
            Course choixCours = new Course();

            Random random = new Random();
            int randomNumber = 0;
            int chance = 0;

            DBA.DbaQuestion managerQuestion = new DBA.DbaQuestion();

            choixCours.name = (Courses.SelectedItem as ComboBoxItem).Content.ToString();
            
            for(int i = 0; i < coursT.Count; i++)
            {
                if (choixCours.name == coursT[i].name)
                    choixCours.Id = coursT[i].Id;
            }

            questionV = managerQuestion.QuestionFiltre(choixCours.Id);

            if(questionV.Count > 0)
            {
                randomNumber = random.Next(0, questionV.Count);
                question1C.Content = questionV[randomNumber].content;
                question1.Content = "Question 1 : ";
                Notation1.Visibility = Visibility.Visible;
                Finish.Visibility = Visibility.Visible;
            }
            else
            {
                question1.Content = "";
                question1C.Content = "";
                Notation1.Visibility = Visibility.Hidden;
                Finish.Visibility = Visibility.Hidden;
                load.Visibility = Visibility.Visible;
            }

            if (questionV.Count > 1)
            {
                randomNumber = random.Next(0, questionV.Count);
                question2C.Content = questionV[randomNumber].content;
                question2.Content = "Question 2 : ";
                Notation2.Visibility = Visibility.Visible;
            }
            else
            {
                question2.Content = "";
                question2C.Content = "";
                Notation2.Visibility = Visibility.Hidden;
            }

            if (questionV.Count > 2)
            {
                randomNumber = random.Next(0, questionV.Count);
                question3C.Content = questionV[randomNumber].content;
                question3.Content = "Question 3 : ";
                Notation3.Visibility = Visibility.Visible;
            }
            else
            {
                question3.Content = "";
                question3C.Content = "";
                Notation3.Visibility = Visibility.Hidden;
            }

            if (questionV.Count > 3)
            {

                do
                {
                    randomNumber = random.Next(0, questionV.Count);
                    chance++;
                    if(questionV[randomNumber].bonus.Equals("YES"))
                    {
                        question4C.Content = questionV[randomNumber].content;
                        question4.Content = "Question 4 : ";
                        Notation4.Visibility = Visibility.Visible;
                    }

                } while (chance <= 10);
                
            }
            else
            {
                question4.Content = "";
                question4C.Content = "";
                Notation4.Visibility = Visibility.Hidden;
            }
        }

        private int countNotation(String note, String comp, int count)
        {
            if (note.Equals(comp))
                count++;

            return count;
        }

        public void FinishValidation(object sender, RoutedEventArgs e)
        {
            int countA = 0;
            int countB = 0;
            int countC = 0;

            tempNotation = new ModelSpecial.NoteTemporaire();
            notationFinal = new Notation();

            managerNotation = new DBA.DbaNotation();

            if (questionV.Count > 0)
            {
                tempNotation.note1 = (Notation1.SelectedItem as ComboBoxItem).Content.ToString();
                countA = countNotation(tempNotation.note1, "A", countA);
                countB = countNotation(tempNotation.note1, "A", countB);
                countC = countNotation(tempNotation.note1, "A", countC);
            }
                
            if (questionV.Count > 1)
            {
                tempNotation.note2 = (Notation2.SelectedItem as ComboBoxItem).Content.ToString();
                countA = countNotation(tempNotation.note2, "A", countA);
                countB = countNotation(tempNotation.note2, "A", countB);
                countC = countNotation(tempNotation.note2, "A", countC);
            }
                
            if (questionV.Count > 2)
            {
                tempNotation.note3 = (Notation3.SelectedItem as ComboBoxItem).Content.ToString();
                countA = countNotation(tempNotation.note3, "A", countA);
                countB = countNotation(tempNotation.note3, "A", countB);
                countC = countNotation(tempNotation.note3, "A", countC);
            }
                
            if (questionV.Count > 3)
            {
                tempNotation.note4 = (Notation4.SelectedItem as ComboBoxItem).Content.ToString();
                countA = countNotation(tempNotation.note4, "A", countA);
                countB = countNotation(tempNotation.note4, "A", countA);
                countC = countNotation(tempNotation.note4, "A", countC);
            }

            if (countC == 0 && countA >= 1)
            {
                notationFinal.validation = "A";
                notationFinal.certification = "A";
            }
            else if (countC == 1 && countA >= 2)
            {
                notationFinal.validation = "A";
                notationFinal.certification = "A";
            }
            else if ((countC / questionV.Count) > (countB / questionV.Count)) // Je calcule la moyenne
            {
                notationFinal.validation = "C";
                notationFinal.certification = "C";
            }else
            {
                notationFinal.validation = "B";
                notationFinal.certification = "B";
            }
            notationFinal.matiere = (Courses.SelectedItem as ComboBoxItem).Content.ToString(); 
            
            for(int i = 0; i < coursT.Count; i++)
            {
                if (coursT[i].name == notationFinal.matiere)
                    notationFinal.TeacherId = coursT[i].Id;
            }

            managerNotation.createNotation(notationFinal);

        }
        
    }
}
