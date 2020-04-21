using MapleStoryHelper.Standard.Character;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace MapleStoryHelper.Standard.Converter
{
    #warning 아니 이게 왜 다른 어셈블리 참조가 안되냐? 내 실력 레알 실화냐? 진짜 레전드다...
    public class ECharacterJobToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string retval = string.Empty;
            var job = (ECharacterJob)value;

            switch (job)
            {
                case ECharacterJob.Hero:
                    retval = "히어로";
                    break;
                case ECharacterJob.Paladin:
                    retval = "팔라딘";
                    break;
                case ECharacterJob.DarkKnight:
                    retval = "다크나이트";
                    break;
                case ECharacterJob.Bishop:
                    retval = "비숍";
                    break;
                case ECharacterJob.ArchMage_FirePoison:
                    retval = "아크메이지(불,독)";
                    break;
                case ECharacterJob.ArchMage_IceLightning:
                    retval = "아크메이지(썬,콜)";
                    break;
                case ECharacterJob.BowMaster:
                    retval = "보우마스터";
                    break;
                case ECharacterJob.Marksman:
                    retval = "신궁";
                    break;
                case ECharacterJob.Pathfinder:
                    retval = "패스파인더";
                    break;
                case ECharacterJob.NightLord:
                    retval = "나이트로드";
                    break;
                case ECharacterJob.Shadower:
                    retval = "섀도어";
                    break;
                case ECharacterJob.DualBlade:
                    retval = "듀얼블레이드";
                    break;
                case ECharacterJob.Corsair:
                    retval = "캡틴";
                    break;
                case ECharacterJob.Buccaneer:
                    retval = "바이퍼";
                    break;
                case ECharacterJob.Cannoneer:
                    retval = "캐논슈터";
                    break;
                case ECharacterJob.Mercedes:
                    retval = "메르세데스";
                    break;
                case ECharacterJob.Aran:
                    retval = "아란";
                    break;
                case ECharacterJob.Phantom:
                    retval = "팬텀";
                    break;
                case ECharacterJob.Luminous:
                    retval = "루미너스";
                    break;
                case ECharacterJob.Evan:
                    retval = "에반";
                    break;
                case ECharacterJob.Shade:
                    retval = "은월";
                    break;
                case ECharacterJob.DawnWarrior:
                    retval = "소울마스터";
                    break;
                case ECharacterJob.BlazeWizard:
                    retval = "플레임위자드";
                    break;
                case ECharacterJob.WindArcher:
                    retval = "윈드브레이커";
                    break;
                case ECharacterJob.NightWalker:
                    retval = "나이트워커";
                    break;
                case ECharacterJob.ThunderBreaker:
                    retval = "스트라이커";
                    break;
                case ECharacterJob.Blaster:
                    retval = "블래스터";
                    break;
                case ECharacterJob.BattleMage:
                    retval = "배틀메이지";
                    break;
                case ECharacterJob.WildHunter:
                    retval = "와일드헌터";
                    break;
                case ECharacterJob.Mechanic:
                    retval = "메카닉";
                    break;
                case ECharacterJob.Xenon:
                    retval = "제논";
                    break;
                case ECharacterJob.DemonSlayer:
                    retval = "데몬슬레이어";
                    break;
                case ECharacterJob.DemonAvenger:
                    retval = "데몬어벤져";
                    break;
                case ECharacterJob.Kaiser:
                    retval = "카이저";
                    break;
                case ECharacterJob.Cadena:
                    retval = "카데나";
                    break;
                case ECharacterJob.AngelicBuster:
                    retval = "엔젤릭버스터";
                    break;
                case ECharacterJob.Adele:
                    retval = "아델";
                    break;
                case ECharacterJob.Illium:
                    retval = "일리움";
                    break;
                case ECharacterJob.Ark:
                    retval = "아크";
                    break;
                case ECharacterJob.Zero:
                    retval = "제로";
                    break;
                case ECharacterJob.Hoyoung:
                    retval = "호영";
                    break;
                case ECharacterJob.Kinesis:
                    retval = "키네시스";
                    break;

                default:
                    retval = "전체";
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
