using Me.Amon.Open.M;

namespace Me.Amon.Pcs.M
{
    public class KuaipanMetaRef : AMetaRef
    {
        /// <summary>
        /// string	复制引用，可以作为copy接口的参数。
        /// </summary>
        public string copy_ref;

        /// <summary>
        /// YYYY-MM-DD hh:mm:ss引用过期时间。
        /// </summary>
        public string expires;

        public override string GetMetaRef()
        {
            return copy_ref;
        }
    }
}
