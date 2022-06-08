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
using SirRandoo.CommonLib.Enums;
using SirRandoo.CommonLib.Helpers;
using UnityEngine;
using Verse;

namespace SirRandoo.CommonLib.Workers
{
    /// <summary>
    ///     A class for displaying tabular content in a portable way.
    /// </summary>
    public class TabWorker
    {
        private protected readonly List<Tab> Tabs = new List<Tab>();
        private int _currentPage = 1;
        private float _maxHeight;
        private float _maxWidth;
        private Vector2 _scrollPos = Vector2.zero;

        /// <summary>
        ///     The id of the currently visible tab.
        /// </summary>
        public string SelectedTab { get; set; }

        /// <summary>
        ///     The current <see cref="TabLayout"/>.
        /// </summary>
        public TabLayout Layout { get; set; } = TabLayout.Horizontal;

        /// <summary>
        ///     Adds a tab to the display.
        /// </summary>
        /// <param name="id">The unique id of the tab</param>
        /// <param name="label">The human readable label of the tab</param>
        /// <param name="contentDrawer">
        ///     A callable invoked when the tab is
        ///     currently selected
        /// </param>
        public void AddTab(string id, string label, Action<Rect> contentDrawer)
        {
            AddTab(id, label, contentDrawer, null);
        }

        /// <summary>
        ///     Adds a tab to the display.
        /// </summary>
        /// <param name="id">The unique id of the tab</param>
        /// <param name="label">The human readable label of the tab</param>
        /// <param name="contentDrawer">
        ///     A callable invoked when the tab is
        ///     currently selected
        /// </param>
        /// <param name="clickHandler">
        ///     A callable invoked when the tab is clicked
        ///     by the user. If the callable returns <c>false</c>, the tab won't
        ///     be displayed.
        /// </param>
        public void AddTab(string id, string label, Action<Rect> contentDrawer, Func<bool> clickHandler)
        {
            AddTab(id, label, null, contentDrawer, clickHandler);
        }

        /// <summary>
        ///     Adds a tab to the display.
        /// </summary>
        /// <param name="id">The unique id of the tab</param>
        /// <param name="label">The human readable label of the tab</param>
        /// <param name="tooltip">The human readable tooltip of the tab</param>
        /// <param name="contentDrawer">
        ///     A callable invoked when the tab is
        ///     currently selected
        /// </param>
        public void AddTab(string id, string label, string tooltip, Action<Rect> contentDrawer)
        {
            AddTab(id, label, tooltip, contentDrawer, null);
        }

        /// <summary>
        ///     Adds a tab to the display.
        /// </summary>
        /// <param name="id">The unique id of the tab</param>
        /// <param name="label">The human readable label of the tab</param>
        /// <param name="tooltip">The human readable tooltip of the tab</param>
        /// <param name="contentDrawer">
        ///     A callable invoked when the tab is
        ///     currently selected
        /// </param>
        /// <param name="clickHandler">
        ///     A callable invoked when the tab is clicked
        ///     by the user. If the callable returns <c>false</c>, the tab won't
        ///     be displayed.
        /// </param>
        public void AddTab(string id, string label, string tooltip, Action<Rect> contentDrawer, Func<bool> clickHandler)
        {
            Tabs.Add(new Tab { Id = id, Label = label, Tooltip = tooltip, ContentDrawer = contentDrawer, ClickHandler = clickHandler });
        }

