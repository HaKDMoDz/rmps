﻿using System.Data;
using Me.Amon.Da.Db;

namespace Me.Amon.Bean
{
    public abstract class Vcs
    {
        public const int OPT_CONFUSE = -2;
        public const int OPT_DELETE = -1;
        public const int OPT_INSERT = 0;
        public const int OPT_DEFAULT = 1;
        public const int OPT_UPDATE = 2;

        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }

        public int Operate { get; set; }

        public int Version { get; set; }

        public abstract bool Load(DataRow row);

        public abstract bool Read(DBAccess dba, string Id);

        public abstract bool Save(DBAccess dba, bool update);
    }
}
