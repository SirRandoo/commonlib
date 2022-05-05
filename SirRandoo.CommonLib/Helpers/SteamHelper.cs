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
using Steamworks;
using Verse;
using Verse.Steam;

namespace SirRandoo.CommonLib.Helpers
{
    /// <summary>
    ///     A class for accessing Steam metadata about workshop mods, as well
    ///     as opening their relevant pages on the Steam overlay, or web
    ///     browser.
    /// </summary>
    public static class SteamHelper
    {
        /// <summary>
        ///     Opens the changelog for the given mod.
        /// </summary>
        /// <param name="metaData">The mod to open the changelog page of</param>
        public static void OpenItemChangelog([CanBeNull] this ModMetaData metaData)
        {
            if (metaData.TryGetWorkshopHook(out WorkshopItemHook hook))
            {
                SteamUtility.OpenUrl($"https://steamcommunity.com/sharedfiles/filedetails/changelog/{hook.PublishedFileId.m_PublishedFileId.ToString()}");
            }
        }

        /// <summary>
        ///     Opens the workshop page for the given mod.
        /// </summary>
        /// <param name="metaData">The mod to open the workshop page of</param>
        public static void OpenItemPage([CanBeNull] this ModMetaData metaData)
        {
            if (metaData.TryGetWorkshopHook(out WorkshopItemHook hook))
            {
                SteamUtility.OpenWorkshopPage(hook.PublishedFileId);
            }
        }

        /// <summary>
        ///     Trys to get the <see cref="WorkshopItemHook"/> of the given mod.
        /// </summary>
        /// <param name="metaData">The mod to get the <see cref="WorkshopItemHook"/> for</param>
        /// <param name="hook">The <see cref="WorkshopItemHook"/> of the mod if it exists, or <c>null</c> if it doesn't</param>
        /// <returns>Whether the mod has a <see cref="WorkshopItemHook"/></returns>
        [ContractAnnotation("metaData:null => false,hook:null; metaData:notnull => false,hook:null; metaData:notnull => true,hook:notnull")]
        public static bool TryGetWorkshopHook(this ModMetaData metaData, out WorkshopItemHook hook)
        {
            hook = metaData?.GetWorkshopItemHook();

            return hook != null && hook.PublishedFileId != PublishedFileId_t.Invalid;
        }
    }
}