        /// <summary>
        ///     Adds a tab to the display.
        /// </summary>
        /// <param name="id">The unique id of the tab</param>
        /// <param name="label">The human readable label of the tab</param>
        /// <param name="tooltip">The human readable tooltip of the tab</param>
        /// <param name="contentDrawer">
        ///     A callable invoked when the tab is
        ///     currently selected
        /// </param>
        /// <param name="clickHandler">
        ///     A callable invoked when the tab is clicked
        ///     by the user. If the callable returns <c>false</c>, the tab won't
        ///     be displayed.
        /// </param>
        /// <param name="icon">
        ///     A <see cref="Texture2D"/> that provides a quick indicator to
        ///     users about the tab's contents.
        /// </param>
        public void AddTab(string id, string label, string tooltip, Action<Rect> contentDrawer, Func<bool> clickHandler, Texture2D icon)
        {
            Tabs.Add(
                new Tab
                {
                    Id = id,
                    Label = label,
                    Tooltip = tooltip,
                    ContentDrawer = contentDrawer,
                    ClickHandler = clickHandler,
                    Icon = icon,
                    Layout = IconLayout.IconAndText
                }
            );
        }

        /// <summary>
        ///     Adds a tab to the display.
        /// </summary>
        /// <param name="id">The unique id of the tab</param>
        /// <param name="label">The human readable label of the tab</param>
        /// <param name="tooltip">The human readable tooltip of the tab</param>
        /// <param name="contentDrawer">
        ///     A callable invoked when the tab is
        ///     currently selected
        /// </param>
        /// <param name="clickHandler">
        ///     A callable invoked when the tab is clicked
        ///     by the user. If the callable returns <c>false</c>, the tab won't
        ///     be displayed.
        /// </param>
        /// <param name="icon">
        ///     A <see cref="Texture2D"/> that provides a quick indicator to
        ///     users about the tab's contents.
        /// </param>
        /// <param name="layout">The <see cref="IconLayout"/> to use for the tab.</param>
        public void AddTab(string id, string label, string tooltip, Action<Rect> contentDrawer, Func<bool> clickHandler, Texture2D icon, IconLayout layout)
        {
            Tabs.Add(
                new Tab
                {
                    Id = id,
                    Label = label,
                    Tooltip = tooltip,
                    ContentDrawer = contentDrawer,
                    ClickHandler = clickHandler,
                    Icon = icon,
                    Layout = layout
                }
            );
        }

        /// <summary>
        ///     Removes a tab from the display.
        /// </summary>
        /// <param name="id">The unique id of the tab</param>
        public void RemoveTab(string id)
        {
            for (int index = Tabs.Count - 1; index >= 0; index--)
            {
                if (!string.Equals(Tabs[index].Id, id))
                {
                    continue;
                }

                Tabs.RemoveAt(index);

                return;
            }
        }

        /// <summary>
        ///     Draws the tabbed content at the given region of the screen.
        /// </summary>
        /// <param name="region">The region to draw the tabbed content in</param>
        public void Draw(Rect region)
        {
            if (_maxWidth <= 0)
            {
                RecacheWidth();
            }

            Rect barRect;
            Rect contentRect;

            switch (Layout)
            {
                case TabLayout.Vertical:
                    barRect = DrawVertical(region);
                    contentRect = new Rect(region.x + barRect.width, region.y, region.width - barRect.width, region.height);

                    break;
                default:
                    barRect = DrawHorizontal(region);
                    contentRect = new Rect(region.x, region.y + barRect.height, region.width, region.height - barRect.height);

                    break;
            }

            DrawTabBackground(contentRect);

            contentRect = contentRect.ContractedBy(4f);
            GUI.BeginGroup(contentRect);

            Tab tab = Tabs.Find(t => string.Equals(t.Id, SelectedTab));

            tab.ContentDrawer?.Invoke(contentRect.AtZero());

            GUI.EndGroup();
        }

