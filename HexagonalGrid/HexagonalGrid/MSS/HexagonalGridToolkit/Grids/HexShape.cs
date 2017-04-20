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

        // Parallelograms
        //unordered_set<Hex> map;
        //for (int q = q1; q <= q2; q++) {
        //    for (int r = r1; r <= r2; r++) {
        //        map.insert(Hex(q, r, -q-r)));
        //    }
        //}

        // Triangles #1
        //unordered_set<Hex> map;
        //for (int q = 0; q <= map_size; q++) {
        //    for (int r = 0; r <= map_size - q; r++) {
        //        map.insert(Hex(q, r, -q-r));
        //    }
        //}

        // Triangles #2
        //unordered_set<Hex> map;
        //for (int q = 0; q <= map_size; q++) {
        //    for (int r = map_size - q; r <= map_size; r++) {
        //        map.insert(Hex(q, r, -q-r));
        //    }
        //}

        // Hexagon
        //unordered_set<Hex> map;
        //for (int q = -map_radius; q <= map_radius; q++) {
        //    int r1 = max(-map_radius, -q - map_radius);
        //    int r2 = min(map_radius, -q + map_radius);
        //    for (int r = r1; r <= r2; r++) {
        //        map.insert(Hex(q, r, -q-r));
        //    }
        //}

        // Ractangle
        //unordered_set<Hex> map;
        //for (int r = 0; r<map_height; r++) {
        //    int r_offset = floor(r / 2); // or r>>1
        //    for (int q = -r_offset; q<map_width - r_offset; q++) {
        //        map.insert(Hex(q, r, -q-r));
        //    }
        //}
    }
}
