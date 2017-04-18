using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MSS.HexagonalGridToolkit
{
    public struct HexCoords
    {
        public int q { get; private set; }
        public int r { get; private set; }
        public int s { get { return -q - s; } }

        private static HexCoords[] s_neighborsCoords = {
            new HexCoords(1, 0),
            new HexCoords(1, -1),
            new HexCoords(0, -1),
            new HexCoords(-1, 0),
            new HexCoords(-1, 1),
            new HexCoords(0, 1)
        };

        public HexCoords(int _q, int _r)
        {
            q = _q;
            r = _r;
            Debug.Assert(q + r + s == 0);
        }

        public IEnumerator<HexCoords> Neighbors()
        {
            for (int i = 0; i < s_neighborsCoords.Length; i++) {
                yield return this + s_neighborsCoords[i];
            }
        }

        public static int Distance(HexCoords a, HexCoords b)
        {
            return (Math.Abs(a.q - b.q) + Math.Abs(a.r - b.r) + Math.Abs(a.s - b.s)) / 2;
        }

        #region Operators

        public static bool operator == (HexCoords a, HexCoords b)
        {
            return a.q == b.q && a.r == b.r && a.s == b.s;
        }

        public static bool operator != (HexCoords a, HexCoords b)
        {
            return !(a == b);
        }

        public static HexCoords operator + (HexCoords a, HexCoords b)
        {
            return new HexCoords(a.q + b.q, a.r + b.r);
        }

        public static HexCoords operator - (HexCoords a, HexCoords b)
        {
            return new HexCoords(a.q - b.q, a.r - b.r);
        }

        public static HexCoords operator * (HexCoords a, int k)
        {
            return new HexCoords(a.q * k, a.r * k);
        }

        #endregion
    }
}
