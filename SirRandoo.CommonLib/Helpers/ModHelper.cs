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
using SirRandoo.CommonLib.Windows;
using Verse;

namespace SirRandoo.CommonLib.Helpers
{
    /// <summary>
    ///     A helper class for mod-related tasks.
    /// </summary>
    public static class ModHelper
    {
        /// <summary>
        ///     Gets the display name of a given mod.
        /// </summary>
        /// <param name="pack">The <see cref="ModContentPack"/> of the mod</param>
        /// <returns>A string that may represent the given mod's name</returns>
        /// <remarks>
        ///     The mod's name may not be accurate as <see cref="ModContentPack"/>
        ///     or its contents may be null.
        /// </remarks>
        [NotNull]
        public static string GetModName([CanBeNull] ModContentPack pack)
        {
            return pack?.IsCoreMod == true ? "RimWorld" : pack?.Name ?? "ERR";
        }

        /// <summary>
        ///     Opens a settings window for a given mod.
        /// </summary>
        /// <param name="mod">The mod to open the settings window for</param>
        /// <typeparam name="T">The type <paramref name="mod"/> should be</typeparam>
        public static void OpenSettings<T>(this T mod) where T : Mod
        {
            ProxySettingsWindow.Open(new ProxySettingsWindow(mod));
        }
    }
}
