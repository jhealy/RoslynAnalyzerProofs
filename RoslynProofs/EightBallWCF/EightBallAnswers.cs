using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EightBallWCF
{
    public class EightBallAnswers
    {
        private readonly List<string> m_Answers = new List<string>
        {
            @"It is certain",
            @"It is decidedly so",
            @"Without a doubt",
            @"Yes, definitely",
            @"You may rely on it",
            @"As I see it, yes",
            @"Most likely",
            @"Outlook good",
            @"Yes",
            @"Signs point to yes",
            @"Reply hazy try again",
            @"Ask again later",
            @"Better not tell you now",
            @"Cannot predict now",
            @"Concentrate and ask again",
            @"Don't count on it",
            @"My reply is no",
            @"My sources say no",
            @"Outlook not so good",
            @"Very doubtful"
        };

        private Int32 m_NumAnswers = -1;
        private Int32 NumAnswers
        {
            get
            {
                if ( m_NumAnswers<=0)
                {
                    m_NumAnswers = m_Answers.Count;
                }
                return m_NumAnswers;
            }
        }

        private static Random m_Random = new Random(DateTime.Now.Millisecond);
        public string RandomAnswer()
        {
            Int32 fetchMe = m_Random.Next(0, NumAnswers - 1);
            return m_Answers[fetchMe]; 
        }
    }
}