// CharacterHandsController
using UnityEngine;

[ExecuteAlways]
public class CharacterHandsController : MonoBehaviour
{
	public bool showHands = true;

	public bool showLeftHand = true;

	public bool showRightHand = true;

	[SerializeField]
	private SpriteRenderer handLeft;

	[SerializeField]
	private SpriteRenderer handRight;

	[SerializeField]
	private SpriteRenderer itemLeft;

	[SerializeField]
	private SpriteRenderer itemRight;

	[SerializeField]
	private Animator handAnim;
}
