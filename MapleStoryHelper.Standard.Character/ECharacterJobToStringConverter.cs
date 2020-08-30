using System;

namespace MapleStoryHelper.Standard.Character
{
    public class EAdvancementToStringConverter
    {
        public static string Convert(EAdvancement value)
        {
            string retval = string.Empty;
            var job = (EAdvancement)value;

            switch (job)
            {
                case EAdvancement.Hero:
                    retval = "히어로";
                    break;
                case EAdvancement.Paladin:
                    retval = "팔라딘";
                    break;
                case EAdvancement.DarkKnight:
                    retval = "다크나이트";
                    break;
                case EAdvancement.Bishop:
                    retval = "비숍";
                    break;
                case EAdvancement.ArchMage_FirePoison:
                    retval = "아크메이지(불,독)";
                    break;
                case EAdvancement.ArchMage_IceLightning:
                    retval = "아크메이지(썬,콜)";
                    break;
                case EAdvancement.BowMaster:
                    retval = "보우마스터";
                    break;
                case EAdvancement.Marksman:
                    retval = "신궁";
                    break;
                case EAdvancement.Pathfinder:
                    retval = "패스파인더";
                    break;
                case EAdvancement.NightLord:
                    retval = "나이트로드";
                    break;
                case EAdvancement.Shadower:
                    retval = "섀도어";
                    break;
                case EAdvancement.DualBlade:
                    retval = "듀얼블레이드";
                    break;
                case EAdvancement.Corsair:
                    retval = "캡틴";
                    break;
                case EAdvancement.Buccaneer:
                    retval = "바이퍼";
                    break;
                case EAdvancement.Cannoneer:
                    retval = "캐논슈터";
                    break;
                case EAdvancement.Mercedes:
                    retval = "메르세데스";
                    break;
                case EAdvancement.Aran:
                    retval = "아란";
                    break;
                case EAdvancement.Phantom:
                    retval = "팬텀";
                    break;
                case EAdvancement.Luminous:
                    retval = "루미너스";
                    break;
                case EAdvancement.Evan:
                    retval = "에반";
                    break;
                case EAdvancement.Shade:
                    retval = "은월";
                    break;
                case EAdvancement.DawnWarrior:
                    retval = "소울마스터";
                    break;
                case EAdvancement.BlazeWizard:
                    retval = "플레임위자드";
                    break;
                case EAdvancement.WindArcher:
                    retval = "윈드브레이커";
                    break;
                case EAdvancement.NightWalker:
                    retval = "나이트워커";
                    break;
                case EAdvancement.ThunderBreaker:
                    retval = "스트라이커";
                    break;
                case EAdvancement.Blaster:
                    retval = "블래스터";
                    break;
                case EAdvancement.BattleMage:
                    retval = "배틀메이지";
                    break;
                case EAdvancement.WildHunter:
                    retval = "와일드헌터";
                    break;
                case EAdvancement.Mechanic:
                    retval = "메카닉";
                    break;
                case EAdvancement.Xenon:
                    retval = "제논";
                    break;
                case EAdvancement.DemonSlayer:
                    retval = "데몬슬레이어";
                    break;
                case EAdvancement.DemonAvenger:
                    retval = "데몬어벤져";
                    break;
                case EAdvancement.Kaiser:
                    retval = "카이저";
                    break;
                case EAdvancement.Cadena:
                    retval = "카데나";
                    break;
                case EAdvancement.AngelicBuster:
                    retval = "엔젤릭버스터";
                    break;
                case EAdvancement.Adele:
                    retval = "아델";
                    break;
                case EAdvancement.Illium:
                    retval = "일리움";
                    break;
                case EAdvancement.Ark:
                    retval = "아크";
                    break;
                case EAdvancement.Zero:
                    retval = "제로";
                    break;
                case EAdvancement.Hoyoung:
                    retval = "호영";
                    break;
                case EAdvancement.Kinesis:
                    retval = "키네시스";
                    break;

                default:
                    retval = "";
                    break;
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
