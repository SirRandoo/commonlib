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
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Verse;

namespace SirRandoo.CommonLib.Workers
{
    /// <summary>
    ///     A worker for drawing virtualized lists.
    /// </summary>
    /// <typeparam name="T">The type of the item being drawn</typeparam>
    public class ListWorker<T>
    {
        private Vector2 _scrollPos = Vector2.zero;
        private readonly Action<T> _itemDrawer;
        
        public ListWorker(Action<T> itemDrawer)
        {
            _itemDrawer = itemDrawer;
        }

        /// <summary>
        ///     Draws the given items as a list on screen.
        /// </summary>
        /// <param name="region">The region of the list</param>
        /// <param name="items">The items to draw</param>
        /// <param name="itemCount">The total number of items being drawn</param>
        /// <param name="lineHeight">The height of each line within the list</param>
        public void Draw(Rect region, [NotNull] IEnumerable<T> items, int itemCount, float lineHeight)
        {
            var view = new Rect(0f, 0f, region.width - 16f, lineHeight * itemCount);
            var index = 0;
            var alternate = false;

            GUI.BeginGroup(region);
            _scrollPos = GUI.BeginScrollView(region.AtZero(), _scrollPos, view);
            
            foreach (T item in items)
            {
                var lineRegion = new Rect(0f, index * lineHeight, view.width, lineHeight);
                
                if (alternate)
                {
                    Widgets.DrawHighlight(lineRegion);
                }
                
                _itemDrawer(item);

                alternate = !alternate;
                index++;
            }
            
            GUI.EndGroup();
            GUI.EndScrollView();
        }
    }
}
