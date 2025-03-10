﻿using System.IO;

namespace SoG_SGreader
{
    public class DataWriter
    {
        private readonly Player playerObject;

        public DataWriter(Player playerObject)
        {
            this.playerObject = playerObject;
        }

        public void WriteToFile(string fileName)
        {
            using (var writeBinary = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                Equip equip = playerObject.Equip;
                Style style = playerObject.Style;

                writeBinary.Write(playerObject.MagicByte);
                writeBinary.Write(equip.Hat);
                writeBinary.Write(equip.Facegear);
                writeBinary.Write(style.Bodytype);
                writeBinary.Write(style.Hair);
                writeBinary.Write(equip.Weapon);
                writeBinary.Write(equip.Shield);
                writeBinary.Write(equip.Armor);
                writeBinary.Write(equip.Shoes);
                writeBinary.Write(equip.Accessory1);
                writeBinary.Write(equip.Accessory2);
                writeBinary.Write(style.Hat);
                writeBinary.Write(style.Facegear);
                writeBinary.Write(style.Weapon);
                writeBinary.Write(style.Shield);
                writeBinary.Write(style.HatHidden);
                writeBinary.Write(style.FacegearHidden);
                writeBinary.Write(playerObject.LastTwoHander);
                writeBinary.Write(playerObject.LastOneHander);
                writeBinary.Write(playerObject.LastBow);

                foreach (var quickslot in playerObject.Quickslots)
                {
                    if (quickslot.GetType() == typeof(SogItems))
                    {
                        writeBinary.Write((byte) 1);
                        writeBinary.Write((int) quickslot);
                    }
                    else if (quickslot.GetType() == typeof(SogSkills))
                    {
                        writeBinary.Write((byte) 2);
                        writeBinary.Write((ushort) quickslot);
                    }
                    else
                    {
                        writeBinary.Write((byte) 0);
                    }
                }

                writeBinary.Write((byte) style.HairColor);
                writeBinary.Write((byte) style.SkinColor);
                writeBinary.Write((byte) style.PonchoColor);
                writeBinary.Write((byte) style.ShirtColor);
                writeBinary.Write((byte) style.PantsColor);
                writeBinary.Write((byte) style.Sex);
                writeBinary.Write(playerObject.Nickname);

                writeBinary.Write(playerObject.ItemsCount);
                for (var i = 0; i != playerObject.ItemsCount; i++)
                {
                    writeBinary.Write((int) playerObject.Inventory[i].ItemID);
                    writeBinary.Write(playerObject.Inventory[i].ItemCount);
                    writeBinary.Write((int) playerObject.Inventory[i].ItemPos);
                }

                writeBinary.Write(playerObject.UnknownVariable0);

                writeBinary.Write(playerObject.MerchantItemsCount);
                for (var i = 0; i != playerObject.MerchantItemsCount; i++)
                {
                    writeBinary.Write((int) playerObject.MerchantItems[i].ItemID);
                    writeBinary.Write(playerObject.MerchantItems[i].ItemCount);
                }

                writeBinary.Write(playerObject.CardsCount);
                for (var i = 0; i != playerObject.CardsCount; i++)
                {
                    writeBinary.Write(playerObject.Cards[i].CardID);
                }

                writeBinary.Write(playerObject.TreasureMapsCount);
                for (var i = 0; i != playerObject.TreasureMapsCount; i++)
                {
                    writeBinary.Write(playerObject.TreasureMaps[i].TreasureMapID);
                }

                writeBinary.Write(playerObject.UnknownVariable01Count);
                for (var i = 0; i != playerObject.UnknownVariable01Count; i++)
                {
                    writeBinary.Write(playerObject.UnknownVariables01[i].UnknownVariable01ID);
                }

                writeBinary.Write(playerObject.SkillsCount);
                for (var i = 0; i != playerObject.SkillsCount; i++)
                {
                    writeBinary.Write((short) playerObject.Skills[i].SkillID);
                    writeBinary.Write(playerObject.Skills[i].SkillLevel);
                }

                writeBinary.Write(playerObject.Level);
                writeBinary.Write(playerObject.ExpCurrent);
                writeBinary.Write(playerObject.ExpUnknown0);
                writeBinary.Write(playerObject.ExpUnknown1);
                writeBinary.Write(playerObject.SkillTalentPoints);
                writeBinary.Write(playerObject.SkillSilverPoints);
                writeBinary.Write(playerObject.SkillGoldPoints);
                writeBinary.Write(playerObject.Cash);

                writeBinary.Write(playerObject.PetsCount);
                for (var i = 0; i != playerObject.PetsCount; i++)
                {
                    var currentPet = playerObject.Pets[i];

                    writeBinary.Write(currentPet.Type1);
                    writeBinary.Write(currentPet.Type2);
                    writeBinary.Write(currentPet.Nickname);
                    writeBinary.Write(currentPet.Level);
                    writeBinary.Write(currentPet.Skin);

                    writeBinary.Write(currentPet.StatHealth);
                    writeBinary.Write(currentPet.StatEnergy);
                    writeBinary.Write(currentPet.StatDamage);
                    writeBinary.Write(currentPet.StatCrit);
                    writeBinary.Write(currentPet.StatSpeed);

                    writeBinary.Write(currentPet.StatProgressHealth);
                    writeBinary.Write(currentPet.StatProgressEnergy);
                    writeBinary.Write(currentPet.StatProgressDamage);
                    writeBinary.Write(currentPet.StatProgressCrit);
                    writeBinary.Write(currentPet.StatProgressSpeed);
                }

                writeBinary.Write(playerObject.PetsSelected);
                writeBinary.Write(playerObject.PetHidden);

                writeBinary.Write(playerObject.QuestsCount);
                for (int i = 0; i != playerObject.QuestsCount; i++)
                {
                    writeBinary.Write(playerObject.Quests[i].QuestID);
                }

                writeBinary.Write(playerObject.EnemiesMetCount);
                for (int i = 0; i != playerObject.EnemiesMetCount; i++)
                {
                    writeBinary.Write((uint) playerObject.Enemies[i].EnemyID);
                }

                writeBinary.Write((ushort) (playerObject.UnknownVariable02Count / 16));
                for (int i = 0; i != playerObject.UnknownVariable02Count; i++)
                {
                    writeBinary.Write(playerObject.UnknownVariables02[i].UnknownByte);
                }

                writeBinary.Write(playerObject.RobinBowHighscore);

                writeBinary.Write(playerObject.UnknownVariable03Count);
                for (int i = 0; i != playerObject.UnknownVariable03Count; i++)
                {
                    writeBinary.Write(playerObject.UnknownVariables03[i].UnknownVariable);
                }

                writeBinary.Write(playerObject.ItemsMetCount);
                for (int i = 0; i != playerObject.ItemsMetCount; i++)
                {
                    writeBinary.Write((int) playerObject.ItemsMet[i].ItemID);
                }

                writeBinary.Write(playerObject.ItemsCraftedCount);
                for (int i = 0; i != playerObject.ItemsCraftedCount; i++)
                {
                    writeBinary.Write((int) playerObject.ItemsCrafted[i].ItemID);
                }

                writeBinary.Write(playerObject.FishiesCaughtCount);
                for (int i = 0; i != playerObject.FishiesCaughtCount; i++)
                {
                    writeBinary.Write((int) playerObject.FishiesCaught[i].FishID);
                }

                writeBinary.Write(playerObject.KilledEnemiesCount);
                for (int i = 0; i != playerObject.KilledEnemiesCount; i++)
                {
                    writeBinary.Write(playerObject.KilledEnemies[i].EnemyID);
                    writeBinary.Write(playerObject.KilledEnemies[i].KillCount);
                }

                writeBinary.Write(playerObject.PotionsMax);
                writeBinary.Write(playerObject.PotionsEquipped);

                for (int i = 0; i != playerObject.PotionsEquipped; i++)
                {
                    writeBinary.Write(playerObject.Potions[i].PotionID);
                }

                writeBinary.Write(playerObject.BirthdayMonth);
                writeBinary.Write(playerObject.BirthdayDay);
                writeBinary.Write((int) playerObject.UniquePlayerId);
                writeBinary.Write(playerObject.UnknownVariable04);
                writeBinary.Write(playerObject.UnknownVariable05);

                writeBinary.Write(playerObject.PlayTimeTotal); // check for overflow

                writeBinary.Write((byte)playerObject.UnknownVariable06);

                writeBinary.Write((ushort) playerObject.UnknownVariable07Count);
                for (int i = 0; i != playerObject.UnknownVariable07Count; i++)
                {
                    writeBinary.Write(playerObject.UnknownVariables07[i].UnknownString);
                    writeBinary.Write(playerObject.UnknownVariables07[i].UnknownFloat);
                }

                writeBinary.Write((ushort) playerObject.FlagsCount);
                for (int i = 0; i != playerObject.FlagsCount; i++)
                {
                    writeBinary.Write(playerObject.Flags[i].FlagID);
                }

                writeBinary.Write(playerObject.HouseStylesCount);
                for (int i = 0; i != playerObject.HouseStylesCount; i++)
                {
                    writeBinary.Write(playerObject.Houses[i].HouseStyleNumber);
                    writeBinary.Write(playerObject.Houses[i].HouseStyleLength);
                    writeBinary.Write(playerObject.Houses[i].HouseStyleBytes);
                }

                writeBinary.Close();
            }
        }
    }
}