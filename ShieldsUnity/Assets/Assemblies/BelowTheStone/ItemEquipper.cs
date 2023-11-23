// BelowTheStone.ItemEquipper
using System;
using BelowTheStone;
using BelowTheStone.InventorySystem;
using UnityEngine;

namespace BelowTheStone
{
	public class ItemEquipper : MonoBehaviour
	{
		[SerializeField]
		private CharacterHandsController handController;

		[SerializeField]
		private GameObject handAttachPoint;

		[SerializeField]
		private GameObject aimRoot;

		[SerializeField]
		private EquippedItem currentItemEquipped;
	}
}
