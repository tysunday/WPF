using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using static _30._01._2024_FinalProjectWpf_PDF.ModelPerson;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace _30._01._2024_FinalProjectWpf_PDF
{
    public class ModelViewPerson : INotifyPropertyChanged
    {
        ModelPerson Person;
        public ModelViewPerson()
        {
            Person = new ModelPerson();
            AddWorkExperience = new RelayCommand(() =>
                WorkExperiences.Add(new WorkExperience())
            );
            DeleteWorkExperience = new RelayCommand(() =>
            {
                if (WorkExperiences.Count > 0)
                    WorkExperiences.RemoveAt(WorkExperiences.Count - 1);
            });

            InsertProfileImage = new RelayCommand(() => SelectImage());

            AddSupplementalEducation = new RelayCommand(() =>
    SupplementalEducations.Add(new SupplementalEducation())
);
            DeleteSupplementalEducation = new RelayCommand(() =>
            {
                if (SupplementalEducations.Count > 0)
                    SupplementalEducations.RemoveAt(SupplementalEducations.Count - 1);
            });

            ChangeLocalizationCommand = new RelayCommand(() =>
            ChangeLocalization());
        }


        public ICommand AddWorkExperience { get; }
        public ICommand DeleteWorkExperience { get; }
        public ICommand InsertProfileImage { get; }
        public ICommand AddSupplementalEducation { get; }
        public ICommand DeleteSupplementalEducation { get; }
        public ICommand ChangeLocalizationCommand { get; }

        #region Реализация OnPropertyChanged
        public string Name
        {
            get { return Person.Name; }
            set
            {
                if (Person.Name != value)
                    Person.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get { return Person.Surname; }
            set
            {
                if (Person.Surname != value)
                    Person.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Patronymic
        {
            get { return Person.Patronymic; }
            set
            {
                if (Person.Patronymic != value)
                    Person.Patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        public DateTime DateOfBirth
        {
            get { return Person.DateOfBirth.Date; }
            set
            {
                if (Person.DateOfBirth != value)
                    Person.DateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public string Skills
        {
            get { return Person.Skills; }
            set
            {
                if (Person.Skills != value)
                    Person.Skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }

        public string Description
        {
            get { return Person.Description; }
            set
            {
                if (Person.Description != value)
                    Person.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public int Seniority
        {
            get { return Person.Seniority; }
            set
            {
                if (Person.Seniority != value)
                    Person.Seniority = value;
                OnPropertyChanged(nameof(Seniority));
            }
        }
        public string Phone
        {
            get { return Person.Phone; }
            set
            {
                if (Person.Phone != value)
                    Person.Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Email
        {
            get { return Person.Email; }
            set
            {
                if (Person.Email != value)
                    Person.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private BitmapImage _profileImage;
        public BitmapImage ProfileImage
        {
            get { return _profileImage; }
            set
            {
                if (_profileImage != value)
                {
                    _profileImage = value;
                    OnPropertyChanged(nameof(ProfileImage));
                }
            }
        }

        private void SelectImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.gif|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                ProfileImage = MyFunctions.LoadImage(imagePath);
            }
        }



        public ObservableCollection<WorkExperience> WorkExperiences
        {
            get { return Person.WorkExperiences; }
            set
            {
                if (Person.WorkExperiences != value)
                    OnPropertyChanged(nameof(WorkExperiences));
            }
        }

        public ObservableCollection<SupplementalEducation> SupplementalEducations
        {
            get { return Person.SupplementalEducations; }
            set
            {
                if (Person.SupplementalEducations != value)
                    OnPropertyChanged(nameof(SupplementalEducation));
            }
        }

        public bool CriminalRecord
        {
            get { return Person.CriminalRecord; }
            set
            {
                if (Person.CriminalRecord != value)
                    Person.CriminalRecord = value;
                OnPropertyChanged(nameof(CriminalRecord));
            }
        }
        public string ArticlesOfConviction
        {
            get { return Person.ArticlesOfConviction; }
            set
            {
                if (Person.ArticlesOfConviction != value)
                    Person.ArticlesOfConviction = value;
                OnPropertyChanged(nameof(ArticlesOfConviction));
            }
        }

        public string BriefDescriptionOfTheOffense
        {
            get { return Person.BriefDescriptionOfTheOffense; }
            set
            {
                if (Person.BriefDescriptionOfTheOffense != value)
                    Person.BriefDescriptionOfTheOffense = value;
                OnPropertyChanged(nameof(BriefDescriptionOfTheOffense));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Локализация
        string CurrentCulture = "ru-RU";
        public void ChangeLocalization()
        {
            UpdateLocalization();
            UpdateUI();
        }

        #region Переменные для локализации
        public string acquiredSkills
        {
            get { return CommonStrings.AcquiredSkills; }
            set
            {
                if (_acquiredSkills != value)
                    _acquiredSkills = value;
                OnPropertyChanged(nameof(acquiredSkills));
            }
        }

        private string _acquiredSkills = CommonStrings.AcquiredSkills;
        public string addSupplementalEducation
        {
            get { return CommonStrings.AddSupplementalEducation; }
            set
            {
                if (_addSupplementalEducation != value)
                    _addSupplementalEducation = value;
                OnPropertyChanged(nameof(addSupplementalEducation));
            }
        }

        private string _addSupplementalEducation = CommonStrings.AddSupplementalEducation;
        public string addWorkExperience
        {
            get { return CommonStrings.AddWorkExperience; }
            set
            {
                if (_addWorkExperience != value)
                    _addWorkExperience = value;
                OnPropertyChanged(nameof(addWorkExperience));
            }
        }

        private string _addWorkExperience = CommonStrings.AddWorkExperience;
        public string brieflyDescribe
        {
            get { return CommonStrings.BrieflyDescribe; }
            set
            {
                if (_brieflyDescribe != value)
                    _brieflyDescribe = value;
                OnPropertyChanged(nameof(brieflyDescribe));
            }
        }

        private string _brieflyDescribe = CommonStrings.BrieflyDescribe;
        public string company
        {
            get { return CommonStrings.Company; }
            set
            {
                if (_company != value)
                    _company = value;
                OnPropertyChanged(nameof(company));
            }
        }

        private string _company = CommonStrings.Company;
        public string courseTitle
        {
            get { return CommonStrings.CourseTitle; }
            set
            {
                if (_courseTitle != value)
                    _courseTitle = value;
                OnPropertyChanged(nameof(courseTitle));
            }
        }

        private string _courseTitle = CommonStrings.CourseTitle;
        public string surname
        {
            get { return CommonStrings.Surname; }
            set
            {
                if (_surname != value)
                    _surname = value;
                OnPropertyChanged(nameof(surname));
            }
        }

        private string _surname = CommonStrings.Surname;
        public string dateOfBirth
        {
            get { return CommonStrings.DateOfBirth; }
            set
            {
                if (_dateOfBirth != value)
                    _dateOfBirth = value;
                OnPropertyChanged(nameof(dateOfBirth));
            }
        }
        private string _dateOfBirth = CommonStrings.DateOfBirth;
        public string criminalRecord
        {
            get { return CommonStrings.CriminalRecord; }
            set
            {
                if (_criminalRecord != value)
                    _criminalRecord = value;
                OnPropertyChanged(nameof(criminalRecord));
            }
        }
        string _criminalRecord = CommonStrings.CriminalRecord;
        public string deleteSupplementalEducation
        {
            get { return _deleteSupplementalEducation; }
            set
            {
                if (_deleteSupplementalEducation != value)
                    _deleteSupplementalEducation = value;
                OnPropertyChanged(nameof(deleteSupplementalEducation));
            }
        }
        string _deleteSupplementalEducation = CommonStrings.DeleteSupplementalEducation;

        public string deleteWorkExperience
        {
            get { return _deleteWorkExperience; }
            set
            {
                if (_deleteWorkExperience != value)
                    _deleteWorkExperience = value;
                OnPropertyChanged(nameof(deleteWorkExperience));
            }
        }
        string _deleteWorkExperience = CommonStrings.DeleteWorkExperience;

        public string describeYourself
        {
            get { return _describeYourself; }
            set
            {
                if (_describeYourself != value)
                    _describeYourself = value;
                OnPropertyChanged(nameof(describeYourself));
            }
        }
        string _describeYourself = CommonStrings.DescribeYourself;

        public string email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                    _email = value;
                OnPropertyChanged(nameof(email));
            }
        }
        string _email = CommonStrings.Email;

        public string infoEducationalCourses
        {
            get { return _infoEducationalCourses; }
            set
            {
                if (_infoEducationalCourses != value)
                    _infoEducationalCourses = value;
                OnPropertyChanged(nameof(infoEducationalCourses));
            }
        }
        string _infoEducationalCourses = CommonStrings.InfoEducationalCourses;

        public string infoPastWork
        {
            get { return _infoPastWork; }
            set
            {
                if (_infoPastWork != value)
                    _infoPastWork = value;
                OnPropertyChanged(nameof(infoPastWork));
            }
        }
        string _infoPastWork = CommonStrings.InfoPastWork;

        public string listTheArticlesSeparatedByCommas
        {
            get { return _listTheArticlesSeparatedByCommas; }
            set
            {
                if (_listTheArticlesSeparatedByCommas != value)
                    _listTheArticlesSeparatedByCommas = value;
                OnPropertyChanged(nameof(listTheArticlesSeparatedByCommas));
            }
        }
        string _listTheArticlesSeparatedByCommas = CommonStrings.ListTheArticlesSeparatedByCommas;

        public string location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                    _location = value;
                OnPropertyChanged(nameof(location));
            }
        }
        string _location = CommonStrings.Location;

        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                    _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        string _name = CommonStrings.Name;

        public string nameOfTheTrainingOrganization
        {
            get { return _nameOfTheTrainingOrganization; }
            set
            {
                if (_nameOfTheTrainingOrganization != value)
                    _nameOfTheTrainingOrganization = value;
                OnPropertyChanged(nameof(nameOfTheTrainingOrganization));
            }
        }
        string _nameOfTheTrainingOrganization = CommonStrings.NameOfTheTrainingOrganization;

        public string patronymic
        {
            get { return _patronymic; }
            set
            {
                if (_patronymic != value)
                    _patronymic = value;
                OnPropertyChanged(nameof(patronymic));
            }
        }
        string _patronymic = CommonStrings.Patronymic;

        public string phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                    _phone = value;
                OnPropertyChanged(nameof(phone));
            }
        }
        string _phone = CommonStrings.Phone;

        public string position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                    _position = value;
                OnPropertyChanged(nameof(position));
            }
        }
        string _position = CommonStrings.Position;

        public string responsibilities
        {
            get { return _responsibilities; }
            set
            {
                if (_responsibilities != value)
                    _responsibilities = value;
                OnPropertyChanged(nameof(responsibilities));
            }
        }
        string _responsibilities = CommonStrings.Responsibilites;

        public string selectImage
        {
            get { return _selectImage; }
            set
            {
                if (_selectImage != value)
                    _selectImage = value;
                OnPropertyChanged(nameof(selectImage));
            }
        }
        string _selectImage = CommonStrings.SelectImage;

        public string seniority
        {
            get { return _seniority; }
            set
            {
                if (_seniority != value)
                    _seniority = value;
                OnPropertyChanged(nameof(seniority));
            }
        }
        string _seniority = CommonStrings.Seniority;

        public string skills
        {
            get { return _skills; }
            set
            {
                if (_skills != value)
                    _skills = value;
                OnPropertyChanged(nameof(skills));
            }
        }
        string _skills = CommonStrings.Skills;

        public string startEndDateCourses
        {
            get { return _startEndDateCourses; }
            set
            {
                if (_startEndDateCourses != value)
                    _startEndDateCourses = value;
                OnPropertyChanged(nameof(startEndDateCourses));
            }
        }
        string _startEndDateCourses = CommonStrings.StartEndDateCourses;

        public string startEndDateWork
        {
            get { return _startEndDateWork; }
            set
            {
                if (_startEndDateWork != value)
                    _startEndDateWork = value;
                OnPropertyChanged(nameof(startEndDateWork));
            }
        }
        string _startEndDateWork = CommonStrings.StartEndDateWork;
        public string add
        {
            get { return _add; }
            set
            {
                if (_add != value)
                    _add = value;
                OnPropertyChanged(nameof(add));
            }
        }
        string _add = CommonStrings.add;

        public string delete
        {
            get { return _delete; }
            set
            {
                if (_delete != value)
                    _delete = value;
                OnPropertyChanged(nameof(delete));
            }
        }
        string _delete = CommonStrings.delete;

        string _languageButton = Thread.CurrentThread.CurrentCulture.Name;
        public string LanguageButton
        {
            get { return _languageButton; }
            set
            {
                if(_languageButton != value)
                    _languageButton = value;
                OnPropertyChanged(nameof(LanguageButton));
            }
        }
 
        #endregion
        private void UpdateUI()
        {
            acquiredSkills = CommonStrings.AcquiredSkills;
            addSupplementalEducation = CommonStrings.AddSupplementalEducation;
            addWorkExperience = CommonStrings.AddWorkExperience;
            brieflyDescribe = CommonStrings.BrieflyDescribe;
            company = CommonStrings.Company;
            courseTitle = CommonStrings.CourseTitle;
            criminalRecord = CommonStrings.CriminalRecord;
            dateOfBirth = CommonStrings.DateOfBirth;    
            deleteSupplementalEducation = CommonStrings.DeleteSupplementalEducation;
            deleteWorkExperience = CommonStrings.DeleteWorkExperience;
            describeYourself = CommonStrings.DescribeYourself;
            email = CommonStrings.Email;
            infoEducationalCourses = CommonStrings.InfoEducationalCourses;
            infoPastWork = CommonStrings.InfoPastWork;
            listTheArticlesSeparatedByCommas = CommonStrings.ListTheArticlesSeparatedByCommas;
            location = CommonStrings.Location;
            name = CommonStrings.Name;
            nameOfTheTrainingOrganization = CommonStrings.NameOfTheTrainingOrganization;
            patronymic = CommonStrings.Patronymic;
            phone = CommonStrings.Phone;
            position = CommonStrings.Position;
            responsibilities = CommonStrings.Responsibilites;
            selectImage = CommonStrings.SelectImage;
            seniority = CommonStrings.Seniority;
            skills = CommonStrings.Skills;
            startEndDateCourses = CommonStrings.StartEndDateCourses;
            startEndDateWork = CommonStrings.StartEndDateWork;
            surname = CommonStrings.Surname;
            add = CommonStrings.add;
            delete = CommonStrings.delete;
            LanguageButton = CurrentCulture;
        }

        private void UpdateLocalization()
        {
            if (CurrentCulture == "ru-RU")
                CurrentCulture = "eu-US";
            else if (CurrentCulture == "eu-US")
                CurrentCulture = "ru-RU";
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(CurrentCulture); 
        }
        #endregion
    }
}
