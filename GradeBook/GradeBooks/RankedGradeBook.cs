using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            char result;

            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grade need at least more than 5 student;");

            //int threshold = (int)(Students.Count*0.2);

            int rank = 1;

            foreach (Student person in Students)
            {
                if (averageGrade < person.AverageGrade)
                {
                    rank++;
                }
            }

            if (rank < (int)(Students.Count * 0.8))
                result = 'A';
            else if (rank < (int)(Students.Count * 0.6))
                result = 'B';
            else if (rank < (int)(Students.Count * 0.4))
                result = 'C';
            else if (rank < (int)(Students.Count * 0.2))
                result = 'D';
            else
            {
                result = 'F';
            }

            return result;
        }
    }
}
