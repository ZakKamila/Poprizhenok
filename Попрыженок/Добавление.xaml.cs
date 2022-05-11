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
    /// Логика взаимодействия для Добавление.xaml
    /// </summary>
    public partial class Добавление : Page
    {
        private Agent _currentAgent = new Agent();


        public Добавление()
        {
            InitializeComponent();
            DataContext = _currentAgent;
            ComboType.ItemsSource = DemoEntities.GetContext().AgentType.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentAgent.Title))
                errors.AppendLine("Укажите название компании!");
            if (string.IsNullOrWhiteSpace(_currentAgent.Address))
                errors.AppendLine("Укажите адрес!");
            if (string.IsNullOrWhiteSpace(_currentAgent.INN))
                errors.AppendLine("Укажите название ИНН!");
            if (string.IsNullOrWhiteSpace(_currentAgent.KPP))
                errors.AppendLine("Укажите название КПП!");
            if (string.IsNullOrWhiteSpace(_currentAgent.DirectorName))
                errors.AppendLine("Укажите ФИО директора!");
            if (string.IsNullOrWhiteSpace(_currentAgent.Phone))
                errors.AppendLine("Укажите номер телефона!");
            if (string.IsNullOrWhiteSpace(_currentAgent.Email))
                errors.AppendLine("Укажите email!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentAgent.ID == 0)
                DemoEntities.GetContext().Agent.Add(_currentAgent);
            try
            {
                DemoEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

