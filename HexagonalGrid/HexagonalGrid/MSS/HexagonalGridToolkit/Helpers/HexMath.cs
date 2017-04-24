using System;

namespace MSS.HexagonalGridToolkit
{
    public static class HexMath
    {
        /// <summary>
        /// Calculates a number of elements in a "ring" of hexes with radius R.
        /// </summary>
        /// <param name="R">Radius</param>
        /// <returns></returns>
        public static int CalcNumElementsInRing(int R)
        {
            return Math.Max(1, 6 * R);
        }

        /// <summary>
        /// Calculates a total number of elements in a hexagon shaped hexes area with radius R.
        /// </summary>
        /// <param name="R">Radius</param>
        /// <returns></returns>
        public static int CalcNumElementsInHexagon(int R)
        {
            return 3 * (R * R + R) + 1;
        }

        /// <summary>
        /// Calculates a total number of elements in a triangle shaped hexes with size "Size".
        /// </summary>
        /// <param name="Size">Size in hexes of the triangle side.</param>
        /// <returns></returns>
        public static int CalcNumElementsInTriangle(int Size)
        {
            return Size / 2 * (Size + 1);
        }
    }
}
