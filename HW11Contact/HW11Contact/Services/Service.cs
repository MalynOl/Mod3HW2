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

        public Dictionary<string, List<Contact>> MethodUK() // [А-ЯҐЄІЇ]
        {
            string patternUK = @"[А-ЯҐЄІЇа-яґєії]";

            List<Contact> contactsUKList = GetListContactsForPattern(patternUK);

            Dictionary<string, List<Contact>> ukContacts = AddToDictionary(contactsUKList);

            List<Contact> contactsDigitList = MethodDigitContacts();

            ukContacts.Add("[0-9]", contactsDigitList);

            string patternOther = @"\W|[a-zA-Z]";

            List<Contact> contactsOtherSymbolList = MethodOtherSymbol(patternOther);

            ukContacts.Add("#", contactsOtherSymbolList);

            return ukContacts;
        }

        public Dictionary<string, List<Contact>> MethodRU()
        {
            string patternRU = @"[А-Яа-я]";

            List<Contact> contactsRUList = GetListContactsForPattern(patternRU);

            Dictionary<string, List<Contact>> ruContacts = AddToDictionary(contactsRUList);

            List<Contact> contactsDigitList = MethodDigitContacts();

            ruContacts.Add("[0-9]", contactsDigitList);

            string patternOther = @"\W|[a-zA-ZҐЄІЇ]";

            List<Contact> contactsOtherSymbolList = MethodOtherSymbol(patternOther);

            ruContacts.Add("#", contactsOtherSymbolList);

            return ruContacts;
        }

        public Dictionary<string, List<Contact>> MethodEN()
        {
            string patternEn = @"[a-zA-Z]";

            List<Contact> contactsENList = GetListContactsForPattern(patternEn);

            Dictionary<string, List<Contact>> enContacts = AddToDictionary(contactsENList);

            List<Contact> contactsDigitList = MethodDigitContacts();

            enContacts.Add("[0-9]", contactsDigitList);

            string patternOther = @"\W|[А-ЯҐЄІЇ]";

            List<Contact> contactsOtherSymbolList = MethodOtherSymbol(patternOther);

            enContacts.Add("#", contactsOtherSymbolList);

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
