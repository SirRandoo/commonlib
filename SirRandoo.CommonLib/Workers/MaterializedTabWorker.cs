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

using System;
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
        private float _foregroundProgress;
        private float _highlightProgress;
        private string _lastTab;

        /// <summary>
        ///     The color of the accent line for the tab.
        /// </summary>
        public Color AccentColor { get; set; } = Color.cyan;

        private void ResetProgresses()
        {
            _highlightProgress = 0f;
            _foregroundProgress = 0f;
            _lastTab = SelectedTab;
        }

        /// <inheritdoc/>
        protected override void DrawContentForeground(Rect region)
        {
            // Unused
        }

        /// <inheritdoc/>
        protected override void DrawContentBackground(Rect region)
        {
            // Unused
        }

        /// <inheritdoc />
        protected override void DrawTabForeground(Rect region)
        {
            // Unused
        }

        /// <inheritdoc/>
        protected override void DrawTabHighlight(Rect region)
        {
            if (!string.Equals(SelectedTab, _lastTab, StringComparison.OrdinalIgnoreCase))
            {
                ResetProgresses();
            }

            Color cache = GUI.color;

            GUI.color = AccentColor;
            Vector2 center = region.center;
            float accentDistance = Mathf.FloorToInt((region.x - center.x) * 0.75f);
            _highlightProgress = Mathf.SmoothStep(_highlightProgress, accentDistance, 0.15f);
            Widgets.DrawLineHorizontal(center.x - _highlightProgress, region.y + region.height - 1f, _highlightProgress * 2f);

            GUI.color = cache;

            _foregroundProgress = Mathf.SmoothStep(_foregroundProgress, center.x - region.x, 0.15f);
            var animationRegion = new Rect(center.x, center.y, 0f, 0f);

            Widgets.DrawLightHighlight(animationRegion.ExpandedBy(_foregroundProgress));
        }
    }
}
