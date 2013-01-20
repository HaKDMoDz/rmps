using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Da.Df;
using Me.Amon.Util;

namespace Me.Amon.M
{
   public class SkinModel
    {
       #region 全局变量
       private AUserModel _UserModel;
       private string _Pattern;
       private string _LookPath;
       private DFEngine _LookProp;
       private string _FeelPath;
       private DFEngine _FeelProp;
       private DFEngine _UserProp;
       #endregion

       #region 构造函数
       public SkinModel(AUserModel userModel)
       {
           _UserModel = userModel;
       }

       public void Init()
       {
       }
       #endregion

       #region 接口实现
       private Dictionary<string, Image> _Imgs;
       public Image GetImage(string key)
       {
           key = _FeelProp.Get(key);
           if (string.IsNullOrEmpty(key))
           {
               return BeanUtil.NaN16;
           }

           if (_Imgs.ContainsKey(key))
           {
               return _Imgs[key];
           }

           Image img = BeanUtil.ReadImage(Path.Combine(_FeelPath, key), BeanUtil.NaN16);
           _Imgs[key] = img;
           return img;
       }

       public Image GetImage(string key, string file)
       {
           if (string.IsNullOrWhiteSpace(file))
           {
               return BeanUtil.NaN16;
           }

           if (Path.IsPathRooted(file))
           {
               file = Path.Combine(Application.StartupPath, file);
           }

           if (!string.IsNullOrEmpty(key))
           {
               if (_Imgs.ContainsKey(key))
               {
                   return _Imgs[key];
               }

               Image img = BeanUtil.ReadImage(file, BeanUtil.NaN16);
               _Imgs[key] = img;
               return img;
           }

           return BeanUtil.ReadImage(file, BeanUtil.NaN16);
       }

       /// <summary>
       /// 布局存储
       /// </summary>
       public void LoadLayout()
       {
           #region Look
           _LookPath = Path.Combine(_UserModel.ResHome, "Skin", "Look", _UserModel.Look);
           _LookProp = new DFEngine();
           _LookProp.Load(Path.Combine(_LookPath, CApp.FILE_LOOK));
           #endregion

           #region Feel
           _FeelPath = Path.Combine(_UserModel.ResHome, "Skin", "Feel", _UserModel.Feel);
           _FeelProp = new DFEngine();
           _FeelProp.Load(Path.Combine(_FeelPath, CApp.FILE_FEEL));

           if (_Imgs == null)
           {
               _Imgs = new Dictionary<string, Image>();
           }
           else
           {
               _Imgs.Clear();
           }
           #endregion
       }

       /// <summary>
       /// 布局加载
       /// </summary>
       public void SaveLayout()
       {
       }
       #endregion
    }
}
