using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tudás_Harca
{
    internal class Question
    {

        public string prompt { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }
        public int correct { get; set; }


        public Question(string _prompt, string _answer1, string _answer2, string _answer3, string _answer4, int _correct)
        {
            this.prompt = _prompt;
            this.answer1 = _answer1;
            this.answer2 = _answer2;
            this.answer3 = _answer3;
            this.answer4 = _answer4;
            this.correct = _correct;
        }
    }
}
