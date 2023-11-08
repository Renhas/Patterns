﻿using MatVec.Matrices.Visitors;

namespace MatVec.Matrices
{
    public interface IMatrix : IDrawable
    {
        public int Rows { get; }
        public int Columns { get; }
        public double this[int row, int col] { get; set; }
        public IMatrix GetElement();
        public void Accept(IVisitor visitor);
    }
}