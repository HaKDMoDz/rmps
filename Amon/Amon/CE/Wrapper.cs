using System;
using System.Collections.Generic;

namespace Me.Amon.CE
{
    public class Wrapper
    {
        private int _PrevDat = 0;
        private int _BitLeft = 0;
        private int _BitMask;
        private int _BitStep;
        private Dictionary<int, char> _Enc;
        private Dictionary<char, int> _Dec;

        public void Init(bool encrypt, char[] charset)
        {
            int cnt;

            if (encrypt)
            {
                // 数值与字符映射
                _Enc = new Dictionary<int, char>();
                for (int i = 0; i < charset.Length; i += 1)
                {
                    _Enc[i] = charset[i];
                }

                cnt = _Enc.Count;
            }
            else
            {
                _Dec = new Dictionary<char, int>();
                for (int i = 0; i < charset.Length; i += 1)
                {
                    _Dec[charset[i]] = i;
                }

                cnt = _Dec.Count;
            }

            // 判断可用位数
            if (cnt < 2)
            {
                throw new Exception("字符太少！");
            }

            _BitStep = 8;
            int tmp = 256;
            while (tmp > cnt)
            {
                tmp >>= 1;
                _BitStep -= 1;
            }
            _BitMask = tmp - 1;

            _PrevDat = 0;
            _BitLeft = 0;
        }

        #region 加密
        public int Encode(byte[] buffer, int offset1, int length, char[] output, int offset2)
        {
            int t;
            int index = offset2;
            length += offset1;
            while (offset1 < length)
            {
                t = buffer[offset1];
                _PrevDat |= (t << _BitLeft);
                _BitLeft += 8;

                while (_BitLeft >= _BitStep)
                {
                    output[index++] = _Enc[_PrevDat & _BitMask];

                    _PrevDat >>= _BitStep;
                    _BitLeft -= _BitStep;
                }

                offset1 += 1;
            }

            return index - offset2;
        }

        public int DoFinal(char[] output, int offset2)
        {
            int index = offset2;
            if (_BitLeft > 0)
            {
                output[index++] = _Enc[_PrevDat & _BitMask];
                _PrevDat = 0;
                _BitLeft = 0;
            }
            return index - offset2;
        }

        public int DoFinal(byte[] buffer, int offset1, int length, char[] output, int offset2)
        {
            int t;
            int index = offset2;
            length += offset1;
            while (offset1 < length)
            {
                t = buffer[offset1];
                _PrevDat |= (t << _BitLeft);
                _BitLeft += 8;

                while (_BitLeft >= _BitStep)
                {
                    output[index++] = _Enc[_PrevDat & _BitMask];

                    _PrevDat >>= _BitStep;
                    _BitLeft -= _BitStep;
                }

                offset1 += 1;
            }

            if (_BitLeft > 0)
            {
                output[index++] = _Enc[_PrevDat & _BitMask];
                _PrevDat = 0;
                _BitLeft = 0;
            }

            return index - offset2;
        }
        #endregion

        #region 解密
        public int Decode(char[] buffer, int offset1, int length, byte[] output, int offset2)
        {
            int t;
            int index = offset2;
            length += offset1;
            while (offset1 < length)
            {
                t = _Dec[buffer[offset1]];
                _PrevDat |= (t << _BitLeft);
                _BitLeft += _BitStep;

                if (_BitLeft >= 8)
                {
                    output[index++] = (byte)(_PrevDat & 0xFF);

                    _PrevDat >>= 8;
                    _BitLeft -= 8;
                }

                offset1 += 1;
            }

            return index - offset2;
        }

        public int DoFinal(byte[] output, int offset2)
        {
            int index = offset2;
            if (_BitLeft > 0)
            {
                output[index++] = (byte)(_PrevDat & 0xFF);
                _PrevDat = 0;
                _BitLeft = 0;
            }
            return index - offset2;
        }

        public int DoFinal(char[] buffer, int offset1, int length, byte[] output, int offset2)
        {
            int t;
            int index = offset2;
            length += offset1;
            while (offset1 < length)
            {
                t = _Dec[buffer[offset1]];
                _PrevDat |= (t << _BitLeft);
                _BitLeft += _BitStep;

                if (_BitLeft >= 8)
                {
                    output[index++] = (byte)(_PrevDat & 0xFF);

                    _PrevDat >>= 8;
                    _BitLeft -= 8;
                }

                offset1 += 1;
            }

            if (_BitLeft > 0)
            {
                output[index++] = (byte)(_PrevDat & 0xFF);
                _PrevDat = 0;
                _BitLeft = 0;
            }

            return index - offset2;
        }
        #endregion
    }
}
