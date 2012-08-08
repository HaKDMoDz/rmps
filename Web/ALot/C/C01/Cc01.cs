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
            if ((round.Includes == null || round.Includes.Count < 1) && (round.Excludes == null || round.Excludes.Count < 1))
            {
                return;
            }

            Item[] tmp = new Item[_Result.Length];
            int idx = 0;
            int m = _Items.Count - 1;
            int n;
            Item item;
            foreach (string key in round.Includes.Keys)
            {
                n = round.Includes[key];
                tmp[idx++] = _Items[n];
                item = _Items[n];
                _Items[n] = _Items[m];
                _Items[m] = item;
            }
            //foreach (Item t in _Items)
            //{
            //    foreach (string key in round.Includes.Keys)
            //    {
            //    }
            //}

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
            int m;
            int n;
            Item item;
            int i = 0;
            while (i < result.Length)
            {
                m = _Items.Count - i - 1;
                n = _Random.Next(_Items.Count - i);
                item = _Items[n];
                _Items[n] = _Items[m];
                _Items[m] = item;
                result[i] = item;
                i += 1;
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
