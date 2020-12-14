using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using ModernWpf.Media.ColorPalette;

namespace ModernWpf
{
    internal class ColorsHelper : DispatcherObject
    {
        private const string AccentKey = "SystemAccentColor";
        private const string AccentDark1Key = "SystemAccentColorDark1";
        private const string AccentDark2Key = "SystemAccentColorDark2";
        private const string AccentDark3Key = "SystemAccentColorDark3";
        private const string AccentLight1Key = "SystemAccentColorLight1";
        private const string AccentLight2Key = "SystemAccentColorLight2";
        private const string AccentLight3Key = "SystemAccentColorLight3";

        internal static readonly Color DefaultAccentColor = Color.FromRgb(0x00, 0x78, 0xD7);

        private readonly ResourceDictionary _colors = new ResourceDictionary();

        private Color _systemBackground;
        private Color _systemAccent;

        private ColorsHelper()
        {
           
        }

        public static bool SystemColorsSupported { get; } = OSVersionHelper.IsWindows10OrGreater;

        public static ColorsHelper Current { get; } = new ColorsHelper();

        public ResourceDictionary Colors => _colors;

        public ApplicationTheme? SystemTheme { get; private set; }

        public Color SystemAccentColor => _systemAccent;

        public event EventHandler SystemThemeChanged;

        public event EventHandler SystemAccentColorChanged;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void FetchSystemAccentColors()
        {
            _colors[AccentKey] = GetColorFromHex("#FF0078D7");
            _colors[AccentDark1Key] = GetColorFromHex("#FF005A9E");
            _colors[AccentDark2Key] = GetColorFromHex("#FF004275");
            _colors[AccentDark3Key] = GetColorFromHex("#FF002642");
            _colors[AccentLight1Key] = GetColorFromHex("#FF429CE3");
            _colors[AccentLight2Key] = GetColorFromHex("#FF76B9ED");
            _colors[AccentLight3Key] = GetColorFromHex("#FFA6D8FF");
        }

        public Color GetColorFromHex(string Hex)
        {
            return (Color)ColorConverter.ConvertFromString(Hex);
        }

        public void SetAccent(Color accent)
        {
            Color color = accent;
            _colors[AccentKey] = color;
            UpdateShades(_colors, color);
        }

        public static void UpdateShades(ResourceDictionary colors, Color accent)
        {
            var palette = new ColorPalette(11, accent);
            colors[AccentDark1Key] = palette.Palette[6].ActiveColor;
            colors[AccentDark2Key] = palette.Palette[7].ActiveColor;
            colors[AccentDark3Key] = palette.Palette[8].ActiveColor;
            colors[AccentLight1Key] = palette.Palette[4].ActiveColor;
            colors[AccentLight2Key] = palette.Palette[3].ActiveColor;
            colors[AccentLight3Key] = palette.Palette[2].ActiveColor;
        }

        public static void RemoveShades(ResourceDictionary colors)
        {
            colors.Remove(AccentDark3Key);
            colors.Remove(AccentDark2Key);
            colors.Remove(AccentDark1Key);
            colors.Remove(AccentLight1Key);
            colors.Remove(AccentLight2Key);
            colors.Remove(AccentLight3Key);
        }

        public void UpdateBrushes(ResourceDictionary themeDictionary)
        {
            UpdateBrushes(themeDictionary, _colors);
        }

        public static void UpdateBrushes(ResourceDictionary themeDictionary, ResourceDictionary colors)
        {
            foreach (DictionaryEntry entry in themeDictionary)
            {
                if (entry.Value is SolidColorBrush brush && !brush.IsFrozen)
                {
                    object colorKey = ThemeResourceHelper.GetColorKey(brush);
                    if (colorKey != null && colors.Contains(colorKey))
                    {
                        brush.SetCurrentValue(SolidColorBrush.ColorProperty, (Color)colors[colorKey]);
                    }
                }
            }
        }

        private void UpdateSystemAppTheme()
        {
            SystemTheme = IsDarkBackground(_systemBackground) ? ApplicationTheme.Dark : ApplicationTheme.Light;
        }

        private static bool IsDarkBackground(Color color)
        {
            return color.R + color.G + color.B < (255 * 3 - color.R - color.G - color.B);
        }
    }
}
