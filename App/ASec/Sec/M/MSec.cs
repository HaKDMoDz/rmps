using System.Xml;

namespace Me.Amon.Sec.M
{
    public class MSec
    {
        public string Operation { get; set; }

        public string Algorithm { get; set; }

        public string Mode { get; set; }

        public string Padding { get; set; }

        public int KeySize { get; set; }
        public int IVSize { get; set; }
        public int BlockSize { get; set; }

        public byte[] Salt { get; set; }

        public bool FromXml(XmlReader reader)
        {
            Algorithm = reader.ReadElementContentAsString();

            BlockSize = reader.ReadElementContentAsInt();

            string salt = reader.ReadElementContentAsString();
            //_Salt = null;

            string mask = reader.ReadElementContentAsString();
            //_Mask = null;
            return true;
        }

        public bool ToXml(XmlWriter writer)
        {
            // 算法
            writer.WriteElementString("Alg", Algorithm);
            // 块大小
            writer.WriteElementString("BlockSize", BlockSize.ToString());
            // 随机向量
            writer.WriteElementString("Salt", "");
            // 掩码文本
            writer.WriteElementString("Mask", "");
            // 文件摘要
            //writer.WriteElementString("Hash", FileHash(""));

            return true;
        }
    }
}
