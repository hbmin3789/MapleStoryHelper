using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using WzComparerR2;
using WzComparerR2.CharaSim;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Standard.SkillLib.Model
{
    public class SkillBase : Skill
    {
        public int PercentDamage
        {
            get
            {
                int retval = 0;

                DataTable dt = new DataTable();

                int count = 0;
                try
                {
                    count = Convert.ToInt32(common["attackCount"]);
                    string expression = common["damage"];
                    expression = expression.Replace("x", "30");

                    retval = (int)dt.Compute(expression, null);
                    retval *= count;
                }
                catch
                {

                }

                

                return retval;
            }
        }

        public int PercentOnceDamage
        {
            get
            {
                try
                {
                    DataTable dt = new DataTable();
                    string expression = common["damage"];
                    expression = expression.Replace("x", "30");

                    return (int)dt.Compute(expression, null);
                }
                catch
                {

                }

                return 0;
            }
        }

        public int HitCount
        {
            get
            {
                int retval = 0;
                try
                {
                    retval = Convert.ToInt32(common["attackCount"]);
                }
                catch
                {

                }

                return retval;
            }
        }

        public int SkillDelay
        {
            get 
            {
                int retval = 0;

                for (int i = 0; i < effectDelay.Count; i++)
                {
                    retval += effectDelay[i];
                }

                double temp = (double)retval * 0.75;
                temp /= 30;
                temp = temp + 0.5;
                retval = ((int)temp)*30;

                return retval;
            }
        }

        private string _skillCode;
        public string SkillCode
        {
            get => _skillCode;
            set => SetProperty(ref _skillCode, value);
        }

        private string _skillName = string.Empty;
        public string SkillName
        {
            get => _skillName;
            set => SetProperty(ref _skillName, value);
        }

        private object _imgBitmapSource;
        [JsonIgnore]
        public object ImgBitmapSource
        {
            get => _imgBitmapSource;
            set => SetProperty(ref _imgBitmapSource, value);
        }

        private byte[] _imgByte;
        public byte[] ImgByte
        {
            get => _imgByte;
            set => SetProperty(ref _imgByte, value);
        }

        public static new SkillBase CreateFromNode(Wz_Node node, GlobalFindNodeFunction findNode)
        {
            SkillBase skill = new SkillBase();
            int skillID;
            if (!Int32.TryParse(node.Text, out skillID))
                return null;
            skill.SkillID = skillID;

            foreach (Wz_Node childNode in node.Nodes)
            {
                switch (childNode.Text)
                {
                    case "info":
                        var temp = childNode.GetNodeWzImage().Node.FindNodeByPath("type");
                        if (temp != null)
                        {
                            skill.type = Convert.ToInt32(temp.Value);
                        }
                        break;
                    case "icon":
                        skill.Icon = BitmapOrigin.CreateFromNode(childNode, findNode);
                        break;
                    case "iconMouseOver":
                        skill.IconMouseOver = BitmapOrigin.CreateFromNode(childNode, findNode);
                        break;
                    case "iconDisabled":
                        skill.IconDisabled = BitmapOrigin.CreateFromNode(childNode, findNode);
                        break;
                    case "common":
                        foreach (Wz_Node commonNode in childNode.Nodes)
                        {
                            if (commonNode.Value != null && !(commonNode.Value is Wz_Vector))
                            {
                                skill.common[commonNode.Text] = commonNode.Value.ToString();
                            }
                        }
                        break;
                    case "effect":
                        for (int i = 0; i < childNode.Nodes.Count; i++)
                        {
                            string val = childNode?.Nodes[i]?.Nodes["delay"]?.Value?.ToString();
                            if (val == null)
                            {
                                continue;
                            }
                            skill.effectDelay.Add(i, Convert.ToInt32(val));
                        }
                        break;
                    case "PVPcommon":
                        foreach (Wz_Node commonNode in childNode.Nodes)
                        {
                            if (commonNode.Value != null && !(commonNode.Value is Wz_Vector))
                            {
                                skill.PVPcommon[commonNode.Text] = commonNode.Value.ToString();
                            }
                        }
                        break;
                    case "level":
                        for (int i = 1; ; i++)
                        {
                            Wz_Node levelNode = childNode.FindNodeByPath(i.ToString());
                            if (levelNode == null)
                                break;
                            Dictionary<string, string> levelInfo = new Dictionary<string, string>();

                            foreach (Wz_Node commonNode in levelNode.Nodes)
                            {
                                if (commonNode.Value != null && !(commonNode.Value is Wz_Vector))
                                {
                                    levelInfo[commonNode.Text] = commonNode.Value.ToString();
                                }
                            }

                            skill.levelCommon.Add(levelInfo);
                        }
                        break;
                    case "hyper":
                        skill.Hyper = (HyperSkillType)childNode.GetValue<int>();
                        break;
                    case "hyperStat":
                        skill.HyperStat = childNode.GetValue<int>() != 0;
                        break;
                    case "invisible":
                        skill.Invisible = childNode.GetValue<int>() != 0;
                        break;
                    case "combatOrders":
                        skill.CombatOrders = childNode.GetValue<int>() != 0;
                        break;
                    case "notRemoved":
                        skill.NotRemoved = childNode.GetValue<int>() != 0;
                        break;
                    case "vSkill":
                        skill.VSkill = childNode.GetValue<int>() != 0;
                        break;
                    case "timeLimited":
                        skill.TimeLimited = childNode.GetValue<int>() != 0;
                        break;
                    case "disableNextLevelInfo":
                        skill.DisableNextLevelInfo = childNode.GetValue<int>() != 0;
                        break;
                    case "masterLevel":
                        skill.MasterLevel = childNode.GetValue<int>();
                        break;
                    case "reqLev":
                        skill.ReqLevel = childNode.GetValue<int>();
                        break;
                    case "req":
                        foreach (Wz_Node reqNode in childNode.Nodes)
                        {
                            if (reqNode.Text == "level")
                            {
                                skill.ReqLevel = reqNode.GetValue<int>();
                            }
                            else if (reqNode.Text == "reqAmount")
                            {
                                skill.ReqAmount = reqNode.GetValue<int>();
                            }
                            else
                            {
                                int reqSkill;
                                if (Int32.TryParse(reqNode.Text, out reqSkill))
                                {
                                    skill.ReqSkill[reqSkill] = reqNode.GetValue<int>();
                                }
                            }
                        }
                        break;
                    case "action":
                        for (int i = 0; ; i++)
                        {
                            Wz_Node idxNode = childNode.FindNodeByPath(i.ToString());
                            if (idxNode == null)
                                break;
                            skill.Action.Add(idxNode.GetValue<string>());
                        }
                        break;
                    case "addAttack":
                        Wz_Node toolTipDescNode = childNode.FindNodeByPath("toolTipDesc");
                        if (toolTipDescNode != null && toolTipDescNode.GetValue<int>() != 0)
                        {
                            skill.AddAttackToolTipDescSkill = childNode.FindNodeByPath("toolTipDescSkill").GetValue<int>();
                        }
                        break;
                    case "assistSkillLink":
                        skill.AssistSkillLink = childNode.FindNodeByPath("skill").GetValue<int>();
                        break;
                }
            }

            if ((skill.common.ContainsKey("forceCon") || (skill.levelCommon.Count > 0 && skill.levelCommon[0].ContainsKey("forceCon"))) && skill.Hyper == HyperSkillType.None)
            {
                Wz_Node forceNode = null;
                if (skill.SkillID / 10000 == 3001 || skill.SkillID / 10000 == 3100 || skill.SkillID / 10000 == 3110 || skill.SkillID / 10000 == 3111 || skill.SkillID / 10000 == 3112)
                {
                    forceNode = findNode.Invoke(string.Format("UI\\UIWindow2.img\\Skill\\main\\Force\\{0}", (Int32.Parse(skill.common["forceCon"]) - 1) / 30));
                }
                else if (skill.SkillID / 10000 / 1000 == 10)
                {
                    forceNode = findNode.Invoke(string.Format("UI\\UIWindow2.img\\SkillZero\\main\\Alpha\\{0}", skill.SkillID / 1000 % 10));
                }
                if (forceNode != null)
                {
                    BitmapOrigin force = BitmapOrigin.CreateFromNode(forceNode, findNode);
                    using (Graphics graphics = Graphics.FromImage(skill.Icon.Bitmap))
                    {
                        graphics.DrawImage(force.Bitmap, new Point(0, 0));
                    }
                    using (Graphics graphics = Graphics.FromImage(skill.IconMouseOver.Bitmap))
                    {
                        graphics.DrawImage(force.Bitmap, new Point(0, 0));
                    }
                    using (Graphics graphics = Graphics.FromImage(skill.IconDisabled.Bitmap))
                    {
                        graphics.DrawImage(force.Bitmap, new Point(0, 0));
                    }
                }
            }

            //判定技能声明版本
            skill.PreBBSkill = false;
            if (skill.levelCommon.Count > 0)
            {
                if (skill.common.Count <= 0
                    || (skill.common.Count == 1 && skill.common.ContainsKey("maxLevel")))
                {
                    skill.PreBBSkill = true;
                }
            }

            return skill;
        }
    }
}
