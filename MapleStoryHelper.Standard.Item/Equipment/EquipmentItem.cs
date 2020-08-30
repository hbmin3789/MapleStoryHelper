using MapleStoryHelper.Converter;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item.Equipment;
using Newtonsoft.Json;
using System.Collections.Generic;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Standard.Item
{
    public class EquipmentItem : ItemBase
    {
        #region Property

        //럭키 아이템인지
        private bool _isJoker;
        [JsonProperty("isJoker")]
        public bool IsJoker
        {
            get => _isJoker;
            set => SetProperty(ref _isJoker, value);
        }

        private int _setItemID;
        [JsonProperty("setItemID")]
        public int SetItemID 
        {
            get => _setItemID;
            set => SetProperty(ref _setItemID, value);
        }

        private int _requiredLevel;
        [JsonProperty("requiredLevel")]
        public int RequiredLevel
        {
            get => _requiredLevel;
            set => SetProperty(ref _requiredLevel, value);
        }

        private int _maxStarForce;
        [JsonProperty("maxStarForce")]
        public int MaxStarForce
        {
            get => _maxStarForce;
            set => SetProperty(ref _maxStarForce, value);
        }

        private int _maxScroll;
        [JsonProperty("maxScroll")]
        public int MaxScroll
        {
            get => _maxScroll;
            set => SetProperty(ref _maxScroll, value);
        }

        private double _weaponConst = 0;
        [JsonProperty("weaponConst")]
        public double WeaponConst
        {
            get => _weaponConst;
            set => SetProperty(ref _weaponConst, value);
        }

        private EEquipmentCategory _equipmentCategory;
        [JsonProperty("equipmentCategory")]
        public EEquipmentCategory EquipmentCategory
        {
            get => _equipmentCategory;
            set => SetProperty(ref _equipmentCategory, value);
        }

        private GearType _gearType;
        [JsonProperty("gearType")]
        public GearType GearType
        {
            get => _gearType;
            set => SetProperty(ref _gearType, value);
        }

        private ECharacterClass _characterClass;
        [JsonProperty("characterClass")]
        public ECharacterClass CharacterClass
        {
            get => _characterClass;
            set => SetProperty(ref _characterClass, value);
        }

        private EAdvancement _advancement;
        [JsonProperty("advancement")]
        public EAdvancement Advancement
        {
            get => _advancement;
            set => SetProperty(ref _advancement, value);
        }

        private StatusBase _status = new StatusBase();
        [JsonProperty("Status")]
        public StatusBase Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        #endregion

        #region Constructor

        public EquipmentItem()
        {

        }

        #endregion
    }
}
