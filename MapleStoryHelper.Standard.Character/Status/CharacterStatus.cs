using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapleStoryHelper.Standard.Character.Status
{
    //장비템에는 레벨 스테이터스가 없으나, 캐릭터에게는 레벨에따른 스테이터스가 있으므로 만들 필요가 있음.
    public class CharacterStatus : StatusBase
    {

        public static CharacterStatus operator +(CharacterStatus a, CharacterStatus b)
        {
            CharacterStatus retval = new CharacterStatus()
            {
                AllStatus = a.AllStatus + b.AllStatus,
                CAllStatus = a.CAllStatus + b.CAllStatus,
                PAllStatus = a.PAllStatus + b.PAllStatus,
                AttackPower = a.AttackPower + b.AttackPower,
                PAttackPower = a.PAttackPower + b.PAttackPower,
                CAttackPower = a.CAttackPower + b.CAttackPower,
                MagicAttack = a.MagicAttack + b.MagicAttack,
                CMagicAttack = a.CMagicAttack + b.CMagicAttack,
                PMagicAttack = a.PMagicAttack + b.PMagicAttack,
                Str = a.Str + b.Str,
                Dex = a.Dex + b.Dex,
                Int = a.Int + b.Int,
                Luk = a.Luk + b.Luk,
                CStr = a.CStr + b.CStr,
                CDex = a.CDex + b.CDex,
                CInt = a.CInt + b.CInt,
                CLuk = a.CLuk + b.CLuk,
                PStr = a.PStr + b.PStr,
                PDex = a.PDex + b.PDex,
                PInt = a.PInt + b.PInt,
                PLuk = a.PLuk + b.PLuk,
                HP = a.HP + b.HP,
                CHP = a.CHP + b.CHP,
                PHP = a.PHP + b.PHP,
                MP = a.MP + b.MP,
                CMP = a.CMP + b.CMP,
                PMP = a.PMP + b.PMP,
                BossDamage = a.BossDamage + b.BossDamage,
                Critical = a.Critical + b.Critical,
                Damage = a.Damage + b.Damage,
                CriticalDamage = a.CriticalDamage + b.CriticalDamage,
                LastDamage = a.LastDamage + b.LastDamage,
                LevelStr = a.LevelStr + b.LevelStr,
                LevelDex = a.LevelDex + b.LevelDex,
                LevelInt = a.LevelInt + b.LevelInt,
                LevelLuk = a.LevelLuk + b.LevelLuk,
                LevelHP = a.LevelHP + b.LevelHP,
                LevelMP = a.LevelMP + b.LevelMP,
            };

            retval.IgnoreDef = new List<double>(a.IgnoreDef);

            for (int i = 0; i < b.IgnoreDef.Count; i++)
            {
                retval.IgnoreDef.Add(b.IgnoreDef[i]);
            }

            return retval;
        }

        //Status와 Character의 테이블이 나뉘어져있음
        public Character Character { get; set; }

        #region Property

        private double _levelStr;
        [Column("level_str")]
        public double LevelStr
        {
            get => _levelStr;
            set => SetProperty(ref _levelStr, value);
        }

        private double _levelDex;
        [Column("level_dex")]
        public double LevelDex
        {
            get => _levelDex;
            set => SetProperty(ref _levelDex, value);
        }

        private double _levelInt;
        [Column("level_int")]
        public double LevelInt
        {
            get => _levelInt;
            set => SetProperty(ref _levelInt, value);
        }

        private double _levelLuk;
        [Column("level_luk")]
        public double LevelLuk
        {
            get => _levelLuk;
            set => SetProperty(ref _levelLuk, value);
        }

        private double _levelHP;
        [Column("level_hp")]
        public double LevelHP
        {
            get => _levelHP;
            set => SetProperty(ref _levelHP, value);
        }

        private double _levelMP;
        [Column("level_mp")]
        public double LevelMP
        {
            get => _levelMP;
            set => SetProperty(ref _levelMP, value);
        }
        #endregion
    }
}
