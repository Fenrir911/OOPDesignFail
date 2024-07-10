using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public class Rooms
    {
        private int MaxRows { get; } = 4;
        private int MaxColumns { get; } = 4;
        public Room[,] RoomsGrid;
        public List<RoomObjects> roomObjects = new List<RoomObjects>();
        public Entrance entrance;
        public Fountain fountain;
        public int roomObjectCounter = 0;
        public Rooms()
        {
            RoomsGrid = new Room[MaxRows, MaxColumns];
            for (int i = 0; i < MaxRows; i++)
            {
                for (int j = 0; j < MaxColumns; j++)
                {
                    RoomsGrid[i, j] = new Room(i, j);
                }
            }
            roomObjects.Add(entrance = new Entrance());
            roomObjects.Add(fountain = new Fountain());
        }
        public Rooms(int maxRows, int maxColumns)
        {
            this.MaxRows = maxRows;
            this.MaxColumns = maxColumns;
            RoomsGrid = new Room[MaxRows, MaxColumns];
            for (int i = 0; i < MaxRows; i++)
            {
                for (int j = 0; j < MaxColumns; j++)
                {
                    RoomsGrid[i, j] = new Room(i, j);
                }
            }
            for (int i = 0; i < roomObjectCounter; i++)
            {
               roomObjects.Add(entrance = new Entrance());
               roomObjects.Add(fountain = new Fountain());
            }
           
        }
    }
    public class Room
    {
        public int Row;
        public int Column;
        public RoomObjects roomObject;
        public (int Row, int Column) Coordinates()
        {
            return (Row, Column);
        }
        
        public Room(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public bool PlayerInRoom(Player player)
        {
            if (player.GetCurrentRow() == Row && player.GetCurrentColumn() == Column)
            {
                return true;
            }
            return false;
        }
        public bool IsEntrance(Rooms rooms)
        {
            return (Row == rooms.entrance.GetRow() && Column == rooms.entrance.GetColumn());
        }
        public bool IsFountain (Rooms rooms)
        {
            return (Row == rooms.fountain.GetRow() && Column == rooms.fountain.GetColumn());
        }
    }
}
