namespace MSS.HexagonalGridToolkit
{
    public class HexGrid
    {
        private HexLayout layout;
        private HexShape shape;
        private HexCoords[] hexMap;

        public HexGrid(HexLayout _layout, HexShape _shape, Coords2 _size)
        {
            layout = _layout;
            shape = _shape;

            hexMap = shape.GenerateHaxMap(_size);
        }

        
    }
}
