// BelowTheStone.NewDatabase.DatabaseElement
using UnityEngine;

namespace BelowTheStone.NewDatabase
{
	public class DatabaseElement : ScriptableObject
	{
		[SerializeField]
		[Delayed]
		private string category;

		[SerializeField]
		[Delayed]
		private string nameID;

		[SerializeField]
		[Delayed]
		private string location;
	}
}
