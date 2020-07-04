using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MapleStoryHelper.Standard.Utils.ExMethods
{
    public static class ToStatusStringExt
    {
        public static string ToStatusString(this StatusBase status)
        {
            StringBuilder retval = new StringBuilder();
            retval.Append("-----효과-----\n");

            var properties = typeof(StatusBase).GetProperties();
            for(int i = 0; i < properties.Length; i++)
            {
                StringBuilder sb = new StringBuilder();

                var property = properties.ElementAt(i);
                var value = property.GetValue(status);

                if (value == null)
                {
                    continue;
                }
                if(Convert.ToInt32(value) == 0)
                {
                    continue;
                }

                string str = property.Name.ToStatusString();
                if(str.Length < 1)
                {
                    continue;
                }
                sb.Append(str);
                sb.Append(" ");

                sb.Append(Convert.ToInt32(value));

                sb.Append("\n");

                retval.Append(sb.ToString());
            }

            return retval.ToString();
        }

        public static string ToStatusString(this string statusName)
        {
            if (statusName.Contains("Binding"))
            {
                return "";
            }
            switch (statusName)
            {
                case "Str":
                    return "STR";
                case "Dex":
                    return "DEX";
                case "Int":
                    return "INT";
                case "Luk":
                    return "LUK";
                case "PStr":
                    return "STR%";
                case "PDex":
                    return "DEX%";
                case "PInt":
                    return "INT%";
                case "PLuk":
                    return "LUK%";
                case "AttackPower":
                    return "공격력";
                case "MagicAttack":
                    return "마력";
                case "PAttackPower":
                    return "공격력%";
                case "PMagicAttack":
                    return "마력%";
                case "Damage":
                    return "데미지";
                case "BossDamage":
                    return "보스 공격력";
                case "IgnoreDef":
                    return "방어율 무시";
                case "PHP":
                    return "HP%";
                case "PMP":
                    return "MP%";
                case "AllStatus":
                    return "올스탯";
                case "PAllStatus":
                    return "올스탯%";
                default:
                    return statusName;
            }
        }
    }
}
