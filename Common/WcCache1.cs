using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Maticsoft.Common
{
    public class WcCache1
    {
        public WcCache1()
        {

        }

        /// <summary>
        /// 缓存类型
        /// </summary>
        public enum CacheType
        {
            /// <summary>
            /// 用户级
            /// </summary>
            User,

            /// <summary>
            /// 全局缓存
            /// </summary>
            Global
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public static void AddCache(Page page, string key, object obj, CacheType cache_type = CacheType.Global)
        {
            if (cache_type == CacheType.Global)
            {
                //如果有此缓存，则覆盖
                page.Cache.Insert(key, obj);
            }
            else
            {
                page.Session[key] = obj;
            }
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cache_type"></param>
        public static void RemoveCache(Page page, string key, CacheType cache_type = CacheType.Global)
        {
            if (cache_type == CacheType.Global)
            {
                page.Cache.Remove(key);
            }
            else
            {
                page.Session[key] = null;
            }
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cache_type"></param>
        public static object GetCache(Page page, string key, CacheType cache_type = CacheType.Global)
        {
            if (cache_type == CacheType.Global)
            {
                return page.Cache[key];
            }
            else
            {
                return page.Session[key];
            }
        }

        public override string ToString()
        {
            return "Wc.Cache";
        }
    }
}
