using MapleStoryHelper.Standard.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Character
{
    public class CharacterBase : BindableBase
    {
        private string _imageSrc;
        public string ImageSrc
        {
            get=>_imageSrc;
            set => SetProperty(ref _imageSrc, value);
        }

        private string _characterName;
        public string CharacterName
        {
            get => _characterName;
            set => SetProperty(ref _characterName, value);
        }

        private int _level;
        public int Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }

        private ECharacterJob _characterJob;
        public ECharacterJob CharacterJob
        {
            get => _characterJob;
            set => SetProperty(ref _characterJob, value);
        }

        private StatusBase _status;
        public StatusBase Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private bool _isUseAttackPower;
        public bool IsUseAttackPower
        {
            get => _isUseAttackPower;
            set => SetProperty(ref _isUseAttackPower, value);
        }

        private double _weaponConst;
        public double WeaponConst
        {
            get => _weaponConst;
            set => SetProperty(ref _weaponConst, value);
        }

        private double _jobConst;
        public double JobConst
        {
            get => _jobConst;
            set => SetProperty(ref _jobConst, value);
        }

        /*
        앞스공	숙련도% × 뒷스공

                물리 공격력 : (주스탯 × 4 + 부스탯) × 총공격력 × 무기상수 × 직업상수 × (1 + 공격력%) × (1 + 데미지%) × (1 + 최종데미지%) × 0.01
        뒷스공
                마법 공격력 : (주스탯 × 4 + 부스탯) × 총  마력 × 무기상수 × 직업상수 × (1 + 마력%) × (1 + 데미지%) × (1 + 최종데미지%) × 0.01

        뒷스공(제논)	         (STR + DEX + LUK) × 4 × 0.01 × 총 공격력 × 무기상수(1.5) × 직업상수(0.875) × (1 + 공격력%) × 1 + 데미지%) × (1 + 최종데미지%)
        데벤져                HP(AP투자) 14당 주스탯 환산값 1, 아이템HP 17.5당 주스탯 환산값 1, 힘이 부스탯
        */

        /// <summary>
        /// 데벤져나 제논,아크같은 경우는 따로 클래스를 만들어 처리가 필요함
        /// </summary>
        /// <param name="status"></param>
        /// <param name="main"></param>
        /// <param name="sub"></param>
        /// <returns></returns>
        public int GetMaxStatusAttack(EStatus main, EStatus sub)
        {
            int retval = 0;
            int MainStatus = 0;
            int SubStatus = 0;
            double Constant = GetCharacterConstant();
            double Percent = GetCharacterPercent(Status);

            #region Switch
            switch (main)
            {
                case EStatus.STR:
                    MainStatus = Status.GetSTR();
                    break;
                case EStatus.DEX:
                    MainStatus = Status.GetDEX();
                    break;
                case EStatus.INT:
                    MainStatus = Status.GetINT();
                    break;
                case EStatus.LUK:
                    MainStatus = Status.GetLUK();
                    break;
                case EStatus.HP:
                    MainStatus = Status.GetHP();
                    break;
                case EStatus.MP:
                    MainStatus = Status.GetMP();
                    break;
            }

            switch (sub)
            {
                case EStatus.STR:
                    SubStatus = Status.GetSTR();
                    break;
                case EStatus.DEX:
                    SubStatus = Status.GetDEX();
                    break;
                case EStatus.INT:
                    SubStatus = Status.GetINT();
                    break;
                case EStatus.LUK:
                    SubStatus = Status.GetLUK();
                    break;
                case EStatus.HP:
                    SubStatus = Status.GetHP();
                    break;
                case EStatus.MP:
                    SubStatus = Status.GetMP();
                    break;
            }

            #endregion

            var temp = ((MainStatus * 4) + SubStatus) * Constant * Percent;
            retval = (int)temp;

            return retval;
        }

        public int GetMinStatusAttack(EStatus main, EStatus sub)
        {
            int retval = 0;
            int MaxStatus = GetMaxStatusAttack(main, sub);

            return retval;
        }

        #warning 공격력 %를 붙여줄지 붙이지 않을지에 대한 실험이 필요함
        private double GetCharacterPercent(StatusBase status)
        {
            double retval = 0;
            if(IsUseAttackPower == true)
            {
                retval += status.GetAttackPower();
            }
            else
            {
                retval += status.GetMagicAttack();
            }

            retval *= (1 + (status.Damage / 100));
            retval *= (1 + (status.LastDamage / 100));

            return retval;
        }

        private double GetCharacterConstant()
        {
            double retval = 0;

            retval += WeaponConst;
            retval *= JobConst;
            retval *= 0.01;

            return retval;
        }
    }
}
