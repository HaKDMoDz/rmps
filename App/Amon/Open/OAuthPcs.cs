using System.Collections.Generic;
using System.Drawing;
using Me.Amon.Pcs.M;

namespace Me.Amon.Open
{
    public interface OAuthPcs
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 相对目录
        /// </summary>
        string Root { get; set; }
        /// <summary>
        /// 显示图标
        /// </summary>
        Image Icon { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        /// <param name="path"></param>
        List<CsMeta> ListMeta(CsMeta meta);

        string GetPath(string key);

        /// <summary>
        /// 获取文件外链
        /// </summary>
        string ShareMeta(CsMeta meta);

        /// <summary>
        /// 文件历史版本
        /// </summary>
        List<CsMeta> History(CsMeta meta);

        bool CreateFolder(CsMeta meta);

        bool Delete(string meta);

        bool Moveto(CsMeta meta, string dstMeta);

        bool Copyto(CsMeta meta, string dstMeta);

        void CopyRef(CsMeta meta);

        void Upload(string nativeFile, string remotePath);

        void Download(string remoteMeta, string nativePath);

        void Thumbnail();

        string Parent(string path);

        string Combine(string path, string meta);

        string Display(string path);
    }
}
