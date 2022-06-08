// MIT License
// 
// Copyright (c) 2022 SirRandoo
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

using UnityEngine;
using Verse;

namespace SirRandoo.CommonLib.Helpers
{
    public static partial class UiHelper
    {
        /// <summary>
        ///     Draws text at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        public static void Label(Rect region, string text)
        {
            Label(region, text, TextAnchor.MiddleLeft, GameFont.Small);
        }

        /// <summary>
        ///     Draws text at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        /// <param name="anchor">
        ///     Where the text should be anchored relative to
        ///     the region given
        /// </param>
        public static void Label(Rect region, string text, TextAnchor anchor)
        {
            Label(region, text, anchor, GameFont.Small);
        }

        /// <summary>
        ///     Draws text at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        /// <param name="anchor">
        ///     Where the text should be anchored relative to
        ///     the region given
        /// </param>
        /// <param name="fontScale">The size the text should be drawn in</param>
        public static void Label(Rect region, string text, TextAnchor anchor, GameFont fontScale)
        {
            Text.Anchor = anchor;
            Text.Font = fontScale;

            Widgets.Label(region, text);

            Text.Anchor = TextAnchor.UpperLeft;
            Text.Font = GameFont.Small;
        }

        /// <summary>
        ///     Draws text at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        /// <param name="color">The color to draw the text</param>
        /// <param name="anchor">
        ///     Where the text should be anchored relative to
        ///     the region given
        /// </param>
        /// <param name="fontScale">The size the text should be drawn in</param>
        public static void Label(Rect region, string text, Color color, TextAnchor anchor, GameFont fontScale)
        {
            GUI.color = color;
            Label(region, text, anchor, fontScale);
            GUI.color = Color.white;
        }

        /// <summary>
        ///     Draws text vertically at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        /// <param name="color">The color to draw the text</param>
        public static void VerticalLabel(Rect region, string text, Color color)
        {
            VerticalLabel(region, text, color, TextAnchor.MiddleLeft, GameFont.Small);
        }

        /// <summary>
        ///     Draws text vertically at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        /// <param name="color">The color to draw the text</param>
        /// <param name="anchor">
        ///     Where the text should be anchored relative to
        ///     the region given
        /// </param>
        public static void VerticalLabel(Rect region, string text, Color color, TextAnchor anchor)
        {
            VerticalLabel(region, text, color, anchor, GameFont.Small);
        }

        /// <summary>
        ///     Draws text vertically at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        /// <param name="color">The color to draw the text</param>
        /// <param name="anchor">
        ///     Where the text should be anchored relative to
        ///     the region given
        /// </param>
        /// <param name="fontScale">The size the text should be drawn in</param>
        public static void VerticalLabel(Rect region, string text, Color color, TextAnchor anchor, GameFont fontScale)
        {
            GUI.color = color;
            VerticalLabel(region, text, anchor, fontScale);
            GUI.color = Color.white;
        }

        /// <summary>
        ///     Draws text vertically at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        public static void VerticalLabel(Rect region, string text)
        {
            VerticalLabel(region, text, TextAnchor.MiddleLeft, GameFont.Small);
        }

        /// <summary>
        ///     Draws text vertically at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        /// <param name="anchor">
        ///     Where the text should be anchored relative to
        ///     the region given
        /// </param>
        public static void VerticalLabel(Rect region, string text, TextAnchor anchor)
        {
            VerticalLabel(region, text, anchor, GameFont.Small);
        }

        /// <summary>
        ///     Draws text vertically at the given region on screen.
        /// </summary>
        /// <param name="region">The region of the screen to draw the text in</param>
        /// <param name="text">The text to draw on screen</param>
        /// <param name="anchor">
        ///     Where the text should be anchored relative to
        ///     the region given
        /// </param>
        /// <param name="fontScale">The size the text should be drawn in</param>
        public static void VerticalLabel(Rect region, string text, TextAnchor anchor, GameFont fontScale)
        {
            Text.Anchor = anchor;
            Text.Font = fontScale;

            region.y += region.width;
            GUIUtility.RotateAroundPivot(-90f, region.position);

            Widgets.Label(region, text);

            GUI.matrix = Matrix4x4.identity;

            Text.Anchor = TextAnchor.UpperLeft;
            Text.Font = GameFont.Small;
        }
    }
}
