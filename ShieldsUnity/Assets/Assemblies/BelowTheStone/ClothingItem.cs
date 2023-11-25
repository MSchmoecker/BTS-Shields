// BelowTheStone.ClothingItem
using BelowTheStone;
using BelowTheStone.Animation;
using UnityEngine;

namespace BelowTheStone
{
	public class ClothingItem : ItemType
	{
		[SerializeField]
		private int damageResistence;

		[SerializeField]
		private ClothingBodyPart bodyPart;

		[SerializeField]
		private SpriteAnimationLayout clothingSprites;

		[SerializeField]
		private SpriteAnimationLayout clothingSpritesAlt;

		[SerializeField]
		private bool hideHair = true;

		[SerializeField]
		[HideInInspector]
		private Texture2D[] characterTextures;
	}
}
