using MapleStoryHelper.Standard.Item;
using System;
using System.Collections.Generic;
using System.Text;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Standard.Character.Common
{
    public static class CharacterExMethods
    {
        public static List<EAdvancement> GetWeaponJob(this EquipmentItem weapon)
        {
            List<EAdvancement> retval = new List<EAdvancement>();

            switch (weapon.GearType)
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
                    retval.Add(EAdvancement.Luminous);
                    break;
                case GearType.espLimiter:
                    retval.Add(EAdvancement.Kinesis);
                    break;
                case GearType.magicGauntlet:
                    retval.Add(EAdvancement.Illium);
                    break;
                case GearType.thSword:
                    retval = TwoHandedSword();
                    break;
                case GearType.thAxe:
                    retval.Add(EAdvancement.Hero);
                    break;
                case GearType.thBlunt:
                    retval.Add(EAdvancement.Paladin);
                    break;
                case GearType.swordZL:
                    retval.Add(EAdvancement.Zero);
                    break;
                case GearType.crossbow:
                    retval = CrossBow();
                    break;
                case GearType.spear:
                    retval.Add(EAdvancement.DarkKnight);
                    break;
                case GearType.polearm:
                    retval = PoleArm();
                    break;
                case GearType.swordZB:
                    retval.Add(EAdvancement.Zero);
                    break;
                case GearType.energySword:
                    retval.Add(EAdvancement.Xenon);
                    break;
                case GearType.gun:
                    retval = Gun();
                    break;
                case GearType.handCannon:
                    retval.Add(EAdvancement.Cannoneer);
                    break;
                case GearType.soulShooter:
                    retval.Add(EAdvancement.AngelicBuster);
                    break;
                case GearType.GauntletBuster:
                    retval.Add(EAdvancement.Blaster);
                    break;
                case GearType.knuckle:
                    retval = Knuckle();
                    break;
                case GearType.throwingGlove:
                    retval = ThrowingGlove();
                    break;
                case GearType.cane:
                    retval.Add(EAdvancement.Phantom);
                    break;
                case GearType.dualBow:
                    retval.Add(EAdvancement.Mercedes);
                    break;
                case GearType.ancientBow:
                    retval.Add(EAdvancement.Pathfinder);
                    break;
                case GearType.tuner:
                    retval.Add(EAdvancement.Adele);
                    break;
                case GearType.fan:
                    retval.Add(EAdvancement.Hoyoung);
                    break;
                case GearType.chain2:
                    retval.Add(EAdvancement.Cadena);
                    break;
                case GearType.desperado:
                    retval.Add(EAdvancement.DemonAvenger);
                    break;
            }

            return retval;
        }

        private static List<EAdvancement> Gun()
        {
            return new List<EAdvancement>() { EAdvancement.Mechanic, EAdvancement.Corsair };
        }

        private static List<EAdvancement> PoleArm()
        {
            return new List<EAdvancement>() { EAdvancement.DarkKnight, EAdvancement.Aran };
        }

        public static List<EAdvancement> OneHandedSword()
        {
            return new List<EAdvancement>() { EAdvancement.Hero, EAdvancement.Paladin, EAdvancement.DawnWarrior, EAdvancement.Mikhail };
        }

        public static List<EAdvancement> OneHandedAxe()
        {
            return new List<EAdvancement>() { EAdvancement.Hero, EAdvancement.DemonSlayer };
        }
        public static List<EAdvancement> OneHandedBlunt()
        {
            return new List<EAdvancement>() { EAdvancement.Paladin, EAdvancement.DemonSlayer };
        }

        public static List<EAdvancement> Staff()
        {
            return new List<EAdvancement>() { EAdvancement.ArchMage_FirePoison, EAdvancement.ArchMage_IceLightning, EAdvancement.Bishop, EAdvancement.BlazeWizard, EAdvancement.BattleMage, EAdvancement.Evan };
        }

        public static List<EAdvancement> Wand()
        {
            return new List<EAdvancement>() { EAdvancement.ArchMage_FirePoison, EAdvancement.ArchMage_IceLightning, EAdvancement.Bishop, EAdvancement.BlazeWizard, EAdvancement.Evan };
        }

        public static List<EAdvancement> ThrowingGlove()
        {
            return new List<EAdvancement>() { EAdvancement.NightLord, EAdvancement.NightWalker };
        }

        public static List<EAdvancement> TwoHandedSword()
        {
            return new List<EAdvancement>() { EAdvancement.Hero, EAdvancement.Paladin, EAdvancement.Kaiser, EAdvancement.DawnWarrior };
        }

        public static List<EAdvancement> TwoHandedAxe()
        {
            return new List<EAdvancement>() { EAdvancement.Hero };
        }

        public static List<EAdvancement> TwoHandedBlunt()
        {
            return new List<EAdvancement>() { EAdvancement.Paladin };
        }

        public static List<EAdvancement> Bow()
        {
            return new List<EAdvancement>() { EAdvancement.BowMaster, EAdvancement.WindArcher };
        }

        public static List<EAdvancement> CrossBow()
        {
            return new List<EAdvancement>() { EAdvancement.WildHunter, EAdvancement.Marksman };
        }

        public static List<EAdvancement> Knuckle()
        {
            return new List<EAdvancement>() { EAdvancement.Shade, EAdvancement.Ark, EAdvancement.Buccaneer, EAdvancement.ThunderBreaker };
        }

    }
}
