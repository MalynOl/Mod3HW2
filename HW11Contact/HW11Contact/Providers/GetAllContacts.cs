using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11Contact
{
    public class GetAllContacts
    {
        public GetAllContacts()
        {
            ListContacts = new List<Contact>
            {
                new Contact("Adamson", "Tom", " ", "020 4565 1232"),
                new Contact("Smith", "Kevin", " ", "020 1234 1232"),
                new Contact("Walker", "Ben", " ", "020 4565 4422"),
                new Contact("Lewis", "Alexander", " ", "020 4465 1235"),
                new Contact("Adamson", "Karl", " ", "020 7878 1232"),
                new Contact("Davis", "Tom", " ", "020 4465 1235"),
                new Contact("Walkers", "Kevin", " ", "720 4442 4422"),
                new Contact("вечер", "Сергей", "Леонидович", "050 4565 132"),
                new Contact("Івасюк", "Данило", "Вікторович", "050 1165 132"),
                new Contact("Кулик", "Остап", "Богданович", "050 4565 456"),
                new Contact("Дорошенко", "Егор", "Александрович", "050 7765 552"),
                new Contact("Доронин", "Иван", "Александрович", "050 1212 552"),
                new Contact("Зелений", "Николай", "Сергеевич", "066 9965 162"),
                new Contact("1255", " ", " ", "098 9965 162"),
                new Contact("  ", "Сергей", " ", "066 1111 162"),
                new Contact("125Простенко", "Сергей", "Сергеевич", "066 9965 162"),
                new Contact("+Ново", " ", " ", "066 1111 162"),
                new Contact("+++", " ", " ", "066 9965 111"),
            };
        }

        public List<Contact> ListContacts { get; set; }
    }
}
