// MIT License
//
// Copyright (c) 2021 SirRandoo
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;

namespace SirRandoo.CommonLib.Helpers
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class TextHelper
    {
        /// <summary>
        ///     Surrounds the given text with the specified rich text tag.
        /// </summary>
        /// <param name="s">The text to surround</param>
        /// <param name="tag">The rich text tag to surround the text with</param>
        /// <returns>The tagged string</returns>
        [NotNull]
        public static string Tagged(this string s, string tag) => $"<{tag}>{s}</{tag}>";

        /// <summary>
        ///     Surrounds the given text with the specified rich text color tag.
        /// </summary>
        /// <param name="s">The text to surround</param>
        /// <param name="hex">The specified color's hex code</param>
        /// <returns>The color tagged text</returns>
        [NotNull]
        public static string ColorTagged(this string s, string hex)
        {
            if (!hex.StartsWith("#"))
            {
                hex = $"#{hex}";
            }

            return $@"<color=""{hex}"">{s}</color>";
        }

        /// <summary>
        ///     Surrounds the given text with the specified rich text tag.
        /// </summary>
        /// <param name="s">The text to surround</param>
        /// <param name="color">The specified color</param>
        /// <returns>The color tagged text</returns>
        [NotNull]
        public static string ColorTagged(this string s, Color color) => ColorTagged(s, ColorUtility.ToHtmlStringRGB(color));
    }
}
