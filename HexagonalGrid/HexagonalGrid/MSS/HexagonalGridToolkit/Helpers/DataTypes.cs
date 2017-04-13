﻿using System.Diagnostics;

namespace MSS.HexagonalGridToolkit
{
    public struct Coords2
    {
        public int x;
        public int y;
    }

    public struct Point2
    {
        public float x;
        public float y;

        public Point2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
    }

    public class Matrix
    {
        // rows, columns
        private float[,] data;

        //     c0 c1 c2
        // r0 { 1, 2, 3},
        // r1 { 5, 4, 2},
        // r2 { 2, 3, 4}

        public float this[int i, int j] {
            get {
                return data[i, j];
            }
            set {
                data[i, j] = value;
            }
        }

        public Matrix(float[,] _data)
        {
            _data = data;
        }

        public static Matrix operator * (Matrix a, int c)
        {
            Matrix result = new Matrix(new float[a.data.GetLength(0), a.data.GetLength(1)]);
            for (int i = 0; i < a.data.GetLength(0); i++) {
                for (int j = 0; j < a.data.GetLength(1); j++) {
                    result[i, j] = a[i, j] * c;
                }
            }
            return result;
        }

        public static Matrix operator * (Matrix a, Matrix b)
        {
            // number of columns (1) of the left matrix is the same as the number of rows (0) of the right matrix
            Debug.Assert(a.data.GetLength(1) != b.data.GetLength(0));
            // If A is an m(0)-by-n(1) matrix and B is an n(0)-by-p(1) matrix, 
            // then their matrix product A*B is the m(0,a)-by-p(1,b) matrix whose entries are 
            // given by dot product of the corresponding row (0) of A and the corresponding column (1) of B:
            Matrix result = new Matrix(new float[a.data.GetLength(0), b.data.GetLength(1)]);
            for (int i = 0; i < a.data.GetLength(0); i++) {
                for (int j = 0; j < b.data.GetLength(1); j++) {
                    result[i, j] = 0;
                    for (int r = 0; r < a.data.GetLength(1); r++) {
                        result[i, j] += a[i, r] * b[r, j];
                    }
                }
            }
            return result;
        }
    }
}
