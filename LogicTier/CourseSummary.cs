namespace LogicTier
{
    public class CourseSummary
    {
        public int Course { get; set; }
        public int TotalDebts { get; set; }
        public string Display
        {
            get { return "Курс " + Course + ": задолженностей = " + TotalDebts; }
        }
    }
}