namespace MSS.HexagonalGridToolkit
{
    public class HexShape
    {
        public virtual HexCoords GetHexCoordsFromOnedimentionalIndex(int _index)
        {
            return new HexCoords();
        }

        public virtual int GetOnedimensionalHexIndex(int q, int r)
        {
            return 0;
        }
    }
}
