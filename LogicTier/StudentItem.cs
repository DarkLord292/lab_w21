using DataTier;

namespace LogicTier
{
    public class StudentItem
    {
        private readonly Student _s;

        public StudentItem(Student s) { _s = s; }

        public string Fio { get { return _s.Fio; } set { _s.Fio = value; } }
        public string Group { get { return _s.Group; } set { _s.Group = value; } }
        public int Course { get { return _s.Course; } set { _s.Course = value; } }
        public int Debts { get { return _s.Debts; } set { _s.Debts = value; } }

        public string Display
        {
            get { return _s.Fio + " | " + _s.Group + " | курс " + _s.Course + " | долгов: " + _s.Debts; }
        }
    }
}