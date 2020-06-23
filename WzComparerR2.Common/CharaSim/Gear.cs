﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WzComparerR2.WzLib;

namespace WzComparerR2.CharaSim
{
    public class Gear : ItemBase
    {
        public Gear()
        {
            Props = new Dictionary<GearPropType, int>();
            PropsString = new Dictionary<GearPropType, string>();
            VariableStat = new Dictionary<GearPropType, float>();
            Options = new Potential[3];
            AdditionalOptions = new Potential[3];
            Additions = new List<Addition>();
        }

        public GearGrade Grade { get; set; }
        public GearGrade AdditionGrade { get; set; }

        public GearType type;
        public GearState State { get; set; }

        public int diff;

        public Potential[] Options { get; private set; }
        public Potential[] AdditionalOptions { get; private set; }
        public AlienStone AlienStoneSlot { get; set; }

        public int Star { get; set; }
        public int ScrollUp { get; set; }
        public int Hammer { get; set; }
        public bool HasTuc { get; internal set; }
        public bool CanPotential { get; internal set; }

        public bool FixLevel { get; internal set; }
        public List<GearLevelInfo> Levels { get; internal set; }
        public List<GearSealedInfo> Seals { get; internal set; }

        public List<Addition> Additions { get; private set; }
        public Dictionary<GearPropType, int> Props { get; private set; }
        public Dictionary<GearPropType, string> PropsString { get; private set; }
        public Dictionary<GearPropType, float> VariableStat { get; private set; }


        public bool Epic
        {
            get
            {
                //return GetBooleanValue(GearPropType.epicItem);
                return true;
            }
        }

        public bool TimeLimited
        {
            get
            {
                //return GetBooleanValue(GearPropType.timeLimited);
                return true;
            }
        }

        public bool Cash
        {
            get
            {
                //return GetBooleanValue(GearPropType.cash); 
                return true;
            }
        }

        public bool GetBooleanValue(GearPropType type)
        {
            int value;
            return this.Props.TryGetValue(type, out value) && value != 0;
        }

        public int GetMaxStar()
        {
            if (!this.HasTuc)
            {
                return 0;
            }
            if (this.Cash)
            {
                return 0;
            }

            int reqLevel;
            this.Props.TryGetValue(GearPropType.reqLevel, out reqLevel);
            int[] data = null;
            foreach (int[] item in starData)
            {
                if (reqLevel >= item[0])
                {
                    data = item;
                }
                else
                {
                    break;
                }
            }
            if (data == null)
            {
                return 0;
            }

            //return data[this.GetBooleanValue(GearPropType.superiorEqp) ? 2 : 1];
            return data[1];
        }

        private static int[][] starData = new int[][] {
            new[]{ 0, 5, 3 },
            new[]{ 95, 8, 5 },
            new[]{ 110, 10, 8 },
            new[]{ 120, 15, 10 },
            new[]{ 130, 20, 12 },
            new[]{ 140, 25, 15 },
        };

        public override object Clone()
        {
            Gear gear = (Gear)this.MemberwiseClone();
            gear.Props = new Dictionary<GearPropType, int>(this.Props.Count);
            foreach (KeyValuePair<GearPropType, int> p in this.Props)
            {
                gear.Props.Add(p.Key, p.Value);
            }
            gear.Options = (Potential[])this.Options.Clone();
            gear.Additions = new List<Addition>(this.Additions);
            return gear;
        }

        public static bool IsWeapon(GearType type)
        {
            return IsLeftWeapon(type)
                || IsDoubleHandWeapon(type);
        }

        /// <summary>
        /// 获取一个值，指示装备类型是否为主手武器。
        /// </summary>
        /// <param name="type">装备类型。</param>
        /// <returns></returns>
        public static bool IsLeftWeapon(GearType type)
        {
            return (int)type >= 121 && (int)type <= 139 && type != GearType.katara;
        }

