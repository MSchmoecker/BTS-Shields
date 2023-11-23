// BelowTheStone.EntityEffects.EffectType
using System;
using System.Text;
using BelowTheStone.EntityEffects;
using BelowTheStone.NewDatabase;
using UnityEngine;

namespace BelowTheStone.EntityEffects
{
	public class EffectType : DatabaseElement
	{
		[Header("General Effect Info")]
		[SerializeField]
		protected string displayName;

		[SerializeField]
		protected string description;

		[SerializeField]
		protected Sprite effectIcon;

		[SerializeField]
		protected Color effectIconColor = Color.white;

		[SerializeField]
		protected GameObject visualPrefab;

		[SerializeField]
		protected float defaultDuration = 1f;

		[SerializeField]
		protected int effectLevel = 1;
	}
}