// BelowTheStone.Crafting.CraftingRecipe
using System;
using System.Collections.Generic;
using BelowTheStone.Crafting;
using BelowTheStone.InventorySystem;
using BelowTheStone.NewDatabase;
using UnityEngine;

namespace BelowTheStone.Crafting
{
	[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "Below The Stone/Database Objects/Crafting Recipe")]
	public class CraftingRecipe : DatabaseElement
	{
		[Flags]
		public enum CraftRecipeCategory : uint
		{
			None = 0x0u,
			Ingot = 0x1u,
			Tool = 0x2u,
			Weapon = 0x4u,
			Armor = 0x8u,
			Blacksmith = 0xFu,
			Healing = 0x10u,
			Buff = 0x20u,
			Combat = 0x40u,
			Alchemy = 0x70u
		}

		[SerializeField]
		private bool hideRecipe;

		[SerializeField]
		private List<Ingredient> ingredients;

		[SerializeField]
		private RecipeOutput recipeOutput = new RecipeOutput();

		public CraftRecipeCategory craftRecipeCategory;
	}
}
