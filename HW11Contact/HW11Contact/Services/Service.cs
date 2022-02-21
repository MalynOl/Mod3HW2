using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace HW11Contact
{
    public class Service
    {
        public Service()
        {
            AllContacts = new GetAllContacts();
        }

        public GetAllContacts AllContacts { get; init; }

        public Dictionary<string, List<Contact>> MethodGeneral(string patternLanguage, string patternOther)
        {
            List<Contact> contactsList = GetListContactsForPattern(patternLanguage);

            Dictionary<string, List<Contact>> contacts = AddToDictionary(contactsList);

            List<Contact> contactsDigitList = MethodDigitContacts();

            contacts.Add("[0-9]", contactsDigitList);

            List<Contact> contactsOtherSymbolList = MethodOtherSymbol(patternOther);

            contacts.Add("#", contactsOtherSymbolList);

            return contacts;
        }

        public Dictionary<string, List<Contact>> MethodUK()
        {
            Dictionary<string, List<Contact>> ukContacts = MethodGeneral(@"[А-ЯҐЄІЇа-яґєії]", @"\W|[a-zA-Z]");

            return ukContacts;
        }

        public Dictionary<string, List<Contact>> MethodRU()
        {
            Dictionary<string, List<Contact>> ruContacts = MethodGeneral(@"[А-Яа-я]", @"\W|[a-zA-ZҐЄІЇ]");

            return ruContacts;
        }

        public Dictionary<string, List<Contact>> MethodEN()
        {
            Dictionary<string, List<Contact>> enContacts = MethodGeneral(@"[a-zA-Z]", @"\W|[А-ЯҐЄІЇ]");

            return enContacts;
        }

        private List<Contact> MethodDigitContacts()
        {
            string pattern = @"^\d";

            List<Contact> contactsDigitList = GetListContactsForPattern(pattern);

            return contactsDigitList;
        }

        private List<Contact> MethodOtherSymbol(string pattern)
        {
            List<Contact> contactSymbolList = GetListContactsForPattern(pattern);

            return contactSymbolList;
        }

        private List<Contact> GetListContactsForPattern(string pattern)
        {
            List<Contact> outputContacs = new List<Contact>();
            try
            {
                if (AllContacts != null)
                {
                    AllContacts.ListContacts.Sort();

                    foreach (var item in AllContacts.ListContacts)
                    {
                        if (Regex.IsMatch(item.FullName.Substring(0, 1), pattern))
                        {
                            outputContacs.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return outputContacs;
        }

        private Dictionary<string, List<Contact>> AddToDictionary(List<Contact> contacts)
        {
            Dictionary<string, List<Contact>> cultureDictionary = new Dictionary<string, List<Contact>>();

            try
            {
                if (contacts != null)
                {
                    foreach (var item in contacts)
                    {
                        string firstLatter = item.FullName.Substring(0, 1);

                        if (!cultureDictionary.ContainsKey(firstLatter))
                        {
                            var selectedContacts = (from c in contacts
                                                    where c.LastName.StartsWith(firstLatter)
                                                    select c).ToList<Contact>();

                            cultureDictionary.Add(firstLatter.ToUpper(), selectedContacts);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return cultureDictionary;
        }
    }
}
