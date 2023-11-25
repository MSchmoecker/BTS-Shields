using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BelowTheStone.Crafting;
using BelowTheStone.NewDatabase;
using HarmonyLib;
using UnityEngine;

namespace Shields {
    [HarmonyPatch]
    public static class ItemPatches {
        public static Dictionary<string, ItemType> vanillaItems = new Dictionary<string, ItemType>();
        public static Dictionary<string, RuntimeAnimatorController> vanillaAnimations = new Dictionary<string, RuntimeAnimatorController>();

        [HarmonyPatch(typeof(SODatabase), nameof(SODatabase.Init), new Type[0]), HarmonyPrefix]
        public static void SODatabaseInit(SODatabase __instance) {
            foreach (DatabaseElement databaseElement in __instance.MasterList) {
                if (databaseElement is ItemType itemType) {
                    vanillaItems[itemType.NameID] = itemType;

                    if (itemType && itemType.EquipItemPrefab && itemType.EquipItemPrefab.TryGetComponent(out EquippedItem equippedItem) &&
                        equippedItem.HandAnimations) {
                        vanillaAnimations[equippedItem.HandAnimations.name] = equippedItem.HandAnimations;
                    }
                }
            }

            AssetBundle assetBundle = LoadAssetBundleFromResources("shields");

            ShieldItemType tinShield = assetBundle.LoadAsset<ShieldItemType>("MS_shield_tin");
            Mocks.FixMocks(tinShield);
            __instance.MasterList.Add(tinShield);
            __instance.MasterList.Add(assetBundle.LoadAsset<CraftingRecipe>("MS_shield_tin_recipe"));

            ShieldItemType copperShield = assetBundle.LoadAsset<ShieldItemType>("MS_shield_copper");
            Mocks.FixMocks(copperShield);
            __instance.MasterList.Add(copperShield);
            __instance.MasterList.Add(assetBundle.LoadAsset<CraftingRecipe>("MS_shield_copper_recipe"));
        }

        [HarmonyPatch(typeof(CraftingRecipe), "OnEnable"), HarmonyPrefix]
        public static void CraftingRecipeOnEnable(CraftingRecipe __instance) {
            Mocks.FixMocks(__instance.OutputItem);

            foreach (Ingredient ingredient in __instance.Ingredients) {
                Mocks.FixMocks(ingredient);
            }
        }

        public static AssetBundle LoadAssetBundleFromResources(string bundleName) {
            Assembly resourceAssembly = Assembly.GetExecutingAssembly();
            string resourceName = resourceAssembly.GetManifestResourceNames().Single(str => str.EndsWith(bundleName));

            using (Stream stream = resourceAssembly.GetManifestResourceStream(resourceName)) {
                return AssetBundle.LoadFromStream(stream);
            }
        }
    }
}
