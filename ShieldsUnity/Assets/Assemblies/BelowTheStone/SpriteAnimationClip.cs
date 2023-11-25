// BelowTheStone.Animation.SpriteAnimationClip
using System;
using System.Collections.Generic;
using BelowTheStone.Animation;
using UnityEngine;

namespace BelowTheStone.Animation
{
	[Serializable]
	public class SpriteAnimationClip
	{
		[SerializeField]
		private int frameRate = 5;

		[SerializeField]
		private bool loops = true;

		[SerializeField]
		private SpriteAnimationFrame[] frames;

		[SerializeField]
		private string clipNameID;

		[SerializeField]
		private SpriteAnimationSheet parentSheet;
	}
}