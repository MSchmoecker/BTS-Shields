// BelowTheStone.InventorySystem.ItemStack
using System;
using BelowTheStone.InventorySystem;
using UnityEngine;

namespace BelowTheStone.InventorySystem
{
	[Serializable]
	public class ItemStack
	{
		[SerializeField]
		private int stackSize;

		[SerializeField]
		private Item item;
	}
}
