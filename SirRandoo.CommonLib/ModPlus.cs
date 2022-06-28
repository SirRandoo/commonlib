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

using SirRandoo.CommonLib.Windows;
using UnityEngine;
using Verse;

namespace SirRandoo.CommonLib
{
    /// <summary>
    ///     An extended <see cref="Mod"/> class with specialized support for
    ///     settings.
    /// </summary>
    public abstract class ModPlus : Mod
    {
        protected ModPlus(ModContentPack content) : base(content)
        {
        }

        /// <summary>
        ///     Represents the window that will open when the mod's settings are
        /// </summary>
        public abstract ProxySettingsWindow SettingsWindow { get; }

        /// <inheritdoc cref="Mod.SettingsCategory"/>
        public override string SettingsCategory() => Content.Name;

        /// <inheritdoc cref="Mod.DoSettingsWindowContents"/>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            ProxySettingsWindow.Open(SettingsWindow);
        }
    }
}
