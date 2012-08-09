using System;
using System.Collections.Generic;
using System.Windows.Threading;
using Me.Amon.Lot.M;
using Me.Amon.Lot.V;

namespace Me.Amon.Lot.C.C01
{
    public class Cc01 : CLot
    {
        private MLot _MLot;
        private VLot _VLot;
        private Random _Random;
        private DispatcherTimer _Time;

        private List<Round> _Rounds;
        private List<Item> _Items;
        private Item[] _Result;

        public Cc01()
        {
        }

        #region 接口实现
        public void Init(MLot mlot, VLot vlot)
        {
            _MLot = mlot;
            _VLot = vlot;

            _Items = mlot.Nodes[0].Items;
            _Rounds = mlot.Nodes[0].Rounds;
            _Result = new Item[mlot.Cfg.ColCount * mlot.Cfg.RowCount];

            _Random = new Random();

            _Time = new DispatcherTimer();
            _Time.Interval = new TimeSpan(0, 0, 0, 0, 1000 / mlot.Cfg.Speed);
            _Time.Tick += new EventHandler(Time_Tick);
        }

        public void Run()
        {
            _Time.Start();
        }

        public void AmonMe()
        {
            _Time.Stop();

            if (_Rounds == null || _Rounds.Count < 1)
            {
                return;
            }
            Round round = _Rounds[0];
            if (round == null)
            {
                return;
            }
            bool bi = round.Includes != null && round.Includes.Count > 0;
            bool be = round.Excludes != null && round.Excludes.Count > 0;
            if (!(bi || be))
            {
                return;
            }

            Item[] arr = new Item[_Result.Length];
            int idx1 = _Items.Count;
            int idx2;
            Item tmp1;
            Item tmp2;
            int i = 0;
            // 列选必中项
            if (bi)
            {
                while (i < round.Includes.Count)
                {
                    idx1 -= 1;
                    tmp1 = _Items[idx1];

                    tmp2 = round.Includes[i];
                    idx2 = tmp2.Index;

                    tmp1.Index = idx2;
                    _Items[idx2] = tmp1;

                    if (_MLot.Cfg.Resualbe)
                    {
                        tmp2.Index = idx1;
                        _Items[idx1] = tmp2;
                    }
                    else
                    {
                        _Items.RemoveAt(idx1);
                    }

                    arr[i++] = tmp2;
                }
            }
            // 排除不中项
            if (be)
            {
                foreach (Item t in round.Excludes)
                {
                    idx1 -= 1;
                    tmp1 = _Items[idx1];

                    idx2 = t.Index;

                    tmp1.Index = idx2;
                    _Items[idx2] = tmp1;

                    t.Index = idx1;
                    _Items[idx1] = t;
                }
            }
            // 列选随机项
            while (i < arr.Length)
            {
                idx1 -= 1;
                tmp1 = _Items[idx1];

                idx2 = _Random.Next(idx1);
                tmp2 = _Items[idx2];

                tmp1.Index = idx2;
                _Items[idx2] = tmp1;

                if (_MLot.Cfg.Resualbe)
                {
                    tmp2.Index = idx1;
                    _Items[idx1] = tmp2;
                }
                else
                {
                    _Items.RemoveAt(idx1);
                }

                arr[i++] = tmp2;
            }

            // 随机分配
            idx1 = arr.Length;
            i = _Result.Length - 1;
            while (i > 0)
            {
                idx1 -= 1;
                idx2 = _Random.Next(idx1);

                _Result[i--] = arr[idx2];
                arr[idx2] = arr[idx1];
            }
            _Result[0] = arr[0];

            _VLot.Value(_Result, _Result.Length);
        }

        public void KeepOn()
        {
            _Time.Start();
        }

        public void End()
        {
            _Time.Stop();
        }
        #endregion

        private int Value(Item[] result)
        {
            int idx1 = _Items.Count;
            int idx2;
            Item tmp1;
            Item tmp2;
            int i = 0;
            while (i < result.Length)
            {
                idx1 -= 1;
                tmp1 = _Items[idx1];

                idx2 = _Random.Next(idx1);
                tmp2 = _Items[idx2];

                tmp1.Index = idx2;
                _Items[idx2] = tmp1;

                tmp2.Index = idx1;
                _Items[idx1] = tmp2;

                result[i++] = tmp2;
            }

            return i;
        }

        public void Reset()
        {
        }

        #region 事件处理
        private void Time_Tick(object sender, EventArgs e)
        {
            int cnt = Value(_Result);
            if (cnt > 0)
            {
                _VLot.Value(_Result, cnt);
            }
        }
        #endregion

        private bool ExistN(Round round, Item item)
        {
            if (round.Excludes == null || round.Excludes.Count < 1)
            {
                return false;
            }
            foreach (string n in round.Excludes.Keys)
            {
                if (n == item.Key || n == item.Value)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ReplaceP(Round round, string[] result)
        {
            if (round.Includes == null || round.Includes.Count < 1)
            {
                return true;
            }
            foreach (string n in round.Includes.Keys)
            {
                result[_Random.Next(1)] = n;
            }
            return true;
        }
    }
}
