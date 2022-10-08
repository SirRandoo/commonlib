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

namespace SirRandoo.CommonLib.Workers
{
    /// <summary>
    ///     A variant of <see cref="TabWorker"/> that uses RimWorld style
    ///     buttons instead of flat colored buttons.
    /// </summary>
    public class RimWorldTabWorker : TabWorker
    {
        /// <inheritdoc/>
        protected override void DrawTabBackground(Rect region)
        {
            Widgets.DrawAtlas(region, Widgets.ButtonBGAtlas);
        }

        /// <inheritdoc />
        protected override void DrawContentForeground(Rect region)
        {
            // Unused
        }

        /// <inheritdoc />
        protected override void DrawContentBackground(Rect region)
        {
            // Unused
        }

        /// <inheritdoc/>
        protected override void DrawTabHighlight(Rect region)
        {
            Widgets.DrawAtlas(region, Widgets.ButtonBGAtlasClick);
        }
    }
}
