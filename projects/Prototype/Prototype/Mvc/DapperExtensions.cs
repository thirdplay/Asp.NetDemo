using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototype.Mvc
{
    /// <summary>
    /// Dapperの拡張機能を提供します。
    /// </summary>
    public static class DapperExtensions
    {
        /// <summary>
        /// プリペアドステートメントで動的な検索条件を作成します。
        /// </summary>
        /// <typeparam name="TSource">対象の値のシーケンス</typeparam>
        /// <param name="list">パラメータリスト</param>
        /// <param name="paramName">パラメータ名</param>
        /// <param name="condition">検索条件を返却するメソッド（引数:パラメータ名）</param>
        /// <param name="separator">区切り記号として使用する文字列</param>
        /// <param name="parameters">動的パラメータの格納先</param>
        /// <returns>検索条件の文字列</returns>
        public static string CreateDynamicCondition<TSource>(this IEnumerable<TSource> list, string paramName, Func<string, string> condition, string separator, ref DynamicParameters parameters)
        {
            var result = new List<string>();
            foreach (var value in list)
            {
                var name = $"{paramName}{result.Count}";
                result.Add(condition(name));
                parameters.Add(name, value);
            }
            return string.Join($" {separator} ", result);
        }
    }
}