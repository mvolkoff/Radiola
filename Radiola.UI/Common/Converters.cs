﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Radiola.UI.Common
{
    public class DoubleToPercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (double)value * 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (double)value / 100;
        }
    }
}
