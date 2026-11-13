using System.Collections.Generic;
using System.Linq;
using DataTier;

namespace LogicTier
{
    public class University
    {
        private readonly List<StudentItem> _students = new List<StudentItem>();
        private readonly List<CourseSummary> _byCourse = new List<CourseSummary>();

        public string Title { get { return "Студенты и задолженности (вариант 25)"; } }

        public List<StudentItem> Students { get { return _students; } }
        public List<CourseSummary> DebtsByCourse { get { return _byCourse; } }
        public int StudentsWithoutDebts { get; private set; }

        public University(string dataPath)
        {
            var raw = AllStudents.LoadFromFile(dataPath);
            foreach (var s in raw)
                _students.Add(new StudentItem(s));

            _byCourse = _students
                .GroupBy(x => x.Course)
                .Select(g => new CourseSummary
                {
                    Course = g.Key,
                    TotalDebts = g.Sum(x => x.Debts)
                })
                .OrderBy(x => x.Course)
                .ToList();

            StudentsWithoutDebts = _students.Count(x => x.Debts == 0);
        }
    }
}