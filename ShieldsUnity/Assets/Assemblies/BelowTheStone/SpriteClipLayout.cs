// BelowTheStone.Animation.SpriteClipLayout
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BelowTheStone.Animation
{
	[Serializable]
	public class SpriteClipLayout
	{
		[SerializeField]
		private List<Sprite> sprites = new List<Sprite>();

		public List<Sprite> Sprites => sprites;
	}
}
