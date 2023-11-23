// ItemType
using System;
using System.Collections.Generic;
using BelowTheStone.Crafting;
using BelowTheStone.NewDatabase;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Type", menuName = "Below The Stone/Database Objects/Item Type")]
public class ItemType : DatabaseElement
{
	[Serializable]
	private class ItemSpecificRecipe
	{
		public List<Ingredient> ingredients;

		public int totalItems = 1;
	}

	[SerializeField]
	private int stackLimit = 1;

	[SerializeField]
	private bool collectionMissionItem;

	[SerializeField]
	private string displayName;

	[SerializeField]
	private string description;

	[SerializeField]
	private Sprite inventorySprite;

	[SerializeField]
	private GameObject itemPrefab;

	[SerializeField]
	private RuntimeAnimatorController itemAnimationController;

	[SerializeField]
	private int goldCoinValue = 1;
}
