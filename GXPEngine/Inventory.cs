using System;

namespace GXPEngine
{
	class Inventory : Pivot
	{
		string[] items;
		int size;
		public Inventory(int size)
		{
			items = new string[size];
			this.size = size;
		}

		void Update()
		{

		}

		public void PickUp(string item)
		{
			for (int i = 0; i < items.Length; i++) {
				if (items[i] == null) {
					items[i] = item;
					Console.WriteLine("Found empty slot at '" + i + "', inserting '" + item + "'");
					Console.WriteLine("Broke function because empty slot was found");
					break;
				}
				Console.WriteLine("Slot '" + i + "' was occupied with '" + items[i] + "', continuing");
			}
		}

		public void PrintContents()
		{
			for (int i = 0; i < items.Length; i++)
				Console.WriteLine("Item slot " + i + " : '" + items[i] + "'");
		}
	}
}
