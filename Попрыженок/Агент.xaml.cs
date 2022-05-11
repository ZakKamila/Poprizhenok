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

namespace Попрыженок
{
    /// <summary>
    /// Логика взаимодействия для Агент.xaml
    /// </summary>
    public partial class Агент : Page
    {
        public Агент()
        {
            InitializeComponent();

            var allTypes = DemoEntities.GetContext().AgentType.ToList();
            allTypes.Insert(0, new AgentType
            {
                Title = "Все типы"
            });



            ComboType.ItemsSource = allTypes;
            ComboType.SelectedIndex = 0;


            var currentAgent = DemoEntities.GetContext().Agent.ToList();
            LViewAgent.ItemsSource = currentAgent;
        }
        
        

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
