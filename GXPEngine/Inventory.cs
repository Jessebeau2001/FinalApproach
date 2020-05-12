using System;
namespace GXPEngine
{
	class Inventory : Pivot
	{
		string[] items;
		private int _size;
		public Inventory(int size)
		{
			items = new string[size];
			_size = size;
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

		public override string ToString()
		{
			string contents = "";
			for (int i = 0; i < items.Length; i++)
				contents += String.Format(@"Slot {0}: '{1}'" + Environment.NewLine, i, items[i]);
			return contents;
		}

		public void PrintContents()
		{
			for (int i = 0; i < items.Length; i++)
				Console.WriteLine("Item slot " + i + " : '" + items[i] + "'");
		}

		public string GetItemName(int slot)
		{
			if (slot > items.Length) return "null"; //if slot is out of inverntory array size bounds -Jesse
			return items[slot];
		}

		public int size
		{
			get { return _size; }
		}
	}
}
