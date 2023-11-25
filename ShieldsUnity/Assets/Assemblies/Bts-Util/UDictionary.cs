// UDictionary<TKey,TValue>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
[ComVisible(false)]
[DebuggerDisplay("Count = {Count}")]
public class UDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializable, IDeserializationCallback, ISerializationCallbackReceiver
{
	[SerializeField]
	private List<TKey> keys = new List<TKey>();

	[SerializeField]
	private List<TValue> values = new List<TValue>();

	public List<TKey> SerializedKeys => keys;

	public List<TValue> SerializedValues => values;

	public UDictionary()
	{
	}

	public UDictionary(IEqualityComparer<TKey> comparer)
		: base(comparer)
	{
	}

	public UDictionary(IDictionary<TKey, TValue> dictionary)
		: base(dictionary)
	{
	}

	public UDictionary(int capacity)
		: base(capacity)
	{
	}

	public UDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		: base(dictionary, comparer)
	{
	}

	public UDictionary(int capacity, IEqualityComparer<TKey> comparer)
		: base(capacity, comparer)
	{
	}

	public virtual void OnAfterDeserialize()
	{
	}

	public virtual void OnBeforeSerialize()
	{
	}
}
