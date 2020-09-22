using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Pra.StreamsEmployee.CORE;
using Pra.StreamsEmployee.CORE.Entities;
using Pra.StreamsEmployee.CORE.Services;

namespace Pra.StreamsEmployee.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreateEmployeeFile_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> employees = JSonReader.ReadJSON("http://dummy.restapiexample.com/api/v1/employees");

            StringBuilder fileContent = new StringBuilder();
            foreach(Employee employee in employees)
            {
                fileContent.Append(employee.ID + "|" + employee.Employee_name + "|" + employee.Employee_salary + "|" + employee.Employee_age + ";");
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.FileName = "employees.txt";
            saveFileDialog.Filter = "Tekstbestand (*.txt)|*.txt|C# bestand (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
            {

                folder = System.IO.Path.GetDirectoryName( saveFileDialog.FileName);
                string fileName = System.IO.Path.GetFileName(saveFileDialog.FileName);
                try
                {
                    FileWriter.WriteStringToFile(fileContent.ToString(), folder, fileName);

                    lstEmployees.ItemsSource = employees;

                }
                catch (Exception fout)
                {
                    MessageBox.Show(fout.Message, "ERROR");
                }
            }

        }

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "Tekstestanden (*.txt)|*.txt|Alle bestanden (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string path = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                string fileName = System.IO.Path.GetFileName(openFileDialog.FileName);

                string content = FileReader.ReadFileToString(path, fileName);
                string[] lines = content.Split(";");
                List<Employee> employees = new List<Employee>();
                foreach(string line in lines)
                {
                    if (line != "")
                    {
                        string[] values = line.Split('|');
                        employees.Add(new Employee
                        {
                            ID = values[0],
                            Employee_name = values[1],
                            Employee_salary = values[2],
                            Employee_age = values[3]
                        });
                    }

                }
                lstEmployees.ItemsSource = employees;

            }

        }
    }
}
