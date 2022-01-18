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

namespace CommonLib.Interfaces
{
    /// <summary>
    ///     An interface for outlining the a logger for RimWorld.
    /// </summary>
    public interface IRimLogger
    {
        /// <summary>
        ///     Formats a log message.
        /// </summary>
        /// <param name="message">The message to format</param>
        /// <returns>The formatted message</returns>
        string FormatMessage(string message);

        /// <summary>
        ///     Formats a log message.
        /// </summary>
        /// <param name="level">The log level of the message</param>
        /// <param name="message">The message to format</param>
        /// <returns>The formatted message</returns>
        string FormatMessage(string level, string message);

        /// <summary>
        ///     Formats a log message.
        /// </summary>
        /// <param name="level">The log level of the message</param>
        /// <param name="message">The message to format</param>
        /// <param name="color">The color code of the message</param>
        /// <returns>The formatted message</returns>
        string FormatMessage(string level, string message, string color);

        /// <summary>
        ///     Logs a message to RimWorld's log window.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Log(string message);

        /// <summary>
        ///     Logs an INFO level message to RimWorld's log window.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Info(string message);

        /// <summary>
        ///     Logs a WARN level message to RimWorld's log window.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Warn(string message);

        /// <summary>
        ///     Logs a ERROR level message to RimWorld's log window.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Error(string message);

        /// <summary>
        ///     Logs a DEBUG level message to RimWorld's log window.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Debug(string message);
    }
}
