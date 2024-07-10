using TheFountainOfObjects;

InitializeTest();
void InitializeTest()
{
    Player player = new Player();
    Rooms rooms = CreateRooms();
    while (!player.HasWon)
    {
        Console.WriteLine($"--------------------------------------------------------------------");
        player.CurrentRoom(rooms);
        if (!player.HasWon)
            player.Action(rooms);
        else
            continue;
    }
}
Rooms CreateRooms()
{
    Console.WriteLine("Select Room size:\n\t1.Small\n\t2.Medium\n\t3.Large");
    string readResult = Console.ReadLine();
    Rooms rooms;
    if (readResult != null )
    {
        readResult = readResult.ToLower();
        switch (readResult)
        {
            case "small":
                rooms = new Rooms(4, 4);
                return rooms;
            case "medium":
                rooms = new Rooms(6, 6);
                return rooms;
            case "large":
                rooms = new Rooms(8, 8);
                return rooms;
        }
    }
    return new Rooms();
}