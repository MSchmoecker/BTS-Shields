// BelowTheStone.Crafting.Ingredient
using System;
using UnityEngine;

namespace BelowTheStone.Crafting
{
	[Serializable]
	public class Ingredient
	{
		[SerializeField]
		private int itemCount;

		[SerializeField]
		private ItemType itemType;
	}
}
