using System;
using System.Collections.Generic;
using BelowTheStone;
using BelowTheStone.Animation;
using BelowTheStone.InventorySystem;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace Shields {
    [HarmonyPatch]
    public static class PlayerPatches {
        private static Dictionary<ClothingVisualController, SpriteRenderer> shieldRenderer = new Dictionary<ClothingVisualController, SpriteRenderer>();
        private static Dictionary<ClothingVisualController, ClothingItem> shieldItem = new Dictionary<ClothingVisualController, ClothingItem>();

        private static bool shieldActive = false;

        [HarmonyPatch(typeof(PlayerObject), nameof(PlayerObject.Update)), HarmonyPostfix]
        private static void PlayerObjectUpdate(PlayerObject __instance) {
            shieldActive = Input.GetMouseButton(1);
        }

        [HarmonyPatch(typeof(PlayerObject), nameof(PlayerObject.FixedUpdate)), HarmonyPostfix]
        private static void PlayerObjectUpdate2(PlayerObject __instance) {
            if (shieldActive && __instance && __instance.mover) {
                __instance.mover.TargetVelocity /= 3f;
            }
        }
        
        [HarmonyPatch(typeof(DamageReciever), nameof(DamageReciever.CalculateNetDamage)), HarmonyPostfix]
        private static void DamageRecieverCalculateNetDamage(DamageReciever __instance, ref int __result) {
            if (shieldActive && __instance && __instance.plyInvScr) {
                ArmorInventory armorInventory = __instance.plyInvScr.PlayerInventory.ArmorInventory;
                ShieldItemType shieldClothing = (ClothingItem)armorInventory.GetAccessorySlot(-1)?.ItemStack?.ItemType as ShieldItemType;

                if (shieldClothing) {
                    __result = CalculateDamageAfterShield(shieldClothing.BlockValue, __result);
                }
            }
        }

        private static int CalculateDamageAfterShield(int block, int damage) {
            return Mathf.FloorToInt(Mathf.Max(0f, damage * (1f / (block * 0.1f + 1f)) - block));
        }

        [HarmonyPatch(typeof(DamageReciever), nameof(DamageReciever.DealDamage), new Type[] { typeof(DamageInfo) }), HarmonyPostfix]
        private static void DamageRecieverDealDamage1(DamageReciever __instance, DamageInfo damageInfo) {
            if (shieldActive && __instance && __instance.plyInvScr) {
                ArmorInventory armorInventory = __instance.plyInvScr.PlayerInventory.ArmorInventory;
                ShieldItemType shieldClothing = (ClothingItem)armorInventory.GetAccessorySlot(-1)?.ItemStack?.ItemType as ShieldItemType;

                if (shieldClothing) {
                    int blockedDamage = (int)damageInfo.damage - CalculateDamageAfterShield(shieldClothing.BlockValue, (int)damageInfo.damage);
                    EmitBlockParticle(__instance.transform.position, blockedDamage);
                }
            }
        }

        [HarmonyPatch(typeof(DamageReciever), nameof(DamageReciever.DealDamage), new Type[] { typeof(int), typeof(Vector2), typeof(bool), typeof(float) }), HarmonyPostfix]
        private static void DamageRecieverDealDamage2(DamageReciever __instance, int damage) {
            if (shieldActive && __instance && __instance.plyInvScr) {
                ArmorInventory armorInventory = __instance.plyInvScr.PlayerInventory.ArmorInventory;
                ShieldItemType shieldClothing = (ClothingItem)armorInventory.GetAccessorySlot(-1)?.ItemStack?.ItemType as ShieldItemType;

                if (shieldClothing) {
                    int blockedDamage = damage - CalculateDamageAfterShield(shieldClothing.BlockValue, damage);
                    EmitBlockParticle(__instance.transform.position, blockedDamage);
                }
            }
        }

        public static void EmitBlockParticle(Vector3 position, int block) {
            if (!GameState.current.gameDefines.damageIndicator) {
                return;
            }

            DamageParticle component = UnityEngine.Object.Instantiate(GameState.current.gameDefines.damageIndicator).GetComponent<DamageParticle>();
            component.transform.position = position + new Vector3(0, 0.1f, 0.1f);
            component.InitParticle(block.ToString());
            component.textMesh.colorGradient = new VertexGradient(Color.white, Color.gray, Color.gray, Color.gray);
        }

        [HarmonyPatch(typeof(ClothingVisualController), nameof(ClothingVisualController.Start)), HarmonyPostfix]
        private static void ClothingVisualControllerStart(ClothingVisualController __instance) {
            shieldRenderer[__instance] = new GameObject("Shield").AddComponent<SpriteRenderer>();
            shieldRenderer[__instance].transform.SetParent(__instance.transform);
            shieldRenderer[__instance].transform.localPosition = new Vector3(0.3f, 0.15f, 0f);
            shieldRenderer[__instance].transform.localRotation = Quaternion.identity;
            shieldRenderer[__instance].transform.localScale = Vector3.one;
            shieldRenderer[__instance].sortingOrder = 2;
            shieldItem[__instance] = null;
        }

        [HarmonyPatch(typeof(ClothingVisualController), nameof(ClothingVisualController.SetClothingItem)), HarmonyPostfix]
        private static void ClothingVisualControllerSetClothingItem(ClothingVisualController __instance, ClothingBodyPart bodyPart, ClothingItem clothingItem) {
            if (bodyPart == ClothingBodyPart.Accessory) {
                shieldItem[__instance] = clothingItem;
            }
        }

        [HarmonyPatch(typeof(ClothingVisualController), nameof(ClothingVisualController.UpdateCharacterSprites)), HarmonyPostfix]
        private static void ClothingVisualControllerUpdateCharacterSprites(ClothingVisualController __instance) {
            if (shieldItem[__instance] && shieldItem[__instance].ClothingSprites) {
                shieldRenderer[__instance].sprite = shieldItem[__instance].ClothingSprites.GetSprite(__instance.clipName, __instance.spriteIndex);
            } else {
                shieldRenderer[__instance].sprite = null;
            }

            if (shieldActive) {
                shieldRenderer[__instance].transform.localPosition = new Vector3(0.25f, 0.2f, 0f);
            } else {
                shieldRenderer[__instance].transform.localPosition = new Vector3(0.2f, 0.15f, 0f);
            }
        }

        [HarmonyPatch(typeof(CharacterClothing), nameof(CharacterClothing.Update)), HarmonyPostfix]
        private static void CharacterClothingUpdate(CharacterClothing __instance) {
            ArmorInventory armorInventory = __instance.plyInv.PlayerInventory.ArmorInventory;
            ClothingItem shieldClothing = (ClothingItem)armorInventory.GetAccessorySlot(-1)?.ItemStack?.ItemType;
            __instance.clothingVis.SetClothingItem(ClothingBodyPart.Accessory, shieldClothing);
        }
    }
}
