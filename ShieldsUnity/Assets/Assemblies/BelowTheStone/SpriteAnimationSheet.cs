// BelowTheStone.Animation.SpriteAnimationSheet
using System.Collections.Generic;
using BelowTheStone.Animation;
using UnityEngine;

namespace BelowTheStone.Animation
{
	public class SpriteAnimationSheet : ScriptableObject
	{
		[SerializeField]
		private UDictionary<string, SpriteAnimationClip> animationClips = new UDictionary<string, SpriteAnimationClip>();

		public UDictionary<string, SpriteAnimationClip> AnimationClips => animationClips;
	}
}
