namespace MSS.HexagonalGridToolkit
{        
    public class HexagonHexGrid<T> : HexGrid<T>
    {
        #region Grid Params
        public int Radius { get; private set; }
        #endregion

        #region Public Override

        protected override int GetOnedimensionalHexIndex(int q, int r)
        {
            return 0;
        }

        #endregion
    }
}

