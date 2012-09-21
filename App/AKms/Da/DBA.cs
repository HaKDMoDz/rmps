using System.Collections.Generic;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.M;

namespace Me.Amon.Da
{
    public interface DBA
    {
        void CloseConnect();

        /// <summary>
        /// 读取数据版本
        /// </summary>
        /// <returns></returns>
        Dbv DbVersion { get; }

        #region 数据更新
        /// <summary>
        /// 存储数据
        /// </summary>
        /// <param name="vcs"></param>
        void SaveVcs(Vcs vcs);

        /// <summary>
        /// 存储日志
        /// </summary>
        /// <param name="log"></param>
        void SaveLog(Log log);
        #endregion

        #region 数据删除
        /// <summary>
        /// 逻辑移除
        /// </summary>
        /// <param name="vcs"></param>
        void RemoveVcs(Vcs vcs);

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="vcs"></param>
        void DeleteVcs(Vcs vcs);

        void DeleteLog(Log log);
        #endregion

        #region 机器人
        List<MLanguage> ListLanguage();

        #region Solution
        List<MSolution> ListSolution();

        MSolution ReadSolution(string solId);

        MSolution ReadSolution(MSolution sol);

        void SaveSolution(MSolution sol);

        void DropSolution(MSolution sol);
        #endregion

        #region Function
        void SaveFunction(MFunction fun, int cat);

        List<MFunction> ListFunction(string solId, int cat);

        void DropFunction(MFunction fun, int cat);
        #endregion

        #region Sentence
        void SaveSentence(MSentence sen);

        MSentence FindSentence(string text);

        List<MSentence> ListSentence(string catId);

        List<MSentence> ListSentence(EStyle style);

        MSentence ReadSentence(string lanId);

        void DropSentence(MSentence sen);
        #endregion

        void AppendResponse(string qId, string rId);

        void RemoveResponse(string qId, string rId);

        List<MCategory> SaveCategory(string[] arr);

        void UpdateResponse(string qId, string rId, int rate);

        bool FindQuestion(List<MSentence> list, string input, EStyle style, string lanId, List<string> catIds);

        bool FindResponse(List<MSentence> list, string askId, EStyle style, string lanId, List<string> catIds);

        List<MCategory> ListTags(string sid);

        void RemoveTags(string sId, string cId);

        void RemoveTags(string cId);

        void SaveTags(string sId, List<MCategory> newCats);
        #endregion
    }
}
