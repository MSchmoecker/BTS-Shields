// BasicItemLogic
using System;
using BelowTheStone;
using BelowTheStone.EntityEffects;
using UnityEngine;

public class BasicItemLogic : MonoBehaviour
{
	[SerializeField]
	private EffectType applyEffectOnConsume;

	[SerializeField]
	private float effectDuration;

	[SerializeField]
	private int healAmount = 10;

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Sprite consumedSprite;

	[SerializeField]
	private AudioClip soundConsume;
}
