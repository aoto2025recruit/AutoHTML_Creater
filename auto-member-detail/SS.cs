using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_member_detail
{
    /// <summary>
    /// シンタクスシュガー用ユーティリティクラス
    /// https://gist.github.com/fumokmm/1876268
    /// </summary>
    public static class SS
    {
        /// <summary>
        /// 指定のディクショナリが空かどうか判定する。
        /// nullの場合も空とみなす。
        /// </summary>
        /// <typeparam name="K">ディクショナリのキー</typeparam>
        /// <typeparam name="V">ディクショナリの値</typeparam>
        /// <param name="list">ディクショナリ</param>
        /// <returns>ディクショナリが空かどうか</returns>
        public static bool IsEmpty<K, V>(this Dictionary<K, V> dic)
        {
            return dic == null || dic.Count == 0;
        }

        /// <summary>
        /// 指定のディクショナリが空でないかどうか判定する。
        /// nullの場合も空とみなす。
        /// </summary>
        /// <typeparam name="K">ディクショナリのキー</typeparam>
        /// <typeparam name="V">ディクショナリの値</typeparam>
        /// <param name="list">ディクショナリ</param>
        /// <returns>ディクショナリが空でないかどうか</returns>
        public static bool IsNotEmpty<K, V>(this Dictionary<K, V> dic)
        {
            return !IsEmpty(dic);
        }

        /// <summary>
        /// 指定のリストが空かどうか判定する。
        /// nullの場合も空とみなす。
        /// </summary>
        /// <typeparam name="T">リストの型</typeparam>
        /// <param name="list">リスト</param>
        /// <returns>リストが空かどうか</returns>
        public static bool IsEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }

        /// <summary>
        /// 指定のリストが空でないかどうか判定する。
        /// nullの場合も空とみなす。
        /// </summary>
        /// <typeparam name="T">リストの型</typeparam>
        /// <param name="list">リスト</param>
        /// <returns>リストが空でないかどうか</returns>
        public static bool IsNotEmpty<T>(this List<T> list)
        {
            return !IsEmpty(list);
        }
    }
}
