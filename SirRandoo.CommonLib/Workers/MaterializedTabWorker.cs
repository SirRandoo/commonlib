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
    ///     A variant of <see cref="TabWorker"/> that loosely follows the
    ///     Material Design documentation.
    /// </summary>
    public class MaterializedTabWorker : TabWorker
    {
        private Vector2? _lastPosition;
        private float _progress;

        /// <summary>
        ///     The color of the accent line for the tab.
        /// </summary>
        public Color AccentColor { get; set; } = Color.cyan;

        /// <inheritdoc/>
        protected override void DrawTabForeground(Rect region)
        {
            Color cache = GUI.color;

            GUI.color = AccentColor;
            Widgets.DrawLineHorizontal(region.x + 2f, region.y + region.height - 1f, region.width - 4f);
            GUI.color = cache;
        }

        /// <inheritdoc/>
        protected override void DrawTabHighlight(Rect region)
        {
            if (region.position != _lastPosition)
            {
                _lastPosition = region.position;
                _progress = 0f;
            }

            Color cache = GUI.color;

            GUI.color = AccentColor;
            Vector2 center = region.center;
            float finalDistance = Mathf.FloorToInt(center.x * 0.75f);
            _progress = Mathf.SmoothStep(_progress, finalDistance, 0.2f);
            Widgets.DrawLineHorizontal(center.x - _progress, region.y + region.height - 1f, _progress * 2f);

            GUI.color = cache;
        }
    }
}
