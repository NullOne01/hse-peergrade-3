using Peergrade3.Extensions;

namespace Peergrade3.Localization
{
    public class LocalizationManager
    {
        private static LocalizationManager instance;

        private int currentLocalNum;

        private readonly DefaultLocalization[] localizations =
        {
            new DefaultLocalization(),
            new RussianLocalization()
        };

        /// <summary>
        ///     Single instance of localization manager.
        /// </summary>
        /// <returns> Static single instance. </returns>
        public static LocalizationManager getInstance()
        {
            if (instance == null)
                instance = new LocalizationManager();

            return instance;
        }

        /// <summary>
        ///     Setting localization by it's <paramref name="localNum" />
        /// </summary>
        /// <param name="localNum"> Number of a written localization. </param>
        public void SetLocalization(int localNum)
        {
            currentLocalNum = localNum;
        }

        /// <summary>
        ///     Switch between Russian and English localizations.
        /// </summary>
        public void SwitchLocalization()
        {
            SetLocalization(currentLocalNum == 0 ? 1 : 0);
        }

        /// <summary>
        ///     Get a localized value by it's <paramref name="key" />
        /// </summary>
        /// <param name="key"> Key of localized value. </param>
        /// <param name="argsFormat"> Some arguments. </param>
        /// <returns> Localized value. </returns>
        public string GetLocalizedValue(string key, params object[] argsFormat)
        {
            return localizations[currentLocalNum].localDict[key].BetterFormat(argsFormat);
        }
    }
}