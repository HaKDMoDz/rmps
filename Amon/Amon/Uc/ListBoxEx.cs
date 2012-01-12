using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Uc
{
    public class ListBoxEx : ListBox
    {
        public ListBoxEx()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();//先画背景

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)//如果选中该选项
            {
                //Brush b = new TextureBrush(new Bitmap(@"../../../sj.bmp"));//读取背景图片,再转变成画刷
                ////就在背景里画图片
                //e.Graphics.FillRectangle(b, e.Bounds);//参数中,e.Bounds 表示当前选项在整个listbox中的区域
            }
            else//不是选中item
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);//在背景上画空白
                //Brush b = new TextureBrush(new Bitmap(@"../../../Listline.bmp"));//底下线的图片
                ////在背景上画线
                //e.Graphics.FillRectangle(b, e.Bounds.X, e.Bounds.Y + 23, e.Bounds.Width, 1);//参数中,23和1是根据图片来的,因为需要在最下面显示线条
            }

            //最后把要显示的文字画在背景图片上
            e.Graphics.DrawString("哈哈", this.Font, Brushes.Black, e.Bounds.X + 15, e.Bounds.Y + 6, StringFormat.GenericDefault);//str要显示的字符数组
        }
    }
}
