using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement
{
    public class MarkSheet
    {
        public int StudentId { get; set; }
        public int Mathematics { get; set; }
        public int Science { get; set; }
        public int English { get; set; }
        public int SocialScience { get; set; }
        public int Hindi { get; set; }
        public int Gujarati { get; set; }
        public int ObtainedMark { get; set; }
        public int TotalMark { get; set; }
        public int Percentage { get; set; }
        public string Grade { get; set; }
        public string Result { get; set; }
    }
}
