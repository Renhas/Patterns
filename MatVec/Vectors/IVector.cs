namespace MatVec.Vectors
{
    public interface IVector
    {
        public int Dimension { get; }
        public double this[int index] { get; set; }
    }
}