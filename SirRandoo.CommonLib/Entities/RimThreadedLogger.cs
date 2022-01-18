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

using System.Threading;
using Verse;

namespace CommonLib.Entities
{
    [StaticConstructorOnStartup]
    public class RimThreadedLogger : RimLogger
    {
        private static readonly SynchronizationContext Context = SynchronizationContext.Current;

        private RimThreadedLogger(string name) : base(name)
        {
        }

        /// <inheritdoc />
        public override void Log(string message)
        {
            if (UnityData.IsInMainThread)
            {
                base.Log(message);
            }
            else
            {
                Context.Post(o => base.Log(message), null);
            }
        }

        /// <inheritdoc />
        public override void Error(string message)
        {
            if (UnityData.IsInMainThread)
            {
                base.Error(message);
            }
            else
            {
                Context.Post(o => base.Error(message), null);
            }
        }
    }
}
