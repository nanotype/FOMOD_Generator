using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_databind.Modules.RoomCarto
{
	internal class Donjon
	{
		public List<List<Room>> Rooms { get; set; } = new List<List<Room>>();
		
		public Donjon()
		{
			InitDonjon();

			AddRoom(1, 1, RoomType.Start);
			AddRoom(1, 0, RoomType.plus);
			AddRoom(0, 1, RoomType.plus);
			AddRoom(2, 1, RoomType.plus);
			AddRoom(1, 2, RoomType.plus);
		}

		private void InitDonjon()
		{
			Rooms.Clear();

			for(int i = 0; i < 3; i++)
			{
				Rooms.Add(new List<Room>());
				for(int y = 0; y < 3; y++)
				{
					Room emptyRoom = new Room();
					emptyRoom.RoomType = RoomType.NotExist;
					Rooms[i].Add(emptyRoom);
				}
			}
		}

		public void AddRoom(int x, int y, RoomType roomType)
		{
			Room newRoom = new Room();
			newRoom.RoomType = roomType;
			Rooms[x][y].RoomType = roomType;
		}
	}
}
