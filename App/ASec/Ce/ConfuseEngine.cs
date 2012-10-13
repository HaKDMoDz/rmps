namespace Me.Amon.Ce
{
    public class ConfuseEngine
    {
        #region 全局变量
        /// <summary>
        /// 密码方向
        /// </summary>
        private bool _Encrypt;
        /// <summary>
        /// 内部索引
        /// </summary>
        private int[] _Indexes;
        #endregion

        #region 公共函数
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="encrypt"></param>
        /// <param name="rounds"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public bool Init(bool encrypt, int rounds, int offset)
        {
            if (rounds < 2 || offset < 0 || offset >= rounds)
            {
                return false;
            }

            _Encrypt = encrypt;

            Rounds = rounds;
            Offset = offset;
            _Indexes = new int[Rounds];
            return true;
        }

        /// <summary>
        /// 连续处理
        /// </summary>
        /// <param name="srcArray"></param>
        /// <param name="srcFrom"></param>
        /// <param name="length"></param>
        /// <param name="dstArray"></param>
        /// <param name="dstFrom"></param>
        /// <returns></returns>
        public int Process(char[] srcArray, int srcFrom, int length, char[] dstArray, int dstFrom)
        {
            if (_Encrypt)
            {
                return DoEncode(srcArray, srcFrom, length, dstArray, dstFrom);
            }

            return DoDecode(srcArray, srcFrom, length, dstArray, dstFrom);
        }

        /// <summary>
        /// 终了处理
        /// </summary>
        /// <param name="srcArray"></param>
        /// <param name="srcFrom"></param>
        /// <param name="length"></param>
        /// <param name="dstArray"></param>
        /// <param name="dstFrom"></param>
        /// <returns></returns>
        public int DoFinal(char[] srcArray, int srcFrom, int length, char[] dstArray, int dstFrom)
        {
            if (_Encrypt)
            {
                return DoEncode(srcArray, srcFrom, length, dstArray, dstFrom);
            }

            return DoDecode(srcArray, srcFrom, length, dstArray, dstFrom);
        }

        /// <summary>
        /// 收尾处理
        /// </summary>
        /// <param name="output"></param>
        /// <param name="outOff"></param>
        /// <returns></returns>
        public int DoFinal(char[] output, int outOff)
        {
            return 0;
        }
        #endregion

        /// <summary>
        /// 圈数
        /// </summary>
        public int Rounds { get; private set; }

        /// <summary>
        /// 起始柱面
        /// </summary>
        public int Offset { get; private set; }

        #region 私有函数
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="srcArray"></param>
        /// <param name="srcFrom"></param>
        /// <param name="length"></param>
        /// <param name="dstArray"></param>
        /// <param name="dstFrom"></param>
        private int DoEncode(char[] srcArray, int srcFrom, int length, char[] dstArray, int dstFrom)
        {
            // 圈长
            int t1 = length / Rounds;
            // 余数
            int odds = length % Rounds;
            int t2 = srcFrom;
            for (int i = 0; i < Rounds; i += 1)
            {
                _Indexes[i] = t2;
                t2 += t1 + (i < odds ? 1 : 0);
            }

            t2 = dstFrom;
            length += dstFrom - odds;
            t1 = Offset;
            while (t2 < length)
            {
                dstArray[t2++] = srcArray[_Indexes[t1]];

                _Indexes[t1] += 1;
                t1 += 1;
                if (t1 >= Rounds)
                {
                    t1 = 0;
                }
            }
            t1 = 0;
            while (t1 < odds)
            {
                dstArray[t2++] = srcArray[_Indexes[t1++]];
            }
            return t2 - dstFrom;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="srcArray"></param>
        /// <param name="srcFrom"></param>
        /// <param name="length"></param>
        /// <param name="dstArray"></param>
        /// <param name="dstFrom"></param>
        private int DoDecode(char[] srcArray, int srcFrom, int length, char[] dstArray, int dstFrom)
        {
            // 圈长
            int t1 = length / Rounds;
            // 余数
            int odds = length % Rounds;
            int t2 = srcFrom;
            for (int i = 0; i < Rounds; i += 1)
            {
                _Indexes[i] = t2;
                t2 += t1 + (i < odds ? 1 : 0);
            }

            t2 = srcFrom;
            length += srcFrom - odds;
            t1 = Offset;
            while (t2 < length)
            {
                dstArray[_Indexes[t1]] = srcArray[t2++];

                _Indexes[t1] += 1;
                t1 += 1;
                if (t1 >= Rounds)
                {
                    t1 = 0;
                }
            }
            t1 = 0;
            while (t1 < odds)
            {
                dstArray[_Indexes[t1++]] = srcArray[t2++];
            }
            return t2 - dstFrom;
        }
        #endregion
    }
}
