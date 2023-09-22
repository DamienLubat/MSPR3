using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestMSPR3
{
    public class ItemEntity
    {
        public int Id { get; set; }
    }

    public class DescriptiveEntity
    {
        public int IDDescriptive { get; set; }
        public int IDLanguage { get; set; }
        public string descriptionShort { get; set; }
        public string descriptionLong { get; set; }
    }

}
