// BelowTheStone.Animation.SpriteAnimationFrame
using System;
using UnityEngine;
using UnityEngine.Events;

namespace BelowTheStone.Animation
{
	[Serializable]
	public class SpriteAnimationFrame
	{
		[SerializeField]
		private int spriteIndex;

		public int SpriteIndex => spriteIndex;
	}
}
