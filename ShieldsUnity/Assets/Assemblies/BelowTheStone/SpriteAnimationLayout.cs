// BelowTheStone.Animation.SpriteAnimationLayout
using System.Collections.Generic;
using BelowTheStone.Animation;
using UnityEngine;

namespace BelowTheStone.Animation
{
	[CreateAssetMenu(fileName = "New Sprite Animation Layout", menuName = "Below The Stone/Database Objects/Sprite Animation Layout")]
	public class SpriteAnimationLayout : ScriptableObject
	{
		[SerializeField]
		private SpriteAnimationSheet associatedAnimationSheet;

		[SerializeField]
		private UDictionary<string, SpriteClipLayout> spriteClips;

		public UDictionary<string, SpriteClipLayout> SpriteClips => spriteClips;
	}
}
