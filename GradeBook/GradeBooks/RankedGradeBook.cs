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
                return 'A';
            else if (rank <= threshold*2)
                return 'B';
            else if (rank <= threshold*3)
                return 'C';
            else if (rank <= threshold*4)
                return 'D';
            else
                return 'F';
        }
    }
}
