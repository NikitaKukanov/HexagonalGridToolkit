namespace MSS.HexagonalGridToolkit
{
    public class HexGrid
    {
        private HexLayout layout;
        private HexShape shape;
        private HexCoords[] hexMap;

        public HexGrid(HexLayout _layout, HexShape _shape)
        {
            layout = _layout;
            shape = _shape;
        }
    }
}
