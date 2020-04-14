using MapleStoryCodeSearcher.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.XPath;

namespace MapleStoryCodeSearcher
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<XmlDocument> XmlDocList { get; set; } = new List<XmlDocument>();
        private List<SearchResult> SearchResultList { get; set; } = new List<SearchResult>();

        public MainWindow()
        {
            InitializeComponent();
            LoadXml();
        }

        private void LoadXml()
        {
            XmlDocument Cash = new XmlDocument();
            XmlDocument Consume = new XmlDocument();
            XmlDocument Etc = new XmlDocument();
            XmlDocument Eqp = new XmlDocument();
            XmlDocument Skill = new XmlDocument();

            Cash.Load(Directory.GetCurrentDirectory() + "/Assets/Cash.img.xml");
            Consume.Load(Directory.GetCurrentDirectory() + "/Assets/Consume.img.xml");
            Etc.Load(Directory.GetCurrentDirectory() + "/Assets/Etc.img.xml");
            Eqp.Load(Directory.GetCurrentDirectory() + "/Assets/Eqp.img.xml");
            Skill.Load(Directory.GetCurrentDirectory() + "/Assets/Skill.img.xml");

            XmlDocList.Add(Cash);
            XmlDocList.Add(Consume);
            XmlDocList.Add(Etc);
            XmlDocList.Add(Eqp);
            XmlDocList.Add(Skill);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchResultList = new List<SearchResult>();
            dgSearchResult.Items.Refresh();

            for(int i = 0; i < XmlDocList.Count; i++)
            {
                var nodes = XmlDocList[i].LastChild.ChildNodes;
                if(nodes.Count > 1)
                {
                    AddEqpItems(nodes, tbSearchWord.Text);
                }
                else
                {
                    AddMatchedItems(nodes, tbSearchWord.Text);
                }
            }

            dgSearchResult.ItemsSource = SearchResultList;
            dgSearchResult.Items.Refresh();
        }

        private void AddMatchedItems(XmlNodeList nodes, string Word)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].FirstChild.Name.Contains(Word) == true)
                {
                    SearchResult newItem = new SearchResult();
                    newItem.ItemName = nodes[i].Name;
                    newItem.ItemType = nodes[i].Name;
                    newItem.ItemCode = nodes[i].Name;
                    SearchResultList.Add(newItem);
                }
            }
        }

        private void AddEqpItems(XmlNodeList nodeList,string Word)
        {
            for(int i = 0; i < nodeList.Count; i++)
            {
                var Items = nodeList[i].ChildNodes;

                for (int j = 0; j < Items.Count; j++)
                {
                    if(Items[j]?.FirstChild?.Attributes["value"].Value.Contains(Word) == true)
                    {
                        SearchResult newItem = new SearchResult();
                        newItem.ItemName = Items[j].FirstChild.Attributes["value"].Value;
                        newItem.ItemType = nodeList[i].Attributes["name"].Value;
                        newItem.ItemCode = Items[j].Attributes["name"].Value;
                        SearchResultList.Add(newItem);
                    }
                }
            }
        }

        private void dgSearchResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgSearchResult.SelectedItem == null)
            {
                return;
            }
            var item = dgSearchResult.SelectedItem as SearchResult;

            tbItemName.Text = item.ItemName;
            tbItemType.Text = item.ItemType;
            tbItemCode.Text = item.ItemCode;
        }
    }
}
