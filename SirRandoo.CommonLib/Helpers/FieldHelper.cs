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

using JetBrains.Annotations;
using UnityEngine;
using Verse;

namespace SirRandoo.CommonLib.Helpers
{
    public static partial class UiHelper
    {
        private const float EntryButtonWidth = 50f;

        /// <summary>
        ///     Draws a number field in the given region of the screen.
        /// </summary>
        /// <param name="region">
        ///     The region of the screen to draw the number
        ///     field in
        /// </param>
        /// <param name="value">
        ///     The value the raw input was parsed into, within
        ///     the given range constraint
        /// </param>
        /// <param name="buffer">
        ///     A reference to a string variable for storing the
        ///     raw input of the user
        /// </param>
        /// <param name="bufferValid">
        ///     A reference to a boolean variable for
        ///     storing whether the user's input was a valid integer
        /// </param>
        /// <returns>Whether a number was successfully parsed from the input</returns>
        public static bool NumberField(Rect region, out int value, ref string buffer, ref bool bufferValid) =>
            NumberField(region, out value, ref buffer, ref bufferValid, 0, int.MaxValue);

        /// <summary>
        ///     Draws a number field in the given region of the screen.
        /// </summary>
        /// <param name="region">
        ///     The region of the screen to draw the number
        ///     field in
        /// </param>
        /// <param name="value">
        ///     The value the raw input was parsed into, within
        ///     the given range constraint
        /// </param>
        /// <param name="buffer">
        ///     A reference to a string variable for storing the
        ///     raw input of the user
        /// </param>
        /// <param name="bufferValid">
        ///     A reference to a boolean variable for
        ///     storing whether the user's input was a valid integer
        /// </param>
        /// <param name="minimum">The minimum integer <see cref="value"/> can be</param>
        /// <param name="maximum">The maximum integer <see cref="value"/> can be</param>
        /// <returns>Whether a number was successfully parsed from the input</returns>
        public static bool NumberField(Rect region, out int value, ref string buffer, ref bool bufferValid, int minimum, int maximum)
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
                    value = 0;
                    bufferValid = false;
                }
            }
            else
            {
                value = 0;
            }

            GUI.backgroundColor = Color.white;

            return @return;
        }

        /// <summary>
        ///     Draws a number field in the given region of the screen.
        /// </summary>
        /// <param name="region">
        ///     The region of the screen to draw the number
        ///     field in
        /// </param>
        /// <param name="value">
        ///     The value the raw input was parsed into, within
        ///     the given range constraint
        /// </param>
        /// <param name="buffer">
        ///     A reference to a string variable for storing the
        ///     raw input of the user
        /// </param>
        /// <param name="bufferValid">
        ///     A reference to a boolean variable for
        ///     storing whether the user's input was a valid floating point value
        /// </param>
        /// <returns>Whether a number was successfully parsed from the input</returns>
        public static bool NumberField(Rect region, out float value, ref string buffer, ref bool bufferValid) =>
            NumberField(region, out value, ref buffer, ref bufferValid, 0f, float.MaxValue);

        /// <summary>
        ///     Draws a number field in the given region of the screen.
        /// </summary>
        /// <param name="region">
        ///     The region of the screen to draw the number
        ///     field in
        /// </param>
        /// <param name="value">
        ///     The value the raw input was parsed into, within
        ///     the given range constraint
        /// </param>
        /// <param name="buffer">
        ///     A reference to a string variable for storing the
        ///     raw input of the user
        /// </param>
        /// <param name="bufferValid">
        ///     A reference to a boolean variable for
        ///     storing whether the user's input was a valid floating point value
        /// </param>
        /// <param name="minimum">
        ///     The minimum floating point value
        ///     <see cref="value"/> can be
        /// </param>
        /// <param name="maximum">
        ///     The maximum floating point value
        ///     <see cref="value"/> can be
        /// </param>
        /// <returns>Whether a number was successfully parsed from the input</returns>
        public static bool NumberField(Rect region, out float value, ref string buffer, ref bool bufferValid, float minimum, float maximum)
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
                    value = 0f;
                    bufferValid = false;
                }
            }
            else
            {
                value = 0f;
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
        /// <param name="buffer">
        ///     A <see cref="string"/> representing the raw
        ///     input from the user
        /// </param>
        /// <param name="bufferValid">
        ///     Whether or not <see cref="buffer"/> is a
        ///     valid number
        /// </param>
        /// <param name="minimum">The minimum number <see cref="value"/> can be</param>
        /// <param name="maximum">The maximum number <see cref="value"/> can be</param>
        /// <param name="increment">
        ///     The amount <see cref="value"/> should change when the user clicks
        ///     the button without a modifier
        ///     key
        /// </param>
        /// <param name="shiftIncrement">
        ///     The amount <see cref="value"/> should change when the user clicks
        ///     the button with SHIFT
        ///     pressed
        /// </param>
        /// <param name="controlIncrement">
        ///     The amount <see cref="value"/> should change when the user clicks
        ///     the button with
        ///     CONTROL pressed
        /// </param>
        /// <param name="comboIncrement">
        ///     The amount <see cref="value"/> should change when the user clicks
        ///     the button with CONTROL
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

            NumberField(fieldRegion, out value, ref buffer, ref bufferValid, minimum, maximum);
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
    }
}
