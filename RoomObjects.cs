using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public abstract class RoomObjects
    {
        private int Row;
        private int Column;
        public int GetRow() => Row;
        public int GetColumn() => Column;
        public RoomObjects(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
    public class Fountain : RoomObjects
    {

        private bool isEnabled = false;
        public Fountain(): base (0, 2)
        {
        }
        Room AssignedRoom(Rooms rooms)
        {
            Room assignedRoom = rooms.RoomsGrid[this.GetRow(), this.GetColumn()];
            return assignedRoom;
        }
        public bool IsEnabled => isEnabled;
        public void EnableFountain()
        {
            isEnabled = true;
        }
    }
    public class Entrance : RoomObjects
    {
        
        public Entrance() : base (0, 0)
        {
        }
        Room AssignedRoom(Rooms rooms)
        {
            Room assignedRoom = rooms.RoomsGrid[this.GetRow(), this.GetColumn()];
            return assignedRoom;
        }

    }
}
