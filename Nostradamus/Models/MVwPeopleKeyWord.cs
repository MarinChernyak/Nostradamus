using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models
{
    public class MVwPeopleKeyWord
    {
        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public byte DataType { get; set; }
        public short Idkw { get; set; }
        public short? ReferenceId { get; set; }
        public byte AccessLevel { get; set; }
        public string AdvKeyWord { get; set; }
        public string KeyWordDescription { get; set; }

        public string ToListPeople
        {
            get
            {
                return $"{SecondName} {FirstName}";
            }
        }
    }
}
