﻿using NostradamusDAL.Entities;
using NostradamusDAL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nostradamus.Models
{
    public class MPersonBase : BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public byte BirthDay { get; set; }
        public byte BirthMonth { get; set; }
        public short BirthYear { get; set; }
        public byte BirthHourFrom { get; set; }
        public byte BirthMinFrom { get; set; }
        public byte BirthSecFrom { get; set; }
        public byte BirthHourTo { get; set; }
        public byte BirthMinTo { get; set; }
        public byte BirthSecTo { get; set; }
        public byte SourceBirthTime { get; set; }
        public byte AdditionalHours { get; set; }
        public int Place { get; set; }
        public byte DataType { get; set; }
        public int? IdContributor { get; set; }
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsAvailable { get; set; }
        public int? Sex { get; set; }

        public string ToListBox
        {
            get
            {
                return $"{SecondName} {FirstName}, ({BirthYear})";
            }
        }
    }
    public class MPersonComplete : MPersonBase
    {

    }
    public class PersonsCollection : BaseModel
    {
        public List<MPersonBase> GetPersonalCollectionByLastName(string LastName)
        {
            List<Person> data = new List<Person>();
            NostradamusContextFactory factory = new NostradamusContextFactory();
            using (var context = factory.CreateDbContext(new string[] { _connection }))
            {

                var tem = context.People;
                data.AddRange(context.People);
                data = data.Where(x => x.SecondName.Contains(LastName)).ToList();

            }

            return ModelsTransformer.TransferModelList<Person, MPersonBase>(data);
        }
    }
}