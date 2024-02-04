using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _30._01._2024_FinalProjectWpf_PDF
{
    public class ModelPerson
    {
        public ModelPerson()
        {
            WorkExperiences = new ObservableCollection<WorkExperience>();
            WorkExperience works = new WorkExperience();
            WorkExperiences.Add(works);
            SupplementalEducations = new ObservableCollection<SupplementalEducation>();
            SupplementalEducation supp = new SupplementalEducation();
            SupplementalEducations.Add(supp);
        }
        #region Общая информация
        public string Name = string.Empty;
        public string Surname { get; set; } = string.Empty;
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Skills { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Стаж. Исчисляется в месяцах
        /// </summary>
        public int Seniority { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public BitmapImage ProfileImage { get; set; }
        #endregion

        #region Опыт работы
        public ObservableCollection<WorkExperience> WorkExperiences { get; set; }

        public class WorkExperience
        {
            public WorkExperience() { }
            public string Position { get; set; } = string.Empty;
            public string Responsibilities { get; set; } = string.Empty;
            public string Company { get; set; } = string.Empty;
            public DateTime DateStartWork { get; set; } = DateTime.Now;
            public DateTime DateEndWork { get; set; } = DateTime.Now;
            public string Location { get; set; } = string.Empty;
        }
        #endregion

        #region Сведения о доп образовании.
        public ObservableCollection<SupplementalEducation> SupplementalEducations { get; set; }
        public class SupplementalEducation
        {
            public string TitleOfAdditionalEducation { get; set; } = string.Empty;
            public string EducationalOrganization { get; set; } = string.Empty;
            public DateTime DateStartWork { get; set; } = DateTime.Now.Date;
            public DateTime DateEndWork { get; set; } = DateTime.Now.Date;
            public string AcquiredSkills { get; set; } = string.Empty;
        }
        #endregion

        #region Сведения о судимости
        public bool CriminalRecord { get; set; } = false;
        public string ArticlesOfConviction { get; set; } = string.Empty;
        public string BriefDescriptionOfTheOffense { get; set; } = string.Empty;
        #endregion
    }
}