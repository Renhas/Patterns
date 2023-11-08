﻿using System;
using MatVec.Matrices;
using MatVec.Matrices.Compositors;
using MatVec.Matrices.Decorators;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Visitors;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleDrawer drawer = new ConsoleDrawer();
            IMatrix simple = new Matrix(5, 3, drawer);
            IMatrix sparse = new SparseMatrix(5, 7, drawer);
            double max_1 = 15.0, max_2 = 100.0;
            int notNull_1 = 14, notNull_2 = 33;
            
            MatrixInitializer.FillMatrix(simple, notNull_1, max_1);
            MatrixInitializer.FillMatrix(sparse, notNull_2, max_2);
            /*
            MatrixStats simpleStats = new MatrixStats(simple);
            MatrixStats sparseStats = new MatrixStats(sparse);

            WriteStats(simpleStats, "Simple matrix");
            WriteStats(sparseStats, "Sparse matrix");
            Console.WriteLine();
            */
            IMatrix first = new SparseMatrix(3, 2, drawer);
            IMatrix second = new SparseMatrix(2, 3, drawer);
            MatrixInitializer.FillMatrix(first, 5, 10);
            MatrixInitializer.FillMatrix(second, 5, 10);
            Draw(first, drawer);
            Draw(second, drawer);
            HCompositorMatrix matrix = new HCompositorMatrix(drawer);
            matrix.Add(first);
            matrix.Add(second);
            Draw(matrix, drawer);
            Draw(new TransposeDecorator(matrix, drawer), drawer);


        }

        private static void Draw(IMatrix mtx, IDrawer drawer) 
        {
            drawer.Clear();
            mtx.Draw();
        }

        private static void WriteStats(MatrixStats stats, string title = "") 
        {
            Console.WriteLine(title);
            Console.WriteLine($"Сумма = {stats.SumValue}");
            Console.WriteLine($"Среднее = {stats.AvgValue}");
            Console.WriteLine($"Максимальное = {stats.MaxValue}");
            Console.WriteLine($"Кол-во ненулевых элементов = {stats.NotNullCount}");
        }
    }
}