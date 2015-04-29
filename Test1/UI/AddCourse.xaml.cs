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
    /// Logique d'interaction pour AddCourse.xaml
    /// </summary>
    public partial class AddCourse : UserControl
    {
        private Course cours;
        private DBA.DbaCourse manager;

        public AddCourse()
        {
            InitializeComponent();
        }

        public void createCoursesSubmit(object sender, RoutedEventArgs e)
        {

            cours = new Course();
            manager = new DBA.DbaCourse();

            cours.name = coursName.Text;

            manager.createCourse(cours);
        }
    }
}
