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
using DataAccessLayer.Repositories;
using WPF_Formulär.ViewModels;
using WPF_Formulär.Models;

namespace WPF_Formulär
    {
    /// <summary>
   
    /// </summary>
    public partial class MainWindow : Window
        {
        PersonRepository repository = new PersonRepository();
        public MainWindow()
            {
            InitializeComponent();
            }
        PersonViewModel CreateViewModel(Person person)
            {
            PersonViewModel vm = new PersonViewModel
                {
                ID = person.ID,
                Name = person.Name,
                LastName = person.LastName,
                Phone = person.Phone,
                Birthdate = person.Birthdate.ToShortDateString(),
                Email = person.Email,
                Notes = person.Notes,
                Subscriber = person.Subscriber,
                PostalCode = person.PostalCode,
                Region = person.Region,
                StreetAddress = person.StreetAddress,
                SocialSecurityNumber = person.SocialSecurityNumber,
                Company = person.Company
                };
            if(person.Type==0)
                {
                radioPrivatPerson.IsChecked = true;
                radioFöretagPerson.IsChecked = false;
                }
            else
                {
                radioPrivatPerson.IsChecked = false;
                radioFöretagPerson.IsChecked = true;
                }
            txtRichText.Document.Blocks.Add(new Paragraph(new Run(person.Notes)));
            return vm;
            }
        void ClearUserInterface()
            {
            txtFörnamn.Text = "";
            txtEfternamn.Text = "";
            txtGatuaddress.Text = "";
            txtOrt.Text = "";
            txtPostnummer.Text = "";
            calCalendar.SelectedDate = null;
            txtFöretag.Text = "";
            txtEpost.Text = "";
            txtMobilnummer.Text = "";
            txtPersonnummer.Text = "";
            checkboxNyhetsbrev.IsChecked = false;
            radioPrivatPerson.IsChecked = false;
            txtRichText.Document.Blocks.Clear();
            }
        bool ValidateForm()
            {
            if(txtFörnamn.Text == "" || txtEfternamn.Text == "" || txtGatuaddress.Text == "" || txtOrt.Text == "" || txtPostnummer.Text == "" || calCalendar.SelectedDate == null || txtFöretag.Text == "" ||
            txtEpost.Text == "" || txtMobilnummer.Text == "" || txtPersonnummer.Text == "")
                {
                return false;
                }
            return true;

            }
        private void radioFöretagPerson_Checked(object sender, RoutedEventArgs e)
            {
            txtFöretag.IsEnabled = true;
            }

        private void radioPrivatPerson_Checked(object sender, RoutedEventArgs e)
            {
            txtFöretag.IsEnabled = false;
            }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
            {
            ClearUserInterface();
            Person person = null;
            if(comboEmail.IsSelected)
                {
                string email = txtSearch.Text;
                person = repository.GetPersonByEmail(email);
                if(person != null) DataContext = CreateViewModel(person);
                }
            else
                {
                string phone = txtSearch.Text;
                person = repository.GetPersonByPhone(phone);
                if(person != null) DataContext = CreateViewModel(person);
                }

            }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
            {
            Person p;

            if(ValidateForm()==false) { MessageBox.Show("Fyll i samtliga fält"); }
            else
                {
                if(txtID.Text!="") {
                p = new Person()
                    {
                    ID=int.Parse(txtID.Text),
                    Name = txtFörnamn.Text,
                    LastName = txtEfternamn.Text,
                    StreetAddress = txtGatuaddress.Text,
                    Region = txtOrt.Text,
                    PostalCode = txtPostnummer.Text,
                    Birthdate = DateTime.Parse(calCalendar.SelectedDate.ToString()),
                    Company = txtFöretag.Text,
                    Email = txtEpost.Text,
                    Phone = txtMobilnummer.Text,
                    SocialSecurityNumber = txtPersonnummer.Text,
                    Subscriber = checkboxNyhetsbrev.IsChecked.HasValue,
                    Type = radioPrivatPerson.IsChecked.Equals(true) ? TypeOfPerson.Privatperson : TypeOfPerson.Företag,
                    Notes = new TextRange(txtRichText.Document.ContentStart, txtRichText.Document.ContentEnd).Text

                    };
                    }
                else
                    {
                    p = new Person()
                        {
                        Name = txtFörnamn.Text,
                        LastName = txtEfternamn.Text,
                        StreetAddress = txtGatuaddress.Text,
                        Region = txtOrt.Text,
                        PostalCode = txtPostnummer.Text,
                        Birthdate = DateTime.Parse(calCalendar.SelectedDate.ToString()),
                        Company = txtFöretag.Text,
                        Email = txtEpost.Text,
                        Phone = txtMobilnummer.Text,
                        SocialSecurityNumber = txtPersonnummer.Text,
                        Subscriber = checkboxNyhetsbrev.IsChecked.HasValue,
                        Type = radioPrivatPerson.IsChecked.Equals(true) ? TypeOfPerson.Privatperson : TypeOfPerson.Företag,
                        Notes = new TextRange(txtRichText.Document.ContentStart, txtRichText.Document.ContentEnd).Text

                        };
                    }
                if(repository.UpdatePerson(p)==false)
                    {
                    MessageBox.Show("Användaren finns redan");
                    }
                ClearUserInterface();
                }
            
            }

        private void txtFöretag_TextChanged(object sender, TextChangedEventArgs e)
            {
            if(txtFöretag.Text != "")
                {
                radioFöretagPerson.IsChecked = true;
                radioPrivatPerson.IsEnabled = false;
                }
            else
                {
                radioFöretagPerson.IsChecked = false;
                radioPrivatPerson.IsEnabled = true;
                }
            }
        }
    }
