using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Radiola.UI.Controls
{
    /// <summary>
	/// CoverFlowIndicator is a companion control to be used exclusively with a CoverFlow control. It serves
	/// the purpose of providing some hinting UI to the user where they are in the navigation of items
	/// within a CoverFlow. This is similar UI as seen in the Windows Store application when viewing the 
	/// screenshots.
	/// </summary>
	/// <remarks>
	/// The best usage is to be immediately underneath a CoverFlow and this is easily accomplished by using 
	/// a <see cref="StackPanel"/> as demonstrated below in Usage. When done this way the margins of the 
	/// CoverFlowIndicator are set correctly. If using in other means, you may need to adjust margins on
	/// the indicator.
	/// </remarks>
    public sealed class CoverFlowIndicator : ListBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoverFlowIndicator"/> class.
        /// </summary>
        public CoverFlowIndicator()
        {
            this.DefaultStyleKey = typeof(CoverFlowIndicator);
        }

        /// <summary>
        /// Gets or sets the flip view.
        /// </summary>
        public CoverFlow CoverFlow
        {
            get { return (CoverFlow)GetValue(CoverFlowProperty); }
            set { SetValue(CoverFlowProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="CoverFlow"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CoverFlowProperty =
            DependencyProperty.Register("CoverFlow", typeof(CoverFlow), typeof(CoverFlowIndicator), new PropertyMetadata(null, (depobj, args) =>
            {
                CoverFlowIndicator cfi = (CoverFlowIndicator)depobj;
                CoverFlow cf = (CoverFlow)args.NewValue;

                // this is a special case where ItemsSource is set in code
                // and the associated CoverFlow's ItemsSource may not be available yet
                // if it isn't available, let's listen for SelectionChanged 
                cf.SelectedItemChanged += (e) =>
                {
                    cfi.ItemsSource = cf.ItemsSource;
                };

                cfi.ItemsSource = cf.ItemsSource;

                // create the element binding source
                Binding eb = new Binding();
                eb.Mode = BindingMode.TwoWay;
                eb.Source = cf;
                eb.Path = new PropertyPath("SelectedItem");

                // set the element binding to change selection when the CoverFlow changes
                cfi.SetBinding(CoverFlowIndicator.SelectedItemProperty, eb);
            }));
    }
}
