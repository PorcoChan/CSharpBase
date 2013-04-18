using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace Notebook
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetMenu_Click(object sender, EventArgs e)
        {
            HtmlUtil htmlUtil = new HtmlUtil();
            String url = "http://166.111.120.90/indexc.php?client=tsinghua&isbn=";
            String isbn = this.textBox1.Text;
            url += isbn;
            string content = htmlUtil.getHtmlContent(url);
            string tag = "\"catalog\":\"";
            int startMenuIndex = content.IndexOf(tag);
            int endMenuIndex = content.IndexOf("\"", startMenuIndex + tag.Length);
            int length = endMenuIndex - startMenuIndex;
            string menuStr = content.Substring(startMenuIndex + tag.Length, length);
            string menuStrDecoded = Regex.Unescape(menuStr);
            this.formatData(menuStrDecoded);
        }

        /// <summary>
        /// 添加目录内容
        /// </summary>
        /// <param name="menuStr"></param>
        private void formatData(string menuStr)
        {
            menuStr = menuStr.Replace("\\r", "");
            menuStr = menuStr.Replace("\\n", "");
            menuStr = menuStr.Replace("<br />", ";");
            menuStr = menuStr.Replace("/", "");
            string[] menuList = menuStr.Split(';');
            this.tvMenu.Nodes.Clear();
            foreach (string menu in menuList)
            {
                if (menu != null && menu.Trim().Length != 0)
                {
                    this.tvMenu.Nodes.Add(menu);
                }
            }
        }

        /// <summary>
        /// 上升目录等级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 下降目录等级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.tvMenu.SelectedNode;
            TreeNode preNode = selectedNode.PrevNode;
            this.tvMenu.Nodes.Remove(selectedNode);
            preNode.Nodes.Add(selectedNode);
        }

        /// <summary>
        /// 删除目录项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {

        }
    }
}
