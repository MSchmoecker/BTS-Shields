using System.Linq;
using BelowTheStone.Crafting;
using BelowTheStone.InventorySystem;
using HarmonyLib;
using UnityEngine;

namespace Shields {
    public static class Mocks {
        public static void FixMocks(ItemStack itemStack) {
            if (itemStack != null && itemStack.ItemType && itemStack.ItemType.name.StartsWith("Mock_")) {
                string itemName = itemStack.ItemType.name.Substring(5);
                AccessTools.FieldRefAccess<Item, ItemType>(itemStack.Item, "itemType") = ItemPatches.vanillaItems[itemName];
            }
        }

        public static void FixMocks(Ingredient ingredient) {
            if (ingredient != null && ingredient.ItemType && ingredient.ItemType.name.StartsWith("Mock_")) {
                string itemName = ingredient.ItemType.name.Substring(5);
                AccessTools.FieldRefAccess<Ingredient, ItemType>(ingredient, "itemType") = ItemPatches.vanillaItems[itemName];
            }
        }

        public static void FixMocks(ItemType itemType) {
            if (itemType != null && itemType.EquipItemPrefab) {
                FixMocks(itemType.EquipItemPrefab);
            }
        }

        public static void FixMocks(GameObject gameObject) {
            if (!gameObject) {
                return;
            }

            if (gameObject.TryGetComponent(out EquippedItem equippedItem)) {
                FixMocks(equippedItem);
            }

            if (gameObject.TryGetComponent(out Renderer renderer)) {
                FixMocks(renderer);
            }

            foreach (Transform child in gameObject.transform) {
                FixMocks(child.gameObject);
            }
        }

        public static void FixMocks(Renderer renderer) {
            if (renderer && renderer.sharedMaterial && renderer.sharedMaterial.name.StartsWith("Mock_")) {
                string materialName = renderer.sharedMaterial.name.Substring(5);

                if (materialName.EndsWith(" (Instance)")) {
                    materialName = materialName.Substring(0, materialName.Length - 11);
                }

                Material material = Resources.FindObjectsOfTypeAll<Material>().First(mat => mat.name == materialName);
                AccessTools.PropertySetter(typeof(Renderer), "sharedMaterial").Invoke(renderer, new object[] { material });
            }
        }

        public static void FixMocks(EquippedItem equippedItem) {
            if (equippedItem) {
                if (equippedItem.ItemTypeData && equippedItem.ItemTypeData.name.StartsWith("Mock_")) {
                    string itemName = equippedItem.ItemTypeData.name.Substring(5);
                    AccessTools.FieldRefAccess<EquippedItem, ItemType>(equippedItem, "itemTypeData") = ItemPatches.vanillaItems[itemName];
                }

                if (equippedItem.HandAnimations && equippedItem.HandAnimations.name.StartsWith("Mock_")) {
                    string controllerName = equippedItem.HandAnimations.name.Substring(5);
                    AccessTools.FieldRefAccess<EquippedItem, RuntimeAnimatorController>(equippedItem, "handAnimations") = ItemPatches.vanillaAnimations[controllerName];
                }
            }
        }
    }
}