        private Rect DrawVertical(Rect region)
        {
            var listRect = new Rect(region.x, region.y, _maxWidth + 16f, _maxHeight);

            Widgets.DrawMenuSection(listRect);

            GUI.BeginGroup(listRect);

            var listView = new Rect(0f, 0f, _maxWidth, _maxHeight * Tabs.Count);

            _scrollPos = GUI.BeginScrollView(listRect, _scrollPos, listView);

            for (var index = 0; index < Tabs.Count; index++)
            {
                Tab tab = Tabs[index];
                var tabRect = new Rect(0f, 0f, _maxWidth, _maxHeight);

                if (tab.Icon != null)
                {
                    DrawTabContent(tabRect, tab);
                }
                else
                {
                    UiHelper.Label(tabRect, tab.Label, TextAnchor.MiddleCenter);
                }

                if (string.Equals(tab.Id, SelectedTab))
                {
                    DrawTabForeground(tabRect);
                }

                DrawTabHighlight(tabRect);

                if (Widgets.ButtonInvisible(tabRect))
                {
                    SelectedTab = tab.Id;
                }
            }

            GUI.EndScrollView();
            GUI.EndGroup();

            return listRect;
        }

        private Rect DrawHorizontal(Rect region)
        {
            float height = Mathf.CeilToInt(Text.LineHeight * 1.5f);
            var barRect = new Rect(region.x, region.y, region.width, height);

            GUI.BeginGroup(barRect);
            DrawTabsHorizontally(barRect);
            GUI.EndGroup();

            return barRect;
        }

        private void DrawTabsHorizontally(Rect region)
        {
            int tabsPerView = Mathf.FloorToInt(Mathf.CeilToInt(region.width - region.height * 2f) / _maxWidth);
            int totalPages = Mathf.CeilToInt(Tabs.Count / (float)tabsPerView);

            var offset = 0f;
            float usableWidth = region.width;

            if (totalPages > 1)
            {
                var leftRect = new Rect(0f, 0f, region.height, region.height);
                var rightRect = new Rect(region.width - region.height, 0f, region.height, region.height);

                DrawHorizontalNavigation(totalPages, leftRect, rightRect);

                offset = leftRect.width;
                usableWidth = region.width - leftRect.width - rightRect.width;
            }

            var tabsRect = new Rect(offset, region.y, usableWidth, region.height);

            GUI.BeginGroup(tabsRect);

            int index = _currentPage - 1 * tabsPerView;
            float width = Mathf.FloorToInt(usableWidth / tabsPerView);

            for (int i = index; i < index + tabsPerView - 1; i++)
            {
                Tab tab = Tabs[index];

                var tabRect = new Rect(index - tabsPerView, 0f, width, region.height);

                DrawTabBackground(tabRect);
                
                if (tab.Icon == null)
                {
                    UiHelper.Label(tabRect, tab.Label, TextAnchor.MiddleCenter);
                }
                else
                {
                    DrawTabContent(tabRect, tab);
                }

                if (Widgets.ButtonInvisible(tabRect))
                {
                    SelectedTab = tab.Id;
                }

                if (string.Equals(SelectedTab, tab.Id))
                {
                    DrawTabForeground(tabRect);
                }
            }

            GUI.EndGroup();
        }

        private void DrawHorizontalNavigation(int pages, Rect leftRegion, Rect rightRegion)
        {
            DrawTabBackground(leftRegion);
            DrawTabBackground(rightRegion);

            UiHelper.Label(leftRegion, "<", TextAnchor.MiddleCenter);
            UiHelper.Label(rightRegion, ">", TextAnchor.MiddleCenter);

            if (Widgets.ButtonInvisible(leftRegion))
            {
                DrawTabForeground(leftRegion);
                _currentPage = Mathf.Clamp(_currentPage, 1, pages);
            }

            if (Widgets.ButtonInvisible(rightRegion))
            {
                DrawTabForeground(rightRegion);
                _currentPage = Mathf.Clamp(_currentPage, 1, pages);
            }
        }

        /// <summary>
        ///     Draws the background of the tab.
        /// </summary>
        /// <param name="region">The region to draw the tab's background in</param>
        protected virtual void DrawTabBackground(Rect region)
        {
            switch (Layout)
            {
                case TabLayout.Vertical:
                    Widgets.DrawMenuSection(region);

                    return;
                case TabLayout.Horizontal:
                    Widgets.DrawLightHighlight(region);
                    Widgets.DrawLightHighlight(region);

                    return;
            }
        }

