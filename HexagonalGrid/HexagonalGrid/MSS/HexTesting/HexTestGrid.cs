using MSS.HexagonalGridToolkit;

namespace MSS.HexTesting
{
    public class HexTestGrid
    {
        private HexGrid grid;

        public HexTestGrid(float _hexSize, HexOrientation _orientation, HexShape _shape, Coords2 _size)
        {
            grid = new HexGrid(new HexLayout(_hexSize, _orientation), _shape, _size);
        }
    }
}
