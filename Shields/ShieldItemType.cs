﻿using UnityEngine;

namespace Shields {
    [CreateAssetMenu(fileName = "New Shield Item Type", menuName = "Below The Stone/Database Objects/Shield Item Type")]
    public class ShieldItemType : ItemType {
        [SerializeField]
        private int blockValue;

        public int BlockValue => blockValue;
    }
}
