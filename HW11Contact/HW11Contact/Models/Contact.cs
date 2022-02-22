using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11Contact
{
    public class Contact : IComparable<Contact>
    {
        public Contact(string lastName, string firstName, string patronymic, string phone)
        {
            FirstName = firstName;
            Patronymic = patronymic;
            LastName = lastName;
            FullName = $"{LastName} {FirstName} {Patronymic}";
            PhoneNumber = phone;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public int CompareTo(Contact other)
        {
            Contact temp = other as Contact;

            if (other == null)
            {
                throw new ArgumentException("Parametr is not a Contact!");
            }
            else
            {
                return FullName.CompareTo(other.FullName);
            }
        }
    }
}
