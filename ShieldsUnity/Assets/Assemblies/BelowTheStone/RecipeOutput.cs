// BelowTheStone.Crafting.RecipeOutput
using System;
using BelowTheStone.InventorySystem;
using UnityEngine;

namespace BelowTheStone.Crafting
{
	[Serializable]
	public class RecipeOutput
	{
		[SerializeField]
		private ItemStack outputItem = new ItemStack();
	}
}
