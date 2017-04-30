﻿using Prototype.Constants;
using System;

namespace Prototype.Mvc.Annotations
{
    /// <summary>
    /// DIコンテナによって依存性を注入するコンポーネントに使用される属性を表します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class ComponentAttribute : Attribute
    {
        /// <summary>
        /// インターフェイスに対して注入する型を取得または設定します。
        /// </summary>
        public Type TargetType { get; private set; }

        /// <summary>
        /// 注入するインスタンスのライフタイムを取得または設定します。
        /// </summary>
        public Lifetime Lifetime { get; private set; }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="targetType">インターフェイスに対して注入する型</param>
        /// <param name="lifetime">注入するインスタンスのライフタイム</param>
        public ComponentAttribute(Type targetType, Lifetime lifetime = Lifetime.Singleton)
        {
            this.TargetType = targetType;
            this.Lifetime = lifetime;
        }
    }
}