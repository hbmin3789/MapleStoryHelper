using MapleStoryHelper.Standard.Item;
using System;
using System.Collections.Generic;
using System.Text;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Standard.Character.Common
{
    public static class CharacterExMethods
    {
        public static List<ECharacterJob> GetWeaponJob(this EquipmentItem weapon)
        {
            List<ECharacterJob> retval = new List<ECharacterJob>();

            switch (weapon.WeaponType)
            {
                case GearType.staff:
                    retval = Staff();
                    break;
                case GearType.wand:
                    retval = Wand();
                    break;
                case GearType.ohSword:
                    retval = OneHandedSword();
                    break;
                case GearType.ohAxe:
                    retval = OneHandedAxe();
                    break;
                case GearType.ohBlunt:
                    retval = OneHandedBlunt();
                    break;
                case GearType.shiningRod:
                    retval.Add(ECharacterJob.Luminous);
                    break;
                case GearType.espLimiter:
                    retval.Add(ECharacterJob.Kinesis);
                    break;
                case GearType.magicGauntlet:
                    retval.Add(ECharacterJob.Illium);
                    break;
                case GearType.thSword:
                    retval = TwoHandedSword();
                    break;
                case GearType.thAxe:
                    retval.Add(ECharacterJob.Hero);
                    break;
                case GearType.thBlunt:
                    retval.Add(ECharacterJob.Paladin);
                    break;
                case GearType.swordZL:
                    retval.Add(ECharacterJob.Zero);
                    break;
                case GearType.crossbow:
                    retval = CrossBow();
                    break;
                case GearType.spear:
                    retval.Add(ECharacterJob.DarkKnight);
                    break;
                case GearType.polearm:
                    retval = PoleArm();
                    break;
                case GearType.swordZB:
                    retval.Add(ECharacterJob.Zero);
                    break;
                case GearType.energySword:
                    retval.Add(ECharacterJob.Xenon);
                    break;
                case GearType.gun:
                    retval = Gun();
                    break;
                case GearType.handCannon:
                    retval.Add(ECharacterJob.Cannoneer);
                    break;
                case GearType.soulShooter:
                    retval.Add(ECharacterJob.AngelicBuster);
                    break;
                case GearType.GauntletBuster:
                    retval.Add(ECharacterJob.Blaster);
                    break;
                case GearType.knuckle:
                    retval = Knuckle();
                    break;
                case GearType.throwingGlove:
                    retval = ThrowingGlove();
                    break;
                case GearType.cane:
                    retval.Add(ECharacterJob.Phantom);
                    break;
                case GearType.dualBow:
                    retval.Add(ECharacterJob.Mercedes);
                    break;
                case GearType.ancientBow:
                    retval.Add(ECharacterJob.Pathfinder);
                    break;
                case GearType.tuner:
                    retval.Add(ECharacterJob.Adele);
                    break;
                case GearType.fan:
                    retval.Add(ECharacterJob.Hoyoung);
                    break;
                case GearType.chain2:
                    retval.Add(ECharacterJob.Cadena);
                    break;
                case GearType.desperado:
                    retval.Add(ECharacterJob.DemonAvenger);
                    break;
            }

            return retval;
        }

        private static List<ECharacterJob> Gun()
        {
            return new List<ECharacterJob>() { ECharacterJob.Mechanic, ECharacterJob.Corsair };
        }

        private static List<ECharacterJob> PoleArm()
        {
            return new List<ECharacterJob>() { ECharacterJob.DarkKnight, ECharacterJob.Aran };
        }

        public static List<ECharacterJob> OneHandedSword()
        {
            return new List<ECharacterJob>() { ECharacterJob.Hero, ECharacterJob.Paladin, ECharacterJob.DawnWarrior, ECharacterJob.Mikhail };
        }

        public static List<ECharacterJob> OneHandedAxe()
        {
            return new List<ECharacterJob>() { ECharacterJob.Hero, ECharacterJob.DemonSlayer };
        }
        public static List<ECharacterJob> OneHandedBlunt()
        {
            return new List<ECharacterJob>() { ECharacterJob.Paladin, ECharacterJob.DemonSlayer };
        }

        public static List<ECharacterJob> Staff()
        {
            return new List<ECharacterJob>() { ECharacterJob.ArchMage_FirePoison, ECharacterJob.ArchMage_IceLightning, ECharacterJob.Bishop, ECharacterJob.BlazeWizard, ECharacterJob.BattleMage, ECharacterJob.Evan };
        }

        public static List<ECharacterJob> Wand()
        {
            return new List<ECharacterJob>() { ECharacterJob.ArchMage_FirePoison, ECharacterJob.ArchMage_IceLightning, ECharacterJob.Bishop, ECharacterJob.BlazeWizard, ECharacterJob.Evan };
        }

        public static List<ECharacterJob> ThrowingGlove()
        {
            return new List<ECharacterJob>() { ECharacterJob.NightLord, ECharacterJob.NightWalker };
        }

        public static List<ECharacterJob> TwoHandedSword()
        {
            return new List<ECharacterJob>() { ECharacterJob.Hero, ECharacterJob.Paladin, ECharacterJob.Kaiser, ECharacterJob.DawnWarrior };
        }

        public static List<ECharacterJob> TwoHandedAxe()
        {
            return new List<ECharacterJob>() { ECharacterJob.Hero };
        }

        public static List<ECharacterJob> TwoHandedBlunt()
        {
            return new List<ECharacterJob>() { ECharacterJob.Paladin };
        }

        public static List<ECharacterJob> Bow()
        {
            return new List<ECharacterJob>() { ECharacterJob.BowMaster, ECharacterJob.WindArcher };
        }

        public static List<ECharacterJob> CrossBow()
        {
            return new List<ECharacterJob>() { ECharacterJob.WildHunter, ECharacterJob.Marksman };
        }

        public static List<ECharacterJob> Knuckle()
        {
            return new List<ECharacterJob>() { ECharacterJob.Shade, ECharacterJob.Ark, ECharacterJob.Buccaneer, ECharacterJob.ThunderBreaker };
        }

    }
}
