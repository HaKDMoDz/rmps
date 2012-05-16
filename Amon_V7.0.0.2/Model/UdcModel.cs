using System.Collections.Generic;
using Me.Amon.Pwd;

namespace Me.Amon.Model
{
    public class UdcModel
    {
        private string _UdcKey;

        public UdcModel()
        {
            Length = 8;
            _UdcKey = "aucs000000000005";
        }

        public void Init(UserModel userModel)
        {
            _UdcList = new List<Udc>();
            _UdcList.Add(new Udc { Id = "aucs000000000001", Name = "仅数字", Tips = "仅数字", Data = "0123456789" });
            _UdcList.Add(new Udc { Id = "aucs000000000002", Name = "大写字母", Tips = "大写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _UdcList.Add(new Udc { Id = "aucs000000000003", Name = "小写字母", Tips = "小写字母", Data = "abcdefghijklmnopqrstuvwxyz" });
            _UdcList.Add(new Udc { Id = "aucs000000000004", Name = "大小写字母", Tips = "大小写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _UdcList.Add(new Udc { Id = "aucs000000000005", Name = "数字及字母", Tips = "数字及字母", Data = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _UdcList.Add(new Udc { Id = "aucs000000000006", Name = "可输入英文符号", Tips = "可输入英文符号", Data = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~" });
            foreach (Udc udc in userModel.DBA.ListUdc())
            {
                _UdcList.Add(udc);
            }
            foreach (Udc item in _UdcList)
            {
                if (item.Id == _UdcKey)
                {
                    Default = item;
                }
            }

            Modified = 0x7FFFFFFF;
        }

        /// <summary>
        /// 字符集列表
        /// </summary>
        public IList<Udc> UdcList
        {
            get
            {
                return _UdcList;
            }
        }
        private List<Udc> _UdcList;

        /// <summary>
        /// 字符集状态
        /// </summary>
        public int Modified { get; set; }

        /// <summary>
        /// 默认字符集
        /// </summary>
        public Udc Default { get; set; }

        /// <summary>
        /// 字符集长度
        /// </summary>
        public int Length { get; set; }
    }
}
