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

using System.Diagnostics;
using System.Reflection;
using CommonLib.Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using Verse;

namespace CommonLib.Entities
{
    public class RimLogger : IRimLogger
    {
        private readonly string _name;
        private bool _debugChecked;
        private bool _debugEnabled;

        public RimLogger(string name)
        {
            _name = name;
        }

        /// <inheritdoc/>
        [NotNull]
        public string FormatMessage(string message) => $"{_name} :: {message}";

        /// <inheritdoc/>
        [NotNull]
        public string FormatMessage([NotNull] string level, string message) => $"{level.ToUpperInvariant()} {_name} :: {message}";

        /// <inheritdoc/>
        [NotNull]
        public string FormatMessage([NotNull] string level, string message, [NotNull] string color) =>
            $@"<color=""#{color.TrimStart('#')}"">{FormatMessage(level, message)}</color>";

        /// <inheritdoc/>
        public virtual void Log(string message)
        {
            Verse.Log.Message(FormatMessage(message));
        }

        /// <inheritdoc/>
        public virtual void Info(string message)
        {
            Log(FormatMessage("INFO", message));
        }

        /// <inheritdoc/>
        public virtual void Warn(string message)
        {
            Log(FormatMessage("WARN", message, "#FF6B00"));
        }

        /// <inheritdoc/>
        public virtual void Error(string message)
        {
            Log(FormatMessage("ERR", message, "#FF768CE"));
            Verse.Log.TryOpenLogWindow();
        }

        /// <inheritdoc/>
        public virtual void Debug(string message)
        {
            if (!_debugChecked)
            {
                _debugEnabled = Assembly.GetCallingAssembly().GetCustomAttribute<DebuggableAttribute>() != null;
                _debugChecked = true;
            }

            if (_debugEnabled)
            {
                Log(FormatMessage("DEBUG", message, ColorUtility.ToHtmlStringRGB(ColorLibrary.LightPink)));
            }
        }
    }
}
