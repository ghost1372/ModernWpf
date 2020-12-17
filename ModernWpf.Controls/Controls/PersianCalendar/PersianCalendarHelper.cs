using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using ModernWpf.Controls.Primitives;

namespace ModernWpf.Controls
{
    public static class PersianCalendarHelper
    {
        #region AutoReleaseMouseCapture

        public static bool GetAutoReleaseMouseCapture(PersianCalendar calendar)
        {
            return (bool)calendar.GetValue(AutoReleaseMouseCaptureProperty);
        }

        public static void SetAutoReleaseMouseCapture(PersianCalendar calendar, bool value)
        {
            calendar.SetValue(AutoReleaseMouseCaptureProperty, value);
        }

        public static readonly DependencyProperty AutoReleaseMouseCaptureProperty = DependencyProperty.RegisterAttached(
            "AutoReleaseMouseCapture",
            typeof(bool),
            typeof(PersianCalendarHelper),
            new PropertyMetadata(OnAutoReleaseMouseCaptureChanged));

        private static void OnAutoReleaseMouseCaptureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = (PersianCalendar)d;
            if ((bool)e.NewValue)
            {
                calendar.GotMouseCapture += OnCalendarGotMouseCapture;
            }
            else
            {
                calendar.GotMouseCapture -= OnCalendarGotMouseCapture;
            }
        }

        #endregion

        private static void OnCalendarGotMouseCapture(object sender, MouseEventArgs e)
        {
            var calendar = (PersianCalendar)sender;
            if (calendar.SelectionMode != CalendarSelectionMode.MultipleRange)
            {
                UIElement originalElement = e.OriginalSource as UIElement;
                if (originalElement is CalendarDayButton || originalElement is CalendarItem)
                {
                    originalElement.ReleaseMouseCapture();
                }
            }
        }
    }
}
