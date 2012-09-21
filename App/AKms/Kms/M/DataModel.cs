using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Me.Amon.Da.Db;
using Me.Amon.Kms.Enums;
using Me.Amon.Util;

namespace Me.Amon.Kms.M
{
    public class DataModel
    {
        private static RDBEngine _DBE;

        public DataModel(UserModel userModel)
        {
            _DBE = new RDBEngine();
            _DBE.Init(userModel);
        }

        private static string ToLike(string text)
        {
            return Regex.Replace(' ' + Regex.Replace(text, "[_]+", " ") + ' ', "[^\\w]+", "%");
        }

        #region Language
        public static List<MLanguage> ListLanguage()
        {
            var list = new List<MLanguage>();

            _DBE.ReInit();
            _DBE.AddTable(DataConst.C1010100);
            _DBE.AddSort(DataConst.C1010106, true);

            foreach (DataRow row in _DBE.ExecuteSelect().Rows)
            {
                var lang = new MLanguage();
                lang.C1010101 = (int)row[DataConst.C1010101];
                lang.C1010102 = (int)row[DataConst.C1010102];
                lang.C1010103 = row[DataConst.C1010103] + "";
                lang.C1010104 = row[DataConst.C1010104] + "";
                lang.C1010105 = row[DataConst.C1010105] + "";
                lang.C1010106 = row[DataConst.C1010106] + "";
                lang.C1010107 = row[DataConst.C1010107] + "";
                lang.C1010108 = row[DataConst.C1010108] + "";
                lang.C1010109 = row[DataConst.C1010109] + "";
                list.Add(lang);
            }

            return list;
        }
        #endregion

        #region Category
        public static MCategory FindCategory(string text)
        {
            return FindCategory(new RDBEngine(), text);
        }

