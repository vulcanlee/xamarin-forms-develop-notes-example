using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFWrapLayout
{
    /// <summary>
    /// Class DataTemplateSelector.
    /// </summary>
    public class DataTemplateSelector
    {
        /// <summary>
        /// Selects the template.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="container">The container.</param>
        /// <returns>DataTemplate.</returns>
        public virtual DataTemplate SelectTemplate(object item, BindableObject container)
        {
            return null;
        }

    }

    /// <summary>
    /// Class DataTemplateSelectorExtensions.
    /// </summary>
    public static class DataTemplateSelectorExtensions
    {
        /// <summary>
        /// Cells for.
        /// </summary>
        /// <param name="This">The this.</param>
        /// <param name="item">The item.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>Cell.</returns>
        /// <exception cref="System.InvalidOperationException">DataTemplate must be either a Cell or a View</exception>
        public static Cell CellFor(this BindableObject This, object item, DataTemplateSelector selector)
        {
            if (selector != null)
            {
                var template = selector.SelectTemplate(item, This);
                if (template != null)
                {
                    var templateInstance = template.CreateContent();
                    // see if it's a view or a cell
                    var templateView = templateInstance as View;
                    var templateCell = templateInstance as Cell;

                    if (templateView == null && templateCell == null)
                        throw new InvalidOperationException("DataTemplate must be either a Cell or a View");

                    if (templateView != null) // we got a view, wrap in a cell
                        templateCell = new ViewCell { View = templateView };

                    return templateCell;
                }
            }

            return null;
        }

        /// <summary>
        /// Views for.
        /// </summary>
        /// <param name="This">The this.</param>
        /// <param name="item">The item.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>View.</returns>
        /// <exception cref="System.InvalidOperationException">DataTemplate must be a View</exception>
        public static View ViewFor(this BindableObject This, object item, DataTemplateSelector selector)
        {
            if (selector != null)
            {
                var template = selector.SelectTemplate(item, This);
                if (template != null)
                {
                    var templateInstance = template.CreateContent();
                    // see if it's a view or a cell
                    var templateView = templateInstance as View;

                    if (templateView == null)
                        throw new InvalidOperationException("DataTemplate must be a View");

                    return templateView;
                }
            }

            return null;
        }
    }
}
