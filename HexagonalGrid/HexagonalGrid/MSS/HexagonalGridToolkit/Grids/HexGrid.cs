using System.Diagnostics;

namespace MSS.HexagonalGridToolkit
{
    public abstract class HexGrid<T>
    {
        #region Grid Params
        public T[] HexMap { get; protected set; }
        public HexOrientation Orientation { get; protected set; }
        #endregion

        public virtual int GetTotalElementsCount()
        {
            return 0;
        }

        protected virtual HexCoords GetHexCoordsFromOnedimentionalIndex(int _index)
        {
            return new HexCoords();
        }

        protected virtual int GetOnedimensionalHexIndex(int q, int r)
        {
            return 0;
        }
    }
}