        public static MCategory FindCategory(RDBEngine _DBA, string text)
        {
            _DBA.AddTable(DataConst.C2010200);
            _DBA.AddWhere(DataConst.C2010205, text);

            DataTable dt = _DBA.ExecuteSelect();
            return dt.Rows.Count == 1 ? ReadCategory(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<MCategory> ListCategory()
        {
            return ListCategory(new RDBEngine());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DBA"></param>
        /// <returns></returns>
        private static List<MCategory> ListCategory(RDBEngine _DBA)
        {
            _DBA.AddTable(DataConst.C2010200);
            _DBA.AddSort(DataConst.C2010201, true);

            DataTable dt = _DBA.ExecuteSelect();
            var list = (from DataRow row in dt.Rows select ReadCategory(row)).ToList();
            dt.Dispose();

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static MCategory ReadCategory(DataRow row)
        {
            var cat = new MCategory();
            cat.C2010201 = (int)row[DataConst.C2010201];
            cat.C2010202 = (int)row[DataConst.C2010202];
            cat.C2010203 = row[DataConst.C2010203] + "";
            cat.C2010204 = row[DataConst.C2010204] + "";
            cat.C2010205 = row[DataConst.C2010205] + "";
            cat.C2010206 = row[DataConst.C2010206] + "";
            cat.C2010207 = row[DataConst.C2010207] + "";
            cat.C2010208 = row[DataConst.C2010208] + "";
            cat.C2010209 = row[DataConst.C2010209] + "";
            return cat;
        }

        public static MCategory SaveCategory(string cat)
        {
            return SaveCategory(new RDBEngine(), cat);
        }

        public static MCategory SaveCategory(RDBEngine _DBA, string text)
        {
            var cat = new MCategory();
            cat.C2010204 = "P3100100";
            cat.C2010205 = text;
            cat.C2010206 = text;
            cat.C2010207 = "";
            cat.C2010208 = "";
            cat.C2010209 = "";
            SaveCategory(_DBA, cat);
            return cat;
        }

        public static List<MCategory> SaveCategory(ICollection<string> cats)
        {
            var list = new List<MCategory>();


            foreach (var tmp in cats)
            {
                var cat = FindCategory(_DBE, tmp);
                _DBE.ReInit();
                if (cat == null)
                {
                    cat = SaveCategory(_DBE, tmp);
                    _DBE.ReInit();
                }
                list.Add(cat);
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat"></param>
        public static void SaveCategory(MCategory cat)
        {
            SaveCategory(new RDBEngine(), cat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DBA"></param>
        /// <param name="cat"></param>
        private static void SaveCategory(RDBEngine _DBA, MCategory cat)
        {
            _DBA.AddTable(DataConst.C2010200);
            _DBA.AddParam(DataConst.C2010201, cat.C2010201);
            _DBA.AddParam(DataConst.C2010202, cat.C2010202);
            _DBA.AddParam(DataConst.C2010204, cat.C2010204);
            _DBA.AddParam(DataConst.C2010205, cat.C2010205);
            _DBA.AddParam(DataConst.C2010206, cat.C2010206);
            _DBA.AddParam(DataConst.C2010207, cat.C2010207);
            _DBA.AddParam(DataConst.C2010208, cat.C2010208);
            _DBA.AddParam(DataConst.C2010209, cat.C2010209);
            _DBA.AddParam(DataConst.C201020A, DataConst.NOW, false);
            if (CharUtil.IsValidateHash(cat.C2010203))
            {
                _DBA.AddWhere(DataConst.C2010203, cat.C2010203);
                _DBA.ExecuteUpdate();
            }
            else
            {
                cat.C2010203 = HashUtil.UtcTimeInEnc(false);
                _DBA.AddParam(DataConst.C2010203, cat.C2010203);
                _DBA.AddParam(DataConst.C201020B, DataConst.NOW, false);
                _DBA.ExecuteInsert();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        public static void DropCategory(MCategory lang)
        {
            DropCategory(new RDBEngine(), lang);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DBA"></param>
        /// <param name="cat"></param>
        private static void DropCategory(RDBEngine _DBA, MCategory cat)
        {
            _DBA.AddTable(DataConst.C2010200);
            _DBA.AddWhere(DataConst.C2010203, cat.C2010203);
            _DBA.ExecuteDelete();
        }
        #endregion

        #region Solution
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<MSolution> ListSolution()
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100500);
            _DBE.AddSort(DataConst.P3100501, false);

            DataTable dt = _DBE.ExecuteSelect();
            var list = new List<MSolution>(dt.Rows.Count);
            list.AddRange(from DataRow row in dt.Rows select ReadSolution(row));
            dt.Dispose();

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hash">方案索引</param>
        /// <returns></returns>
        public static MSolution ReadSolution(string hash)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100500);
            _DBE.AddWhere(DataConst.P3100502, hash);

            DataTable dt = _DBE.ExecuteSelect();
            if (dt.Rows.Count != 1)
            {
                return null;
            }

            // 会议方案
            MSolution sol = ReadSolution(dt.Rows[0]);
            dt.Dispose();

            // 前置动作
            _DBE.ReInit();
            sol.PreFunction = ListFunction(_DBE, hash, -1);

            // 后置动作
            _DBE.ReInit();
            sol.SufFunction = ListFunction(_DBE, hash, 1);

            // 标签资源
            _DBE.ReInit();
            sol.Category = new List<string>();
            _DBE.AddTable(DataConst.P3100700);
            _DBE.AddWhere(DataConst.P3100702, hash);
            dt = _DBE.ExecuteSelect();
            foreach (DataRow row in dt.Rows)
            {
                sol.Category.Add(row[DataConst.P3100703] + "");
            }
            dt.Dispose();

            return sol;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sol"></param>
        /// <returns></returns>
        public static MSolution ReadSolution(MSolution sol)
        {
            _DBE.ReInit();

            // 前置动作
            sol.PreFunction = ListFunction(_DBE, sol.Hash, -1);

            // 后置动作
            _DBE.ReInit();
            sol.SufFunction = ListFunction(_DBE, sol.Hash, 1);

            // 标签资源
            _DBE.ReInit();
            sol.Category = new List<string>();
            _DBE.AddTable(DataConst.P3100700);
            _DBE.AddWhere(DataConst.P3100702, sol.Hash);
            DataTable dt = _DBE.ExecuteSelect();
            foreach (DataRow row in dt.Rows)
            {
                sol.Category.Add(row[DataConst.P3100703] + "");
            }
            dt.Dispose();

            return sol;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static MSolution ReadSolution(DataRow row)
        {
            var sol = new MSolution();
            sol.Order = (int)row[DataConst.P3100501];
            sol.Hash = row[DataConst.P3100502] + "";
            sol.Name = row[DataConst.P3100503] + "";
            sol.Language = row[DataConst.P3100504] + "";
            sol.Target = (ETarget)Enum.Parse(typeof(ETarget), row[DataConst.P3100505] + "");
            sol.Method = (EMethod)Enum.Parse(typeof(EMethod), row[DataConst.P3100506] + "");
            sol.Output = (EOutput)Enum.Parse(typeof(EMethod), row[DataConst.P3100507] + "");
            sol.Intval = (int)row[DataConst.P3100508];
            sol.PostPrepare = row[DataConst.P3100509] + "";
            sol.PostConfirm = row[DataConst.P310050A] + "";
            sol.Remark = row[DataConst.P310050B] + "";
            sol.WorkKey = row[DataConst.P310050C] + "";
            sol.HaltKey = row[DataConst.P310050D] + "";
            sol.NextKey = row[DataConst.P310050E] + "";
            sol.StopKey = row[DataConst.P310050F] + "";
            return sol;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sol"></param>
        public static void SaveSolution(MSolution sol)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100500);
            _DBE.AddParam(DataConst.P3100501, sol.Order);
            _DBE.AddParam(DataConst.P3100503, sol.Name);
            _DBE.AddParam(DataConst.P3100504, sol.Language);
            _DBE.AddParam(DataConst.P3100505, (long)sol.Target);
            _DBE.AddParam(DataConst.P3100506, (long)sol.Method);
            _DBE.AddParam(DataConst.P3100507, (long)sol.Output);
            _DBE.AddParam(DataConst.P3100508, sol.Intval);
            _DBE.AddParam(DataConst.P3100509, sol.PostPrepare);
            _DBE.AddParam(DataConst.P310050A, sol.PostConfirm);
            _DBE.AddParam(DataConst.P310050B, sol.Remark);
            _DBE.AddParam(DataConst.P310050C, sol.WorkKey);
            _DBE.AddParam(DataConst.P310050D, sol.HaltKey);
            _DBE.AddParam(DataConst.P310050E, sol.NextKey);
            _DBE.AddParam(DataConst.P310050F, sol.StopKey);
            if (CharUtil.IsValidateHash(sol.Hash))
            {
                _DBE.AddWhere(DataConst.P3100502, sol.Hash);
                _DBE.AddUpdateBatch();
            }
            else
            {
                sol.Hash = HashUtil.UtcTimeInEnc(false);
                _DBE.AddParam(DataConst.P3100502, sol.Hash);
                _DBE.AddInsertBatch();
            }

            // 清空已有操作
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100600);
            _DBE.AddWhere(DataConst.P3100602, sol.Hash);
            _DBE.AddDeleteBatch();

            int order = 1;
            // 前置操作
            foreach (MFunction fun in sol.PreFunction)
            {
                _DBE.ReInit();
                fun.Order = order++;

                _DBE.AddTable(DataConst.P3100600);
                _DBE.AddParam(DataConst.P3100601, fun.Order);
                _DBE.AddParam(DataConst.P3100602, sol.Hash);
                _DBE.AddParam(DataConst.P3100603, -1);
                _DBE.AddParam(DataConst.P3100604, (long)fun.Action);
                _DBE.AddParam(DataConst.P3100605, fun.Param);
                _DBE.AddInsertBatch();
            }

            order = 1;
            // 后置操作
            foreach (MFunction fun in sol.SufFunction)
            {
                _DBE.ReInit();
                fun.Order = order++;

                _DBE.AddTable(DataConst.P3100600);
                _DBE.AddParam(DataConst.P3100601, fun.Order);
                _DBE.AddParam(DataConst.P3100602, sol.Hash);
                _DBE.AddParam(DataConst.P3100603, 1);
                _DBE.AddParam(DataConst.P3100604, (long)fun.Action);
                _DBE.AddParam(DataConst.P3100605, fun.Param);
                _DBE.AddInsertBatch();
            }

            // 清空已有
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100700);
            _DBE.AddWhere(DataConst.P3100702, sol.Hash);
            _DBE.AddDeleteBatch();

            order = 1;
            // 标签资源
            foreach (string cat in sol.Category)
            {
                _DBE.ReInit();
                _DBE.AddTable(DataConst.P3100700);
                _DBE.AddParam(DataConst.P3100701, order++);
                _DBE.AddParam(DataConst.P3100702, sol.Hash);
                _DBE.AddParam(DataConst.P3100703, cat);
                _DBE.AddInsertBatch();
            }

            _DBE.ExecuteBatch();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sol"></param>
        public static void DropSolution(MSolution sol)
        {
            _DBE.ReInit();

            // 语言选项
            _DBE.AddTable(DataConst.P3100700);
            _DBE.AddWhere(DataConst.P3100702, sol.Hash);
            _DBE.ExecuteDelete();

            // 预定动作
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100600);
            _DBE.AddWhere(DataConst.P3100601, sol.Hash);
            _DBE.ExecuteDelete();

            // 方案信息
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100500);
            _DBE.AddWhere(DataConst.P3100502, sol.Hash);
            _DBE.ExecuteDelete();
        }
        #endregion

        #region Function
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fun"></param>
        /// <param name="cat"></param>
        public static void SaveFunction(MFunction fun, int cat)
        {
            SaveFunction(new RDBEngine(), fun, cat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DBA"></param>
        /// <param name="fun"></param>
        /// <param name="cat">前置操作-1，后置操作1</param>
        private static void SaveFunction(RDBEngine _DBA, MFunction fun, int cat)
        {
            _DBA.AddTable(DataConst.P3100600);
            _DBA.AddParam(DataConst.P3100601, fun.Order);
            _DBA.AddParam(DataConst.P3100602, fun.SolId);
            _DBA.AddParam(DataConst.P3100603, cat);
            _DBA.AddParam(DataConst.P3100604, (long)fun.Action);
            _DBA.AddParam(DataConst.P3100605, fun.Param);
            _DBA.ExecuteInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solId"></param>
        /// <param name="cat"></param>
        /// <returns></returns>
        public static List<MFunction> ListFunction(string solId, int cat)
        {
            return ListFunction(new RDBEngine(), solId, cat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DBA"></param>
        /// <param name="solId"></param>
        /// <param name="cat"></param>
        /// <returns></returns>
        private static List<MFunction> ListFunction(RDBEngine _DBA, string solId, int cat)
        {
            _DBA.AddTable(DataConst.P3100600);
            _DBA.AddWhere(DataConst.P3100602, solId);
            _DBA.AddWhere(DataConst.P3100603, cat.ToString());
            _DBA.AddSort(DataConst.P3100601);
            DataTable dt = _DBA.ExecuteSelect();
            var list = (from DataRow row in dt.Rows select ReadFunction(row)).ToList();
            dt.Dispose();

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static MFunction ReadFunction(DataRow row)
        {
            var fun = new MFunction();
            fun.Order = (int)row[DataConst.P3100601];
            fun.SolId = row[DataConst.P3100602] + "";
            fun.Action = (EAction)Enum.Parse(typeof(EAction), row[DataConst.P3100604] + "");
            fun.Param = row[DataConst.P3100605] + "";
            return fun;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fun"></param>
        /// <param name="cat"></param>
        public static void DropFunction(MFunction fun, int cat)
        {
            DropFunction(new RDBEngine(), fun, cat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DBA"></param>
        /// <param name="fun"></param>
        /// <param name="cat">前置操作-1，后置操作1</param>
        private static void DropFunction(RDBEngine _DBA, MFunction fun, int cat)
        {
            _DBA.AddTable(DataConst.P3100600);
            _DBA.AddWhere(DataConst.P3100601, fun.Order.ToString());
            _DBA.AddWhere(DataConst.P3100602, fun.SolId);
            _DBA.AddWhere(DataConst.P3100603, cat.ToString());
            _DBA.ExecuteDelete();
        }
        #endregion

        #region Sentence
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static MSentence FindSentence(string text)
        {
            text = ToLike(text);
            if (string.IsNullOrEmpty(text) || text == "%")
            {
                return null;
            }

            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100100);
            _DBE.AddWhere(DataConst.P3100106, "LIKE", MSentence.Encode(text), true);

            DataTable dt = _DBE.ExecuteSelect();
            return dt.Rows.Count != 1 ? null : ReadSentence(dt.Rows[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catId">标签索引</param>
        /// <returns></returns>
        public static List<MSentence> ListSentence(string catId)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100100);
            _DBE.AddTable(DataConst.P3100300);

            _DBE.AddColumn(DataConst.P3100101);
            _DBE.AddColumn(DataConst.P3100102);
            _DBE.AddColumn(DataConst.P3100103);
            _DBE.AddColumn(DataConst.P3100104);
            _DBE.AddColumn(DataConst.P3100105);
            _DBE.AddColumn(DataConst.P3100106);

            _DBE.AddWhere(DataConst.P3100103, DataConst.P3100302, false);
            _DBE.AddWhere(DataConst.P3100301, catId);
            _DBE.AddSort(DataConst.P3100101, false);

            DataTable dt = _DBE.ExecuteSelect();
            var list = (from DataRow row in dt.Rows select ReadSentence(row)).ToList();
            dt.Dispose();
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catList"></param>
        /// <returns></returns>
        public static List<MSentence> ListSentence(List<string> catList)
        {
            var buf = new StringBuilder();
            foreach (string cat in catList)
            {
                buf.Append("'").Append(cat).Append("',");
            }

            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100100);
            if (buf.Length > 0)
            {
                _DBE.AddTable(DataConst.P3100300);
                _DBE.AddWhere(DataConst.P3100103, DataConst.P3100302, false);
                _DBE.AddWhere(DataConst.P3100301, "IN", '(' + buf.ToString(0, buf.Length - 1) + ')', false);
            }

            _DBE.AddColumn(DataConst.P3100101);
            _DBE.AddColumn(DataConst.P3100102);
            _DBE.AddColumn(DataConst.P3100103);
            _DBE.AddColumn(DataConst.P3100104);
            _DBE.AddColumn(DataConst.P3100105);
            _DBE.AddColumn(DataConst.P3100106);

            _DBE.AddSort(DataConst.P3100101, false);

            DataTable dt = _DBE.ExecuteSelect();
            var list = (from DataRow row in dt.Rows select ReadSentence(row)).ToList();
            dt.Dispose();
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static List<MSentence> ListSentence(EStyle style)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100100);

            _DBE.AddColumn(DataConst.P3100101);
            _DBE.AddColumn(DataConst.P3100102);
            _DBE.AddColumn(DataConst.P3100103);
            _DBE.AddColumn(DataConst.P3100104);
            _DBE.AddColumn(DataConst.P3100105);
            _DBE.AddColumn(DataConst.P3100106);

            _DBE.AddWhere(DataConst.P3100102, ((int)style).ToString());
            _DBE.AddSort(DataConst.P3100101, false);

            DataTable dt = _DBE.ExecuteSelect();
            var list = (from DataRow row in dt.Rows select ReadSentence(row)).ToList();
            dt.Dispose();
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lanId"></param>
        /// <returns></returns>
        public static MSentence ReadSentence(string lanId)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100100);

            _DBE.AddColumn(DataConst.P3100101);
            _DBE.AddColumn(DataConst.P3100102);
            _DBE.AddColumn(DataConst.P3100103);
            _DBE.AddColumn(DataConst.P3100104);
            _DBE.AddColumn(DataConst.P3100105);
            _DBE.AddColumn(DataConst.P3100106);

            _DBE.AddWhere(DataConst.P3100103, lanId);
            _DBE.AddSort(DataConst.P3100101, false);

            DataTable dt = _DBE.ExecuteSelect();
            return dt.Rows.Count == 1 ? ReadSentence(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static MSentence ReadSentence(DataRow row)
        {
            var lan = new MSentence();
            lan.P3100101 = (int)row[DataConst.P3100101];
            lan.P3100102 = (EStyle)Enum.Parse(typeof(EStyle), row[DataConst.P3100101] + "");
            lan.P3100103 = row[DataConst.P3100103] + "";
            lan.P3100104 = row[DataConst.P3100104] + "";
            lan.P3100105 = row[DataConst.P3100105] + "";
            lan.P3100106 = row[DataConst.P3100106] + "";
            return lan;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static int SaveSentence(MSentence sentence)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100100);

            _DBE.AddParam(DataConst.P3100101, sentence.P3100101);
            _DBE.AddParam(DataConst.P3100102, (long)sentence.P3100102);
            _DBE.AddParam(DataConst.P3100104, sentence.P3100104);
            _DBE.AddParam(DataConst.P3100105, MSentence.Encode(sentence.P3100105));
            _DBE.AddParam(DataConst.P3100106, MSentence.Encode(sentence.P3100106));
            _DBE.AddParam(DataConst.P3100107, DataConst.NOW, false);

            if (CharUtil.IsValidateHash(sentence.P3100103))
            {
                _DBE.AddWhere(DataConst.P3100103, sentence.P3100103);
                return _DBE.ExecuteUpdate();
            }

            sentence.P3100103 = HashUtil.UtcTimeInEnc(false);
            _DBE.AddParam(DataConst.P3100103, sentence.P3100103);
            _DBE.AddParam(DataConst.P3100108, DataConst.NOW, false);
            return _DBE.ExecuteInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lan"></param>
        public static void DropSentence(MSentence lan)
        {
            DropSentence(new RDBEngine(), lan);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DBA"></param>
        /// <param name="lan"></param>
        private static void DropSentence(RDBEngine _DBA, MSentence lan)
        {
            _DBA.AddTable(DataConst.P3100100);
            _DBA.AddWhere(DataConst.P3100103, lan.P3100103);
            _DBA.ExecuteDelete();
        }
        #endregion

        #region 问答
        /// <summary>
        /// 获取指定标签下回答给定问题的答案
        /// </summary>
        /// <param name="list"></param>
        /// <param name="input"></param>
        /// <param name="style"></param>
        /// <param name="lanId">语言索引</param>
        /// <param name="catIds">标签索引</param>
        /// <returns></returns>
        public static bool FindQuestion(List<MSentence> list, string input, EStyle style, string lanId, List<string> catIds)
        {
            input = ToLike(input);

            var buf = new StringBuilder();
            string cats = "";
            if (catIds != null && catIds.Count > 0)
            {
                foreach (string catId in catIds)
                {
                    if (CharUtil.IsValidate(catId))
                    {
                        buf.Append('\'').Append(catId).Append(",'");
                    }
                }
                if (buf.Length > 0)
                {
                    cats = buf.ToString(0, buf.Length - 1);
                }
                buf.Remove(0, buf.Length);
            }

            buf.Append("SELECT ");
            buf.Append(DataConst.P3100101).Append(',');
            buf.Append(DataConst.P3100102).Append(',');
            buf.Append(DataConst.P3100103).Append(',');
            buf.Append(DataConst.P3100104).Append(',');
            buf.Append(DataConst.P3100105).Append(',');
            buf.Append(DataConst.P3100106);
            buf.Append("  FROM ");
            buf.Append(DataConst.P3100100);
            if (cats.Length > 0)
            {
                buf.Append(" LEFT JOIN ").Append(DataConst.P3100300).Append(" ON ").Append(DataConst.P3100103).Append('=').Append(DataConst.P3100302);
            }
            buf.Append(" WHERE ");
            buf.Append(DataConst.P3100102).Append('=').Append((long)style);
            if (input.Length > 0 || input != "%")
            {
                buf.Append("  AND ").Append(DataConst.P3100106).Append(" LIKE '").Append(MSentence.Encode(input)).Append('\'');
            }
            if (CharUtil.IsValidateHash(lanId))
            {
                buf.Append("  AND ").Append(DataConst.P3100104).Append("='").Append(lanId).Append('\'');
            }
            if (cats.Length > 0)
            {
                buf.Append("  AND ").Append(DataConst.P3100301).Append("in (").Append(cats).Append(')');
            }
            buf.Append(" ORDER BY ").Append(DataConst.P3100101).Append(" DESC");

            DataTable dt = new RDBEngine().ExecuteSelect(buf.ToString());
            list.AddRange(from DataRow row in dt.Rows select ReadSentence(row));
            dt.Dispose();
            return true;
        }


        public static bool FindResponse(List<MSentence> list, string askId, EStyle style, string lanId, List<string> catIds)
        {
            var buf = new StringBuilder();
            if (catIds != null && catIds.Count > 0)
            {
                foreach (string catId in catIds)
                {
                    if (CharUtil.IsValidate(catId))
                    {
                        buf.Append('\'').Append(catId).Append(",'");
                    }
                }
            }

            bool withCat = buf.Length > 1;

            _DBE.AddTable(DataConst.P3100100);
            _DBE.AddTable(DataConst.P3100200);
            if (withCat)
            {
                _DBE.AddTable(DataConst.P3100300);
            }

            _DBE.AddColumn(DataConst.P3100101);
            _DBE.AddColumn(DataConst.P3100102);
            _DBE.AddColumn(DataConst.P3100103);
            _DBE.AddColumn(DataConst.P3100104);
            _DBE.AddColumn(DataConst.P3100105);
            _DBE.AddColumn(DataConst.P3100106);

            _DBE.AddWhere(DataConst.P3100103, DataConst.P3100202, false);
            if (withCat)
            {
                _DBE.AddWhere(DataConst.P3100103, DataConst.P3100302, false);
                _DBE.AddWhere(DataConst.P3100301, "IN", '(' + buf.ToString(0, buf.Length - 1) + ')', false);
            }
            _DBE.AddWhere(DataConst.P3100102, "" + style, false);
            _DBE.AddWhere(DataConst.P3100201, askId);
            if (CharUtil.IsValidateHash(lanId))
            {
                _DBE.AddWhere(DataConst.P3100104, lanId);
            }
            _DBE.AddSort(DataConst.P3100203, false);

            DataTable dt = _DBE.ExecuteSelect();
            list.AddRange(from DataRow row in dt.Rows select ReadSentence(row));
            dt.Dispose();
            return true;
        }

        public static void UpdateResponse(string qId, string rId, int rate)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100200);
            _DBE.AddParam(DataConst.P3100203, "=", DataConst.P3100203 + (rate < 0 ? "" : "+") + rate, false);
            _DBE.AddParam(DataConst.P3100204, "=", DataConst.P3100204 + "+1", false);
            _DBE.AddWhere(DataConst.P3100201, qId);
            _DBE.AddWhere(DataConst.P3100202, rId);
            _DBE.ExecuteUpdate();
        }

        public static void AppendResponse(string qId, string rId)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100200);
            _DBE.AddParam(DataConst.P3100201, qId);
            _DBE.AddParam(DataConst.P3100202, rId);
            _DBE.AddParam(DataConst.P3100203, 0);
            _DBE.AddParam(DataConst.P3100204, 0);
            _DBE.ExecuteInsert();
        }
        public static void RemoveResponse(string qId, string rId)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100200);
            _DBE.AddWhere(DataConst.P3100201, qId);
            _DBE.AddWhere(DataConst.P3100202, rId);
            _DBE.ExecuteDelete();
        }

        public static List<MCategory> ListTags(string sid)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.C2010200);
            _DBE.AddTable(DataConst.P3100300);

            _DBE.AddColumn(DataConst.C2010201);
            _DBE.AddColumn(DataConst.C2010202);
            _DBE.AddColumn(DataConst.C2010203);
            _DBE.AddColumn(DataConst.C2010204);
            _DBE.AddColumn(DataConst.C2010205);
            _DBE.AddColumn(DataConst.C2010206);
            _DBE.AddColumn(DataConst.C2010207);
            _DBE.AddColumn(DataConst.C2010208);
            _DBE.AddColumn(DataConst.C2010209);

            _DBE.AddWhere(DataConst.C2010203, DataConst.P3100301, false);
            _DBE.AddWhere(DataConst.P3100302, sid);

            DataTable dt = _DBE.ExecuteSelect();
            var list = (from DataRow row in dt.Rows select ReadCategory(row)).ToList();
            dt.Dispose();

            return list;
        }

        public static void RemoveTags(string sId, string cId)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100300);
            _DBE.AddWhere(DataConst.P3100301, cId);
            _DBE.AddWhere(DataConst.P3100302, sId);
            _DBE.ExecuteDelete();
        }

        public static void RemoveTags(string cId)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100300);
            _DBE.AddWhere(DataConst.P3100301, cId);
            _DBE.ExecuteDelete();
        }

        public static void SaveTags(string sId, List<MCategory> newCats)
        {
            _DBE.ReInit();
            _DBE.AddTable(DataConst.P3100300);
            _DBE.AddColumn(DataConst.P3100301);
            _DBE.AddWhere(DataConst.P3100302, sId);
            DataTable dt = _DBE.ExecuteSelect();
            var catMap = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                catMap["" + row[DataConst.P3100301]] = "";
            }
            _DBE.ReInit();

            bool notNull = false;
            foreach (MCategory cat in newCats)
            {
                if (catMap.ContainsKey(cat.C2010203))
                {
                    continue;
                }
                _DBE.AddTable(DataConst.P3100300);
                _DBE.AddParam(DataConst.P3100301, cat.C2010203);
                _DBE.AddParam(DataConst.P3100302, sId);
                _DBE.AddInsertBatch();
                _DBE.ReInit();
                notNull = true;
            }
            if (notNull)
            {
                _DBE.ExecuteBatch();
            }
        }
        #endregion
    }
}
