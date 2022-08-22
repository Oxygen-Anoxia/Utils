using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Person> CollectionOfPeople = new List<Person>();

                Person Jeff = new Person();
                Jeff.Age = 33;
                Jeff.Firstname = "Jeff";
                Jeff.Lastname = "Jefferson";
                Jeff.GroupCode = "JJJ";
                // LOOK! This line was added
                Jeff.Validate();

                CollectionOfPeople.Add(Jeff);

                Person Tim = new Person();
                Tim.Age = 444;
                Tim.Firstname = "";
                Tim.Lastname = "";
                Tim.GroupCode = "";
                // LOOK! This line was added
                Tim.Validate();
                CollectionOfPeople.Add(Tim);

            }
            catch (ValidationException Exp)
            {
                MessageBox.Show(this, Exp.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception Exp)
            {
                MessageBox.Show(this, Exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

    public class Person
    {
        private int m_iAge = 1;
        private string m_sFirstname = "Unknown";
        private string m_sLastname = "";
        private string m_sGroupCode = "AAA";

        [Required(ErrorMessage = "Age is a required field.")]
        [Range(1, 100, ErrorMessage = "A persons age must be between 1 and 100.")]
        public int Age
        {
            get { return m_iAge; }
            set { m_iAge = value; }
        }

        [Required(ErrorMessage = "Firstname is a required field.")]
        public string Firstname
        {
            get { return m_sFirstname; }
            set { m_sFirstname = value; }
        }

        public string Lastname
        {
            get { return m_sLastname; }
            set { m_sLastname = value; }
        }

        [StringLength(3, MinimumLength = 3)]
        public string GroupCode
        {
            get { return m_sGroupCode; }
            set { m_sGroupCode = value; }
        }

        public void Validate()
        {
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid == false)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                throw new ValidationException(sbrErrors.ToString());
            }
        }
    }

}
