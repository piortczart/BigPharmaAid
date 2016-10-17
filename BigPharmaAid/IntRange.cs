namespace BigPharmaAid
{
    public class IntRange
    {
        public int From { get; }
        public int To { get; }

        public IntRange(int from, int to)
        {
            From = from;
            To = to;
        }

        public bool Overlaps(IntRange otherRange)
        {
            return (To >= otherRange.From && From <= otherRange.To) ||
                   (otherRange.To >= From && otherRange.From <= To);
        }

        public bool Contains(int i)
        {
            return i >= From && i <= To;
        }

        public override string ToString()
        {
            return $"{From}-{To}";
        }
    }
}