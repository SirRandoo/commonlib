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
using SirRandoo.CommonLib.Enums;
using Steamworks;
using UnityEngine;
using Verse;

namespace SirRandoo.CommonLib.Helpers
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class UiHelper
    {
        private const float EntryButtonWidth = 50f;
        private static readonly Color ActiveTabColor = new Color(0.46f, 0.49f, 0.5f);
        private static readonly Color InactiveTabColor = new Color(0.21f, 0.23f, 0.24f);
        private static readonly Color TableHeaderColor = new Color(0.62f, 0.65f, 0.66f);
        private static readonly Color ExperimentalNoticeColor = new Color(1f, 0.53f, 0.76f);
        private static readonly Color DescriptionTextColor = new Color(0.72f, 0.72f, 0.72f);

        /// <summary>
        ///     An internal method for creating a <see cref="Rect"/> suitable for
        ///     drawing "field icons" in.
        /// </summary>
        /// <param name="parentRegion">The region of the field the icon is being drawn over</param>
        /// <param name="offset">An optional number indicating how many slots to offset the icon</param>
        /// <returns>The <see cref="Rect"/> to draw the field icon in</returns>
        private static Rect GetFieldIconRect(Rect parentRegion, int offset = 0) => LayoutHelper.IconRect(
            parentRegion.x + parentRegion.width - parentRegion.height * (offset + 1),
            parentRegion.y,
            parentRegion.height,
            parentRegion.height,
            Mathf.CeilToInt(parentRegion.height * 0.1f)
        );

        /// <summary>
        ///     Draws an icon over an input field.
        /// </summary>
        /// <param name="parentRegion">The region of the field the icon is being drawn over</param>
        /// <param name="icon">A character to be used as the icon</param>
        /// <param name="tooltip">An optional tooltip for the icon</param>
        /// <param name="offset">An optional number indicated how many slots to offset the icon</param>
        public static void FieldIcon(Rect parentRegion, char icon, [CanBeNull] string tooltip = null, int offset = 0)
        {
            Rect region = GetFieldIconRect(parentRegion, offset);
            Label(region, icon.ToString(), TextAnchor.MiddleCenter);
            TooltipHandler.TipRegion(region, tooltip);
        }

        /// <summary>
        ///     Draws an icon over an input field.
        /// </summary>
        /// <param name="parentRegion">The region of the field the icon is being drawn over</param>
        /// <param name="icon">A string to be used as the icon</param>
        /// <param name="tooltip">An optional tooltip for the icon</param>
        /// <param name="offset">An optional number indicated how many slots to offset the icon</param>
        public static void FieldIcon(Rect parentRegion, string icon, [CanBeNull] string tooltip = null, int offset = 0)
        {
            Rect region = GetFieldIconRect(parentRegion, offset);
            Label(region, icon, TextAnchor.MiddleCenter);
            TooltipHandler.TipRegion(region, tooltip);
        }

        /// <summary>
        ///     Draws an icon over an input field.
        /// </summary>
        /// <param name="parentRegion">The region of the field the button is being drawn over</param>
        /// <param name="icon">A texture to be drawn as the icon</param>
        /// <param name="tooltip">An optional tooltip for the icon</param>
        /// <param name="offset">An optional number indicated how many slots to offset the icon</param>
        public static void FieldIcon(Rect parentRegion, Texture2D icon, [CanBeNull] string tooltip = null, int offset = 0)
        {
            Rect region = GetFieldIconRect(parentRegion, offset);
            GUI.DrawTexture(region, icon);
            TooltipHandler.TipRegion(region, tooltip);
        }

        /// <summary>
        ///     An internal method for handling the "click" on input field buttons.
        /// </summary>
        /// <param name="region">The region to handle</param>
        /// <param name="removeControl">Whether or not clicking the button will remove keyboard control from the input field</param>
        /// <returns>Whether or not the button was clicked</returns>
        private static bool HandleInputFieldButton(Rect region, bool removeControl = true)
        {
            bool clicked = Mouse.IsOver(region) && Event.current.type == EventType.Used && Input.GetMouseButtonDown(0);

            if (clicked && removeControl)
            {
                GUIUtility.keyboardControl = 0;

                return clicked;
            }

            return clicked;
        }

        /// <summary>
        ///     Draws a button over an input field.
        /// </summary>
        /// <param name="parentRegion">The region of the field the button is being drawn over</param>
        /// <param name="icon">A string to be used as the icon for the button</param>
        /// <param name="tooltip">An optional tooltip for the button</param>
        /// <param name="offset">An optional number indicated how many slots to offset the button</param>
        /// <param name="removeControl">Whether or not clicking the button will remove keyboard control from the input field</param>
        /// <returns>Whether or not the button was clicked</returns>
        public static bool FieldButton(Rect parentRegion, string icon, [CanBeNull] string tooltip = null, int offset = 0, bool removeControl = true)
        {
            Rect region = GetFieldIconRect(parentRegion, offset);
            Label(region, icon, TextAnchor.MiddleCenter, GameFont.Tiny);
            TooltipHandler.TipRegion(region, tooltip);

            return HandleInputFieldButton(region, removeControl);
        }

        /// <summary>
        ///     Draws a button over an input field.
        /// </summary>
        /// <param name="parentRegion">The region of the field the button is being drawn over</param>
        /// <param name="icon">A texture to be used as the icon for the button</param>
        /// <param name="tooltip">An optional tooltip for the button</param>
        /// <param name="offset">An optional number indicated how many slots to offset the button</param>
        /// <param name="removeControl">Whether or not clicking the button will remove keyboard control from the input field</param>
        /// <returns>Whether or not the button was clicked</returns>
        public static bool FieldButton(Rect parentRegion, Texture2D icon, [CanBeNull] string tooltip = null, int offset = 0, bool removeControl = true)
        {
            Rect region = LayoutHelper.IconRect(parentRegion.x + parentRegion.width - parentRegion.height * (offset + 1), parentRegion.y, parentRegion.height, parentRegion.height, Mathf.FloorToInt(parentRegion.height * 0.25f));

            GUI.DrawTexture(region, icon);
            TooltipHandler.TipRegion(region, tooltip);

            return HandleInputFieldButton(region, removeControl);
        }

        /// <summary>
        ///     Draws a clear button over an input field.
        /// </summary>
        /// <param name="parentRegion">The region of the field the button is being drawn over</param>
        /// <param name="tooltip">An optional tooltip for the button</param>
        /// <param name="offset">An optional number indicated how many slots to offset the button</param>
        /// <param name="removeControl">Whether or not clicking the button will remove keyboard control from the input field</param>
        /// <returns>Whether or not the button was clicked</returns>
        public static bool ClearButton(Rect parentRegion, [CanBeNull] string tooltip = null, int offset = 0, bool removeControl = false) =>
            FieldButton(parentRegion, "×", tooltip, offset, removeControl);

        /// <summary>
        ///     Draws a sort indicator
        /// </summary>
        /// <param name="parentRegion"></param>
        /// <param name="order"></param>
        public static void SortIndicator(Rect parentRegion, SortOrder order)
        {
            Rect region = LayoutHelper.IconRect(
                parentRegion.x + parentRegion.width - parentRegion.height + 3f,
                parentRegion.y + 8f,
                parentRegion.height - 9f,
                parentRegion.height - 16f
            );

            switch (order)
            {
                case SortOrder.Ascending:
                    GUI.DrawTexture(region, TexButton.ReorderUp);

                    return;
                case SortOrder.Descending:
                    GUI.DrawTexture(region, TexButton.ReorderDown);

                    return;
            }
        }

        /// <summary>
        ///     Draws a stateful number field.
        /// </summary>
        /// <param name="region">The region to draw the number field in</param>
        /// <param name="buffer">A <see cref="string"/> that houses the user's raw input</param>
        /// <param name="value">The numerical value of the user's input if it's valid</param>
        /// <param name="bufferValid">Whether or not the <see cref="buffer"/> is a valid number</param>
        /// <param name="minimum">The minimum number <see cref="value"/> can be</param>
        /// <param name="maximum">The maximum value <see cref="value"/> can be</param>
        /// <returns>Whether a new, valid number was entered</returns>
        public static bool NumberField(Rect region, ref string buffer, ref int value, ref bool bufferValid, int minimum = 0, int maximum = int.MaxValue)
        {
            var @return = false;
            GUI.backgroundColor = bufferValid ? Color.white : Color.red;

            if (TextField(region, buffer, out string newBuffer))
            {
                buffer = newBuffer;

                if (int.TryParse(buffer, out int result))
                {
                    value = Mathf.Clamp(result, minimum, maximum);
                    bufferValid = true;
                    @return = true;
                }
                else
                {
                    bufferValid = false;
                }
            }

            GUI.backgroundColor = Color.white;

            return @return;
        }

        /// <summary>
        ///     Draws a stateful number field.
        /// </summary>
        /// <param name="region">The region to draw the number field in</param>
        /// <param name="buffer">A <see cref="string"/> that houses the user's raw input</param>
        /// <param name="value">The numerical value of the user's input if it's valid</param>
        /// <param name="bufferValid">Whether or not the <see cref="buffer"/> is a valid number</param>
        /// <param name="minimum">The minimum number <see cref="value"/> can be</param>
        /// <param name="maximum">The maximum value <see cref="value"/> can be</param>
        /// <returns>Whether a new, valid number was entered</returns>
        public static bool NumberField(Rect region, ref string buffer, ref float value, ref bool bufferValid, float minimum = 0f, float maximum = float.MaxValue)
        {
            var @return = false;
            GUI.backgroundColor = bufferValid ? Color.white : Color.red;

            if (TextField(region, buffer, out string newBuffer))
            {
                buffer = newBuffer;

                if (float.TryParse(buffer, out float result))
                {
                    value = Mathf.Clamp(result, minimum, maximum);
                    bufferValid = true;
                    @return = true;
                }
                else
                {
                    bufferValid = false;
                }
            }

            GUI.backgroundColor = Color.white;

            return @return;
        }

        /// <summary>
        ///     Draws a stateful number field with buttons for incrementing and
        ///     decrementing the value within said field.
        ///     <seealso cref="KeyCode"/>
        /// </summary>
        /// <param name="region">The region to draw the entry widget</param>
        /// <param name="value">The value of the number field</param>
        /// <param name="buffer">A <see cref="string"/> representing the raw input from the user</param>
        /// <param name="bufferValid">Whether or not <see cref="buffer"/> is a valid number</param>
        /// <param name="minimum">The minimum number <see cref="value"/> can be</param>
        /// <param name="maximum">The maximum number <see cref="value"/> can be</param>
        /// <param name="increment">
        ///     The amount <see cref="value"/> should change when the user clicks the button without a modifier
        ///     key
        /// </param>
        /// <param name="shiftIncrement">
        ///     The amount <see cref="value"/> should change when the user clicks the button with SHIFT
        ///     pressed
        /// </param>
        /// <param name="controlIncrement">
        ///     The amount <see cref="value"/> should change when the user clicks the button with
        ///     CONTROL pressed
        /// </param>
        /// <param name="comboIncrement">
        ///     The amount <see cref="value"/> should change when the user clicks the button with CONTROL
        ///     and SHIFT pressed
        /// </param>
        public static void IntEntry(
            Rect region,
            ref int value,
            ref string buffer,
            ref bool bufferValid,
            int minimum = 1,
            int maximum = int.MaxValue,
            int increment = 1,
            int shiftIncrement = 10,
            int controlIncrement = 100,
            int comboIncrement = 1000
        )
        {
            var reduceRect = new Rect(region.x, region.y, EntryButtonWidth, region.height);

            var raiseRect = new Rect(region.x + region.width - EntryButtonWidth, region.y, EntryButtonWidth, region.height);

            var fieldRegion = new Rect(region.x + EntryButtonWidth + 2f, region.y, region.width - EntryButtonWidth * 2 - 4f, region.height);

            bool isShiftDown = InputHelper.AnyKeyDown(KeyCode.LeftShift, KeyCode.RightShift);
            bool isControlDown = InputHelper.AnyKeyDown(KeyCode.LeftControl, KeyCode.RightControl);

            if (isControlDown && isShiftDown)
            {
                DrawEntryButtonPair(reduceRect, raiseRect, ref value, ref buffer, ref bufferValid, comboIncrement);
            }
            else if (isControlDown)
            {
                DrawEntryButtonPair(reduceRect, raiseRect, ref value, ref buffer, ref bufferValid, controlIncrement);
            }
            else if (isShiftDown)
            {
                DrawEntryButtonPair(reduceRect, raiseRect, ref value, ref buffer, ref bufferValid, shiftIncrement);
            }
            else
            {
                DrawEntryButtonPair(reduceRect, raiseRect, ref value, ref buffer, ref bufferValid, increment);
            }

            NumberField(fieldRegion, ref buffer, ref value, ref bufferValid, minimum, maximum);
        }

        /// <summary>
        ///     Draws an button for modifying a given value by
        ///     a specified increment/decrement when pressed.
        /// </summary>
        /// <param name="region">The region to draw the button</param>
        /// <param name="value">The value to modify</param>
        /// <param name="buffer">The buffer of the value</param>
        /// <param name="bufferValid">Whether or not the buffer is a valid number</param>
        /// <param name="modifier">A number to increment/decrement the value by</param>
        private static void DrawEntryButton(Rect region, ref int value, ref string buffer, ref bool bufferValid, int modifier)
        {
            if (!Widgets.ButtonText(region, modifier.ToString("N0")))
            {
                return;
            }

            value += modifier;
            buffer = value.ToString();
            bufferValid = true;
        }

        /// <summary>
        ///     Draws a pair of buttons for modifying a given value by
        ///     a specified increment/decrement when pressed.
        /// </summary>
        /// <param name="decrementRegion">The region to draw the decrement button</param>
        /// <param name="incrementRegion">The region to draw the increment button</param>
        /// <param name="value">The value to modify</param>
        /// <param name="buffer">The buffer of the value</param>
        /// <param name="bufferValid">Whether or not the buffer is a valid number</param>
        /// <param name="modifier">A number to increment/decrement the value by</param>
        private static void DrawEntryButtonPair(Rect decrementRegion, Rect incrementRegion, ref int value, ref string buffer, ref bool bufferValid, int modifier)
        {
            DrawEntryButton(decrementRegion, ref value, ref buffer, ref bufferValid, -modifier);
            DrawEntryButton(incrementRegion, ref value, ref buffer, ref bufferValid, modifier);
        }

        /// <summary>
        ///     Draws a button with a check mark as its icon.
        /// </summary>
        /// <param name="region">The region to draw the button in</param>
        /// <returns>Whether or not the button was clicked</returns>
        /// <remarks>
        ///     Commonly used to indicate a "submit" or "finish" type of action.
        /// </remarks>
        public static bool DoneButton(Rect region) => FieldButton(region, "✔");

        /// <summary>
        ///     Draws the specified texture in the color given.
        /// </summary>
        /// <param name="region">The region to draw the texture in</param>
        /// <param name="icon">The texture to draw</param>
        /// <param name="color">The color to draw the texture</param>
        /// <remarks>
        ///     This method doesn't recolor the texture given to the color specified;
        ///     it changes the value of <see cref="GUI.color"/> to the color specified
        ///     and lets Unity handle the recoloring.
        /// </remarks>
        public static void Icon(Rect region, Texture2D icon, Color? color)
        {
            region = LayoutHelper.IconRect(region.x, region.y, region.width, region.height);

            Color old = GUI.color;

            GUI.color = color ?? Color.white;
            GUI.DrawTexture(region, icon);
            GUI.color = old;
        }

        /// <summary>
        ///     Draws a label at the given region.
        /// </summary>
        /// <param name="region">The region to draw the label in</param>
        /// <param name="text">The text of the label</param>
        /// <param name="anchor">The anchor of the label</param>
        /// <param name="fontScale">The font scale of the label</param>
        /// <param name="vertical">Whether or not to draw the label vertically</param>
        public static void Label(Rect region, string text, TextAnchor anchor = TextAnchor.MiddleLeft, GameFont fontScale = GameFont.Small, bool vertical = false)
        {
            Text.Anchor = anchor;
            Text.Font = fontScale;

            if (vertical)
            {
                region.y += region.width;
                GUIUtility.RotateAroundPivot(-90f, region.position);
            }

            Widgets.Label(region, text);

            if (vertical)
            {
                GUI.matrix = Matrix4x4.identity;
            }

            Text.Anchor = TextAnchor.UpperLeft;
            Text.Font = GameFont.Small;
        }

        /// <summary>
        ///     Draws a label at the given region.
        /// </summary>
        /// <param name="region">The region to draw the label in</param>
        /// <param name="text">The text of the label</param>
        /// <param name="color">The color of the label's text</param>
        /// <param name="anchor">The anchor of the label</param>
        /// <param name="fontScale">The font scale of the label</param>
        /// <param name="vertical">Whether or not to draw the label vertically</param>
        public static void Label(
            Rect region,
            string text,
            Color color,
            TextAnchor anchor = TextAnchor.MiddleLeft,
            GameFont fontScale = GameFont.Small,
            bool vertical = false
        )
        {
            GUI.color = color;
            Label(region, text, anchor, fontScale, vertical);
            GUI.color = Color.white;
        }

        /// <summary>
        ///     Draws a background suitable for a tab.
        /// </summary>
        /// <param name="region">The region to draw the background in</param>
        /// <param name="vertical">Whether or not to draw the background vertically</param>
        /// <param name="active">Whether or not the associated tab is the active tab</param>
        public static void DrawTabBackground(Rect region, bool vertical = false, bool active = false)
        {
            if (vertical)
            {
                region.y += region.width;
                GUIUtility.RotateAroundPivot(-90f, region.position);
            }

            GUI.color = active ? ActiveTabColor : InactiveTabColor;
            Widgets.DrawHighlight(region);
            GUI.color = Color.white;

            if (!active && Mouse.IsOver(region))
            {
                Widgets.DrawLightHighlight(region);
            }

            if (vertical)
            {
                GUI.matrix = Matrix4x4.identity;
            }
        }

        /// <summary>
        ///     Draws a text field that notifies when its contents were changed.
        /// </summary>
        /// <param name="region">The region to draw the text field in</param>
        /// <param name="content">The text within the field</param>
        /// <param name="newContent">The changed text</param>
        /// <returns>Whether or not the text field was changed</returns>
        [ContractAnnotation("=> true,newContent:notnull; => false,newContent:null")]
        public static bool TextField(Rect region, string content, out string newContent)
        {
            string text = Widgets.TextField(region, content);
            newContent = string.Equals(text, content) ? null : text;

            return newContent != null;
        }

        /// <summary>
        ///     Draws a table header at the given region.
        /// </summary>
        /// <param name="region">The region to draw the header in</param>
        /// <param name="name">The name of the header</param>
        /// <param name="order">The sort order of the header's data</param>
        /// <param name="anchor">The text anchor of the header's name</param>
        /// <param name="fontScale">The font scale of the header's name</param>
        /// <param name="vertical">Whether or not to draw the header vertically</param>
        /// <param name="marginX">
        ///     The amount of space to contract from <see cref="region"/>'s horizontal axis before drawing <see cref="name"/>
        /// </param>
        /// <param name="marginY">
        ///     The amount of space to contract from <see cref="region"/>'s vertical axis before drawing <see cref="name"/>
        /// </param>
        /// <returns>Whether or not the header was clicked</returns>
        public static bool TableHeader(
            Rect region,
            string name,
            SortOrder order = SortOrder.None,
            TextAnchor anchor = TextAnchor.MiddleLeft,
            GameFont fontScale = GameFont.Small,
            bool vertical = false,
            float marginX = 5f,
            float marginY = 0f
        )
        {
            Text.Anchor = anchor;
            Text.Font = fontScale;

            if (vertical)
            {
                region.y += region.width;
                GUIUtility.RotateAroundPivot(-90f, region.position);
            }

            GUI.color = TableHeaderColor;
            Widgets.DrawHighlight(region);
            GUI.color = Color.white;

            if (Mouse.IsOver(region))
            {
                GUI.color = Color.grey;
                Widgets.DrawLightHighlight(region);
                GUI.color = Color.white;
            }

            Rect textRegion = region.ContractedBy(marginX, marginY);
            Widgets.Label(textRegion, name);
            bool pressed = Widgets.ButtonInvisible(region);

            switch (order)
            {
                case SortOrder.Descending:
                case SortOrder.Ascending:
                    SortIndicator(textRegion, order);

                    break;
            }

            if (vertical)
            {
                GUI.matrix = Matrix4x4.identity;
            }

            Text.Anchor = TextAnchor.UpperLeft;
            Text.Font = GameFont.Small;

            return pressed;
        }

        /// <summary>
        ///     Draws a table header at the given region.
        /// </summary>
        /// <param name="region">The region to draw the header in</param>
        /// <param name="icon">The icon of the header</param>
        /// <param name="order">The sort order of the header's data</param>
        /// <param name="vertical">Whether or not to draw the header vertically</param>
        /// <param name="margin">
        ///     The amount of space to contract from <see cref="region"/> before drawing <see cref="icon"/>
        /// </param>
        /// <returns>Whether or not the header was clicked</returns>
        public static bool TableHeader(Rect region, Texture2D icon, SortOrder order = SortOrder.None, bool vertical = false, float margin = 5f)
        {
            if (vertical)
            {
                region.y += region.width;
                GUIUtility.RotateAroundPivot(-90f, region.position);
            }

            GUI.color = TableHeaderColor;
            Widgets.DrawHighlight(region);
            GUI.color = Color.white;

            if (Mouse.IsOver(region))
            {
                GUI.color = Color.grey;
                Widgets.DrawLightHighlight(region);
                GUI.color = Color.white;
            }

            Rect innerRegion = region.ContractedBy(margin);

            Rect iconRect = LayoutHelper.IconRect(innerRegion.x, innerRegion.y, innerRegion.height, innerRegion.height, 4f);

            GUI.DrawTexture(iconRect, icon);
            bool pressed = Widgets.ButtonInvisible(region);

            switch (order)
            {
                case SortOrder.Descending:
                case SortOrder.Ascending:
                    SortIndicator(innerRegion, order);

                    break;
            }

            if (vertical)
            {
                GUI.matrix = Matrix4x4.identity;
            }

            return pressed;
        }

        /// <summary>
        ///     Draws a button suitable for tabbed content.
        /// </summary>
        /// <param name="region">The region to draw the tab button in</param>
        /// <param name="name">The name of the tab</param>
        /// <param name="anchor">The text anchor of the tab</param>
        /// <param name="fontScale">The font scale of the tab</param>
        /// <param name="vertical">Whether or not to draw the tab vertically</param>
        /// <param name="active">Whether or not the tab is the currently open tab</param>
        /// <returns>Whether or not the tab was clicked</returns>
        public static bool TabButton(
            Rect region,
            string name,
            TextAnchor anchor = TextAnchor.MiddleLeft,
            GameFont fontScale = GameFont.Small,
            bool vertical = false,
            bool active = false
        )
        {
            Text.Anchor = anchor;
            Text.Font = fontScale;

            if (vertical)
            {
                region.y += region.width;
                GUIUtility.RotateAroundPivot(-90f, region.position);
            }

            GUI.color = active ? ActiveTabColor : InactiveTabColor;
            Widgets.DrawHighlight(region);
            GUI.color = Color.white;

            if (!active && Mouse.IsOver(region))
            {
                Widgets.DrawLightHighlight(region);
            }

            Widgets.Label(region, name);
            bool pressed = Widgets.ButtonInvisible(region);

            if (vertical)
            {
                GUI.matrix = Matrix4x4.identity;
            }

            Text.Anchor = TextAnchor.UpperLeft;
            Text.Font = GameFont.Small;

            return pressed;
        }

        /// <summary>
        ///     A convenience method for tipping a region and drawing
        ///     a mouse over highlight in said region.
        /// </summary>
        /// <param name="region">The region to tip</param>
        /// <param name="tooltip">The tooltip of the region</param>
        public static void TipRegion(this Rect region, string tooltip)
        {
            Widgets.DrawHighlightIfMouseover(region);
            TooltipHandler.TipRegion(region, tooltip);
        }

        /// <summary>
        ///     Draws an experimental notice at the region specified.
        /// </summary>
        /// <param name="listing">The <see cref="Listing"/> object use for layout</param>
        public static void DrawExperimentalNotice([NotNull] this Listing listing)
        {
            listing.DrawDescription("ExperimentalContent".TranslateSimple(), ExperimentalNoticeColor);
        }

        /// <summary>
        ///     Draws text suitable for content descriptions.
        /// </summary>
        /// <param name="listing">The <see cref="Listing"/> object use for layout</param>
        /// <param name="text">The description of the content</param>
        /// <param name="color">The color of the description text</param>
        /// <param name="anchor">The text anchor of the description text</param>
        public static void DrawDescription([NotNull] this Listing listing, string text, Color color, TextAnchor anchor = TextAnchor.UpperLeft)
        {
            GameFont fontCache = Text.Font;
            GUI.color = color;
            Text.Font = GameFont.Tiny;
            float width = listing.ColumnWidth * 0.7f;
            float height = Text.CalcHeight(text, width);
            Rect lineRect = listing.GetRect(height);
            var labelRect = new Rect(lineRect.x + 10f, lineRect.y, width, lineRect.height);

            Label(labelRect, text, anchor, GameFont.Tiny);

            GUI.color = Color.white;
            Text.Font = fontCache;

            listing.Gap(6f);
        }

        /// <summary>
        ///     Draws text suitable for content descriptions.
        /// </summary>
        /// <param name="listing">The <see cref="Listing"/> object use for layout</param>
        /// <param name="text">The description of the content</param>
        /// <param name="anchor">The text anchor of the description text</param>
        public static void DrawDescription([NotNull] this Listing listing, string text, TextAnchor anchor)
        {
            DrawDescription(listing, text, DescriptionTextColor, anchor);
        }

        /// <summary>
        ///     Draws text suitable for content descriptions.
        /// </summary>
        /// <param name="listing">The <see cref="Listing"/> object use for layout</param>
        /// <param name="text">The description of the content</param>
        public static void DrawDescription([NotNull] this Listing listing, string text)
        {
            DrawDescription(listing, text, DescriptionTextColor);
        }

        /// <summary>
        ///     Draws a grouping header for the given content.
        /// </summary>
        /// <param name="listing">The <see cref="Listing"/> object use for layout</param>
        /// <param name="name">The name of the group header</param>
        /// <param name="gapPrefix">Whether or not to prepend a gap before the group header</param>
        public static void GroupHeader([NotNull] this Listing listing, string name, bool gapPrefix = true)
        {
            if (gapPrefix)
            {
                listing.Gap(Mathf.CeilToInt(Text.LineHeight * 1.25f));
            }

            Label(listing.GetRect(Text.LineHeight), name, TextAnchor.LowerLeft, GameFont.Tiny);
            listing.GapLine(6f);
        }

        /// <summary>
        ///     Draws a grouping header for the given mod-specific content.
        /// </summary>
        /// <param name="listing">The <see cref="Listing"/> object use for layout</param>
        /// <param name="modName">The human readable name of the mod</param>
        /// <param name="modId">The workshop id of the mod</param>
        /// <param name="gapPrefix">Whether or not to prepend a gap before the group header</param>
        public static void ModGroupHeader([NotNull] this Listing listing, string modName, ulong modId, bool gapPrefix = true)
        {
            if (gapPrefix)
            {
                listing.Gap(Mathf.CeilToInt(Text.LineHeight * 1.25f));
            }

            Rect lineRect = listing.GetRect(Text.LineHeight);
            Label(lineRect, modName, TextAnchor.LowerLeft, GameFont.Tiny);

            string modRequirementString = "ContentRequiresMod".Translate(modName);
            GUI.color = ExperimentalNoticeColor;

            Text.Font = GameFont.Tiny;
            float width = Text.CalcSize(modRequirementString).x;
            var modRequirementRect = new Rect(lineRect.x + lineRect.width - width, lineRect.y, width, Text.LineHeight);
            Text.Font = GameFont.Small;

            Label(lineRect, modRequirementString, TextAnchor.LowerRight, GameFont.Tiny);
            GUI.color = Color.white;

            Widgets.DrawHighlightIfMouseover(modRequirementRect);

            if (Widgets.ButtonInvisible(modRequirementRect))
            {
                SteamUtility.OpenWorkshopPage(new PublishedFileId_t(modId));
            }

            listing.GapLine(6f);
        }

        /// <summary>
        ///     Draws a checkbox.
        /// </summary>
        /// <param name="region">The region to draw the checkbox in</param>
        /// <param name="state">The current state of the checkbox</param>
        /// <returns>Whether or not the checkbox was clicked</returns>
        public static bool DrawCheckbox(Rect region, ref bool state)
        {
            bool proxy = state;
            Widgets.Checkbox(region.position, ref proxy, Mathf.Min(region.width, region.height), paintable: true);

            bool changed = proxy != state;
            state = proxy;

            return changed;
        }

        /// <summary>
        ///     Draws a labeled checkbox with support for RimWorld's "click-and-drag"
        ///     feature for checkboxes.
        /// </summary>
        /// <param name="region">The region to draw the checkbox in</param>
        /// <param name="label">The label of the checkbox</param>
        /// <param name="state">The state of the checkbox</param>
        /// <returns>Whether or not the checkbox was clicked</returns>
        public static bool LabeledPaintableCheckbox(Rect region, string label, ref bool state)
        {
            var labelRect = new Rect(region.x, region.y, region.width - region.height - 2f, region.height);

            Rect checkPos = LayoutHelper.IconRect(region.x + region.width - region.height + 4f, region.y + 4f, region.height - 8f, region.height - 8f);

            bool proxy = state;

            Label(labelRect, label);
            Widgets.Checkbox(checkPos.position, ref proxy, checkPos.height, paintable: true);

            bool changed = proxy != state;
            state = proxy;

            return changed;
        }

        /// <summary>
        ///     Draws the specified <see cref="ThingDef"/> in form suitable for users.
        /// </summary>
        /// <param name="region">The region to draw the thing at</param>
        /// <param name="def">The <see cref="ThingDef"/> to draw</param>
        /// <param name="labelOverride">An override for the thing's label</param>
        /// <param name="infoCard">Whether or not to show the info card for the thing when it's clicked</param>
        public static void DrawThing(Rect region, ThingDef def, [CanBeNull] string labelOverride = null, bool infoCard = true)
        {
            var iconRect = new Rect(region.x + 2f, region.y + 2f, region.height - 4f, region.height - 4f);
            var labelRect = new Rect(iconRect.x + region.height, region.y, region.width - region.height, region.height);

            Widgets.ThingIcon(iconRect, def);
            Label(labelRect, labelOverride ?? def.label?.CapitalizeFirst() ?? def.defName);

            if (Current.Game == null || !infoCard)
            {
                return;
            }

            if (Widgets.ButtonInvisible(region))
            {
                Find.WindowStack.Add(new Dialog_InfoCard(def));
            }

            Widgets.DrawHighlightIfMouseover(region);
        }

        /// <summary>
        ///     Draws a button with a reset icon.
        /// </summary>
        /// <param name="region">The region to draw the button</param>
        /// <param name="tooltip">The tooltip of the reset button</param>
        /// <returns>Whether or not the reset button was clicked</returns>
        public static bool ResetButton(Rect region, [CanBeNull] string tooltip = null)
        {
            TooltipHandler.TipRegion(region, tooltip);

            return Widgets.ButtonImage(LayoutHelper.IconRect(region.x, region.y, region.width, region.height), TexButton.CurveResetTex);
        }
    }
}
