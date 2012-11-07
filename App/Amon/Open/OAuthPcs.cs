 using System.Collections.Generic;
using System.Drawing;
using Me.Amon.Pcs.M;

namespace Me.Amon.Open
{
    public interface OAuthPcs
    {
        string Name { get; set; }

        string Path { get; set; }

        Image Icon { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        /// <param name="path"></param>
        List<CsMeta> ListMeta(CsMeta meta);

        List<CsMeta> ListMeta(string key);

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

        bool Moveto(CsMeta meta, string dstPath);

        bool Copyto(CsMeta meta, string dstPath);

        void CopyRef(CsMeta meta);

        void Upload(string nativeFile, string remotePath);

        void Download(string remoteMeta, string nativePath);

        void Thumbnail();

        string Parent(string path);

        string Combine(string path, string meta);

        string Display(string path);
    }
}
