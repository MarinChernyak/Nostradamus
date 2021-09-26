using NostradamusDAL.Entities;
using NostradamusDAL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nostradamus.Models
{
    public class MKeyword :BaseModel
    {
        public short Idkw { get; set; }
        public short? ReferenceId { get; set; }
        public byte AccessLevel { get; set; }
        public string AdvKeyWord { get; set; }
        public string KeyWordDescription { get; set; }

    }
    public class KeywordsCollection : BaseModel
    {
        public List<MKeyword> GetKeywordsCollection(int refId)
        {
            List<Keyword> data = new List<Keyword>();
            NostradamusContextFactory factory = new NostradamusContextFactory();
            using (var context = factory.CreateDbContext(new string[] { _connection }))
            {

                var tem = context.Keywords;
                data.AddRange(context.Keywords);
                data = data.Where(x => x.ReferenceId==refId && x.Idkw!=0 && x.Idkw!=400).ToList();

            }

            return ModelsTransformer.TransferModelList<Keyword, MKeyword>(data);
        }
        public MKeyword GetKWbyId(int Id)
        {
            Keyword kw = null;
            NostradamusContextFactory factory = new NostradamusContextFactory();
            using (var context = factory.CreateDbContext(new string[] { _connection }))
            {
                var tem = context.Keywords;

                kw = context.Keywords.Where(x => x.Idkw==Id).FirstOrDefault();
                if(kw!=null)
                    return ModelsTransformer.TransferModel<Keyword, MKeyword>(kw);
            }

            return null;
        }
    }
}
