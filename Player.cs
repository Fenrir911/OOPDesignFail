using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    public class Player
    {
        private int currentRow { get; set; } = 0;
        private int currentColumn { get; set; } = 0;

        public bool HasWon = false;
        public Player()
        {

        }
        public override string ToString()
        {
            return $"(Row = {GetCurrentRow()} Column = {GetCurrentColumn()})";
        }
        public int GetCurrentRow() => currentRow;
        public int GetCurrentColumn() => currentColumn;
        public (int currentRow, int currentColumn) GetCoordinates() => (currentRow, currentColumn);

        public Room CurrentRoom(Rooms rooms)
        {
            Room currentRoom = rooms.RoomsGrid[currentRow, currentColumn];
            Console.WriteLine($"You are in the room at {this.ToString()}");
            if (currentRoom.IsEntrance(rooms))
            {
                Console.WriteLine("You see the light coming from the cavern entrance.");
                if(rooms.fountain.IsEnabled == true)
                {
                    Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
                    HasWon = true;
                }
            }
            else if (currentRoom.IsFountain(rooms) && (!rooms.fountain.IsEnabled))
                {
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
                }
            else if (currentRoom.IsFountain(rooms) && (rooms.fountain.IsEnabled == true))
            {
                Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            }
            return currentRoom;
        }
        public void Action(Rooms rooms)
        {
            bool legalMove = false;
            string readResult;
            do
                {
                Console.Write("What do you want to do? ");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                        switch (readResult)
                        {
                            case "move north":
                            if (currentRow - 1 >= 0)
                            {
                                legalMove = true;
                                currentRow -= 1;
                            }
                            else
                            {
                                Console.WriteLine("Inavlid Move");
                            }
                            break;
                            case "move south":
                            if (currentRow + 1 < rooms.RoomsGrid.GetLength(0))
                            {
                                legalMove = true;
                                currentRow += 1;
                            }
                            else
                            {
                                Console.WriteLine("Inavlid Move");
                            }
                            break;
                            case "move east":
                            if (currentColumn + 1 < rooms.RoomsGrid.GetLength(1))
                            {
                                legalMove = true;
                                currentColumn += 1;
                            }
                            else
                            {
                                Console.WriteLine("Inavlid Move");
                            }
                            break;
                        case "move west":
                            if (currentColumn - 1 >= 0)
                            {
                                legalMove = true;
                                currentColumn -= 1;
                            }
                            else
                            {
                                Console.WriteLine("Inavlid Move");
                            }
                            break;
                        case "enable fountain":
                            if (rooms.fountain.IsEnabled == false)
                            {
                                legalMove = true;
                                rooms.fountain.EnableFountain();
                            }
                            else
                            {
                                Console.WriteLine("Inavlid Move");
                            }
                            break;
                        default:
                                continue;
                        }       
                    }
                } while (!legalMove);
            
        }

    }
}