        /// <summary>
        ///     Draws the foreground of the tab.
        /// </summary>
        /// <param name="region">The region to draw the tab's foreground in</param>
        protected virtual void DrawTabForeground(Rect region)
        {
            switch (Layout)
            {
                case TabLayout.Vertical:
                    Widgets.DrawHighlightSelected(region);

                    return;
                case TabLayout.Horizontal:
                    Widgets.DrawLightHighlight(region);

                    return;
            }
        }

        /// <summary>
        ///     Draws a mouse over highlight over the tab's region.
        /// </summary>
        /// <param name="region">The region to draw the highlight in</param>
        protected virtual void DrawTabHighlight(Rect region)
        {
            if (!Mouse.IsOver(region))
            {
                return;
            }

            Widgets.DrawLightHighlight(region);
        }

        private void RecacheWidth()
        {
            GameFont cache = Text.Font;
            Text.Font = GameFont.Small;

            foreach (Tab tab in Tabs)
            {
                float width = Text.CalcSize(tab.Label).x;
                float adjustedWidth = width + 10f;

                if (tab.Icon != null)
                {
                    adjustedWidth += 20f;
                }

                if (adjustedWidth > _maxWidth)
                {
                    _maxWidth = adjustedWidth;
                }

                float height = Text.CalcHeight(tab.Label, width);
                float adjustedHeight = height + 10f;

                if (adjustedHeight > _maxHeight)
                {
                    _maxHeight = adjustedHeight;
                }
            }

            Text.Font = cache;
        }

        private static void DrawTabContent(Rect region, Tab tab)
        {
            switch (tab.Layout)
            {
                case IconLayout.IconAndText:
                    DrawTabIconAndText(region, tab);

                    return;
                case IconLayout.Text:
                    UiHelper.Label(region, tab.Label, TextAnchor.MiddleCenter);

                    return;
                case IconLayout.Icon:
                    Vector2 center = region.center;
                    Rect iconRect = LayoutHelper.IconRect(center.x - 8f, center.y - 8f, 16f, 16f);
                    UiHelper.Icon(iconRect, tab.Icon, Color.white);

                    return;
                default:
                    UiHelper.Label(region, tab.Label, TextAnchor.MiddleCenter);

                    return;
            }
        }

        private static void DrawTabIconAndText(Rect region, Tab tab)
        {
            Rect iconRect = LayoutHelper.IconRect(region.x + 2f, region.y + 2f, 16f, 16f);
            var textRect = new Rect(iconRect.x + 2f, region.y, region.width - iconRect.width - 2f, region.height);

            UiHelper.Icon(iconRect, tab.Icon, Color.white);
            UiHelper.Label(textRect, tab.Label, TextAnchor.MiddleCenter);
        }

        /// <summary>
        ///     An internal class for storing display data for a tab.
        /// </summary>
        protected struct Tab
        {
            /// <summary>
            ///     The id of the tab.
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            ///     The human readable name of the tab.
            /// </summary>
            public string Label { get; set; }

            /// <summary>
            ///     The human readable tooltip of the tab.
            /// </summary>
            public string Tooltip { get; set; }

            /// <summary>
            ///     The icon of the tab.
            /// </summary>
            public Texture2D Icon { get; set; }

            /// <summary>
            ///     The layout of the <see cref="Icon"/> and <see cref="Label"/>.
            /// </summary>
            public IconLayout Layout { get; set; }

            /// <summary>
            ///     A callable invoked when the user clicks the tab. If the callable
            ///     returns <c>false</c>, the currently selected tab won't change.
            /// </summary>
            public Func<bool> ClickHandler { get; set; }

            /// <summary>
            ///     A callable invoked when a tab is selected. The callable is
            ///     responsible for drawing the content of the tab.
            /// </summary>
            public Action<Rect> ContentDrawer { get; set; }
        }
    }
}