        public static bool IsSubWeapon(GearType type)
        {
            switch (type)
            {
                case GearType.katara:
                //case GearType.shield:
                case GearType.demonShield:
                case GearType.soulShield:
                    return true;

                default:
                    if ((int)type / 1000 == 135)
                    {
                        return true;
                    }
                    return false;
            }
        }

        public static bool IsV5SupportPropType(GearPropType type)
        {
            switch (type)
            {
                case GearPropType.incMDD:
                case GearPropType.incMDDr:
                case GearPropType.incACC:
                case GearPropType.incACCr:
                case GearPropType.incEVA:
                case GearPropType.incEVAr:
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// 获取一个值，指示装备类型是否为双手武器。
        /// </summary>
        /// <param name="type">装备类型。</param>
        /// <returns></returns>
        public static bool IsDoubleHandWeapon(GearType type)
        {
            int _type = (int)type;
            return (_type >= 140 && _type <= 149)
                || (_type >= 152 && _type <= 158);
        }

        public static bool IsMechanicGear(GearType type)
        {
            return (int)type >= 161 && (int)type <= 165;
        }

        public static bool IsDragonGear(GearType type)
        {
            return (int)type >= 194 && (int)type <= 197;
        }

        public static int Compare(Gear gear, Gear originGear)
        {
            if (gear.ItemID != originGear.ItemID)
                return 0;
            int diff = 0;
            int tempValue;
            foreach (KeyValuePair<GearPropType, int> prop in gear.Props)
            {
                originGear.Props.TryGetValue(prop.Key, out tempValue);//在原装备中寻找属性 若没有找到 视为0
                diff += (prop.Value - tempValue) / GetPropTypeWeight(prop.Key);
            }
            foreach (KeyValuePair<GearPropType, int> prop in originGear.Props)
            {
                if (!gear.Props.TryGetValue(prop.Key, out tempValue))//寻找装备原属性里新装备没有的
                {
                    diff -= prop.Value / GetPropTypeWeight(prop.Key);
                }
            }
            return diff;
        }

        private static int GetPropTypeWeight(GearPropType type)
        {
            if ((int)type < 100)
            {
                switch (type)
                {
                    case GearPropType.incMHP:
                    case GearPropType.incMMP:
                    case GearPropType.incACC:
                    case GearPropType.incEVA:
                        return 10;
                }
                return 1;
            }
            return int.MaxValue;
        }

        public static bool IsEpicPropType(GearPropType type)
        {
            switch (type)
            {
                case GearPropType.incPAD:
                case GearPropType.incMAD:
                case GearPropType.incSTR:
                case GearPropType.incDEX:
                case GearPropType.incINT:
                case GearPropType.incLUK:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 获取装备类型。
        /// </summary>
        /// <param Name="gearCode"></param>
        /// <returns></returns>
        public static GearType GetGearType(int code)
        {
            switch (code / 1000)
            {
                case 1098:
                    return GearType.soulShield;
                case 1099:
                    return GearType.demonShield;
            }
            if (code / 10000 == 135)
            {
                switch (code / 100)
                {
                    case 13522:
                    case 13528:
                    case 13529:
                        return (GearType)(code / 10);

                    default:
                        return (GearType)(code / 100 * 10);
                }
            }
            return (GearType)(code / 10000);
        }

        public static int GetGender(int code)
        {
            GearType type = GetGearType(code);
            switch (type)
            {
                case GearType.emblem:
                case GearType.bit:
                case (GearType)3: //发型
                    return 2;
            }

            return code / 1000 % 10;
        }

        public static bool SpecialCanPotential(GearType type)
        {
            switch (type)
            {
                case GearType.soulShield:
                case GearType.demonShield:
                case GearType.katara:
                case GearType.magicArrow:
                case GearType.card:
                case GearType.box:
                case GearType.orb:
                case GearType.novaMarrow:
                case GearType.soulBangle:
                case GearType.mailin:
                case GearType.emblem:
                    return true;
                default:
                    return false;
            }
        }

        public static Gear CreateFromNode(Wz_Node node, GlobalFindNodeFunction findNode)
        {
            int gearID;
            Match m = Regex.Match(node.Text, @"^(\d{8})\.img$");
            if (!(m.Success && Int32.TryParse(m.Result("$1"), out gearID)))
            {
                return null;
            }
            Gear gear = new Gear();
            gear.ItemID = gearID;
            gear.type = Gear.GetGearType(gear.ItemID);
            Wz_Node infoNode = node.FindNodeByPath("info");

            if (infoNode != null)
            {
                foreach (Wz_Node subNode in infoNode.Nodes)
                {
                    switch (subNode.Text)
                    {
                        case "icon":
                            if (subNode.Value is Wz_Png)
                            {
                                gear.Icon = BitmapOrigin.CreateFromNode(subNode, findNode);
                            }
                            break;

                        case "addition": //附加属性信息
                            foreach (Wz_Node addiNode in subNode.Nodes)
                            {
                                Addition addi = Addition.CreateFromNode(addiNode);
                                if (addi != null)
                                    gear.Additions.Add(addi);
                            }
                            gear.Additions.Sort((add1, add2) => (int)add1.Type - (int)add2.Type);
                            break;

                        case "option": //附加潜能信息
                            Wz_Node itemWz = findNode != null ? findNode("Item\\ItemOption.img") : null;
                            if (itemWz == null)
                                break;
                            int optIdx = 0;
                            foreach (Wz_Node optNode in subNode.Nodes)
                            {
                                int optId = 0, optLevel = 0;
                                foreach (Wz_Node optArgNode in optNode.Nodes)
                                {
                                    switch (optArgNode.Text)
                                    {
                                        case "option": optId = Convert.ToInt32(optArgNode.Value); break;
                                        case "level": optLevel = Convert.ToInt32(optArgNode.Value); break;
                                    }
                                }

                                Potential opt = Potential.CreateFromNode(itemWz.FindNodeByPath(optId.ToString("d6")), optLevel);
                                if (opt != null)
                                    gear.Options[optIdx++] = opt;
                            }
                            break;

                        case "level": //可升级信息
                            if (subNode.Nodes["fixLevel"].GetValueEx<int>(0) != 0)
                            {
                                gear.FixLevel = true;
                            }

                            Wz_Node levelInfo = subNode.Nodes["info"];
                            gear.Levels = new List<GearLevelInfo>();
                            if (levelInfo != null)
                            {
                                for (int i = 1; ; i++)
                                {
                                    Wz_Node levelInfoNode = levelInfo.Nodes[i.ToString()];
                                    if (levelInfoNode != null)
                                    {
                                        GearLevelInfo info = GearLevelInfo.CreateFromNode(levelInfoNode);
                                        int lv;
                                        Int32.TryParse(levelInfoNode.Text, out lv);
                                        info.Level = lv;
                                        gear.Levels.Add(info);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            Wz_Node levelCase = subNode.Nodes["case"];
                            if (levelCase != null)
                            {
                                int probTotal = 0;
                                foreach (Wz_Node caseNode in levelCase.Nodes)
                                {
                                    int prob = caseNode.Nodes["prob"].GetValueEx(0);
                                    probTotal += prob;
                                    for (int i = 0; i < gear.Levels.Count; i++)
                                    {
                                        GearLevelInfo info = gear.Levels[i];
                                        Wz_Node caseLevel = caseNode.Nodes[info.Level.ToString()];
                                        if (caseLevel != null)
                                        {
                                            //随机技能
                                            Wz_Node caseSkill = caseLevel.Nodes["Skill"];
                                            if (caseSkill != null)
                                            {
                                                foreach (Wz_Node skillNode in caseSkill.Nodes)
                                                {
                                                    int id = skillNode.Nodes["id"].GetValueEx(-1);
                                                    int level = skillNode.Nodes["level"].GetValueEx(-1);
                                                    if (id >= 0 && level >= 0)
                                                    {
                                                        info.Skills[id] = level;
                                                    }
                                                }
                                            }

                                            //装备技能
                                            Wz_Node equipSkill = caseLevel.Nodes["EquipmentSkill"];
                                            if (equipSkill != null)
                                            {
                                                foreach (Wz_Node skillNode in equipSkill.Nodes)
                                                {
                                                    int id = skillNode.Nodes["id"].GetValueEx(-1);
                                                    int level = skillNode.Nodes["level"].GetValueEx(-1);
                                                    if (id >= 0 && level >= 0)
                                                    {
                                                        info.EquipmentSkills[id] = level;
                                                    }
                                                }
                                            }
                                            info.Prob = prob;
                                        }
                                    }
                                }

                                foreach (var info in gear.Levels)
                                {
                                    info.ProbTotal = probTotal;
                                }
                            }
                            gear.Props.Add(GearPropType.level, 1);
                            break;

                        case "sealed": //封印解除信息
                            Wz_Node sealedInfo = subNode.Nodes["info"];
                            gear.Seals = new List<GearSealedInfo>();
                            if (sealedInfo != null)
                            {
                                foreach (Wz_Node levelInfoNode in sealedInfo.Nodes)
                                {
                                    GearSealedInfo info = GearSealedInfo.CreateFromNode(levelInfoNode, findNode);
                                    int lv;
                                    Int32.TryParse(levelInfoNode.Text, out lv);
                                    info.Level = lv;
                                    gear.Seals.Add(info);
                                }
                            }
                            gear.Props.Add(GearPropType.@sealed, 1);
                            break;

                        case "variableStat": //升级奖励属性
                            foreach (Wz_Node statNode in subNode.Nodes)
                            {
                                GearPropType type;
                                if (Enum.TryParse(statNode.Text, out type))
                                {
                                    try
                                    {
                                        gear.VariableStat.Add(type, Convert.ToSingle(statNode.Value));
                                    }
                                    finally
                                    {
                                    }
                                }
                            }
                            break;

                        default:
                            {
                                GearPropType type;
                                if (Enum.TryParse(subNode.Text, out type))
                                {
                                    try
                                    {
                                        if (subNode.Value != null)
                                        {
                                            gear.Props.Add(type, Convert.ToInt32(subNode.Value));
                                            gear.PropsString.Add(type, subNode.Value.ToString());
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    finally
                                    {

                                    }
                                }
                            }
                            break;
                    }
                }
            }
            int value;

            //读取默认可升级状态
            if (gear.Props.TryGetValue(GearPropType.tuc, out value) && value > 0)
            {
                gear.HasTuc = true;
                gear.CanPotential = true;
            }
            else if (Gear.SpecialCanPotential(gear.type))
            {
                gear.CanPotential = true;
            }

            //读取默认gearGrade
            //if (gear.Props.TryGetValue(GearPropType.fixedGrade, out value))
            //{
            //    gear.Grade = (GearGrade)(value - 1);
            //}

            //添加默认装备要求
            GearPropType[] types = new GearPropType[]{
                GearPropType.reqJob,GearPropType.reqLevel,GearPropType.reqSTR,GearPropType.reqDEX,
            GearPropType.reqINT,GearPropType.reqLUK};
            foreach (GearPropType type in types)
            {
                if (!gear.Props.ContainsKey(type))
                {
                    gear.Props.Add(type, 0);
                }
            }

            //修复恶魔盾牌特殊属性
            if (gear.type == GearType.demonShield)
            {
                if (gear.Props.TryGetValue(GearPropType.incMMP, out value))
                {
                    gear.Props.Remove(GearPropType.incMMP);
                    gear.Props.Add(GearPropType.incMDF, value);
                }
            }

            return gear;
        }
    }
}