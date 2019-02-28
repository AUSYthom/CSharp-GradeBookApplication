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

            int rank = 1;
            int threshold = (int)Math.Ceiling(Students.Count * 0.2);

            foreach (Student person in Students)
            {
                if (averageGrade < person.AverageGrade)
                {
                    rank++;
                }
            }

            if (rank <= threshold)
                result = 'A';
            else if (rank <= threshold*2)
                result = 'B';
            else if (rank <= threshold*3)
                result = 'C';
            else if (rank <= threshold*4)
                result = 'D';
            else
                result = 'F';

            return result;
        }
    }
}
