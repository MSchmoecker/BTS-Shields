// BelowTheStone.InventorySystem.Item
using System;
using BelowTheStone;
using BelowTheStone.InventorySystem;
using UnityEngine;

namespace BelowTheStone.InventorySystem
{
	[Serializable]
	public class Item
	{
		private ItemAttributes attributes;

		[SerializeField]
		private ItemType itemType;
	}
}
