﻿using MapleStoryHelper.Standard.Boss.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Boss.ChaosRootAbyss
{
    public class ChaosBloodQueen : BossBase
    {
        private int _tolerance;
        public int Tolerance
        {
            get => _tolerance;
            set => SetProperty(ref _tolerance, value);
        }

        private int _defense;
        public int Defense
        {
            get => _defense;
            set => SetProperty(ref _defense, value);
        }

        public ChaosBloodQueen() : base()
        {
            InitChaosBloodQueen();
        }

        private void InitChaosBloodQueen()
        {
            FinalMaxHP = "140000000000";
            Tolerance = 50;
            Defense = 120;
        }
    }
}
