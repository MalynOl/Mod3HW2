using System;
using System.Globalization;
using System.Collections.Generic;

namespace HW11Contact
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, List<Contact>> ukContacts;
            Dictionary<string, List<Contact>> ruContacts;
            Dictionary<string, List<Contact>> enContacts;

            Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
            Console.WriteLine("Press EN or RU or UK for select oher culture");

            string cultureName = Console.ReadLine();

            Service service = new Service();

            switch (cultureName)
            {
                case "UK":
                    ukContacts = service.MethodUK();
                    WriteConsole(ukContacts);
                    break;

                case "RU":
                    ruContacts = service.MethodRU();
                    WriteConsole(ruContacts);
                    break;

                case "EN":
                    enContacts = service.MethodEN();
                    WriteConsole(enContacts);
                    break;
            }
        }

        public static void WriteConsole(Dictionary<string, List<Contact>> listContacts)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Your contacts list: ");

            foreach (KeyValuePair<string, List<Contact>> contactsList in listContacts)
            {
                Console.WriteLine(contactsList.Key);
                Console.WriteLine();

                if (contactsList.Value != null)
                {
                    foreach (var contact in contactsList.Value)
                    {
                        Console.WriteLine($"{contact.LastName} {contact.FirstName} {contact.Patronymic} {contact.PhoneNumber}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
